using System;
using System.IO;

namespace CashSearch
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Чистка Кэш.Нажмите, чтобы удалить");
            if (CashSearch.ChromeCashSearch() == true)
            {
                Console.WriteLine("'G' кэш GoogleChrome");
            }
            if (CashSearch.OperaCashSearch() == true)
            {
                Console.WriteLine("'O' кэш Opera");
            }
            if (CashSearch.YandexCashSearch() == true)
            {
                Console.WriteLine("'Y' кэш YandexBrawser");
            }
            if (CashSearch.ChromeCashSearch() == true || CashSearch.OperaCashSearch() == true || CashSearch.ChromeCashSearch() == true)
            {
                Console.WriteLine("'A' кэш всех браузеров");
            }
            else
            {
                Console.WriteLine("Кэш не найден, нажмите 'E' для выхода");
                Console.ReadKey();

            }


            var key = Console.ReadLine();
            switch (key)
            {
                case "G":
                    string[] chrome = CashSearch.ChromeCashFiles();
                    CashSearch.ChromeCashDelete();
                    break;
                case "O":
                    string[] opera = CashSearch.OperaCashFiles();
                    CashSearch.OperaCashDelete();
                    break;
                case "Y":
                    string[] yandex = CashSearch.YandexCashFiles();
                    CashSearch.YandexCashDelete();
                    break;
                case "A":
                    string[] chrome_2 = CashSearch.ChromeCashFiles();
                    string[] opera_2 = CashSearch.OperaCashFiles();
                    string[] yandex_2 = CashSearch.YandexCashFiles();
                    CashSearch.AllDelete();
                    break;               


            }
        }
    }
}

