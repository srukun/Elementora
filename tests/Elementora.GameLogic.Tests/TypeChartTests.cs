using Elementora.GameLogic.Types;

namespace Elementora.GameLogic.Tests;
public class TypeChartTests
{
    [Theory]
    [InlineData(ElementType.Tech, ElementType.Bio)]
    [InlineData(ElementType.Bio, ElementType.Energy)]
    [InlineData(ElementType.Energy, ElementType.Tech)]

    public void Strong_matchups_return_strong_modifier(ElementType attack, ElementType defender)
    {
        Assert.Equal(TypeChart.StrongModifier, TypeChart.GetModifier(attack, defender));
    }

    [Theory]
    [InlineData(ElementType.Bio, ElementType.Tech)]
    [InlineData(ElementType.Energy, ElementType.Bio)]
    [InlineData(ElementType.Tech, ElementType.Energy)]

    public void Weak_matchups_return_weak_modifier(ElementType attack, ElementType defender)
    {
        Assert.Equal(TypeChart.WeakModifier, TypeChart.GetModifier(attack, defender));
    }

    [Theory]
    [InlineData(ElementType.Tech, ElementType.Tech)]
    [InlineData(ElementType.Bio, ElementType.Bio)]
    [InlineData(ElementType.Energy, ElementType.Energy)]
    [InlineData(ElementType.Null, ElementType.Null)]
    public void Same_type_is_neutral(ElementType attack, ElementType defender)
    {
        Assert.Equal(TypeChart.NeutralModifier, TypeChart.GetModifier(attack, defender));
    }

    [Theory]
    [InlineData(ElementType.Tech)]
    [InlineData(ElementType.Energy)]
    [InlineData(ElementType.Bio)]

    public void Null_is_neutral_both_ways(ElementType other)
    {
        Assert.Equal(TypeChart.NeutralModifier, TypeChart.GetModifier(ElementType.Null, other));
        Assert.Equal(TypeChart.NeutralModifier, TypeChart.GetModifier(other, ElementType.Null));
    }

    [Fact]
    public void Null_beats_nothing()
    {
        Assert.Null(TypeChart.Beats(ElementType.Null));
    }

}
