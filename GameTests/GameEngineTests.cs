using GameEngines.Interfaces;
using GameEngines.Slots;
using Xunit;

namespace GameTests
{
    internal class GameEngineTests
    {
        private ISlotsGameEngine _gameEngine;

        internal GameEngineTests()
        {
            _gameEngine = new SlotsGameEngine();
        }

        //[Fact]
        //public void Deposit_Invalid_Amount_Should_Return_False
        //{
        //    _gameEngine.
        //}
    }
}
