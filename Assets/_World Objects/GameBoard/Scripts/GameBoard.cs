using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameBoard : MonoBehaviour
{
    [Header("Simulated Aircraft")]
    [SerializeField] private Aircraft aircraft;

    [Header("Board Interfaces")]
    [SerializeField] private GameObject[] boardTabs;
    [SerializeField] private GameObject[] boardDisplays;

    [Header("Simulation Interfaces")]
    [SerializeField] private Text simulationTabHeader;
    [SerializeField] private GameObject simulationNavNext;
    [SerializeField] private GameObject simulationNavPrev;
    [SerializeField] private GameObject[] simulationTabs;

    public enum simulationModes
    {
        Practise,
        Challenge,
        Hunt
    }

    private simulationModes activeMode;
    private int focusedSimulationTab;
    private bool activeSimulation;
    // Navigates the board’s main tabs to a specified tab.
    public void SwitchBoardTab(int activeTab)
    {
        for (int tab = 0; tab < boardDisplays.Length; tab++)
        {
            if (tab == activeTab)
            {
                boardDisplays[tab].SetActive(true);
            }
            else
            {
                boardDisplays[tab].SetActive(false);
            }
        }
    }



    // Navigates the board’s simulation sub-tabs to a specified sub-tab.
    public void SwitchSimulationTab(int activeTab)
    {
        // Lazy deactivation of all tabs.
        simulationNavNext.SetActive(true);
        simulationNavPrev.SetActive(true);
        for (int tab = 0; tab < simulationTabs.Length; tab++)
        {
            simulationTabs[tab].SetActive(false);
        }

        // Ensures that the focused tab loops.
        if (activeTab < 1)
        {
            activeTab = 1;
        }
        else if (activeTab > simulationTabs.Length - 2)
        {
            activeTab = simulationTabs.Length - 2;
        }

        // Activate and position relevent tabs.
        switch (activeTab)
        {
            case (1):
                focusedSimulationTab = 1;
                simulationTabs[0].SetActive(true);
                simulationTabs[0].transform.localPosition = new Vector3(-55, 0, 0);
                simulationTabs[1].SetActive(true);
                simulationTabs[1].transform.localPosition = new Vector3(0, 0, 0);
                simulationTabs[2].SetActive(true);
                simulationTabs[2].transform.localPosition = new Vector3(55, 0, 0);
                simulationNavPrev.SetActive(false);
                break;

            case (2):
                focusedSimulationTab = 2;
                simulationTabs[1].SetActive(true);
                simulationTabs[1].transform.localPosition = new Vector3(-55, 0, 0);
                simulationTabs[2].SetActive(true);
                simulationTabs[2].transform.localPosition = new Vector3(0, 0, 0);
                simulationTabs[3].SetActive(true);
                simulationTabs[3].transform.localPosition = new Vector3(55, 0, 0);
                break;

            case (3):
                focusedSimulationTab = 3;
                simulationTabs[2].SetActive(true);
                simulationTabs[2].transform.localPosition = new Vector3(-55, 0, 0);
                simulationTabs[3].SetActive(true);
                simulationTabs[3].transform.localPosition = new Vector3(0, 0, 0);
                simulationTabs[4].SetActive(true);
                simulationTabs[4].transform.localPosition = new Vector3(55, 0, 0);
                break;

            case (4):
                focusedSimulationTab = 4;
                simulationTabs[3].SetActive(true);
                simulationTabs[3].transform.localPosition = new Vector3(-55, 0, 0);
                simulationTabs[4].SetActive(true);
                simulationTabs[4].transform.localPosition = new Vector3(0, 0, 0);
                simulationTabs[5].SetActive(true);
                simulationTabs[5].transform.localPosition = new Vector3(55, 0, 0);
                break;

            case (5):
                focusedSimulationTab = 5;
                simulationTabs[4].SetActive(true);
                simulationTabs[4].transform.localPosition = new Vector3(-55, 0, 0);
                simulationTabs[5].SetActive(true);
                simulationTabs[5].transform.localPosition = new Vector3(0, 0, 0);
                simulationTabs[6].SetActive(true);
                simulationTabs[6].transform.localPosition = new Vector3(55, 0, 0);
                break;

            case (6):
                focusedSimulationTab = 6;
                simulationTabs[5].SetActive(true);
                simulationTabs[5].transform.localPosition = new Vector3(-55, 0, 0);
                simulationTabs[6].SetActive(true);
                simulationTabs[6].transform.localPosition = new Vector3(0, 0, 0);
                simulationTabs[7].SetActive(true);
                simulationTabs[7].transform.localPosition = new Vector3(55, 0, 0);
                
                break;

            case (7):
                focusedSimulationTab = 7;
                simulationTabs[6].SetActive(true);
                simulationTabs[6].transform.localPosition = new Vector3(-55, 0, 0);
                simulationTabs[7].SetActive(true);
                simulationTabs[7].transform.localPosition = new Vector3(0, 0, 0);
                simulationTabs[8].SetActive(true);
                simulationTabs[8].transform.localPosition = new Vector3(55, 0, 0);
                simulationTabs[9].SetActive(true);
                simulationTabs[9].transform.localPosition = new Vector3(55, -20, 0);
                simulationNavNext.SetActive(false);
                break;

            //case (8):
            //    focusedSimulationTab = 8;
            //    simulationTabs[7].SetActive(true);
            //    simulationTabs[7].transform.localPosition = new Vector3(-55, 0, 0);
            //    simulationTabs[8].SetActive(true);
            //    simulationTabs[8].transform.localPosition = new Vector3(0, 0, 0);
            //    simulationTabs[9].SetActive(true);
            //    simulationTabs[9].transform.localPosition = new Vector3(0, -20, 0);
            //    simulationNavNext.SetActive(false);
            //    break;
        }
    }



    // Navigates the simulation sub-tabs one to the right.
    public void NextSimulationTab()
    {
        SwitchSimulationTab(focusedSimulationTab + 1);
    }



    // Navigates the simulation sub-tabs one to the left.
    public void PreviousSimulationTab()
    {
        SwitchSimulationTab(focusedSimulationTab - 1);
    }



    // Starts up a simulation and flicks to the simulation main board tab.
    private void StartSimulation()
    {
        activeSimulation = true;
        boardTabs[0].SetActive(true); // Submit Button
        boardTabs[1].SetActive(false); // Setup Tab Button
        boardTabs[2].SetActive(true); // Simulation Tab Button
        SwitchBoardTab(1);
        SwitchSimulationTab(1);
    }



    // Closes a simulation and compiles the user’s results for display.
    private void EndSimulation()
    {
        activeSimulation = false;
        boardTabs[0].SetActive(false); // Submit Button
        boardTabs[1].SetActive(true); // Setup Tab Button
        boardTabs[2].SetActive(true); // Simulation Tab Button
        SwitchBoardTab(1);

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
        tally = tally - mistakenFaults*5; // Apply 5% penalty for marking a functional part as faulty.
        if (tally < 0)
        {
            tally = 0;
        }

        simulationTabHeader.text = "Final Score = " + (int)tally + "%";
    }



    // Wipes all faults from the aircraft and resets the simulation board.
    private void ClearSimulation()
    {
        activeSimulation = false;
        boardTabs[0].SetActive(false); // Submit Button
        boardTabs[1].SetActive(true); // Setup Tab Button
        boardTabs[2].SetActive(false); // Simulation Tab Button
        SwitchBoardTab(0);
        aircraft.Reset();
    }



    // Begins a practise mode simulation and loads pre-defined fault states.
    public void InitiatePractise()
    {
        ClearSimulation();
        activeMode = simulationModes.Practise;
        simulationTabHeader.text = "Simulation - Practise";
        aircraft.RunPractiseScenario();
        StartSimulation();
    }



    // Begins a challenge mode simulation and randomises the aircraft entirely.
    public void InitiateChallenge()
    {
        ClearSimulation();
        activeMode = simulationModes.Challenge;
        simulationTabHeader.text = "Simulation - Challenge";
        StartSimulation();
        aircraft.RandomiseFaults();
    }



    // Begins a hunt mode simulation and generates just one fault.
    public void InitiateHunt()
    {
        ClearSimulation();
        activeMode = simulationModes.Hunt;
        simulationTabHeader.text = "Simulation - Hunt";
        StartSimulation();
        aircraft.RandomisePart();
    }



    // Ends the simulation and scores the user.
    public void Submit()
    {
        EndSimulation();
    }



    // Wipes all faults from the aircraft and resets the simulation board.
    public void Reset()
    {
        ClearSimulation();
    }
}
