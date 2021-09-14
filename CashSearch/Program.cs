using System;
using System.Collections.Generic;


namespace CashSearch
{
    class Program
    {
        private delegate void Operations(string address, DataBase db);
        private static Dictionary<string, Operations> _actions;
        static void Main()
        {           
                       
            //Проверка наличия Кэш браузеров

           bool googleCFlag = CashSearch.CashSearching(CashSearch.adr[0]);
           bool operaCFlag = CashSearch.CashSearching(CashSearch.adr[1]);
           bool yandexCFlag = CashSearch.CashSearching(CashSearch.adr[2]);

            //Реализация меню

            Message message;
            message = Show.StartString;
            if (googleCFlag) message += Show.GoogleChromeInfo;
            if (operaCFlag) message += Show.OperaInfo;
            if (yandexCFlag) message += Show.YandexInfo;
            if ((Convert.ToInt32(googleCFlag)+ Convert.ToInt32(operaCFlag) + Convert.ToInt32(yandexCFlag)) >1) message += Show.AllInfo;
            if (message != Show.StartString) message += Show.EndInfo;
            else message = Show.NonResult;      
            message();

            //Вывод на экран удаленных файлов, запись лога в БД, удаление файлов
            if (googleCFlag || operaCFlag || yandexCFlag)
            {
                _actions = new Dictionary<string, Operations>
               {                    
                {"1", LoggingAndClearing},
                {"2", LoggingAndClearing},
                {"3", LoggingAndClearing},
                {"4",null}
               };

                DataBase db = new DataBase();
                bool flag=true;
                do
                {
                    var key = Console.ReadLine();
                    if (key != "4") flag = Actions(key, db);
                    else
                    {
                        if ((Convert.ToInt32(googleCFlag) + Convert.ToInt32(operaCFlag) + Convert.ToInt32(yandexCFlag)) <= 1)
                        {
                            Console.WriteLine("Вы ввели неправильный пункт меню. Введите повторно");
                            flag = false;
                        }
                        else
                        {
                            if (googleCFlag) flag = Actions("1", db);
                            if (operaCFlag) flag = Actions("2", db);
                            if (yandexCFlag) flag = Actions("3", db);
                        }
                    }

                } while (!flag);
                
                
            }        
        
        }
        public static bool Actions(string key, DataBase db)
        {
            
            if (!_actions.ContainsKey(key))
            {
                if (key=="0") return true;                               
                Console.WriteLine("Вы ввели неправильный пункт меню. Введите повторно");
                return false;
            }           
            LoggingAndClearing(CashSearch.adr[Convert.ToInt32(key) - 1], db);
            return true;            
        }

        public static void LoggingAndClearing(string adr, DataBase db)
        {
            string[] files = CashSearch.CashFiles(adr);
            CashSearch.ShowFiles(files);
            db.ExportToDB(files);
            CashSearch.CashDelete(adr);            
        }
    }
}

