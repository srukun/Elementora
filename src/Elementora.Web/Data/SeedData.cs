using Elementora.GameLogic.Battle;
using Elementora.GameLogic.Creatures;
using Elementora.GameLogic.Types;
using Elementora.Web.Data.Entities;

namespace Elementora.Web.Data;

public static class SeedData
{
    public static readonly Species[] AllSpecies =
    [
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

    public static readonly Move[] AllMoves =
    [
        new() { Id = 1, Name = "Spark Bite",   Type = ElementType.Energy, Category = MoveCategory.Physical, Power = 40, Accuracy = 100 },
        new() { Id = 2, Name = "Volt Beam",    Type = ElementType.Energy, Category = MoveCategory.Special,  Power = 70, Accuracy = 95 },
        new() { Id = 3, Name = "Vine Lash",    Type = ElementType.Bio,    Category = MoveCategory.Physical, Power = 45, Accuracy = 100 },
        new() { Id = 4, Name = "Spore Burst",  Type = ElementType.Bio,    Category = MoveCategory.Special,  Power = 65, Accuracy = 95 },
        new() { Id = 5, Name = "Gear Smash",   Type = ElementType.Tech,   Category = MoveCategory.Physical, Power = 60, Accuracy = 95 },
        new() { Id = 6, Name = "Laser Pulse",  Type = ElementType.Tech,   Category = MoveCategory.Special,  Power = 55, Accuracy = 100 },
        new() { Id = 7, Name = "Static Shift", Type = ElementType.Null,   Category = MoveCategory.Special,  Power = 50, Accuracy = 100 },
        new() { Id = 8, Name = "Tackle",       Type = ElementType.Null,   Category = MoveCategory.Physical, Power = 35, Accuracy = 100 },
        new() { Id = 9, Name = "Harden",       Type = ElementType.Null,   Category = MoveCategory.Utility,  Power = 0,  Accuracy = 100 },
    ];

    public static readonly SpeciesMove[] AllSpeciesMoves =
    [
        new() { SpeciesId = 1, MoveId = 1 }, new() { SpeciesId = 1, MoveId = 2 }, new() { SpeciesId = 1, MoveId = 8 },
        new() { SpeciesId = 2, MoveId = 3 }, new() { SpeciesId = 2, MoveId = 4 }, new() { SpeciesId = 2, MoveId = 9 },
        new() { SpeciesId = 3, MoveId = 5 }, new() { SpeciesId = 3, MoveId = 6 }, new() { SpeciesId = 3, MoveId = 9 },
        new() { SpeciesId = 4, MoveId = 7 }, new() { SpeciesId = 4, MoveId = 8 }, new() { SpeciesId = 4, MoveId = 9 },
        new() { SpeciesId = 5, MoveId = 3 }, new() { SpeciesId = 5, MoveId = 4 }, new() { SpeciesId = 5, MoveId = 8 },
        new() { SpeciesId = 6, MoveId = 2 }, new() { SpeciesId = 6, MoveId = 5 }, new() { SpeciesId = 6, MoveId = 6 },
    ];
}