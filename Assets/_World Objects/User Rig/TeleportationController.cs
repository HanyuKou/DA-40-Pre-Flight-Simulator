using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;



public class TeleportationController : MonoBehaviour
{
    static private bool teleportIsActive = false; // Active state of the teleportation system.

    public enum ControllerType { RightHand, LeftHand }

    public ControllerType targetController;
    public InputActionAsset inputAction;
    public XRRayInteractor rayInteractor;
    public TeleportationProvider teleportationProvider;

    private InputAction thumbstickInputAction;
    private InputAction teleportActivate;
    private InputAction teleportCancel;



    void Start()
    {
        // Initialize with rayInteractor off.
        rayInteractor.enabled = false;

        // Find the action map for the target controller's teleportation activation.
        teleportActivate = inputAction.FindActionMap("XRI " + targetController.ToString() + " Locomotion").FindAction("Teleport Mode Activate");
        teleportActivate.Enable();
        teleportActivate.performed += OnTeleportActivate;

        // Find the action map for the target controller's teleportation cancelation.
        teleportCancel = inputAction.FindActionMap("XRI " + targetController.ToString() + " Locomotion").FindAction("Teleport Mode Cancel");
        teleportCancel.Enable();
        teleportCancel.performed += OnTeleportCancel;

        // Find the action map for thet target controller's movement for reference if thumbstick is being pressed.
        thumbstickInputAction = inputAction.FindActionMap("XRI " + targetController.ToString() + " Locomotion").FindAction("Move");
    }



    private void OnDestroy()
    {
        teleportActivate.performed -= OnTeleportActivate;
        teleportCancel.performed -= OnTeleportCancel;
    }



    void Update()
    {
        if (!teleportIsActive)
        {
            return;
        }
        if (!rayInteractor.enabled)
        {
            return;
        }
        if (thumbstickInputAction.IsPressed())
        {
            return;
        }
        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit raycastHit))
        {
            rayInteractor.enabled = false;
            teleportIsActive = false;
            return;
        }

        TeleportRequest teleportRequest = new TeleportRequest()
        {
            destinationPosition = raycastHit.point,
        };

        teleportationProvider.QueueTeleportRequest(teleportRequest);

        rayInteractor.enabled = false;
        teleportIsActive = false;
    }



    // This is called when Teleport Mode Activated action map is triggered.
    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        if (!teleportIsActive)
        {
            rayInteractor.enabled = true;
            teleportIsActive = true;
        }
    }



    // This is called when our Teleport Mode Cancel action map is triggered.
    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        if (teleportIsActive && rayInteractor.enabled == true)
        {
            rayInteractor.enabled = false;
            teleportIsActive = false;
        }
    }
}
