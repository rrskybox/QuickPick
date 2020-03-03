//Module for installing the observing list database search file (embedded in the app as QuickPick.dbq) also installed as same name.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace QuickPIck
{
    public partial class DBQFileManagement
    {
        //Location to deposit database query: "C:\Users\" + System.Environment.UserName + 
        //   "\Documents\Software Bisque\TheSkyX Professional Edition\Database Queries\QuickPick.dbq"

        public static string QuickPickDestinationPath;

        public static bool DBQInstalled()
        {
            //Checks to see if search database file is already installed or not
            QuickPickDestinationPath = "C:\\Users\\" + System.Environment.UserName +
                "\\Documents\\Software Bisque\\TheSkyX Professional Edition\\Database Queries\\QuickPick.dbq";
            return File.Exists(QuickPickDestinationPath);
        }

        public static void InstallDBQ()
        {
            //Installs the dbq file
            QuickPickDestinationPath = "C:\\Users\\" + System.Environment.UserName +
                "\\Documents\\Software Bisque\\TheSkyX Professional Edition\\Database Queries\\QuickPick.dbq";
            //Collect the file contents to be written
            Assembly dassembly = Assembly.GetExecutingAssembly();
            Stream dstream = dassembly.GetManifestResourceStream("QuickPick.QuickPick.dbq");
            Byte[] dbytes = new Byte[dstream.Length];
            FileStream dbqfile = File.Create(QuickPickDestinationPath);
            dbqfile.Close();
            //write to destination file
            File.WriteAllBytes(QuickPickDestinationPath, dbytes);
            dstream.Close();
            return;
        }

    }
}
