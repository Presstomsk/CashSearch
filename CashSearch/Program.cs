using System;

namespace CashSearch
{
    class Program
    {
        static void Main()
        {
            var is_chrome = CashSearch.IsChrome();
            var is_opera = CashSearch.IsOpera();
            var is_yandex = CashSearch.IsYandex();

            Console.WriteLine("Нажмите, чтобы удалить");
            if (is_chrome == true)
            {
                Console.WriteLine("'G' кэш GoogleChrome");
            }
            if (is_opera == true)
            {
                Console.WriteLine("'O' кэш Opera");
            }
            if (is_yandex == true)
            {
                Console.WriteLine("'Y' кэш YandexBrawser");
            }
            if (is_opera == true|| is_chrome == true || is_yandex == true)
            {
                Console.WriteLine("'A' кэш всех браузеров");
            }
            else
            {
                Console.WriteLine("Кэш не найден, нажмите 'E' для выхода");
                
            }
            

            var key = Console.ReadLine();
            switch (key)
            {
                case "G":
                    CashSearch.DeleteChrome();
                    break;
                case "O":
                    CashSearch.DeleteOpera();
                    break;
                case "Y":
                    CashSearch.DeleteYandex();
                    break;
                case "A":
                    CashSearch.DeleteAll();
                    break;
                case "E":
                    break;


            }
        }
    }
}
