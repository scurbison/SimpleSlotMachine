using GameEngines.Interfaces;

namespace GameEngines.ValueObjects
{
    public record SpinSymbol(string Name, string Symbol, decimal Coefficient) : ISpinSymbol;
}
