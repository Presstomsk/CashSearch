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

        public static void YandexCashSearch()
        {
            if (CashSearching(_yandex)) Console.WriteLine("Обнаружен Кэш Yandex");
        }
        public static void ChromeCashSearch()
        {
            if (CashSearching(_googleChrome)) Console.WriteLine("Обнаружен Кэш Google Chrome");
        }
        public static void OperaCashSearch()
        {
            if (CashSearching(_opera)) Console.WriteLine("Обнаружен Кэш Opera");
        }

        var files = Directory.GetFiles(_yandex);

    }
}
