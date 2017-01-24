using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace Rocket.Unturned.Commands
{
    public class CommandVanish : IRocketCommand
    {
        #region Properties

        public AllowedCaller AllowedCaller { get { return AllowedCaller.Player; } }

        public string Name { get { return "vanish"; } }

        public string Help { get { return "Are we rushing in or are we goin' sneaky beaky like?"; } }

        public string Syntax { get { return ""; } }

        public List<string> Aliases { get { return new List<string>(); } }

        public List<string> Permissions { get { return new List<string>() { "rocket.vanish" }; } }

        #endregion Properties

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            Logger.Log(U.Translate("command_vanish_toggle_console", player.CharacterName));
            UnturnedChat.Say(player, U.Translate("command_vanish_toggle_private"));
            player.Features.VanishMode = !player.Features.VanishMode;
        }
    }
}