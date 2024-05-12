using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;



public class MovementOptions : MonoBehaviour
{
    [SerializeField] private GameObject[] teleportationPointer;
    private bool isTeleportMovement = false;
    private bool isContinuousMovement = true;
    private bool isContinuousTurn = false;
    private bool isSnapTurn = true;



    public void ToggleTeleportMovement()
    {
        Debug.Log("isTeleportMovement:" + isTeleportMovement);
        if (!isTeleportMovement)
        {
            GetComponent<TeleportationProvider>().enabled = true;
            teleportationPointer[0].SetActive(true);
            teleportationPointer[1].SetActive(true);
            isTeleportMovement = true;
        }
        else
        {
            GetComponent<TeleportationProvider>().enabled = false;
            teleportationPointer[0].SetActive(false);
            teleportationPointer[1].SetActive(false);
            isTeleportMovement = false;
        }
    }



    public void ToggleContiniousMovement()
    {
        if (!isContinuousMovement)
        {
            GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
            isContinuousMovement = true;
        }
        else
        {
            GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            isContinuousMovement = false;
        }
    }



    public void ToggleContiniousTurn()
    {
        if (!isContinuousTurn)
        {
            GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;
            isContinuousTurn = true;
        }
        else
        {
            GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
            isContinuousTurn = false;
        }
    }



    public void ToggleSnapTurn()
    {
        if (!isSnapTurn)
        {
            GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
            isSnapTurn = true;
        }
        else
        {
            GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
            isSnapTurn = false;
        }
    }
}
