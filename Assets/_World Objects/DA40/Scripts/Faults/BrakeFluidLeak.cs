using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeFluidLeak : Visual_Fault
{
    [Header("Brake Fluid Leak Parameters")]
    [SerializeField] private GameObject brakeFluid;

    public override void GenerateFault()
    {
        base.GenerateFault();
        // Activate the brake fluid and particle system
        brakeFluid.SetActive(true);

    }

    public override void RemoveFault()
    {
        base.RemoveFault();
        // Stop the particle system and deactivate the brake fluid
        brakeFluid.SetActive(false);
    }

}
