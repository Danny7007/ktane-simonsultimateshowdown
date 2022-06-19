using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class SimonsUltimateShowdownScript : MonoBehaviour
{

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMBombModule Module;
    public KMColorblindMode Colorblind;

    public GameObject[] prefabs;
    public Transform buttonPositionParent;

    private ModuleLayout layout;
    private SimonButton[] buttons;
    private List<Pair<SimonColor, SpecialEventType>> solution;
    private int stage, enteredPresses;

    private bool interactable = true;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    

    void Awake()
    {
        moduleId = moduleIdCounter++;

        GenerateLayout();
    }

    void GenerateLayout()
    {
        SimonButton[] buttons = new SimonButton[6];
        for (int i = 0; i < 6; i++)
        {
            buttons[i] = Instantiate(prefabs.PickRandom().GetComponent<SimonButton>(), buttonPositionParent);
            buttons[i].position = (ButtonPosition)i;
            buttons[i].PositionButton();
        }
        layout = new ModuleLayout(buttons.ToArray());
    }


    void Start()
    {
        
    }

    void Update()
    {

    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use <!{0} foobar> to do something.";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command)
    {
        command = command.Trim().ToUpperInvariant();
        List<string> parameters = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        yield return null;
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        yield return null;
    }
}