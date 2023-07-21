using GameEngines.Interfaces;

namespace GameEngines.ValueObjects
{
    public class SpinRow
    {
        public List<ISpinSymbol> Symbols = new(3);

        public void AddSymbolToRow(ISpinSymbol symbol) => Symbols.Add(symbol);
    }
}
