using GameEngines.Interfaces;
using GameEngines.Slots;
using Xunit;

namespace GameTests
{
    public class GameEngineTests
    {
        private SlotsGameEngine _gameEngine;

        public GameEngineTests()
        {
            _gameEngine = new SlotsGameEngine();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("This is not a number")]
        public void Deposit_Invalid_Amount_Should_Return_False(string? depositAmount)
        {
            var isValid = _gameEngine.IsValidDeposit(depositAmount);
            Assert.False(isValid);
        }
    }
}
