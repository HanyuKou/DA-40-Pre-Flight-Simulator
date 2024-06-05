using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail_Skid : Visual_Fault
{
    [Header("Tail Skid Parameters")]
    [SerializeField] private GameObject tailSkidLow;
    [SerializeField] private GameObject tailSkidHigh;

    public override void GenerateFault()
    {
        base.GenerateFault();
        tailSkidHigh.SetActive(true); // Set the high tail skid vibration to be active.
        tailSkidLow.SetActive(false); // Set the low tail skid vibration to be inactive.

    }

    public override void RemoveFault()
    {
        base.RemoveFault();
        tailSkidHigh.SetActive(false); // Set the high tail skid vibration to be inactive.
        tailSkidLow.SetActive(true); // Set the low tail skid vibration to be active.
    }
}
