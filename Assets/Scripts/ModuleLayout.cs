using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Stores information about the state of the module buttons.
/// </summary>
public class ModuleLayout : IEnumerable<SimonButton> {

    private SimonButton[] _btns;

    public IEnumerator<SimonButton> GetEnumerator()
    { return _btns.ToList().GetEnumerator(); }
    IEnumerator IEnumerable.GetEnumerator()
    { return GetEnumerator(); }

    public SimonButton[] buttons { get { return _btns.ToArray(); } }

    public ModuleLayout(SimonButton[] btns)
    {
        if (btns == null)
            throw new ArgumentNullException("btns");
        if (btns.Length != 6)
            throw new ArgumentOutOfRangeException("btns", btns.Length.ToString(), "expected length of 6 for module layout.");
        _btns = btns;
    }
    /// <returns>
    /// The colors of each button in order.
    /// </returns>
    public SimonColor[] colors { get { return _btns.Select(b => b.color).ToArray(); } }
    /// <returns>
    /// The types of each button.
    /// </returns>
    public SimonModType[] types { get { return _btns.Select(b => b.type).ToArray(); } }
    /// <returns>
    /// The sequence of flashes produced by the buttons in order.
    /// </returns>
    public Flash[] flashes { get { return _btns.Where(b => b.flashes != null).SelectMany(b => b.flashes.Select(f => f.Value)).OrderBy(f => f.positionInSequence).ToArray(); } }
    /// <returns>
    /// The colors of the flashing buttons in order.
    /// </returns>
    public SimonColor[] flashColors { get { return flashes.Select(f => f.color).ToArray(); } }
    /// <returns>
    /// The positions of the flashing buttons in order.
    /// </returns>
    public int[] flashPositions { get { return flashes.Select(f => f.flashingPosition).ToArray(); } }
    /// <returns>
    /// The types of the flashing buttons in order.
    /// </returns>
    public SimonModType[] flashTypes { get { return flashes.Select(f => f.type).ToArray(); } }

}
