namespace AutoFix
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    internal static class Globals
    {
        internal static class Application
        {
            internal static Version CurrentVersion { get; set; }
            internal static string LatestVersion { get; set; }
            internal static string Name { get; set; }
            internal static string Author { get; set; }
            internal static string ConfigPath { get; set; }
        }

        internal static class Settings
        {
            internal static bool DebugLogging { get; set; }
            internal static Keys OpenMenuKey { get; set; }
            internal static Keys OpenMenuModififierKey { get; set; }
        }

        internal static class Requirements
        {
            internal static Version RAGENativeUI { get; set; }
            internal static Version RagePluginHook { get; set; }
            internal static Version GTA { get; set; }
        }

        internal static void Initialize()
        {
            Application.CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            Application.Name = "AutoFix";
            Application.Author = "Nikolai";
            Application.ConfigPath = "/plugins/AutoFix";

            Requirements.RAGENativeUI = new Version(1, 7, 0, 0);
            Requirements.RagePluginHook = new Version(1, 81, 1410, 16064);
            Requirements.GTA = new Version(1, 0, 2060, 1);
        }
    }
}