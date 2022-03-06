using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSimonsButton : SimonButton {
    public override SimonModType type
    { get { return SimonModType.Simon_Simons; } }

    public override float interactionPunch
    { get { return 1; } }

    protected override float flashTime
    { get { return 0.5f; } }
    public override bool resetOnStrike
    { get { return true; } }

    protected override Dictionary<SimonColor, Color32> matColors
    { get {
            return new Dictionary<SimonColor, Color32>()
            {
                { SimonColor.Red, new Color32(0xFF, 0x20, 0x20, 0xFF) },
                { SimonColor.Green, new Color32(0x42, 0xA3, 0x00, 0xFF) },
                { SimonColor.Blue, new Color32(0x17, 0x18, 0xFF, 0xFF )},
                { SimonColor.Yellow, new Color32(0xD6, 0xD8, 0x49, 0xFF) }
            };
    }}

    public override string GetFlashSound()
    {
        return "Simons" + color.ToString();
    }

    public override IEnumerable<SimonColor> GetSolution(Flash flash)
    {
        throw new System.NotImplementedException();
    }

    protected override void OnStart()
    {
        base.OnStart();
        lights[0].color = Color.white;
    }
}
