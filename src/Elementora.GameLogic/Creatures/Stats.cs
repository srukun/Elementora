namespace Elementora.GameLogic.Creatures;

public readonly record struct Stats(long Hp, long PhysicalAttack, long SpecialAttack, long Defense, long Speed)
{
    public long Total => Hp + PhysicalAttack + SpecialAttack + Defense + Speed;
}
