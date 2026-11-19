using Elementora.GameLogic.Types;

namespace Elementora.GameLogic.Battle;
public readonly record struct MoveData(ElementType Type, MoveCategory Category, int Power);