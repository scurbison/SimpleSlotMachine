﻿using GameEngines.Interfaces;
using GameEngines.ValueObjects;

namespace GameEngines.Slots
{
    public class SpinMechanic : ISpinMechanic
    {
        private const int RowsPerGame = 4;
        private const int ColumnsPerRow = 3;
        
        public List<SpinRow> Spin()
        {
            var game = new List<SpinRow>(4);
            var randomNumberGenerator = new Random();
            Console.WriteLine("SPINNING!!! Good Luck!");
            Console.WriteLine();
            for (int i = 0; i < RowsPerGame; i++)
            {
                var row = new SpinRow();
                for (int j = 0; j < ColumnsPerRow; j++)
                {
                    var randomNumber = randomNumberGenerator.Next(0, 99);
                    AddSymbolToGameRow(randomNumber, row);
                }
                game.Add(row);
            }

            DisplaySpinResult(game);
            return game;
        }

        public void AddSymbolToGameRow(int randomNumber, SpinRow row)
        {
            switch (randomNumber)
            {
                case >= 0 and < 5:
                    row.AddSymbolToRow(SpinSymbols.Wildcard);
                    break;
                case >= 5 and < 20:
                    row.AddSymbolToRow(SpinSymbols.Pineapple);
                    break;
                case >= 20 and < 55:
                    row.AddSymbolToRow(SpinSymbols.Banana);
                    break;
                case >= 55 and < 100:
                    row.AddSymbolToRow(SpinSymbols.Apple);
                    break;
            }
        }

        private void DisplaySpinResult(List<SpinRow> rows)
        {
            rows.ForEach(row =>
            {
                row.Symbols.ForEach(symbol => Console.Write(symbol.Symbol));
                Console.WriteLine();
            });
            Console.WriteLine();
        }
    }
}
