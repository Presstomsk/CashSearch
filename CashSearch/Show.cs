using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSearch
{
    delegate void Message();
    
    public static class Show
    {

        public static void NonResult() => Console.WriteLine("Кэш не найден!");
        public static void StartString() => Console.WriteLine("ОЧИСТКА CACHE.НАЖМИТЕ СЛЕДУЮЩИЕ КЛАВИШИ:");
        public static void GoogleChromeInfo() => Console.WriteLine("1 - очистка кэш браузера GoogleChrome");
        public static void OperaInfo() => Console.WriteLine("2 - очистка кэш браузера Opera");
        public static void YandexInfo() => Console.WriteLine("3 - очистка кэш браузера Yandex");
        public static void AllInfo() => Console.WriteLine("4 - полная очистка");
        public static void EndInfo() => Console.WriteLine("0 - выход из программы");
        public static void ErrorChoiсe()=> Console.WriteLine("Вы ввели неправильный пункт меню. Введите повторно");
    }
}
