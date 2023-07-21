using GameEngines.ValueObjects;

namespace GameEngines.Interfaces
{
    public interface IPrizeGenerator
    {
        decimal GeneratePrize(List<SpinRow> game, decimal currentStake);

        bool IsWinningRow(SpinRow row);
    }
}