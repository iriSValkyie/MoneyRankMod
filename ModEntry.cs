using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace StardewValleyMoneyRankMod
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {

        private MoneyRank m_MoneyRank = new MoneyRank();
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            if (m_MoneyRank == null)
            {
                m_MoneyRank = new MoneyRank();
            }
            
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.GameLoop.DayStarted += this.OnDayStarted;
            helper.Events.Multiplayer.PeerConnected += this.OnConnectPlayer;
            helper.Events.Multiplayer.PeerDisconnected += this.OnDisConnectPlayer;

            
        }

        private void OnDisConnectPlayer(object? sender, PeerDisconnectedEventArgs e)
        {
            m_MoneyRank.RemovePlayer(e.Peer);
        }

        private void OnConnectPlayer(object? sender, PeerConnectedEventArgs e)
        {
            m_MoneyRank.AddPlayer(e.Peer);
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;


            if (e.Button == SButton.F2)
            {
                
            }
            
            // print button presses to the console window
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
        }

        private void OnDayStarted(object? sender,DayStartedEventArgs e)
        {
            
        }
    }
}