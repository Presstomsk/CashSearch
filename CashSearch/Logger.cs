
using MySql.Data.MySqlClient;


namespace CashSearch
{
    public class DataBase
    {
        private MySqlConnection db;
        private MySqlCommand command;

        public DataBase()
        {
            var conection_str = "Server=mysql60.hostland.ru;Database=host1323541_sbd06;Uid=host1323541_itstep;Pwd=269f43dc;";
            db = new MySqlConnection(conection_str);
            command = new MySqlCommand { Connection = db };
        }


        public void Open() => db.Open();
        public void Close() => db.Close();


        public void ExportToDB(string[] files)
        {
            Open();
            foreach (var file in files)
            {

                var sql = @$"INSERT INTO tab_log (file_name) VALUES ('{file}');";
                command.CommandText = sql;
                command.ExecuteNonQuery();

            }
            Close();
        }

    }
}

