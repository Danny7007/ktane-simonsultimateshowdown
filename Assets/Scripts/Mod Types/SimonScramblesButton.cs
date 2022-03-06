using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonScramblesButton : SimonButton {
    public override SimonModType type
    { get { return SimonModType.Simon_Scrambles; } }

    protected override Dictionary<SimonColor, Color32> matColors
    { get { return new Dictionary<SimonColor, Color32>()
            {
                { SimonColor.Red, new Color32(0xFF, 0x00, 0x00, 0xFF)},
                { SimonColor.Green, new Color32(0x68, 0xFF, 0x00, 0xFF)},
                { SimonColor.Blue, new Color32(0x09, 0x0B, 0xFF, 0xFF)},
                { SimonColor.Yellow, new Color32(0xFF, 0xF8, 0x00, 0xFF)}
            }; } 
    }

    public override float interactionPunch
    { get { return 0; } }

    protected override float flashTime
    { get { return 0.9f; } }
 
    public override IEnumerable<SimonColor> GetSolution(Flash flash)
    {
        Log("Indexing into color table with color {0} and positions {1} {2}.", this.color, flash.positionInSequence, flash.positionInSequence + 5);
        yield return table[color][flash.positionInSequence];
        yield return table[color][flash.positionInSequence + 5];
    }
    


    public override string GetFlashSound()
    {
        return null;
    }

    private static readonly Dictionary<SimonColor, SimonColor[]> table = new Dictionary<SimonColor, SimonColor[]>()
    {
        { SimonColor.Blue, new[] { SimonColor.Yellow, SimonColor.Green, SimonColor.Red, SimonColor.Red, SimonColor.Red, SimonColor.Blue, SimonColor.Yellow, SimonColor.Yellow, SimonColor.Red, SimonColor.Green, } },
        { SimonColor.Yellow, new[] { SimonColor.Green, SimonColor.Blue, SimonColor.Green, SimonColor.Yellow, SimonColor.Blue, SimonColor.Yellow, SimonColor.Green, SimonColor.Blue, SimonColor.Yellow, SimonColor.Red} },
        { SimonColor.Red, new[] { SimonColor.Blue, SimonColor.Yellow, SimonColor.Yellow, SimonColor.Green, SimonColor.Green, SimonColor.Red, SimonColor.Blue, SimonColor.Green, SimonColor.Blue, SimonColor.Yellow } },
        { SimonColor.Green, new[] { SimonColor.Red, SimonColor.Red, SimonColor.Blue, SimonColor.Blue, SimonColor.Yellow, SimonColor.Green, SimonColor.Red, SimonColor.Red, SimonColor.Green, SimonColor.Blue } }
    };
}
