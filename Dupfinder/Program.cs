using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dupfinder
{
    class Program
    {
        static void Main(string[] args)
        {

            MySqlConnection conn;
            string server = "10.106.169.40";
            string database = "HashDB";
            string uid = "outside";
            string password = "b36eWa";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            conn = new MySqlConnection(connectionString);

            // Open the connection.
            conn.Open();

            // Execute some SQL code:

            MySqlCommand cmd = new MySqlCommand("INSERT INTO all_files (Path, Size, hash_MD5, hash_SHA256) VALUES('C:\\\\fedpik\\\\pik.exe', 20, 'MD5HASHSAMPLE', 'SHA256HASHSAMPLE'); ", conn);

            cmd.ExecuteScalar();


        }





    }
}
