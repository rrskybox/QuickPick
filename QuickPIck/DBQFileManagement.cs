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
            string userDocumentsDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Checks to see if search database file is already installed or not
            QuickPickDestinationPath = userDocumentsDirectory + "\\Software Bisque\\TheSkyX Professional Edition\\Database Queries\\QuickPick.dbq";
            return File.Exists(QuickPickDestinationPath);
        }

        public static void InstallDBQ()
        {
            //Installs the dbq file
            string userDocumentsDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            QuickPickDestinationPath = userDocumentsDirectory + "\\Software Bisque\\TheSkyX Professional Edition\\Database Queries\\QuickPick.dbq";
            //Collect the file contents to be written
            Assembly dgassembly = Assembly.GetExecutingAssembly();
            Stream dgstream = dgassembly.GetManifestResourceStream("QuickPick.QuickPick.dbq");
            Byte[] dgbytes = new Byte[dgstream.Length];
            FileStream dbqgfile = File.Create(QuickPickDestinationPath);
            int dgreadout = dgstream.Read(dgbytes, 0, (int)dgstream.Length);
            dbqgfile.Close();
            //write to destination file
            File.WriteAllBytes(QuickPickDestinationPath, dgbytes);
            dgstream.Close();
            return;
        }

    }
}
