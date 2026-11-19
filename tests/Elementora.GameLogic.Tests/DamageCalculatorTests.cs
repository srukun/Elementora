using Elementora.GameLogic.Battle;
using Elementora.GameLogic.Creatures;
using Elementora.GameLogic.Types;

namespace Elementora.GameLogic.Tests;

public class DamageCalculatorTests
{
    private static readonly Stats BaseStats = new(Hp: 80, PhysicalAttack: 90, SpecialAttack: 60, Defense: 80, Speed: 80);
    private static readonly Stats Attacker = StatCalculator.Calculate(BaseStats, level: 50);
    private static readonly Stats Defender = StatCalculator.Calculate(BaseStats, level: 50);

    private static readonly MoveData TechStrike = new(ElementType.Tech, MoveCategory.Physical, Power: 60);
    private static readonly MoveData TechBeam = new(ElementType.Tech, MoveCategory.Special, Power: 60);
    private static readonly MoveData Repair = new(ElementType.Tech, MoveCategory.Utility, Power: 0);

    private static long Hit(MoveData move, ElementType defenderType, double roll = 0.999) =>
        DamageCalculator.Calculate(50, Attacker, move, Defender, defenderType, roll);

    [Fact]
    public void Strong_matchup_deals_about_20_percent_more_than_neutral()
    {
        double ratio = (double)Hit(TechStrike, ElementType.Bio) / Hit(TechStrike, ElementType.Null);

        Assert.InRange(ratio, 1.17, 1.23);
    }

    [Fact]
    public void Weak_matchup_deals_about_20_percent_less_than_neutral()
    {
        double ratio = (double)Hit(TechStrike, ElementType.Energy) / Hit(TechStrike, ElementType.Null);

        Assert.InRange(ratio, 0.77, 0.83);
    }

    [Fact]
    public void Physical_moves_use_physical_attack_and_special_moves_use_special_attack()
    {
        Assert.True(Hit(TechStrike, ElementType.Null) > Hit(TechBeam, ElementType.Null));
    }

    [Fact]
    public void Utility_moves_deal_no_damage()
    {
        Assert.Equal(0, Hit(Repair, ElementType.Null));
    }
    [Fact]
    public void Random_factor_spans_85_to_100_percent()
    {
        double ratio = (double)Hit(TechStrike, ElementType.Null, roll: 0.0) / Hit(TechStrike, ElementType.Null, roll: 0.999999);

        Assert.InRange(ratio, 0.83, 0.87);
    }

    [Fact]
    public void Same_inputs_always_give_the_same_damage()
    {
        Assert.Equal(Hit(TechStrike, ElementType.Bio, roll: 0.5), Hit(TechStrike, ElementType.Bio, roll: 0.5));
    }
    [Fact]
    public void Damaging_moves_always_deal_at_least_one()
    {
        var weak = StatCalculator.Calculate(BaseStats, level: 1);
        var tank = StatCalculator.Calculate(BaseStats with { Defense = 255 }, level: 1000);

        Assert.True(DamageCalculator.Calculate(1, weak, TechStrike, tank, ElementType.Energy, roll: 0) >= 1);
    }
    [Theory]
    [InlineData(-0.1)]
    [InlineData(1.0)]
    public void Roll_outside_zero_to_one_throws(double roll)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Hit(TechStrike, ElementType.Null, roll));
    }
}
