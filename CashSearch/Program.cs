using System;
using System.Collections.Generic;
using System.IO;


namespace CashSearch
{
    public delegate void Operations(string address);
    class Program
    {
        
        private static Dictionary<string, Operations> _menu;
        public static Dictionary<string, string> _cacheAddresses;
        public static Dictionary<string, bool> _flags;

        static void Main()
        {                      

            bool flagAll = false;
            bool flag = false;
            _cacheAddresses =new Dictionary<string, string> //Словарь адресов папок кэша
            {
                {"0",null},
                {"1", CashSearch.adr[0]},
                {"2", CashSearch.adr[1]},
                {"3", CashSearch.adr[2]},
                {"4", null}
            };

            _flags = new Dictionary<string, bool> // Проверка наличия папок кэш на диске 
               {
                {"0", false },
                {"1", CashSearch.CashSearching(_cacheAddresses["1"])},
                {"2", CashSearch.CashSearching(_cacheAddresses["2"])},
                {"3", CashSearch.CashSearching(_cacheAddresses["3"])},
                {"4", flagAll}
               };
            _menu = new Dictionary<string, Operations> //Словарь Меню
               {
                {"0", LoggingAndClearing},
                {"1", LoggingAndClearing},
                {"2", LoggingAndClearing},
                {"3", LoggingAndClearing},
                {"4", AllLoggingAndClearing}
               };
                        
            // Меню

            Message message;
            message = Show.StartString;
            if (_flags["1"]) message += Show.GoogleChromeInfo;
            if (_flags["2"]) message += Show.OperaInfo;
            if (_flags["3"]) message += Show.YandexInfo;
            if ((Convert.ToInt32(_flags["1"]) + Convert.ToInt32(_flags["2"]) + Convert.ToInt32(_flags["3"])) > 1)
            {
                message += Show.AllInfo;
                _flags["4"] = true;

            }
            if (message != Show.StartString)
            {
                message += Show.EndInfo;
                message();
            }
            else
            {
                message = Show.NonResult;
                message();
                Console.ReadKey();
                flag = true;
            }


            //Вывод на экран удаленных файлов, запись лога в БД, удаление файлов


            while (!flag) 
               {
                    var key = Console.ReadLine();                    
                    flag = ActionLogic.Actions(_menu, key);               
               } 

                
                
                    
        
        }                    
        public static void LoggingAndClearing(string address) 
        {
            DataBase db = new DataBase();
            string[] files = CashSearch.CashFiles(address);            
            CashSearch.ShowFiles(files);
            db.ExportToDB(files);
            try { CashSearch.CashDelete(address); }
            catch (UnauthorizedAccessException) { Console.WriteLine("Ошибка очистки кэша! Пожалуйста, закройте браузер!"); }
        }
        public static void AllLoggingAndClearing(string address)
        {
            if (_flags["1"]) ActionLogic.Actions(_menu, "1");
            if (_flags["2"]) ActionLogic.Actions(_menu, "2");
            if (_flags["3"]) ActionLogic.Actions(_menu, "3");

        }
    }
}

