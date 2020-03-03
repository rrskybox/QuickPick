using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSkyXLib;

namespace QuickPIck
{
    public class DBQObject
    {
        public string[] ObjectTypeName = {
                "STAR",
                "VARIABLE STAR",
                "SUSPECTED VARIABLE",
                "DOUBLE STAR",
                "GALAXY",
                "C TYPE GAlAXY",
                "ELLIPTICAL GALAXY",
                "LENTICULAR GALAXY",
                "SPIRAL GALAXY",
                "IRREGULAR GALAXY",
                "GALACTIC CLUSTER",
                "OPEN CLUSTER",
                "GLOBULAR CLUSTER",
                "NEBULA CLUSTER",
                "NEBULA",
                "BRIGHT NEBULA",
                "DARK NEBULA",
                "PLANETARY NEBULA",
                "ACTUAL STAR",
                "OTHER NGC",
                "MIXED DEEP SKY",
                "NST GSC",
                "QUASAR",
                "XRAY SOURCE",
                "RADIO SOURCE",
                "SUN",
                "MERCURY",
                "VENUS",
                "EARTH",
                "MARS",
                "JUPITER",
                "SATURN",
                "URANUS",
                "NEPTUNE",
                "PLUTO",
                "MOON",
                "COMET",
                "ASTEROID",
                "EXT COMET",
                "EXT ASTEROID",
                "SPACECRAFT"};

        public string Name;
        public int Type;
        public string TypeName;
        public double Size;
        public DateTime Rise;
        public DateTime Set;
        public double Duration;
        public double Alt;
        public double Azm;
        public double Dec;
        public double RA;

        public DBQObject(string noname, int notype, double nosize, DateTime norise, DateTime noset, double noaltitude, double noazimuth, double noDec, double noRA)
        {
            Name = noname;
            Type = notype;
            TypeName = ObjectTypeName[notype];
            Size = nosize;
            Rise = norise;
            Set = noset;
            Alt = noaltitude;
            Azm = noazimuth;
            Dec = noDec;
            RA = noRA;
            Duration = CalcDuration(norise, noset);
            return;
        }

        private double CalcDuration(DateTime tRise, DateTime tSet)
        {
            const int DawnHour = 5;
            const int DuskHour = 17;

            DateTime tNow = DateTime.Now;
            DateTime tDusk = (DateTime.Now - DateTime.Now.TimeOfDay).AddHours(DuskHour);
            DateTime tDawn = (DateTime.Now - DateTime.Now.TimeOfDay).AddHours(DawnHour);
            //Correct dusk and dawn to correct days relative to Now
            //if now happens before dawn, then dawn stays at today and dusk stays at today
            //if now happens after dawn but before dusk, then dawn -> tomorrow and dusk stays at today
            //if now happens after dawn and after dusk, then dawn -> tomorrow and dusk stays at today
            if ((tNow > tDawn) && (tNow < tDusk))
            { tDawn = tDawn.AddDays(1); }
            else if ((tNow > tDawn) && (tNow > tDusk))
            {
                tDawn = tDawn.AddDays(1);
            }
            //Check to see if rise and set are the same -- if so, then just calc the dusk to dawn
            if (tRise == tSet)
            { return (tDawn - tDusk).TotalHours; }
            else
            {
                //If Now is after rise, then set rise to Now
                if (tRise < tNow)
                { tRise = tNow; }
                //Dusk is after Rise, then set Rise to Dusk
                if (tDusk > tRise)
                { tRise = tDusk; }
                //Dawn is before Set, then Set is Dawn
                if (tDawn < tSet)
                { tSet = tDawn; }
                //Calculate the duration of Rise to Set
                TimeSpan durationTS = tSet - tRise;
                double durationD = durationTS.TotalHours;
                if (durationD < 0)
                { durationD = 0; }
                return durationD;
            }
        }
    }

    public class ObjectList
    {

        private string oname;
        private int otype;
        private double osize;
        private DateTime orise;
        private DateTime oset;
        private double oaltitude;
        private double oazimuth;
        private double oDec;
        private double oRA;

        private List<DBQObject> dbqList = new List<DBQObject>();

        public ObjectList()
        {
            //Create the object list 
            //Need to make this a bunch more robust later, including installing search database file, if not already installed
            //
            //Determine if search database file exists, if not, create it
            if (!DBQFileManagement.DBQInstalled())
            { DBQFileManagement.InstallDBQ(); }
            sky6DataWizard tsxdw = new sky6DataWizard();
            tsxdw.Path = DBQFileManagement.QuickPickDestinationPath;
            tsxdw.Open();
            //sky6ObjectInformation tsxoi = new sky6ObjectInformation();
            sky6ObjectInformation tsxoi = tsxdw.RunQuery;

            //Fill in data arrays (for speed purposes)
            for (int i = 0; i < tsxoi.Count; i++)
            {
                tsxoi.Index = i;
                tsxoi.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_NAME1);
                oname = (tsxoi.ObjInfoPropOut);
                tsxoi.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_OBJECTTYPE);
                otype = (tsxoi.ObjInfoPropOut);
                tsxoi.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_MAJ_AXIS_MINS);
                osize = (tsxoi.ObjInfoPropOut);
                tsxoi.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_RISE_TIME);
                orise = (DateTime.Now - DateTime.Now.TimeOfDay).AddHours(tsxoi.ObjInfoPropOut);
                tsxoi.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_SET_TIME);
                oset = (DateTime.Now - DateTime.Now.TimeOfDay).AddHours(tsxoi.ObjInfoPropOut);
                tsxoi.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_ALT);
                oaltitude = (tsxoi.ObjInfoPropOut);
                tsxoi.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_AZM);
                oazimuth = (tsxoi.ObjInfoPropOut);
                tsxoi.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_DEC_2000);
                oDec = (tsxoi.ObjInfoPropOut);
                tsxoi.Property(Sk6ObjectInformationProperty.sk6ObjInfoProp_RA_2000);
                oRA = (tsxoi.ObjInfoPropOut);
                dbqList.Add(new DBQObject(oname, otype, osize, oset, orise, oaltitude, oazimuth, oDec, oRA));
            }
            return;
        }

        public int Count
        {
            get { return (dbqList.Count); }
            set { return; }
        }

        public string TgtName(int entry)
        {
            return dbqList[entry].Name;
        }

        public int TypeId(int entry)
        {
            return dbqList[entry].Type;
        }

        public string TypeName(int entry)
        {
            return dbqList[entry].TypeName;
        }

        public double TgtSize(int entry)
        {
            return dbqList[entry].Size;
        }

        public double TgtDuration(int entry)
        {
            return dbqList[entry].Duration;
        }

        public double TgtAltitude(int entry)
        {
            return (dbqList[entry].Alt);
        }

        public double TgtAzimuth(int entry)
        {
            return (dbqList[entry].Azm);
        }

        public double TgtRA(int entry)
        {
            return dbqList[entry].RA;
        }

        public double TgtDec(int entry)
        {
            return dbqList[entry].Dec;
        }

        public int TgtFind(string tname)
        {
            for (int i = 0; i < dbqList.Count; i++)
            {
                if (tname == dbqList[i].Name)
                { return i; }
            }
            return 0;
        }

        public List<DBQObject> SizeSort()
        {
            //Sort list on size of object
            dbqList =  dbqList.OrderBy(i => -i.Size).ToList();
            return dbqList;
        }
        public List<DBQObject> AltitudeSort()
        {
            //Sort list on size of object
            dbqList = dbqList.OrderBy(i => -i.Alt).ToList();
            return dbqList;
        }
        public List<DBQObject> DurationSort()
        {
            //Sort list on size of object
            dbqList = dbqList.OrderBy(i => i.Set).ToList();
            return dbqList;
        }
    }
}
