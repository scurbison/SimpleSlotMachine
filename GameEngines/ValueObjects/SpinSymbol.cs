using GameEngines.Interfaces;

namespace GameEngines.ValueObjects
{
    public record SpinSymbol(string Name, string Symbol, double Coefficient) : ISpinSymbol;
}
