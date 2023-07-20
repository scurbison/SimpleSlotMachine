using GameEngines.Interfaces;

namespace GameEngines.Slots
{
    public class SlotsGameEngine : ISlotsGameEngine
    {
        private const string AbandonGameKey = "q";
        private decimal _deposit;

        public void StartGame()
        {
            var deposit = RequestAmount();
            if (IsValidDeposit(deposit))
            {
                PlaceStake(0);
                return;
            }

            StartGame();
        }

        private string? RequestAmount()
        {
            Console.WriteLine("Welcome, Please specify how much you would like to deposit, or press Q to abandon the game?");
            var response = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(response))
                return RequestAmount();

            if (response.ToLower() == AbandonGameKey)
                CloseApplication();

            return response;
        }

        private void CloseApplication()
        {
            Console.WriteLine("Thank you for playing, we hope to see you soon. Press any key to close");
            Console.ReadLine();
            Environment.Exit(0);
        }

        public bool IsValidDeposit(string depositEntered)
        {
            if (!decimal.TryParse(depositEntered, out decimal validDeposit)) 
                return false;

            _deposit = validDeposit;
            return true;
        }

        public void PlaceStake(decimal initialStake)
        {
            throw new NotImplementedException();
        }
    }
}
