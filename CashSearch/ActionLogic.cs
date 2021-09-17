using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSearch
{
    public delegate void Operations(string address, DataBase db);
    
    public static class ActionLogic
    {
        public static bool Actions(Dictionary<string,Operations> _menu, string key, string address, bool flag, DataBase db)
        {
            if (key == "0") return ExitProgram();            
            if (!flag) return FalseChoice();
            return TrueChoice(_menu,key,address,db);
        }
        public static bool ExitProgram() { return true; }
        public static bool FalseChoice()
        {
            Show.ErrorChoiсe();
            return false;
        }
        public static bool TrueChoice(Dictionary<string, Operations> _menu, string key, string address, DataBase db)
        {
            _menu[key](address, db);
            return true;
        }




    }
}
