using Elementora.GameLogic.Creatures;
using Elementora.GameLogic.Types;
using Elementora.Web.Data.Entities;

namespace Elementora.Web.Services;

public class InMemorySpeciesService : ISpeciesService
{
    private readonly List<Species> _species = [
        new() { Id = 1, Name = "Voltkit", Type = ElementType.Energy, Rarity = Rarity.Common, Rank = Rank.Rank1,
                BaseHp = 60, BasePhysicalAttack = 50, BaseSpecialAttack = 75, BaseDefense = 50, BaseSpeed = 85 },
        new() { Id = 2, Name = "Sproutling", Type = ElementType.Bio, Rarity = Rarity.Common, Rank = Rank.Rank1,
                BaseHp = 75, BasePhysicalAttack = 60, BaseSpecialAttack = 55, BaseDefense = 70, BaseSpeed = 45 },
        new() { Id = 3, Name = "Cogling", Type = ElementType.Tech, Rarity = Rarity.Common, Rank = Rank.Rank1,
                BaseHp = 65, BasePhysicalAttack = 75, BaseSpecialAttack = 45, BaseDefense = 75, BaseSpeed = 50 },
        new() { Id = 4, Name = "Glitchmote", Type = ElementType.Null, Rarity = Rarity.Uncommon, Rank = Rank.Rank1,
                BaseHp = 70, BasePhysicalAttack = 65, BaseSpecialAttack = 65, BaseDefense = 65, BaseSpeed = 65 },
        new() { Id = 5, Name = "Thornback", Type = ElementType.Bio, Rarity = Rarity.Rare, Rank = Rank.Rank2,
                BaseHp = 95, BasePhysicalAttack = 90, BaseSpecialAttack = 60, BaseDefense = 100, BaseSpeed = 55 },
        new() { Id = 6, Name = "Arcforge", Type = ElementType.Tech, Rarity = Rarity.Legendary, Rank = Rank.Rank3,
                BaseHp = 110, BasePhysicalAttack = 120, BaseSpecialAttack = 100, BaseDefense = 110, BaseSpeed = 90 },
        ];


    public Task<IReadOnlyList<Species>> GetAllAsync() => Task.FromResult<IReadOnlyList<Species>>(_species);

    public Task<Species?> GetByIdAsync(int id) => Task.FromResult(_species.FirstOrDefault(s => s.Id == id));

}


