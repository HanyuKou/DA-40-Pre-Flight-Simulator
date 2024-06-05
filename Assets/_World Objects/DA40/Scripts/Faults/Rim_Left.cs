using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rim_Left : Visual_Fault
{
    [Header("Left Rim Parameters")]
    [SerializeField] private GameObject RimUndamaged;
    [SerializeField] private GameObject RimDamaged;

    public override void GenerateFault()
    {
        base.GenerateFault();
        RimDamaged.SetActive(true); // Set the damaged rim to be active.
        RimUndamaged.SetActive(false); // Set the undamaged rim to be inactive.

    }

    public override void RemoveFault()
    {
        base.RemoveFault();
        RimDamaged.SetActive(false); // Set the damaged rim to be inactive.
        RimUndamaged.SetActive(true); // Set the undamaged rim to be active.
    }
}
