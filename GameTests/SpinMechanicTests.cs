using GameEngines.Interfaces;
using GameEngines.Slots;
using GameEngines.ValueObjects;
using Xunit;

namespace GameTests
{
    public class SpinMechanicTests
    {
        private readonly ISpinMechanic _spinMechanic;

        public SpinMechanicTests() => _spinMechanic = new SpinMechanic();

        [Fact]
        public void Spin_With_5_Percent_number_Range_Should_return_Row_Of_Wildcards()
        {
            var numberRange = Enumerable.Range(0, 4);
            foreach (var i in numberRange)
            {
                var spinRow = new SpinRow();
                _spinMechanic.AddSymbolToGameRow(i, spinRow);
                spinRow.Symbols.ForEach(s => Assert.Equal("*", s));
            }
        }

        [Fact]
        public void Spin_With_15_Percent_number_Range_Should_return_Row_Of_Pineapples()
        {
            var numberRange = Enumerable.Range(5, 15);
            foreach (var i in numberRange)
            {
                var spinRow = new SpinRow();
                _spinMechanic.AddSymbolToGameRow(i, spinRow);
                spinRow.Symbols.ForEach(s => Assert.Equal("P", s));
            }
        }

        [Fact]
        public void Spin_With_35_Percent_number_Range_Should_return_Row_Of_Bananas()
        {
            var numberRange = Enumerable.Range(20, 35);
            foreach (var i in numberRange)
            {
                var spinRow = new SpinRow();
                _spinMechanic.AddSymbolToGameRow(i, spinRow);
                spinRow.Symbols.ForEach(s => Assert.Equal("B", s));
            }
        }

        [Fact]
        public void Spin_With_45_Percent_number_Range_Should_return_Row_Of_Apples()
        {
            var numberRange = Enumerable.Range(55, 45);
            foreach (var i in numberRange)
            {
                var spinRow = new SpinRow();
                _spinMechanic.AddSymbolToGameRow(i, spinRow);
                spinRow.Symbols.ForEach(s => Assert.Equal("A", s));
            }
        }
    }
}