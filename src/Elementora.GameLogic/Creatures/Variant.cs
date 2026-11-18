namespace Elementora.GameLogic.Creatures;

public enum Variant
{
    None,
    Emerald,
    Plasma,
    Magnetic
}

public readonly record struct StatBonus(double Hp, double PhysicalAttack, double SpecialAttack, double Defense, double Speed)
{
    public double Total => Hp + PhysicalAttack + SpecialAttack + Defense + Speed;
}

public static class Variants
{
    public const double BonusBudget = 0.10;

    public static StatBonus GetBonus(Variant variant) => variant switch
    {
        Variant.None => default,

        Variant.Emerald => new StatBonus(Hp: .10, PhysicalAttack: 0, SpecialAttack: 0, Defense: 0, Speed: 0),

        Variant.Plasma => new StatBonus(Hp: 0, PhysicalAttack: 0.05, SpecialAttack: 0.05, Defense: 0, Speed: 0),

        Variant.Magnetic => new StatBonus(Hp: 0, PhysicalAttack: 0, SpecialAttack: 0, Defense: 0.05, Speed: 0.05),

        _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
    };
}