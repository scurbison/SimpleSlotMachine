using GameEngines.Interfaces;

namespace GameEngines.Slots
{
    public class SlotsGameEngine : ISlotsGameEngine
    {
        private const string AbandonGameKey = "q";
        public decimal Balance { get; private set; }
        public decimal CurrentStake { get; private set; }

        private readonly ISpinMechanic _spinMechanic;
        private readonly IPrizeGenerator _prizeGenerator;

        public SlotsGameEngine(ISpinMechanic spinMechanic, IPrizeGenerator prizeGenerator)
        {
            _spinMechanic = spinMechanic;
            _prizeGenerator = prizeGenerator;
        } 

        public void StartGame()
        {
            var deposit = RequestAmount();
            if (ValidateAndStoreDeposit(deposit))
            {
                while (Balance > 0)
                {
                    PlaceStake();
                    var game = _spinMechanic.Spin();
                    var prizeAmount = _prizeGenerator.GeneratePrize(game, CurrentStake);
                    AddAndDisplayPrize(prizeAmount);
                    DisplayCurrentBalance();
                    Console.WriteLine();
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

            Balance = Math.Round(validDeposit, 2);
            return true;
        }

        public void PlaceStake()
        {
            Console.WriteLine("How much would you like to stake?");
            var stake = Console.ReadLine();
            if (!ValidateAndStoreStake(stake))
            {
                Console.WriteLine("The Steak amount you have entered is not valid.");
                Console.WriteLine($"please enter a valid amount which is less than your current balance: £{Balance}");
                Console.WriteLine();
                PlaceStake();
            }
            Console.WriteLine();
        }

        public bool ValidateAndStoreStake(string? stake)
        {
            if (!decimal.TryParse(stake, out decimal validStake))
                return false;

            if (validStake > 0 && validStake > Balance)
                return false;

            CurrentStake = Math.Round(validStake, 2);
            Balance -= CurrentStake;
            return true;
        }

        private void AddAndDisplayPrize(decimal prizeAmount)
        {
            Console.WriteLine($"You have won: £{prizeAmount}");
            Balance += prizeAmount;
        }

        private void DisplayCurrentBalance() => Console.WriteLine($"Your current balance is £{Balance}");
    }
}
