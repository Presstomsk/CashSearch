using System;
using System.IO;

namespace CashSearch
{
    public static class CashSearch
    {
        public static string[] adr = new string[3]
        {
        @"C:\Users\Admin\AppData\Local\Google\Chrome\User Data\Default\Cache",        
        @"C:\Users\Admin\AppData\Local\Opera Software\Opera Stable\Cache",
        @"C:\Users\Admin\AppData\Local\Yandex\YandexBrowser\User Data\Default\Cache"
        };
              

        public static bool CashSearching(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }
        public static string[] CashFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            return files;
        }
        public static void CashDelete(string path)
        {
            Directory.Delete(path, true);
        }    
    }
}
