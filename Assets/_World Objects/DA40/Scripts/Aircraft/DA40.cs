using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DA40 : Aircraft
{

    [Header("Steps")]
    [SerializeField] private Aircraft_Part RightStep; // Fault index: 3
    [SerializeField] private Aircraft_Part LeftStep; // Fault index:4

    [Header("Propeller")]
    [SerializeField] private Aircraft_Part Propeller; // Fault index: 5

    [Header("Fuselage")]
    [SerializeField] private Aircraft_Part Fuselage; // Fault index: 6

    [Header("Antenna")]
    [SerializeField] private Aircraft_Part Antenna; // Fault index: 7

    [Header("Wings")]
    [SerializeField] private Aircraft_Part RightWing; // Fault index: 8
    [SerializeField] private Aircraft_Part LeftWing; // Fault index: 9

    [Header("Ailerons")]
    [SerializeField] private Aircraft_Part RightAileron; // Fault index: 10
    [SerializeField] private Aircraft_Part LeftAileron; // Fault index: 11

    [Header("Break Flaps")]
    [SerializeField] private Aircraft_Part RightBreakFlap; // Fault index: 12
    [SerializeField] private Aircraft_Part LeftBreakFlap; // Fault index: 13

    [Header("Lift Flap")]
    [SerializeField] private Aircraft_Part LiftFlap; // Fault index: 14

    [Header("Rudder")]
    [SerializeField] private Aircraft_Part Rudder; // Fault index: 15

    [Header("Landing Light")]
    [SerializeField] private Aircraft_Part LandingLight; // Fault index: 16

    [Header("Traffic Lights")]
    [SerializeField] private Aircraft_Part RightTrafficLight; // Fault index: 17
    [SerializeField] private Aircraft_Part LeftTrafficLight; // Fault index: 18

    [Header("Strobe Lights")]
    [SerializeField] private Aircraft_Part RightStrobeLight; // Fault index: 19
    [SerializeField] private Aircraft_Part LeftStrobeLight; // Fault index: 20

    [Header("Stall Warning")]
    [SerializeField] private Aircraft_Part StallWarning; // Fault index: 21

    [Header("Pitot")]
    [SerializeField] private Aircraft_Part Pitot; // Fault index: 22

    [Header("Fuel Caps")]
    [SerializeField] private Aircraft_Part FuselageFuelCap; // Fault index: 23
    [SerializeField] private Aircraft_Part WingFuelCap; // Fault index: 24

    [Header("Brake System")]
    [SerializeField] private Aircraft_Part BrakeFluidLeakModel; // Added for brake system fault.

    [Header("Tail Skid")]
    [SerializeField] private Aircraft_Part TailSkid; // Added for tail skid fault.

    [Header("Rim Front")]
    [SerializeField] private Aircraft_Part RimFront; // Added for rim front fault.

    [Header("Rim Right")]
    [SerializeField] private Aircraft_Part RimRight; // Added for rim right fault.

    [Header("Rim Left")]
    [SerializeField] private Aircraft_Part RimLeft; // Added for rim left fault.


    // Start is called before the first frame update.
    void Start()
    {
        parts = new Aircraft_Part[25];
        //parts[0] = FrontLandingGear;
        //parts[1] = RightLandingGear;
        //parts[2] = LeftLandingGear;
        parts[0] = RightStep;
        parts[1] = LeftStep;
        parts[2] = Propeller;
        parts[3] = Fuselage;
        parts[4] = Antenna;
        parts[5] = RightWing;
        parts[6] = LeftWing;
        parts[7] = RightAileron;
        parts[8] = LeftAileron;
        parts[9] = RightBreakFlap;
        parts[10] = LeftBreakFlap;
        parts[11] = LiftFlap;
        parts[12] = Rudder;
        parts[13] = LandingLight;
        parts[14] = RightTrafficLight;
        parts[15] = LeftTrafficLight;
        parts[16] = RightStrobeLight;
        parts[17] = LeftStrobeLight;
        parts[18] = StallWarning;
        parts[19] = Pitot;
        // parts[23] = FuselageFuelCap;
        // parts[24] = WingFuelCap;
        parts[20] = BrakeFluidLeakModel;
        parts[21] = TailSkid;
        parts[22] = RimFront;
        parts[23] = RimRight;
        parts[24] = RimLeft;
        //parts[25] = BrakePropellorModel;
    }
}
