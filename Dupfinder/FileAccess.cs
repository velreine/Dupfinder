using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace WindowsFiles
{
    class FileAccess
    {

        public enum Flag_Attributes
        {
            FILE_ATTRIBUTE_ARCHIVE = 0x20,
            FILE_ATTRIBUTE_COMPRESSED = 0x800,
            FILE_ATTRIBUTE_DEVICE = 0x40,
            FILE_ATTRIBUTE_DIRECTORY = 0x10,
            FILE_ATTRIBUTE_ENCRYPTED = 0x4000,
            FILE_ATTRIBUTE_HIDDEN = 0x2,
            FILE_ATTRIBUTE_NORMAL = 0x80,
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x2000,
            FILE_ATTRIBUTE_NO_SCRUB_DATA = 0x20000,
            FILE_ATTRIBUTE_OFFLINE = 0x1000,
            FILE_ATTRIBUTE_READONLY = 0x1,
            FILE_ATTRIBUTE_RECALL_ON_DATA_ACCESS = 0x400000,
            FILE_ATTRIBUTE_RECALL_ON_OPEN = 0x40000,
            FILE_ATTRIBUTE_REPARSE_POINT = 0x400,
            FILE_ATTRIBUTE_SPARSE_FILE = 0x200,
            FILE_ATTRIBUTE_SYSTEM = 0x4,
            FILE_ATTRIBUTE_TEMPORARY = 0x100,
            FILE_ATTRIBUTE_VIRTUAL = 0x10000,

        };

        ///<summary>GetDirectories is a member of the FileAccess class.
        /// <para>Returns a string-array with Directories of the current location.</para>
        /// <para>If am empty string is passed, will return array of directories of the executing binary.</para>
        /// </summary>
        public string[] GetDirectories(string location)
        {

            // If an empty string was passed return the current binaries directory.
            if(String.IsNullOrEmpty(location))
            {
                string p = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                return  Directory.GetDirectories(p);
            }

            string[] dirs = Directory.GetDirectories(location);

            return dirs;
            
        }


        ///<summary>GetDirectories is a member of the FileAccess class.
        /// <para>Returns a string-array with Directories of the current location.</para>
        /// <para>If am empty string is passed, will return array of directories of the executing binary.</para>
        /// </summary>
        public string[] GetDirectories(string location, Flag_Attributes[] ignore)
        {
            string[] all_dirs;// = Directory.GetDirectories(location);

            if (String.IsNullOrEmpty(location))
            {
                all_dirs = Directory.GetDirectories(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            }else
            {
                all_dirs = Directory.GetDirectories(location);
            }

            int length = all_dirs.Length;
            string[] dirs = new string[length - CountWithFlag(all_dirs, ignore)]; // Does this shit even work lol?
            int dirpos = 0;

            for (int i = 0; i < length; i++)
            {

                DirectoryInfo dinfo = new DirectoryInfo(all_dirs[i]);
                FileAttributes fileab = dinfo.Attributes;

                // Check if the current directory has flags that we ignore.
                // If it doesn't have any of those flags that we ignore.
                // We will add it to the string to be returned,
                // And then increase the integer that indexes that string.
                if( !(HasAnyFlag(fileab, ignore)) ) { dirs[dirpos] = all_dirs[i]; dirpos++; }
            }



            return dirs;
            
        }

        public bool HasAnyFlag(FileAttributes fileattributes, Flag_Attributes[] flags)
        {
            int length = flags.Length;

            for (int i = 0; i < length; i++)
            {
                
                if(fileattributes.HasFlag((FileAttributes)flags[i])) { return true; }

            }

            return false;
        }

        public int CountWithFlag(string[] origin, Flag_Attributes flag)
        {
            int length = origin.Length;
            int count = 0;

            for (int i = 0; i < length; i++)
            {
                DirectoryInfo dirinfo = new DirectoryInfo(origin[i]);
                FileAttributes fileab = dirinfo.Attributes;

                // If the file contains the FileAttribute flag count it.
                if (fileab.HasFlag((FileAttributes)flag)) { count++; }

            }

            return count;

        }

        // Returns an integer representing how many of the folders have the flags provided.
        // Can be used to determine how big the size of a string array should be.
        public int CountWithFlag(string[] origin, Flag_Attributes[] flags)
        {
            int length = origin.Length;
            int flag_amount = flags.Length;
            int count = 0;

            for (int i = 0; i < length; i++)
            {
                DirectoryInfo dirinfo = new DirectoryInfo(origin[i]);
                FileAttributes fileab = dirinfo.Attributes;

                for (int d = 0; d < flag_amount; d++)
                {
                    // Break because we don't wanna count the same folders multiple times. 
                    // This function counts folders WITH flags, not total flags!!
                    if (fileab.HasFlag((FileAttributes)flags[d])) { count++; break; }


                }


            }

            // Return the amount of counted folders with flags.
            return count;
        }

        public string[] GetDirectories(string location, Flag_Attributes ignore_flag)
        {
            string[] all_dirs;// = Directory.GetDirectories(location);

            if (String.IsNullOrEmpty(location))
            {
                all_dirs = Directory.GetDirectories(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            }else
            {
                all_dirs = Directory.GetDirectories(location);
            }

            int length = all_dirs.Length;
            int valid_folders = length - CountWithFlag(all_dirs, ignore_flag);
            string[] dirs = new string[valid_folders];
            int dirpos = 0;

            for (int i = 0; i < length; i++)
            {
                DirectoryInfo dinfo = new DirectoryInfo(all_dirs[i]);
                FileAttributes fileab = dinfo.Attributes;

                // Check if the current directory has flags that we ignore.
                // If it doesn't have any of those flags that we ignore.
                // We will add it to the string to be returned,
                // And then increase the integer that indexes that string.
                if (!(fileab.HasFlag((FileAttributes)ignore_flag))) { dirs[dirpos] = all_dirs[i]; dirpos++; }


            }

            return dirs;

        }

    
        public bool ContainsSTR(string[] origin, string value)
        {

            int length = origin.Length;

            for (int i = 0; i < length; i++)
            {

                if(origin[i] == value) { return true; }

            }


            return false;
        }











    }
}
