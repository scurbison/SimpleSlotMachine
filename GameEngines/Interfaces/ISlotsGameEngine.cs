namespace GameEngines.Interfaces
{
    public interface ISlotsGameEngine
    {
        decimal Balance { get; }
        decimal CurrentStake { get; }

        void StartGame();

        bool ValidateAndStoreDeposit(string? depositAmount);

        bool ValidateAndStoreStake(string? stake);
    }
}
