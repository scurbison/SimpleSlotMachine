using GameEngines.Interfaces;

namespace SimpleSlotMachine
{
    internal class Game
    {
        private readonly ISlotsGameEngine _slotsGameEngine;

        public Game(ISlotsGameEngine slotsGameSlotsGameEngine) => _slotsGameEngine = slotsGameSlotsGameEngine;

        internal void Begin()
        {
            DisplaySlotsWelcomeMessage();
            _slotsGameEngine.StartGame();
        }

        private void DisplaySlotsWelcomeMessage()
        {
            Console.WriteLine(@"
             $$$$$$\ $$\          $$\                    $$\      $$\                  $$\      $$\                   
            $$  __$$\$$ |         $$ |                   $$$\    $$$ |                 $$ |     \__|                  
            $$ /  \__$$ |$$$$$$\$$$$$$\   $$$$$$$\       $$$$\  $$$$ |$$$$$$\  $$$$$$$\$$$$$$$\ $$\$$$$$$$\  $$$$$$\  
            \$$$$$$\ $$ $$  __$$\_$$  _| $$  _____|      $$\$$\$$ $$ |\____$$\$$  _____$$  __$$\$$ $$  __$$\$$  __$$\ 
             \____$$\$$ $$ /  $$ |$$ |   \$$$$$$\        $$ \$$$  $$ |$$$$$$$ $$ /     $$ |  $$ $$ $$ |  $$ $$$$$$$$ |
            $$\   $$ $$ $$ |  $$ |$$ |$$\ \____$$\       $$ |\$  /$$ $$  __$$ $$ |     $$ |  $$ $$ $$ |  $$ $$   ____|
            \$$$$$$  $$ \$$$$$$  |\$$$$  $$$$$$$  |      $$ | \_/ $$ \$$$$$$$ \$$$$$$$\$$ |  $$ $$ $$ |  $$ \$$$$$$$\ 
             \______/\__|\______/  \____/\_______/       \__|     \__|\_______|\_______\__|  \__\__\__|  \__|\_______|
            ");
        }
    }
}