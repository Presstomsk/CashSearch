using System;
using System.IO;

namespace CashSearch
{
    class Program
    {
        static void Main()
        {
            string[] chromeCashFiles;
            string[] operaCashFiles;
            string[] yandexCashFiles;


            Console.WriteLine("Чистка Кэш.Нажмите, чтобы удалить");
            if (CashSearch.CashSearching(CashSearch.adr[0]) == true)
            {
                Console.WriteLine("'G' кэш GoogleChrome");
            }
            if (CashSearch.CashSearching(CashSearch.adr[1]) == true)
            {
                Console.WriteLine("'O' кэш Opera");
            }
            if (CashSearch.CashSearching(CashSearch.adr[2]) == true)
            {
                Console.WriteLine("'Y' кэш YandexBrawser");
            }
            if (CashSearch.CashSearching(CashSearch.adr[0]) == true || CashSearch.CashSearching(CashSearch.adr[1]) == true || CashSearch.CashSearching(CashSearch.adr[2]) == true)
            {
                Console.WriteLine("'A' кэш всех браузеров");
            }
            else
            {
                Console.WriteLine("Кэш не найден!");
                Console.ReadKey();

            }


            var key = Console.ReadLine();
            switch (key)
            {
                case "G":
                    chromeCashFiles = CashSearch.CashFiles(CashSearch.adr[0]);
                    CashSearch.CashDelete(CashSearch.adr[0]);
                    break;
                case "O":
                    operaCashFiles = CashSearch.CashFiles(CashSearch.adr[1]);
                    CashSearch.CashDelete(CashSearch.adr[1]);
                    break;
                case "Y":
                    yandexCashFiles = CashSearch.CashFiles(CashSearch.adr[2]);
                    CashSearch.CashDelete(CashSearch.adr[2]);
                    break;
                case "A":
                    chromeCashFiles = CashSearch.CashFiles(CashSearch.adr[0]);
                    operaCashFiles = CashSearch.CashFiles(CashSearch.adr[1]);
                    yandexCashFiles = CashSearch.CashFiles(CashSearch.adr[2]);
                    CashSearch.CashDelete(CashSearch.adr[0]);
                    CashSearch.CashDelete(CashSearch.adr[1]);
                    CashSearch.CashDelete(CashSearch.adr[2]);
                    break;               


            }
        }
    }
}

