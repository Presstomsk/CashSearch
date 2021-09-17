using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSearch
{
    
    
    public static class ActionLogic
    {
        public static bool Actions(Dictionary<string,Operations> _menu, string key)
        {
            if (!_menu.ContainsKey(key)) return FalseChoice();
            if (key == "0") return ExitProgram();         
            if (!Program._flags[key]) return FalseChoice();
            return TrueChoice(_menu,key,Program._cacheAddresses[key]);
        }
        public static bool ExitProgram() { return true; }
        public static bool FalseChoice()
        {
            Show.ErrorChoiсe();
            return false;
        }
        public static bool TrueChoice(Dictionary<string, Operations> _menu, string key, string address)
        {
            _menu[key](address);
            return true;
        }




    }
}
