using System;
using System.Diagnostics;
using System.IO;

namespace AutoFix.Utils
{
    internal static class Dependecies
    {
        internal static void Check()
        {
            // RAGENativeUI
            if (File.Exists("RAGENativeUI.dll"))
            {
                var InstalledRNUI = new Version(FileVersionInfo.GetVersionInfo("RAGENativeUI.dll").ProductVersion);
                if (Globals.Requirements.RAGENativeUI.CompareTo(InstalledRNUI) != 0)
                {
                    Rage.Game.DisplayNotification($"RAGENativeUI.dll V{ InstalledRNUI } is not compatible with this plug-in");
                    Rage.Game.UnloadActivePlugin();
                }
            }
            else
            {
                Rage.Game.DisplayNotification("Missing RAGENativeUI.dll");
                Rage.Game.UnloadActivePlugin();
            }

            // RagePluginHook
            if (File.Exists("RagePluginHook.exe"))
            {
                var InstalledRPH = new Version(FileVersionInfo.GetVersionInfo("RagePluginHook.exe").ProductVersion);
                if (Globals.Requirements.RagePluginHook.CompareTo(InstalledRPH) != 0)
                {
                    Rage.Game.DisplayNotification($"RagePluginHook.exe V{ InstalledRPH } is not compatible with this plug-in");
                    Rage.Game.UnloadActivePlugin();
                }
            }
            else
            {
                // imagine this happening LOL just a failsafe if someone uses IOBit and then deletes it
                Rage.Game.DisplayNotification("Missing RagePluginHook.exe");
                Rage.Game.UnloadActivePlugin();
            }

            // Grand Theft Auto V
            if (File.Exists("GTA5.exe"))
            {
                var InstalledGTA = new Version(FileVersionInfo.GetVersionInfo("GTA5.exe").ProductVersion);
                if (Globals.Requirements.GTA.CompareTo(InstalledGTA) != 0)
                {
                    Rage.Game.DisplayNotification($"GTA5.exe V{ InstalledGTA } is not compatible with this plug-in");
                    Rage.Game.UnloadActivePlugin();
                }
            }
            else
            {
                // imagine this happening LOL just a failsafe if someone uses IOBit and then deletes it
                Rage.Game.DisplayNotification("Missing GTA5.exe");
                Rage.Game.UnloadActivePlugin();
            }
        }
    }
}