using Elementora.GameLogic.Creatures;

namespace Elementora.GameLogic.Tests;

public class StatsAndVariantTests
{
    [Fact]
    public void Total_is_the_sum_of_all_five_stats()
    {
        var stats = new Stats(Hp: 10, PhysicalAttack: 20, SpecialAttack: 30, Defense: 40, Speed: 50);

        Assert.Equal(150, stats.Total);
    }

    [Fact]
    public void Stats_with_the_same_values_are_equal()
    {
        var a = new Stats(80, 90, 60, 80, 80);
        var b = new Stats(80, 90, 60, 80, 80);

        Assert.Equal(a, b);
    }

    [Fact]
    public void With_expression_creates_a_changed_copy_and_leaves_the_original_alone()
    {
        var original = new Stats(80, 90, 60, 80, 80);

        var tougher = original with { Defense = 200 };

        Assert.Equal(80, original.Defense);
        Assert.Equal(200, tougher.Defense);
    }

    [Fact]
    public void No_variant_gives_no_bonus()
    {
        var bonus = Variants.GetBonus(Variant.None);

        Assert.Equal(0, bonus.Total);
    }

    [Fact]
    public void Every_variant_uses_exactly_the_bonus_budget()
    {
        foreach(var variant in Enum.GetValues<Variant>())
        {
            if(variant == Variant.None)
            {
                continue;
            }

            var bonus = Variants.GetBonus(variant);

            Assert.Equal(Variants.BonusBudget, bonus.Total, precision: 10);
        }
    }

    [Fact]
    public void Plasma_only_boosts_the_two_attack_stats()
    {
        var bonus = Variants.GetBonus(Variant.Plasma);

        Assert.Equal(0, bonus.Hp);
        Assert.True(bonus.PhysicalAttack > 0);
        Assert.True(bonus.SpecialAttack > 0);
        Assert.Equal(0, bonus.Defense);
        Assert.Equal(0, bonus.Speed);
    }
    private static readonly Stats SampleBase = new(Hp: 80, PhysicalAttack: 90, SpecialAttack: 60, Defense: 80, Speed: 80);

    [Fact]

    public void Level_50_stats_match_the_formula()
    {
        var stats = StatCalculator.Calculate(SampleBase, level: 50);

        Assert.Equal(140, stats.Hp);

        Assert.Equal(95, stats.PhysicalAttack);
    }

    [Fact]
    public void Stats_grow_with_level()
    {
        var low = StatCalculator.Calculate(SampleBase, level: 10);
        var high = StatCalculator.Calculate(SampleBase, level: 100);

        Assert.True(high.Total > low.Total);
    }

    [Fact]
    public void Level_bellow_one_throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => StatCalculator.Calculate(SampleBase, level: 0));
    }

    [Fact]
    public void Plasma_variant_boosts_attacks_but_not_defense()
    {
        var plain = StatCalculator.Calculate(SampleBase, level: 50);
        var plasma = StatCalculator.Calculate(SampleBase, level: 50, Variant.Plasma);

        Assert.True(plasma.PhysicalAttack > plain.PhysicalAttack);
        Assert.True(plasma.SpecialAttack > plain.SpecialAttack);
        Assert.Equal(plain.Defense, plasma.Defense);
    }

    [Fact]
    public void Huge_levels_throw_instead_of_overflowing()
    {
        Assert.Throws<OverflowException>(() => StatCalculator.Calculate(SampleBase, level: long.MaxValue / 2));
    }
}
