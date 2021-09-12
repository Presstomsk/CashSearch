using System;


namespace CashSearch
{
    class Program
    {
        static void Main()
        {
            //Проверка наличия Кэш браузеров

            int googleCFlag = CashSearch.CashSearching(CashSearch.adr[0]);
            int operaCFlag = CashSearch.CashSearching(CashSearch.adr[1]);
            int yandexCFlag = CashSearch.CashSearching(CashSearch.adr[2]);

            //Реализация меню

            Message message;
            message = Show.StartString;
            if (googleCFlag==1) message += Show.GoogleChromeInfo;
            if (operaCFlag==1) message += Show.OperaInfo;
            if (yandexCFlag==1) message += Show.YandexInfo;
            if ((googleCFlag+operaCFlag+yandexCFlag)>1) message += Show.AllInfo;
            message();
            if (message == Show.StartString)
            {
                message = Show.NonResult;
                message();
                
            }

            //Вывод на экран удаленных файлов, запись лога в БД, удаление файлов

            DataBase db = new DataBase();       
            
            bool flag = true;
            if ((googleCFlag + operaCFlag + yandexCFlag) != 0)
            {
                do
                {
                    var key = Console.ReadLine();
                    if ((key == "1") && (googleCFlag == 1))
                    {
                        LoggingAndClearing(CashSearch.adr[0], db);
                        break;
                    }
                    else if ((key == "2") && (operaCFlag == 1))
                    {
                        LoggingAndClearing(CashSearch.adr[1], db);
                        break;

                    }
                    else if ((key == "3") && (yandexCFlag == 1))
                    {
                        LoggingAndClearing(CashSearch.adr[2], db);
                        break;

                    }
                    else if ((key == "4") && ((googleCFlag + operaCFlag + yandexCFlag) > 1))
                    {
                        if (googleCFlag == 1) LoggingAndClearing(CashSearch.adr[0], db);
                        if (operaCFlag == 1) LoggingAndClearing(CashSearch.adr[1], db);
                        if (yandexCFlag == 1) LoggingAndClearing(CashSearch.adr[3], db);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели неправильный пункт меню. Введите повторно");
                        flag = false;
                    }
                } while (!flag);
            }
           
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

