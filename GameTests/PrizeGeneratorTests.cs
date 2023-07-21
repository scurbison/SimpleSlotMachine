using GameEngines.Interfaces;
using GameEngines.Slots;
using GameEngines.ValueObjects;
using Xunit;

namespace GameTests
{
    public class PrizeGeneratorTests
    {
        private readonly IPrizeGenerator _prizeGenerator;
        private readonly List<SpinRow> _testWinningSpinRows = new()
        {
            new SpinRow {Symbols = new() { SpinSymbols.Apple, SpinSymbols.Apple, SpinSymbols.Apple }},
            new SpinRow {Symbols = new() { SpinSymbols.Apple, SpinSymbols.Apple, SpinSymbols.Wildcard }},
            new SpinRow {Symbols = new() { SpinSymbols.Wildcard, SpinSymbols.Apple, SpinSymbols.Wildcard }},
            new SpinRow {Symbols = new() { SpinSymbols.Wildcard, SpinSymbols.Wildcard, SpinSymbols.Wildcard }},
        };

        public PrizeGeneratorTests()
        {
            _prizeGenerator = new PrizeGenerator();
        }

        [Fact]
        private void Winning_Row_Returns_True_From_Conditional_Test() => 
            _testWinningSpinRows.ForEach(row => Assert.True(_prizeGenerator.IsWinningRow(row)));
    }
}
