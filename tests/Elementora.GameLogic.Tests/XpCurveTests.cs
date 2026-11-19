using Elementora.GameLogic.Progression;

namespace Elementora.GameLogic.Tests;

public class XpCurveTests
{
    private readonly XpCurve _curve = new();

    [Fact]
    public void Level_one_needs_the_base_xp()
    {
        Assert.Equal(100, _curve.XpToNextLevel(1));
    }

    [Fact]
    public void Each_level_needs_more_xp_than_the_last()
    {
        for(long level = 1; level < 100; level++)
        {
            Assert.True(_curve.XpToNextLevel(level + 1) > _curve.XpToNextLevel(level));
        }
    }
    [Fact]
    public void Level_two_needs_five_percent_more()
    {
        Assert.Equal(105, _curve.XpToNextLevel(2));
    }
    [Fact]
    public void Custom_settings_are_used()
    {
        var hardCurve = new XpCurve(baseXp: 200, growth: 1.10);

        Assert.Equal(200, hardCurve.XpToNextLevel(1));
        Assert.Equal(220, hardCurve.XpToNextLevel(2));
    }
    [Theory]
    [InlineData(0, 1.05)]
    [InlineData(100, 1.0)]
    [InlineData(100, 0.9)]
    public void Invalid_settings_throw(long baseXp, double growth)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new XpCurve(baseXp, growth));
    }

    [Fact]
    public void Max_supported_level_works_and_one_past_it_throws()
    {
        long max = _curve.MaxSupportedLevel;

        Assert.True(_curve.XpToNextLevel(max) > 0);
        Assert.Throws<OverflowException>(() => _curve.XpToNextLevel(max + 1));
    }
}
