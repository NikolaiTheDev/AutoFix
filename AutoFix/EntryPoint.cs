[assembly: Rage.Attributes.Plugin("AutoFix", Author = "Nikolai", Name = "AutoFix", PrefersSingleInstance = true, ShouldTickInPauseMenu = false)]

namespace AutoFix
{
    using AutoFix.Utils;
    using AutoFix.Fixes;

    public static class EntryPoint
    {
        public static void Main()
        {
            Rage.Game.DisplayNotification("Loading AutoFix");
            Logger.Log($"-------------------- { Globals.Application.Name } Startup Log --------------------");

            Globals.Initialize();
            Settings.Initialize();
            Dependecies.Check();
            Updater.Check();

            LogGenerator.CreateInstalledPluginsLog();

            Rage.Game.DisplayNotification("AutoFix loaded successfully");
        }

        public static void OnUnload()
        {
            Rage.Game.DisplayNotification("Unloading AutoFix");
        }
    }
}