using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DBAccess;
using WindowsFiles;
using static WindowsFiles.FileAccess;

namespace Dupfinder
{
    class Program
    {
        static void Main(string[] args)
        {

            FileAccess fa = new FileAccess();
            
            

            string[] dir = fa.GetDirectories("C:\\", Flag_Attributes.FILE_ATTRIBUTE_SYSTEM);

            foreach (string s in dir)
            {
                Console.WriteLine(s);
            }


            // WAITER:::
            Console.ReadKey();

            //MySQLAccess db = new MySQLAccess();
            //MySqlConnection conn = db.GetConnection();
            //db.OpenConnection(conn);
           // db.ExecQuery("INSERT INTO all_files (Path, Size, hash_MD5, hash_SHA256) VALUES('C:\\\\fedpik\\\\pik.exe', 20, 'MD5HASHSAMPLE', 'SHA256HASHSAMPLE'); ", conn);
         
            // Open the connection.
          //  conn.Open();

            // Execute some SQL code:

          //  MySqlCommand cmd = new MySqlCommand("INSERT INTO all_files (Path, Size, hash_MD5, hash_SHA256) VALUES('C:\\\\fedpik\\\\pik.exe', 20, 'MD5HASHSAMPLE', 'SHA256HASHSAMPLE'); ", conn);

          //  cmd.ExecuteScalar();


        }





    }
}
