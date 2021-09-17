using System;
using System.Collections.Generic;


namespace CashSearch
{
    
    class Program
    {
        
        private static Dictionary<string, Operations> _menu;
        public static Dictionary<string, string> _cacheAddresses;
        public static Dictionary<string, bool> _flags;

        static void Main()
        {
            DataBase db = new DataBase();
            _cacheAddresses =new Dictionary<string, string>
            {
                {"1", CashSearch.adr[0]},
                {"2", CashSearch.adr[1]},
                {"3", CashSearch.adr[2]}
            };

            _flags = new Dictionary<string, bool>
               {
                {"1", CashSearch.CashSearching(_cacheAddresses["1"])},
                {"2", CashSearch.CashSearching(_cacheAddresses["2"])},
                {"3", CashSearch.CashSearching(_cacheAddresses["3"])}                
               };
            _menu = new Dictionary<string, Operations>
               {
                {"1", LoggingAndClearing},
                {"2", LoggingAndClearing},
                {"3", LoggingAndClearing},                
               };        

            Message message;
            message = Show.StartString;
            if (_flags["1"]) message += Show.GoogleChromeInfo;
            if (_flags["2"]) message += Show.OperaInfo;
            if (_flags["3"]) message += Show.YandexInfo;
            if ((Convert.ToInt32(_flags["1"]) + Convert.ToInt32(_flags["2"]) + Convert.ToInt32(_flags["3"])) >1) message += Show.AllInfo;
            if (message != Show.StartString) message += Show.EndInfo;
            else message = Show.NonResult;      
            message();

            
            //Вывод на экран удаленных файлов, запись лога в БД, удаление файлов
            if (_flags["1"] || _flags["2"] || _flags["3"])
            {
                
                bool flag=true;
                do
                {
                    var key = Console.ReadLine();
                    
                    if (_menu.ContainsKey(key)) flag = ActionLogic.Actions(_menu, key, _cacheAddresses[key],_flags[key],db);
                    else  flag=ActionLogic.FalseChoice();
                    /* else
                     {
                         if ((Convert.ToInt32(googleCFlag) + Convert.ToInt32(operaCFlag) + Convert.ToInt32(yandexCFlag)) <= 1)
                         {
                             ActionLogic.FalseChoice();
                         }
                         else
                         {
                             if (googleCFlag) flag = Actions("1", db);
                             if (operaCFlag) flag = Actions("2", db);
                             if (yandexCFlag) flag = Actions("3", db);
                         }
                     }*/

                } while (!flag);
                
                
            }        
        
        }                    
        public static void LoggingAndClearing(string address, DataBase db)
        {
            Console.WriteLine(address);
            string[] files = CashSearch.CashFiles(address);
            CashSearch.ShowFiles(files);
            db.ExportToDB(files);
            CashSearch.CashDelete(address);           
        }
    }
}

