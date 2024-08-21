using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    public InputActionReference menu;  // Action to toggle the menu
    public Canvas canvas;              // Canvas to show/hide

    private void OnEnable()
    {
        if (menu != null)
        {
            menu.action.Enable();  // Enable input action
            menu.action.performed += ToggleMenu;  // Call ToggleMenu when action is triggered
        }
    }

    private void OnDisable()
    {
        if (menu != null)
        {
            menu.action.performed -= ToggleMenu;  // Unsubscribe from event
            menu.action.Disable();  // Disable input action
        }
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        canvas.enabled = !canvas.enabled;  // Toggle Canvas visibility
    }
}