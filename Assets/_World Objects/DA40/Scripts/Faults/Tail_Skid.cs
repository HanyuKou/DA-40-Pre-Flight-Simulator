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
        tailSkidHigh.SetActive(true);
        tailSkidLow.SetActive(false);

    }

    public override void RemoveFault()
    {
        base.RemoveFault();
        tailSkidHigh.SetActive(false);
        tailSkidLow.SetActive(true);
    }
}
