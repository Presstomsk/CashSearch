using System;
using System.IO;

namespace CashSearch
{
    public static class CashSearch
    {        
        private static string _yandex = @"C:\Users\Admin\AppData\Local\Yandex\YandexBrowser\User Data\Default\Cache";
        private static string _googleChrome = @"C:\Users\Admin\AppData\Local\Google\Chrome\User Data\Default\Cache";
        private static string _opera = @"C:\Users\Admin\AppData\Local\Opera Software\Opera Stable\Cache";

        public static bool CashSearching(string path)
        {
            return (Directory.Exists(path)) ;                           
        }

        public static bool YandexCashSearch()
        {
            if (CashSearching(_yandex))
            {
                return true;
            }
            return false;
        }
        public static bool ChromeCashSearch()
        {
            if (CashSearching(_googleChrome))
            {
                return true;
            }
            return false;
        }
        public static bool OperaCashSearch()
        {
            if (CashSearching(_opera))
            {                
                return true;
            }
            return false;
        }

        public static string[] YandexCashFiles()
        {
            string[] files = Directory.GetFiles(_yandex);
            return files;
        }
        public static string[] ChromeCashFiles()
        {
            string[] files = Directory.GetFiles(_googleChrome);
            return files;
        }

        public static string[] OperaCashFiles()
        {
            string[] files = Directory.GetFiles(_opera);
            return files;
        }

   


        public static void CashDelete(string path)
        {
            Directory.Delete(path, true);
        }
        public static void YandexCashDelete()
        {
            CashDelete(_yandex);
        }
        public static void ChromeCashDelete()
        {
           CashDelete(_googleChrome);
        }
        public static void OperaCashDelete()
        {
            CashDelete(_opera);
        }

        public static void AllDelete()
        {
            YandexCashDelete();
            ChromeCashDelete();
            OperaCashDelete();
        }




    }
}
