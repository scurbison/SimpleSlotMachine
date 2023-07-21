namespace GameEngines.ValueObjects
{
    public class SpinRow
    {
        public List<string> Symbols = new(3);

        public void AddSymbolToRow(string symbol) => Symbols.Add(symbol);
    }
}
