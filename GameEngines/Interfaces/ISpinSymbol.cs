namespace GameEngines.Interfaces
{
    public interface ISpinSymbol
    {
        string Name { get; init; }
        string Symbol { get; init;}
        decimal Coefficient { get; init; }
    }
}
