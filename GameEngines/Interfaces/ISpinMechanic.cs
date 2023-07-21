using GameEngines.ValueObjects;

namespace GameEngines.Interfaces
{
    public interface ISpinMechanic
    {
        List<SpinRow> Spin();

        void AddSymbolToGameRow(int randomNumber, SpinRow row);
    }
}
