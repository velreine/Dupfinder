using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBAccess
{
    class MySQLAccess
    {

       // Server info::
       //host: 10.106.169.40
       //database: HashDB
       //user: outside
       //password: b36eWa
 

        
        public MySqlConnection GetConnection(string server, string database, string uid, string password)
        {
            
            string s_conn = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            MySqlConnection conn = new MySqlConnection(s_conn);


            return conn;
        }

        public MySqlConnection GetConnection()
        {
            string s_conn = "SERVER=" + "10.106.169.40" + ";" + "DATABASE=" +
            "hashdb" + ";" + "UID=" + "outside" + ";" + "PASSWORD=" + "b36eWa" + ";";

            MySqlConnection conn = new MySqlConnection(s_conn);

            return conn;


        }

        public void OpenConnection(MySqlConnection conn)
        {
            conn.Open();

        }

        public void ExecQuery(string query, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.ExecuteScalar();

        }




    }
}
