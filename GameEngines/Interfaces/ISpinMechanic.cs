using GameEngines.ValueObjects;

namespace GameEngines.Interfaces
{
    public interface ISpinMechanic
    {
        void Spin();

        void AddSymbolToGameRow(int randomNumber, SpinRow row);
    }
}
