namespace Elementora.Web.Data.Entities;

public class SpeciesMove
{
    public int SpeciesId { get; set; }
    public Species Species { get; set; } = null!;

    public int MoveId { get; set; }
    public Move Move { get; set; } = null!;
}
