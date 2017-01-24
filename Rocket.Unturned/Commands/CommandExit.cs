using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;

namespace Rocket.Unturned.Commands
{
    public class CommandExit : IRocketCommand
    {
        #region Properties

        public AllowedCaller AllowedCaller { get { return AllowedCaller.Player; } }

        public string Name { get { return "exit"; } }

        public string Help { get { return "Exit the game without cooldown"; } }

        public string Syntax { get { return ""; } }

        public List<string> Aliases { get { return new List<string>(); } }

        public List<string> Permissions { get { return new List<string>() { "rocket.exit" }; } }

        #endregion Properties

        public void Execute(IRocketPlayer caller, string[] command)
        {
            Provider.kick((caller as UnturnedPlayer).CSteamID, "you exited");
        }
    }
}