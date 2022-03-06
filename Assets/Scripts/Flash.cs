/// <summary>
/// Stores info about a singular flash produced by the module.
/// </summary>
public struct Flash {

    public SimonColor color { get; private set; }
	public SimonModType type { get; private set; }
	public int flashingPosition { get; private set; }
    public int positionInSequence { get; private set; }

    public Flash(SimonColor color, SimonModType type, int flashingPosition, int positionInSequence)
    {
        this.color = color;
        this.type = type;
        this.flashingPosition = flashingPosition;
        this.positionInSequence = positionInSequence;
    }
}
