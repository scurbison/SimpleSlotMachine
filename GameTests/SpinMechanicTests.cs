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
        public void Spin_With_5_Percent_number_Should_return_row_of_wildcards()
        {
            var spinRow = new SpinRow();
            _spinMechanic.AddSymbolToGameRow(3, spinRow);
            spinRow.Symbols.ForEach(s => Assert.Equal("*", s));
        }
    }
}