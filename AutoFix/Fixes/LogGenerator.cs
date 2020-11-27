namespace AutoFix.Fixes
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;

    internal static class LogGenerator
    {
        internal static string B2HumanReadable(double len)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return String.Format("{0:0.##} {1}", len, sizes[order]);
        }

        internal static void CreateInstalledPluginsLog()
        {
            string message = "AutoFix - v" + Assembly.GetExecutingAssembly().GetName().Version + "\n\n";
            string fileName = Globals.Application.ConfigPath + "GameInfo/InstalledPlugins.log";

            DirectoryInfo di(string dir) => new DirectoryInfo(dir);
            FileInfo[] fi(DirectoryInfo dir) => dir.GetFiles();

            message += "MAIN FOLDER\n";
            foreach (FileInfo info in fi(di(new Uri(Directory.GetCurrentDirectory()).LocalPath)))
            {
                if (!info.Name.EndsWith(".dll")) continue;
                message += $"{info.Name}\nLast Updated: {info.LastWriteTimeUtc}\nLast Opened: {info.LastAccessTimeUtc}\nBytes: {B2HumanReadable(info.Length)}\n\n";
            }

            message += "\nPLUGINS FOLDER\n";

            foreach (FileInfo info in fi(di("Plugins/")))
            {
                if (!info.Name.EndsWith(".dll")) continue;
                message += $"{info.Name}\nLast Updated: {info.LastWriteTimeUtc}\nLast Opened: {info.LastAccessTimeUtc}\nBytes: {B2HumanReadable(info.Length)}\n\n";
            }

            try
            {
                // Check if file already exists. If yes, delete it.
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file
                    Byte[] title = new UTF8Encoding(true).GetBytes(message);
                    fs.Write(title, 0, title.Length);
                }
            }
            catch (Exception ex)
            {
                Rage.Game.Console.Print($"IGNORE THIS EXCEPTION UNLESS IT CRASHED...\n{ex}");
            }
        }
    }
}
