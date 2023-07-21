using GameEngines.ValueObjects;

namespace GameEngines.Interfaces
{
    public interface IPrizeGenerator
    {
        decimal GeneratePrize(List<SpinRow> game);

        bool IsWinningRow(SpinRow row);
    }
}