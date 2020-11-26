namespace AutoFix.Utils
{
    internal static class Logger
    {
        internal static void Log(string line)
        {
            Rage.Game.Console.Print($"[{ Globals.Application.Name }] { line }");
        }

        internal static void DebugLog(string line)
        {
            if (!Globals.Settings.DebugLogging) return;
            Rage.Game.Console.Print($"[DEBUG] [{ Globals.Application.Name }] { line }");
        }
    }
}