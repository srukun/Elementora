namespace Elementora.GameLogic.Creatures;

public static class StatCalculator
{
    public const int LevelDivisor = 50;

    public static Stats Calculate(Stats baseStats, long level, Variant variant = Variant.None)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(level, 1);

        var bonus = Variants.GetBonus(variant);

        return new Stats(Hp: ApplyBonus(HpStat(baseStats.Hp, level), bonus.Hp),
            PhysicalAttack: ApplyBonus(OtherStat(baseStats.PhysicalAttack, level), bonus.PhysicalAttack),
            SpecialAttack: ApplyBonus(OtherStat(baseStats.SpecialAttack, level), bonus.SpecialAttack),
            Defense: ApplyBonus(OtherStat(baseStats.Defense, level), bonus.Defense),
            Speed: ApplyBonus(OtherStat(baseStats.Speed, level), bonus.Speed));
    }

    private static long HpStat(long baseHp, long level) => checked(baseHp * level / LevelDivisor + level + 10);

    private static long OtherStat(long baseStat, long level) => checked(baseStat * level / LevelDivisor + 5);

    private static long ApplyBonus(long value, double bonus) => bonus == 0 ? value : (long)Math.Floor(value * (1 + bonus));

}
