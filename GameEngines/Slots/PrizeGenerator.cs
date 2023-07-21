using GameEngines.Interfaces;
using GameEngines.ValueObjects;

namespace GameEngines.Slots
{
    public class PrizeGenerator : IPrizeGenerator
    {
        public decimal GeneratePrize(List<SpinRow> game, decimal currentStake)
        {
            decimal amount = 0;
            decimal coefficientTotal = 0;
            game.ForEach(row =>
            {
                if (IsWinningRow(row))
                {
                    coefficientTotal += CalculateCoefficientForRow(row);
                }
            });

            if (coefficientTotal > 0)
            {
                amount = currentStake * coefficientTotal;
            }

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

        public decimal CalculateCoefficientForRow(SpinRow row)
        {
            decimal coefficientTotal = 0;
            row.Symbols.ForEach(symbol =>
            {
                coefficientTotal += symbol.Coefficient;
            });

            return coefficientTotal;
        }

        private void RemoveWildcardsFromRow(SpinRow row) => row.Symbols.RemoveAll(symbol => symbol == SpinSymbols.Wildcard);
    }
}