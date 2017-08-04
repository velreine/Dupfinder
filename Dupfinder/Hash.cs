using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashMGR
{
    class Hash
    {


        // Computes the MD5 hash of a file.
        private static string ComputeMD5(string file)
        {
            MD5 md5 = MD5.Create();

            FileStream stream = File.OpenRead(file);

            byte[] hash = md5.ComputeHash(stream);

            // Convert it to a more appropiate display.
            return hexlike(hash);
        }


        // Computes the SHA256 hash of a file.
        private static string ComputeSHA256(string file)
        {

            SHA256 sha = SHA256.Create();

            FileStream stream = File.OpenRead(file);

            byte[] hash = sha.ComputeHash(stream);

            // Convert it to a more appropiate display.
            return hexlike(hash);



        }

        private static string hexlike(byte[] bytes)
        {
            string sText = "";

            foreach (byte x in bytes)
            {
                sText += String.Format("{0:x2}", x);
            }


            return sText;
        }











    }
}
