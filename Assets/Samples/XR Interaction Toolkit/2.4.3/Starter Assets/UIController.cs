using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Toggles the UI Canvas visibility using a button press
public class UIController : MonoBehaviour
{
    public InputActionReference menu;  // Action to toggle the menu
    public Canvas canvas;              // Canvas to show/hide

    private void Start()
    {
        if(menu != null)
        {
            menu.action.Enable();  // Enable input action
            menu.action.performed += ToggleMenu;  // Call ToggleMenu when action is triggered
        }
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        canvas.enabled = !canvas.enabled;  // Toggle Canvas visibility
    }
}


