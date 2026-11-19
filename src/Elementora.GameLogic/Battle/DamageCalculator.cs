using Elementora.GameLogic.Creatures;
using Elementora.GameLogic.Types;

namespace Elementora.GameLogic.Battle;

public static class DamageCalculator
{
    public const double MinRandomFactor = 0.85;

    public static long Calculate(long attackerLevel, Stats attacker, MoveData move, Stats defender, ElementType defenderType, double roll)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(attackerLevel, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(roll, 0.0);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(roll, 1.0);

        if (move.Category == MoveCategory.Utility || move.Power <= 0)
        {
            return 0;
        }

        double attack = move.Category == MoveCategory.Physical ? attacker.PhysicalAttack : attacker.SpecialAttack;

        double defense = Math.Max(1, defender.Defense);

        double levelFactor = 2.0 * attackerLevel / 5.0 + 2.0;
        double baseDamage = levelFactor * move.Power * (attack / defense) / 50.0 + 2.0;

        double typeModifier = TypeChart.GetModifier(move.Type, defenderType);

        double randomFactor = MinRandomFactor + (1.0 - MinRandomFactor) * roll;

        return Math.Max(1, (long)Math.Floor(baseDamage * typeModifier * randomFactor));
    }
}
