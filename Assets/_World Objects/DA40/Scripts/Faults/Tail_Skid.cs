using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail_Skid : Visual_Fault
{
    [Header("Tail Skid Parameters")]
    [SerializeField] private GameObject tailSkid;

    public override void GenerateFault()
    {
        base.GenerateFault();
        tailSkid.SetActive(true);

    }

    public override void RemoveFault()
    {
        base.RemoveFault();
        tailSkid.SetActive(false);
    }
}
