using Elementora.GameLogic.Creatures;
using Elementora.GameLogic.Types;

namespace Elementora.Web.Data.Entities;

public class Species
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ElementType Type { get; set; }
    public Rarity Rarity { get; set; }
    public Rank Rank { get; set; }

    public int BaseHp { get; set; }
    public int BasePhysicalAttack { get; set; }
    public int BaseSpecialAttack { get; set; }
    public int BaseDefense { get; set; }
    public int BaseSpeed { get; set; }

    public ICollection<SpeciesMove> SpeciesMoves { get; set; } = new List<SpeciesMove>();
    public Stats TotalBaseStats() => new(BaseHp, BasePhysicalAttack, BaseSpecialAttack, BaseDefense, BaseSpeed);
}
