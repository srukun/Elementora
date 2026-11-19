namespace Elementora.GameLogic.Progression;

public sealed class XpCurve
{
    public XpCurve(long baseXp = 100, double growth = 1.05)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(baseXp, 1);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(growth, 1.0);

        BaseXp = baseXp;
        Growth = growth;
        MaxSupportedLevel = 1 + (long)Math.Floor(Math.Log(long.MaxValue / 2.0 / baseXp) / Math.Log(growth));
    }

    public long BaseXp { get; }
    public double Growth { get; }
    public long MaxSupportedLevel { get; }
    public long XpToNextLevel(long level)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(level, 1);
        if(level > MaxSupportedLevel)
        {
            throw new OverflowException($"Level {level} is beyond the supported maximum of {MaxSupportedLevel}.");

        }
        return (long)Math.Round(BaseXp * Math.Pow(Growth, level - 1));
    }
}
