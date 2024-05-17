using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rim_Front : Visual_Fault
{
    [Header("Tail Skid Parameters")]
    [SerializeField] private GameObject RimUndamaged;
    [SerializeField] private GameObject RimDamaged;

    public override void GenerateFault()
    {
        base.GenerateFault();
        RimDamaged.SetActive(true);
        RimUndamaged.SetActive(false);

    }

    public override void RemoveFault()
    {
        base.RemoveFault();
        RimDamaged.SetActive(false);
        RimUndamaged.SetActive(true);
    }
}
