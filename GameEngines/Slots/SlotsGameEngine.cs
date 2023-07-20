using GameEngines.Interfaces;

namespace GameEngines.Slots
{
    public class SlotsGameEngine : ISlotsGameEngine
    {
        private decimal _deposit;

        public void StartGame()
        {
            Console.WriteLine("Welcome, Please specify how much you would like to deposit?");
            var deposit = Console.ReadLine();
            if (IsValidDeposit(deposit))
            {

            }
        }

        private bool IsValidDeposit(string depositEntered)
        {
            return false;
        }

        public void PlaceStake(decimal initialStake)
        {
            throw new NotImplementedException();
        }
    }
}
