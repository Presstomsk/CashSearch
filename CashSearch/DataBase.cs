using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CashSearch
{
    class DataBase
    {
       static void Main()
        {
            const string CONN_STR = "Server=mysql60.hostland.ru;Database=host1323541_sbd10;Uid=host1323541_itstep;Pwd=269f43dc;";
            var data_base = new MySqlConnection(CONN_STR);
            data_base.Open();
​
            ShowInfo("Выберите продукт, остатки которого хотите посмотреть");
            ShowInfo("1. Phone");
            ShowInfo("2. Car");
            var select = Console.ReadLine();
                        
            var sql = $"SELECT count FROM tab_products_stock JOIN tab_products ON tab_products_stock.product_id = tab_products.id WHERE product_id = {select}";
          
           var sql=$"INSERT INTO host1323541_sbd04.table_students (first_name, last_name, faculty, is_study)
            VALUES ('Igor', 'Ivanov', 'SoftDev', 1);"
           
            var command = new MySqlCommand
            {
                CommandText = sql,
                Connection = data_base
            };
           data_base.Close(); 
    }
        
}

