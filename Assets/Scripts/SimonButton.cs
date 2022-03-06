using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
/// <summary>
/// Represents a button on the module.
/// </summary>
public abstract class SimonButton : MonoBehaviour {

	/// <summary>
	/// The prefab which will be spawned by the module.
	/// </summary>
	public GameObject prefab;

	/// <summary>
	/// The selectable component of the button.
	/// </summary>
	public KMSelectable selectable;
	/// <summary>
	/// The meshrenderers which should be colored with the button's color.
	/// </summary>
	public MeshRenderer[] meshRenderers;
	/// <summary>
	/// Lights in the module which will turn on when flashing.
	/// </summary>
	public Light[] lights = new Light[0];
	/// <summary>
	/// The layout of buttons on the module and their flashes.
	/// </summary>
	public ModuleLayout modLayout { private get; set; }
	/// <summary>
	/// The color of the button
	/// </summary>
	public SimonColor color { get; set; }
	/// <summary>
	/// Information about the flashes that this button produces.
	/// </summary>
	public List<Flash?> flashes { get; set; }
	/// <summary>
	/// The ID of the SUS module. Used for logging.
	/// </summary>
	public int moduleId { private get; set; }
	/// <summary>
	/// The type of button that this is.
	/// </summary>
	public abstract SimonModType type { get; }
	/// <summary>
	/// The amount the bomb rocks back when the buttton is selected.
	/// </summary>
	public abstract float interactionPunch { get; }
	/// <summary>
	/// The amount of time the button stays lit when it flashes.
	/// </summary>
	protected abstract float flashTime { get; }
	/// <summary>
	/// The material colors associated with each color that the button can be.
	/// </summary>
	protected abstract Dictionary<SimonColor, Color> matColors { get; }
	/// <summary>
	/// The light colors associated with each color that the button can be. 
	/// </summary>
	protected virtual Dictionary<SimonColor, Color> lightColors { get { return matColors; } }
	/// <summary>
	/// The colors that the button can be.
	/// </summary>
	protected SimonColor[] possibleColors { get { return matColors.Keys.ToArray(); } }
	/// <summary>
	/// Gets the solution for the <paramref name="flashPosition"/>'th flash that this button produces.
	/// </summary>
	/// <param name="flashPosition">The flash which this button produces.</param>
	/// <returns>A series of colors paired with SpecialEventTypes. If no special event occurs, a null is returned.</returns>

	public IEnumerable<Pair<SimonColor, SpecialEventType?>> GetSolution(int flashPosition)
    {
		return GetSolution(flashes[flashPosition].Value);
    }
	/// <summary>
	/// Gets the solution for the <paramref name="flash"/> given.
	/// </summary>
	/// <param name="flash">The flash to calculate for.</param>
	/// <returns>A series of colors paired with SpecialEventTypes. If no special event occurs, a null is returned.</returns>
	public abstract IEnumerable<Pair<SimonColor, SpecialEventType?>> GetSolution(Flash flash);
	/// <summary>
	/// Obtains the name of the audio clip to play when this button flashes and is pressed.<br></br>If null is returned, the standard button press will be played.
	/// </summary>
	public abstract string GetFlashSound();
	/// <summary>
	/// Contains the flash animation for the button.
	/// </summary>
	public virtual IEnumerator Flash()
    {
		foreach (Light light in lights)
			light.enabled = true;
		yield return new WaitForSeconds(flashTime);
		foreach (Light light in lights)
			light.enabled = false;
    }
	/// <summary>
	/// Contains the animation that plays on this button when the module is solved.
	/// </summary>
	public virtual IEnumerator SolveAnimation()
    {
		yield break;
    }
	/// <summary>
	/// Fills the output of a color sequence with paired nulls so that it can be the result of GetSolution.
	/// </summary>
	/// <param name="colors">The sequence to be paired, typically the solution to the flash.</param>
	/// <returns>The sequence <paramref name="colors"/> with each color paired with a null value.</returns>
	protected IEnumerable<Pair<SimonColor, SpecialEventType?>> PopulateWithNull(IEnumerable<SimonColor> colors)
    {
		foreach (SimonColor color in colors)
			yield return new Pair<SimonColor, SpecialEventType?>(color, null);
    }
	/// <summary>
	/// Sends a logging message compatible with the Logfile Analyzer to the Unity Log.
	/// </summary>
	protected void Log(string msg, params object[] args)
    {
		Debug.LogFormat("[Simon's Ultimate Showdown #{0}] {1}", msg, string.Format(msg, args));
    }

    public override string ToString()
    {
		string typeName = type.ToString().Replace('_', ' ');
		typeName = Regex.Replace(typeName, "^Simons", "Simon's");
		return string.Format("[{0}: {1}]", typeName, color);
    }

	void Start()
    {
        foreach (MeshRenderer rend in meshRenderers)
			rend.material.color = matColors[color];
		foreach (Light light in lights)
        {
			light.color = lightColors[color];
			light.range *= GetComponentInParent<SimonsUltimateShowdownScript>().transform.lossyScale.x;
        }
    }
}
