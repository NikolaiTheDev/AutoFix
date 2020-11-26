namespace AutoFix
{
    using AutoFix.Utils;
    using Rage;
    using System.Windows.Forms;

    internal static class Settings
    {
        private static InitializationFile InitializeFile(string filepath)
        {
            var ini = new InitializationFile(filepath);
            ini.Create();
            return ini;
        }

        public static void Initialize()
        {
            // Reads and creates a new Settings.ini file if it doesn't exists
            var Settings = InitializeFile(Globals.Application.ConfigPath + "/Settings/Settings.ini");

            // Makes a new KeyConverter to convert the keys (I like it this way personally)
            var KeysConverter = new KeysConverter();

            // KEYS
            // Reads the keys from the Settings.ini
            var OpenMenuKey = Settings.ReadString("KEYS", "OpenMenuKey", "Y");
            var OpenMenuModifierKey = Settings.ReadString("Keys", "OpenMenuModifierKey", "LControlKey");

            // KEY CONVERTERS
            // Converts the read strings to a key
            Globals.Settings.OpenMenuKey = (Keys)KeysConverter.ConvertFromString(OpenMenuKey);
            Globals.Settings.OpenMenuModififierKey = (Keys)KeysConverter.ConvertFromString(OpenMenuModifierKey);

            // GENERAL
            // Reads the other values from the Settings.ini file
            Globals.Settings.DebugLogging = Settings.ReadBoolean("GENERAL", "DebugLogging", false);

            Logger.Log("Loaded all the settings successfully");
            Logger.Log($"OpenMenuKey: { Globals.Settings.OpenMenuKey }");
            Logger.Log($"OpenMenuModifierKey: { Globals.Settings.OpenMenuModififierKey }");
            Logger.Log($"DebugLogging: { Globals.Settings.DebugLogging }");
            Logger.Log("----------------------------------------");
        }
    }
}