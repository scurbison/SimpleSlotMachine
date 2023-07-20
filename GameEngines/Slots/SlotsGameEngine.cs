using GameEngines.Interfaces;

namespace GameEngines.Slots
{
    public class SlotsGameEngine : ISlotsGameEngine
    {
        public void StartGame(decimal initialStake)
        {
            Console.WriteLine("GamesEngineStarted");
        }
    }
}
