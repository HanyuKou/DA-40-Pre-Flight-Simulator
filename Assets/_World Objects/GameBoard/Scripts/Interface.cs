using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Interface : MonoBehaviour
{
    [Header("Simulated Aircraft")]
    [SerializeField] private Aircraft aircraft;

    [Header("Board Interfaces")]
    [SerializeField] private GameObject[] boardTabs;
    [SerializeField] private GameObject[] boardDisplays;

    [Header("Simulation Interfaces")]
    [SerializeField] private Text simulationTabHeader;
    [SerializeField] private GameObject[] simulationTabs;

    public enum SimulationModes
    {
        Practise,
        Challenge,
        Hunt
    }

    private SimulationModes activeMode;
    //private bool activeSimulation = false;


    // Starts up a simulation and flicks to the simulation main board tab.
    private void StartSimulation()
    {
        // activeSimulation = true;
        boardTabs[0].SetActive(true); // Submit Button
        boardTabs[1].SetActive(false); // Main Menu Button
        boardTabs[2].SetActive(true); // Simulation Tab Button

        ExitMainMenu();
        boardDisplays[1].SetActive(true); //simulation panel
    }



    // Closes a simulation and compiles the user results for display.
    private void EndSimulation()
    {
        // activeSimulation = false;
        boardTabs[0].SetActive(false); // Submit Button
        boardTabs[1].SetActive(true); // Main Menu Button
        boardTabs[2].SetActive(true); // Simulation Tab Button
    
        GetMainMenu();

        // Sift through each part and it's faults to compare tags with faults states.
        int faultsPresent = 0;
        int mistakenFaults = 0;
        int faultsMissed = 0;

        for (int part = 0; part < aircraft.NumberOfParts(); part++)
        {
            for (int fault = 0; fault < aircraft.GetPart(part).NumberOfFaults(); fault++)
            {
                aircraft.GetPart(part).GetFault(fault).ColourButton(); // applies visual indicator to the board's button.
                aircraft.GetPart(part).GetFault(fault).EnableButton(false); // locks button from being toggled until reset.

                if (aircraft.GetPart(part).GetFault(fault).IsFaulty())
                {
                    faultsPresent++;
                    if (!aircraft.GetPart(part).GetFault(fault).IsTagged())
                    {
                        faultsMissed++;
                    }
                }
                else if (!aircraft.GetPart(part).GetFault(fault).IsFaulty())
                {
                    if (aircraft.GetPart(part).GetFault(fault).IsTagged())
                    {
                        mistakenFaults++;
                    }
                }

            }
        }

        // Calculate the final score as a percentile.
        int score = faultsMissed;
        float tally = 0;

        if (faultsPresent > 0) // Protects against dividing by 0.
        {
            tally = 100 - (score * 100 / faultsPresent);
        }
        tally = tally - mistakenFaults * 5; // Apply 5% penalty for marking a functional part as faulty.
        if (tally < 0)
        {
            tally = 0;
        }

        simulationTabHeader.text = "Final Score = " + (int)tally + "%";
    }



    // Wipes all faults from the aircraft and resets the simulation board.
    private void ClearSimulation()
    {
        // activeSimulation = false;
        boardTabs[0].SetActive(false); // Submit Button
        boardTabs[1].SetActive(true); // Main Menu Button
        boardTabs[2].SetActive(false); // Simulation Tab Button

        GetMainMenu(); //mainMenu panel
        aircraft.Reset();
    }



    // Begins a practise mode simulation and loads pre-defined fault states.
    public void InitiatePractise()
    {
        Debug.Log("Initiating Practice Mode");
        ClearSimulation();
        activeMode = SimulationModes.Practise;
        simulationTabHeader.text = "Simulation - Practise";
        aircraft.RunPractiseScenario();
        StartSimulation();
    }



    // Begins a challenge mode simulation and randomises the aircraft entirely.
    public void InitiateChallenge()
    {
        Debug.Log("Initiating Challenge Mode");
        ClearSimulation();
        activeMode = SimulationModes.Challenge;
        simulationTabHeader.text = "Simulation - Challenge";
        StartSimulation();
        aircraft.RandomiseFaults();
    }



    // Begins a hunt mode simulation and generates just one fault.
    public void InitiateHunt()
    {
        Debug.Log("Initiating Hunt Mode");
        ClearSimulation();
        activeMode = SimulationModes.Hunt;
        simulationTabHeader.text = "Simulation - Hunt";
        StartSimulation();
        aircraft.RandomisePart();
    }

    public void GetMainMenu()
    {
        Debug.Log("Returning to Main Menu");
        // Assume boardDisplays[0] is main menu panel
        boardDisplays[0].SetActive(true);  // Activate the main menu panel
        boardDisplays[1].SetActive(false); // Deactivate the simulation panel
    }

    public void ExitMainMenu()
    {
        boardDisplays[0].SetActive(false);  // Deactivate the main menu panel
    }

    public void GetControls()
    {
        Debug.Log("Opening Controls");
        // Assume boardDisplays[2] is controls panel
        boardDisplays[2].SetActive(true);  // Deactivate the controls panel
    }

    public void ExitControls()
    {
        Debug.Log("Opening Controls");
        // Assume boardDisplays[2] is controls panel
        boardDisplays[2].SetActive(false);  // Deactivate the controls panel
    }



    // Ends the simulation and scores the user.
    public void Submit()
    {
        Debug.Log("Submitting Results");
        EndSimulation();
    }



    // Wipes all faults from the aircraft and resets the simulation board.
    public void Reset()
    {
        Debug.Log("Resetting Simulation");
        ClearSimulation();
    }
}
