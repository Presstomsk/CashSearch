﻿using System;
using System.IO;

namespace CashSearch
{
    class Program
    {
        static void Main()
        {            
            CashSearch.YandexCashSearch();
            CashSearch.ChromeCashSearch();
            CashSearch.OperaCashSearch();
        }
    }
}
