using System.IO;
using System;

namespace CashSearch
{

    public static class CashSearch
    {
        private static string _system = Environment.GetFolderPath(Environment.SpecialFolder.System);
        private static string _path = Path.GetPathRoot(_system);

        public static string[] adr = new string[3]
        {
        @$"{_path}Users\Admin\AppData\Local\Google\Chrome\User Data\Default\Cache",
        @$"{_path}Users\Admin\AppData\Local\Opera Software\Opera Stable\Cache",
        @$"{_path}Users\Admin\AppData\Local\Yandex\YandexBrowser\User Data\Default\Cache"
        };


        public static bool CashSearching(string path)
        {
            if (Directory.Exists(path)) return true;
            return false;
        }
        public static string[] CashFiles(string path)
        { return Directory.GetFiles(path); }

        public static void CashDelete(string path) => Directory.Delete(path, true);

        public static void ShowFiles(string[] files)
        {
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }

    }
}

