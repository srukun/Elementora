using Elementora.GameLogic.Creatures;

namespace Elementora.GameLogic.Capture;

public enum CaptureCardTier
{
    Basic,
    Advanced,
    Elite
}

public static class CatchCalculator
{
    public static double CatchChance(CaptureCardTier card, Rarity rarity, long currentHp, long maxHp)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(maxHp, 1);
        ArgumentOutOfRangeException.ThrowIfNegative(currentHp);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(currentHp, maxHp);

        double hpRatio = (double)currentHp / maxHp;

        double hpFactor = 1.0 - (2.0 / 3.0) * hpRatio;

        double chance = BaseRate(rarity) * CardMultiplier(card) * hpFactor;

        return Math.Clamp(chance, 0.0, 1.0);
    }
    public static bool TryCatch(CaptureCardTier card, Rarity rarity, long currentHp, long maxHp, double roll) 
        => roll < CatchChance(card, rarity, currentHp, maxHp);
    public static double BaseRate(Rarity rarity) => rarity switch
    {
        Rarity.Common => 0.6,
        Rarity.Uncommon => 0.4,
        Rarity.Rare => 0.2,
        Rarity.Mythical => 0.08,
        Rarity.Legendary => 0.03,
        _ => throw new ArgumentOutOfRangeException(nameof(rarity), rarity, null),
    };
    public static double CardMultiplier(CaptureCardTier card) => card switch
    {
        CaptureCardTier.Basic => 1.0,
        CaptureCardTier.Advanced => 1.5,
        CaptureCardTier.Elite => 2.5,
        _ => throw new ArgumentOutOfRangeException(nameof(card), card, null),
    };

}