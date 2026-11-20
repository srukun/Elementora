using Elementora.GameLogic.Battle;
using Elementora.GameLogic.Types;

namespace Elementora.Web.Data.Entities;

public class Move
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ElementType Type { get; set; }
    public MoveCategory Category { get; set; }
    public int Power { get; set; }
    public int Accuracy { get; set; }

    public ICollection<SpeciesMove> SpeciesMoves { get; set; } = new List<SpeciesMove>();

    public MoveData ToMoveData() => new(Type, Category, Power);

}
