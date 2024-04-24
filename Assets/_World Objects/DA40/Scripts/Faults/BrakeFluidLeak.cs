using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeFluidLeak : Visual_Fault
{
    [Header("Brake Fluid Leak Parameters")]
    [SerializeField] public GameObject brakeFluidModel;

    public override void GenerateFault()
    {
        base.GenerateFault();
        // Activate the brake fluid model and particle system
        brakeFluidModel.SetActive(true);

    }

    public override void RemoveFault()
    {
        base.RemoveFault();
        // Stop the particle system and deactivate the brake fluid model
        brakeFluidModel.SetActive(false);
    }

}
