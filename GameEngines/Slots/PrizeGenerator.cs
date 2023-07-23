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
            return row.Symbols.Count <= 1 || row.Symbols.All(s => s == row.Symbols[0]);
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