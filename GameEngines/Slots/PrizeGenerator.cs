using GameEngines.Interfaces;
using GameEngines.ValueObjects;

namespace GameEngines.Slots
{
    public class PrizeGenerator : IPrizeGenerator
    {
        public decimal GeneratePrize(List<SpinRow> game)
        {
            decimal amount = 0;
            game.ForEach(row =>
            {
                if (IsWinningRow(row))
                {
                    //TODO: calculate the win rate and add it to the amount.
                }
            });

            return Math.Round(amount, 2);
        }

        public bool IsWinningRow(SpinRow row)
        {
            RemoveWildcardsFromRow(row);
            if (row.Symbols.Count <= 1)
                return true;

            if (row.Symbols.Count == 2 && row.Symbols[0] == row.Symbols[1])
                return true;

            if (row.Symbols.Count == 3 && row.Symbols[0] == row.Symbols[1] && row.Symbols[1] == row.Symbols[2])
                return true;

            return false;
        }

        private void RemoveWildcardsFromRow(SpinRow row) => row.Symbols.RemoveAll(symbol => symbol == SpinSymbols.Wildcard);
    }
}