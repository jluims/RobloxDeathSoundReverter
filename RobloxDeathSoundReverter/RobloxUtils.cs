using IWshRuntimeLibrary;
using System.Security.Cryptography;

namespace RobloxDeathSoundReverter
{
    internal class RobloxUtils
    {

        private static string GetHash(string file)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(file))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
        }

        public static string? GetRobloxDirectory()
        {
            string roamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string shortcutPath = Path.Join(roamingPath, @"Microsoft\Windows\Start Menu\Programs\Roblox\Roblox Player.lnk");

            if (!System.IO.File.Exists(shortcutPath))
            {
                return null;
            }

            // Find the shortcut target
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            string shortcutTarget = shortcut.TargetPath;

            DirectoryInfo? robloxDirInfo = Directory.GetParent(shortcutTarget);

            if (robloxDirInfo == null)
            {
                return null;
            }

            return robloxDirInfo.FullName;
        }

        public static bool HasNewOof(string robloxDir)
        {
            return GetHash(Path.Join(robloxDir, @"content\sounds\ouch.ogg")) == "c089723e98c07accd3036f11e70afa3b";
        }

    }
}
