using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DBAccess;
using WindowsFiles;


namespace Dupfinder
{
    class Program
    {
        static void Main(string[] args)
        {
            MySQLAccess db = new MySQLAccess();
            MySqlConnection conn = db.GetConnection();
            db.OpenConnection(conn);
            db.ExecQuery("INSERT INTO all_files (Path, Size, hash_MD5, hash_SHA256) VALUES('C:\\\\fedpik\\\\pik.exe', 20, 'MD5HASHSAMPLE', 'SHA256HASHSAMPLE'); ", conn);
         
            // Open the connection.
          //  conn.Open();

            // Execute some SQL code:

          //  MySqlCommand cmd = new MySqlCommand("INSERT INTO all_files (Path, Size, hash_MD5, hash_SHA256) VALUES('C:\\\\fedpik\\\\pik.exe', 20, 'MD5HASHSAMPLE', 'SHA256HASHSAMPLE'); ", conn);

          //  cmd.ExecuteScalar();


        }





    }
}
