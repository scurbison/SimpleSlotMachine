using GameEngines.Interfaces;

namespace GameEngines.Slots
{
    public class SlotsGameEngine : ISlotsGameEngine
    {
        private const string AbandonGameKey = "q";
        public decimal Deposit { get; private set; }
        public decimal CurrentStake { get; private set; }

        private readonly ISpinMechanic _spinMechanic;

        public SlotsGameEngine(ISpinMechanic spinMechanic) => _spinMechanic = spinMechanic;

        public void StartGame()
        {
            var deposit = RequestAmount();
            if (ValidateAndStoreDeposit(deposit))
            {
                while (Deposit > 0)
                {
                    PlaceStake();
                    _spinMechanic.Spin();
                }
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

        public bool ValidateAndStoreDeposit(string depositEntered)
        {
            if (!decimal.TryParse(depositEntered, out decimal validDeposit)) 
                return false;

            Deposit = Math.Round(validDeposit, 2);
            return true;
        }

        public void PlaceStake()
        {
            Console.WriteLine("How much would you like to stake?");
            var stake = Console.ReadLine();
            if (!ValidateAndStoreStake(stake))
            {
                Console.WriteLine("The Steak amount you have entered is not valid.");
                Console.WriteLine($"please enter a valid amount which is less than your current balance: {Deposit}");
                PlaceStake();
            }
            Console.WriteLine();
        }

        public bool ValidateAndStoreStake(string? stake)
        {
            if (!decimal.TryParse(stake, out decimal validStake))
                return false;

            if (validStake > Deposit)
                return false;

            CurrentStake = Math.Round(validStake, 2);
            Deposit -= CurrentStake;
            return true;
        }
    }
}
