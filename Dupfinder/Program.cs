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

        static Flag_Attributes[] g_flagArr;


        static void Main(string[] args)
        {

            FileAccess fa = new FileAccess();


            while (true)
            {
                PrintMenu();
            }

            
            




            // WAITER:::
            

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

        private static void PrintHeader()
        {
            Console.WriteLine("Dupfinder v.0.0.1 by Velreine");

            string str = "";
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                str += "~";

                if (i == (Console.BufferWidth - 1)) { Console.Write(str + "\n"); }
            }
        }


        private static void PrintMenu()
        {

            PrintHeader();

            Console.WriteLine("Options::");
            Console.WriteLine("[1] - Setup attributes to ignore");
            Console.WriteLine("[2] - Setup folders to ignore.");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    PrintAttributesIgnoreMenu();
                    // Call print menu for this option.
                    break;
                case "2":
                    Console.Clear();
                    // Call print menu for this option.
                    break;


                default:
                    // Unknown commands.
                    Console.Clear();
                    PrintMenu();
                    break;
            }



        }


        private static void PrintAttributesIgnoreMenu()
        {
            PrintHeader();
            Console.WriteLine("FILE_ATTRIBUTE_ARCHIVE = 0x20");
            Console.WriteLine("FILE_ATTRIBUTE_COMPRESSED = 0x800");
            Console.WriteLine("FILE_ATTRIBUTE_DEVICE = 0x40");
            Console.WriteLine("FILE_ATTRIBUTE_DIRECTORY = 0x10");
            Console.WriteLine("FILE_ATTRIBUTE_ENCRYPTED = 0x4000");
            Console.WriteLine("FILE_ATTRIBUTE_HIDDEN = 0x2");
            Console.WriteLine("FILE_ATTRIBUTE_NORMAL = 0x80");
            Console.WriteLine("FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x2000");
            Console.WriteLine("FILE_ATTRIBUTE_NO_SCRUB_DATA = 0x20000");
            Console.WriteLine("FILE_ATTRIBUTE_OFFLINE = 0x1000");
            Console.WriteLine("FILE_ATTRIBUTE_READONLY = 0x1");
            Console.WriteLine("FILE_ATTRIBUTE_RECALL_ON_DATA_ACCESS = 0x400000");
            Console.WriteLine("FILE_ATTRIBUTE_RECALL_ON_OPEN = 0x40000");
            Console.WriteLine("FILE_ATTRIBUTE_REPARSE_POINT = 0x400");
            Console.WriteLine("FILE_ATTRIBUTE_SPARSE_FILE = 0x200");
            Console.WriteLine("FILE_ATTRIBUTE_SYSTEM = 0x4");
            Console.WriteLine("FILE_ATTRIBUTE_TEMPORARY = 0x100");
            Console.WriteLine("FILE_ATTRIBUTE_VIRTUAL = 0x10000");
            Console.WriteLine("\n\n");
            Console.WriteLine("Type 'add ignore 0x4' to add it to the ignored list");
            Console.WriteLine("This will ignore system files!");
            Console.WriteLine("Type 'get ignore' to get a list of ignored attribtues");
            Console.WriteLine("Type 'clr ignore' to clear the list of ignored attributes");

            string input = Console.ReadLine();
            string sub = "";
            if (input.Length > 9) { sub = input.Substring(0, 10); }

            switch (sub)
            {
                case "add ignore":
                    // Call to add ignore.
                    string ign = input.Substring(11);
                    AddIgnore(ign);
                    break;
                    

                case "get ignore":
                    // Call to get current ignores.
                    break;
                case "clr ignore":
                    // Call to clear current ignores.
                    if (!(g_flagArr == null)){ Array.Clear(g_flagArr, 0, g_flagArr.Length); };
                    Console.WriteLine("Ignore flags was cleared, we are now ignoring nothing!");
                    break;

                default:
                    break;
            }

            switch (input)
            {
                case "exit":
                    break;
                default:
                    Console.ReadLine();
                    PrintAttributesIgnoreMenu();
                    break;
            }



        }
        
        private static void AddIgnore(string ignore)
        {

            // There's 18 total flags.
            if(g_flagArr == null) { g_flagArr = new Flag_Attributes[18]; }


            // Get empty space.
            int d = -1;
            for (int i = 0; i < 18; i++)
            {

                if(g_flagArr[i] == (Flag_Attributes)0) { d = i; break; }

            }
            



            switch (ignore)

            {
                case "0x4":
                    // SYSTEM.
                    if(d == -1) { Console.WriteLine("No empty space found, did you already add ALL attributes to ignore?!"); break; }
                    g_flagArr[d] = Flag_Attributes.FILE_ATTRIBUTE_SYSTEM;
                    Console.WriteLine("Added SYSTEM Attribute to be ignored");
                    
                    break;
                case "0x20":
                    // ARCHIVE
                    break;
                case "0x800":
                    // COMPRESSED
                    break;
                case "0x40":
                    // DEVICE
                    break;
                case "0x4000":
                    // ENCRYPTED
                    break;
                case "0x2":
                    // HIDDEN
                    break;
                case "0x80":
                    // NORMAL
                    break;
                case "0x2000":
                    // NOT INDEXED
                    break;
                case "0x20000":
                    // NO SCRUB DATA
                    break;
                case "0x1000":
                    // OFFLINE
                    break;
                case "0x1":
                    // READONLY
                    break;
                case "0x400000":
                    // RECALL ON DATA ACCESS
                    break;
                case "0x40000":
                    // RECALL ON OPEN
                    break;
                case "0x400":
                    // REPARSE POINT
                    break;
                case "0x200":
                    // SPARSE FILE
                    break;
                case "0x100":
                    // TEMPORARY
                    break;
                case "0x10000":
                    // VIRTUAL
                    break;





                default:
                    // Unknown attribute?
                    Console.WriteLine("Unknown attribute specified?");
                    break;
            }




        }






    }
}
