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
}
