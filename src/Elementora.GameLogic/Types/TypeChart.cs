namespace Elementora.GameLogic.Types;
public static class TypeChart
{
    public const double StrongModifier = 1.2;
    public const double WeakModifier = 0.8;
    public const double NeutralModifier = 1.0;
    public static ElementType? Beats(ElementType type) => type switch
    {
        ElementType.Tech => ElementType.Bio,
        ElementType.Bio => ElementType.Energy,
        ElementType.Energy => ElementType.Tech,
        ElementType.Null => null,
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
    };

    public static double GetModifier(ElementType attacker, ElementType defender)
    {
        if (Beats(attacker) == defender)
        {
            return StrongModifier;
        }
        if (Beats(defender) == attacker)
        {
            return WeakModifier;
        }
        return NeutralModifier;
    }
}
