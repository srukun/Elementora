using Elementora.GameLogic.Capture;
using Elementora.GameLogic.Creatures;

namespace Elementora.GameLogic.Tests;

public class CatchCalculatorTests
{
    [Fact]
    public void Lower_hp_gives_a_higher_chance()
    {
        double fullHp = CatchCalculator.CatchChance(CaptureCardTier.Basic, Rarity.Rare, currentHp: 100, maxHp: 100);
        double lowHp = CatchCalculator.CatchChance(CaptureCardTier.Basic, Rarity.Rare, currentHp: 10, maxHp: 100);

        Assert.True(lowHp > fullHp);
    }

    [Fact]
    public void Full_hp_chance_is_a_third_of_zero_hp_chance()
    {
        double fullHp = CatchCalculator.CatchChance(CaptureCardTier.Basic, Rarity.Rare, currentHp: 100, maxHp: 100);
        double zeroHp = CatchCalculator.CatchChance(CaptureCardTier.Basic, Rarity.Rare, currentHp: 0, maxHp: 100);

        Assert.Equal(zeroHp / 3, fullHp, precision: 10);
    }

    [Fact]
    public void Better_cards_give_a_higher_chance()
    {
        double basic = CatchCalculator.CatchChance(CaptureCardTier.Basic, Rarity.Rare, 50, 100);
        double advanced = CatchCalculator.CatchChance(CaptureCardTier.Advanced, Rarity.Rare, 50, 100);
        double elite = CatchCalculator.CatchChance(CaptureCardTier.Elite, Rarity.Rare, 50, 100);

        Assert.True(advanced > basic);
        Assert.True(elite > advanced);
    }

    [Fact]
    public void Rarer_creatures_are_harder_to_catch()
    {
        var rarities = Enum.GetValues<Rarity>();

        for (int i = 1; i < rarities.Length; i++)
        {
            Assert.True(CatchCalculator.BaseRate(rarities[i]) < CatchCalculator.BaseRate(rarities[i - 1]));
        }
    }
    [Fact]
    public void Chance_never_goes_above_100_percent()
    {
        double chance = CatchCalculator.CatchChance(CaptureCardTier.Elite, Rarity.Common, currentHp: 0, maxHp: 100);

        Assert.Equal(1.0, chance);
    }

    [Theory]
    [InlineData(0.0, true)]
    [InlineData(0.999, false)]
    public void TryCatch_succeeds_only_when_roll_is_below_the_chance(double roll, bool expected)
    {
        bool caught = CatchCalculator.TryCatch(CaptureCardTier.Basic, Rarity.Rare, currentHp: 50, maxHp: 100, roll);

        Assert.Equal(expected, caught);
    }

    [Fact]
    public void Current_hp_above_max_throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CatchCalculator.CatchChance(CaptureCardTier.Basic, Rarity.Common, currentHp: 101, maxHp: 100));
    }

}
