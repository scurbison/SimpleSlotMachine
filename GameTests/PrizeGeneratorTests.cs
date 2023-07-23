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

        private readonly List<SpinRow> _testLosingSpinRows = new()
        {
            new SpinRow {Symbols = new() { SpinSymbols.Apple, SpinSymbols.Banana, SpinSymbols.Apple }},
            new SpinRow {Symbols = new() { SpinSymbols.Apple, SpinSymbols.Banana, SpinSymbols.Pineapple }},
            new SpinRow {Symbols = new() { SpinSymbols.Pineapple, SpinSymbols.Apple, SpinSymbols.Wildcard }},
            new SpinRow {Symbols = new() { SpinSymbols.Wildcard, SpinSymbols.Pineapple, SpinSymbols.Apple }},
        };

        public PrizeGeneratorTests()
        {
            _prizeGenerator = new PrizeGenerator();
        }

        [Fact]
        private void Winning_Row_Returns_True_From_Conditional_Test() => 
            _testWinningSpinRows.ForEach(row => Assert.True(_prizeGenerator.IsWinningRow(row)));


        [Fact]
        private void Losing_Row_Returns_Flase_From_Conditional_Test() => 
            _testLosingSpinRows.ForEach(row => Assert.False(_prizeGenerator.IsWinningRow(row)));


        [Fact]
        private void Coefficient_Calculation_Single_Winning_Row_Test()
        {
            var spinRows = new List<SpinRow> 
            {
                new() {Symbols = new() { SpinSymbols.Apple, SpinSymbols.Apple, SpinSymbols.Apple }}
            };
            var prize = _prizeGenerator.GeneratePrize(spinRows, 10);
            Assert.Equal(12, prize);
        }

        [Fact]
        private void Coefficient_Calculation_Double_Winning_Row_Test()
        {
            var spinRows = new List<SpinRow> 
            {
                new() {Symbols = new() { SpinSymbols.Apple, SpinSymbols.Apple, SpinSymbols.Apple }},
                new() {Symbols = new() { SpinSymbols.Pineapple, SpinSymbols.Pineapple, SpinSymbols.Pineapple }}
            };
            var prize = _prizeGenerator.GeneratePrize(spinRows, 10);
            Assert.Equal(36, prize);
        }

        [Fact]
        private void Coefficient_Calculation_Triple_Winning_Row_Test()
        {
            var spinRows = new List<SpinRow> 
            {
                new() {Symbols = new() { SpinSymbols.Apple, SpinSymbols.Apple, SpinSymbols.Apple }},
                new() {Symbols = new() { SpinSymbols.Pineapple, SpinSymbols.Pineapple, SpinSymbols.Pineapple }},
                new() {Symbols = new() { SpinSymbols.Banana, SpinSymbols.Banana, SpinSymbols.Banana }}
            };
            var prize = _prizeGenerator.GeneratePrize(spinRows, 10);
            Assert.Equal(54, prize);
        }

        [Fact]
        private void Coefficient_Calculation_Four_Winning_Rows_Test()
        {
            var spinRows = new List<SpinRow> 
            {
                new() {Symbols = new() { SpinSymbols.Apple, SpinSymbols.Apple, SpinSymbols.Apple }},
                new() {Symbols = new() { SpinSymbols.Pineapple, SpinSymbols.Pineapple, SpinSymbols.Pineapple }},
                new() {Symbols = new() { SpinSymbols.Banana, SpinSymbols.Banana, SpinSymbols.Banana }},
                new() {Symbols = new() { SpinSymbols.Banana, SpinSymbols.Wildcard, SpinSymbols.Banana }}
            };
            var prize = _prizeGenerator.GeneratePrize(spinRows, 10);
            Assert.Equal(66, prize);
        }

        [Fact]
        private void Coefficient_Calculation_For_Wildcard_Row_Test()
        {
            var spinRows = new List<SpinRow> 
            {
                new() {Symbols = new() { SpinSymbols.Wildcard, SpinSymbols.Wildcard, SpinSymbols.Wildcard }}
            };
            var prize = _prizeGenerator.GeneratePrize(spinRows, 10);
            Assert.Equal(0, prize);
        }
    }
}
