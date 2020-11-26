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
            string response = null;

            try
            {
                Logger.Log("Fetching latest plug-in version from GitHub");
                response = wc.DownloadStringTaskAsync(new Uri("https://raw.githubusercontent.com/NikolaiTheDev/AutoFix/master/PluginVersionInfo/LatestVersion")).Result;
            }
            catch (Exception)
            {
                Logger.Log($"Checking version of plug-in {Globals.Application.Name} Failed");
            }

            //If we get a null response then the download failed and we just return -2 and inform user of failing the download
            if (string.IsNullOrWhiteSpace(response))
            {
                return -2;
            }

            Globals.Application.LatestVersion = response.Trim();

            var current = Globals.Application.CurrentVersion;
            var latest = new Version(Globals.Application.LatestVersion);

            //This is where we're checking the results
            //If the plug-in is newer than what's being reported then we'll return 1 (This will just log the issue, no notification)
            //If the plug-in is older than what's being reported then we'll return -1(This Logs as well as displays a notification)
            //If the plug-in is the same version as what's being reported than we'll return 0 (This logs & displays notification that it loaded successfully)
            if (current.CompareTo(latest) > 0)
            {
                return 1;
            }
            else if (current.CompareTo(latest) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
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
