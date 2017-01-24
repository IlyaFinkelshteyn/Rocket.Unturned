﻿using Rocket.API;
using Rocket.Unturned.Chat;
using SDG.Unturned;
using System.Collections.Generic;

namespace Rocket.Unturned.Commands
{
    public class CommandInvestigate : IRocketCommand
    {
        #region Properties

        public AllowedCaller AllowedCaller { get { return AllowedCaller.Both; } }

        public string Name { get { return "investigate"; } }

        public string Help { get { return "Shows you the SteamID64 of a player"; } }

        public string Syntax { get { return "<player>"; } }

        public List<string> Aliases { get { return new List<string>(); } }

        public List<string> Permissions { get { return new List<string>() { "rocket.investigate" }; } }

        #endregion Properties

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length != 1)
            {
                UnturnedChat.Say(caller, U.Translate("command_generic_invalid_parameter"));
                throw new WrongUsageOfCommandException(caller, this);
            }

            SteamPlayer otherPlayer = PlayerTool.getSteamPlayer(command[0]);
            if (otherPlayer == null && (caller != null || otherPlayer.playerID.steamID.ToString() == caller.ToString()))
            {
                UnturnedChat.Say(caller, U.Translate("command_generic_failed_find_player"));
                throw new WrongUsageOfCommandException(caller, this);
            }

            UnturnedChat.Say(caller, U.Translate("command_investigate_private", otherPlayer.playerID.characterName, otherPlayer.playerID.steamID.m_SteamID));
        }
    }
}