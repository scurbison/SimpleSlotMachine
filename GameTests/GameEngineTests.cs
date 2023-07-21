using GameEngines.Interfaces;
using GameEngines.Slots;
using Xunit;

namespace GameTests
{
    public class GameEngineTests
    {
        private ISlotsGameEngine _gameEngine;

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
            var isValid = _gameEngine.ValidateAndStoreDeposit(depositAmount);
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("10")]
        [InlineData("10.50")]
        [InlineData("10.00")]
        public void Deposit_Valid_Amount_Should_Return_True(string? depositAmount)
        {
            var isValid = _gameEngine.ValidateAndStoreDeposit(depositAmount);
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("10", 10.00)]
        [InlineData("10.50", 10.50)]
        [InlineData("10.00", 10.00)]
        [InlineData("10.12345678", 10.12)]
        public void Deposit_Valid_Amount_Should_Set_Game_Deposit_To_Valid_2DP(string deposit, decimal expectedOutput)
        {
            var isValid = _gameEngine.ValidateAndStoreDeposit(deposit);
            Assert.True(isValid);
            Assert.Equal(_gameEngine.Deposit, expectedOutput);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("This is not a number")]
        public void Enter_Invalid_Stake_Returns_False(string? stake)
        {
            var isValid = _gameEngine.ValidateAndStoreStake(stake);
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("10", 10.00)]
        [InlineData("10.50", 10.50)]
        [InlineData("10.00", 10.00)]
        [InlineData("10.12345678", 10.12)]
        public void Enter_Valid_Stake_Should_Return_True_And_Record_Stake(string stakeAmount, decimal expectedStake)
        {
            _gameEngine.ValidateAndStoreDeposit("100");
            var isValid = _gameEngine.ValidateAndStoreStake(stakeAmount);
            Assert.True(isValid);
            Assert.Equal(_gameEngine.CurrentStake, expectedStake);
        }

        [Fact]
        public void Stake_Greater_Than_Remaining_Deposit_Should_Return_False()
        {
            _gameEngine.ValidateAndStoreDeposit("100");
            var isValid = _gameEngine.ValidateAndStoreStake("200");
            Assert.False(isValid);
        }
    }
}
