namespace AutoFix.Utils
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Reflection;

    internal static class Updater
    {
        private static int IsUpdateAvaibible()
        {
            var wc = new WebClient();
            var LatestVersion = new Version(wc.DownloadString("https://raw.githubusercontent.com/NikolaiTheDev/AutoFix/master/PluginVersionInfo/LatestVersion"));
            Globals.Application.LatestVersion = LatestVersion;
            return LatestVersion.CompareTo(Globals.Application.CurrentVersion);
        }

        internal static void Check()
        {
            var res = IsUpdateAvaibible();
            switch (res)
            {
                case -1:
                    Rage.Game.DisplayNotification($"~b~Update Available!\n~r~Current Version: { Globals.Application.CurrentVersion }\n~g~Latest Version: { Globals.Application.LatestVersion }");
                    break;
                case 1:
                    Rage.Game.DisplayNotification("~r~Your current version is higher then reported on Github, this can be an error in my plug-in...");
                    break;
                default:
                    break;
            }
        }
    }
}
