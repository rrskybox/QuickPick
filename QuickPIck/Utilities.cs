using System;
using System.Drawing;

namespace QuickPIck
{
    class Utilities
    {

        public static string HourString(double dvalue)
        //Converts a double value (dvalue) to a string looking like an hour:minutes
        {
            int hr = (int)Math.Truncate(dvalue);
            int min = (int)Math.Truncate((dvalue - hr) * 60);
            return (hr.ToString() + ":" + min.ToString());
        }

        public static Point LocationOffset(Point Center, double Diameter)
        { //Determines the upper left corner offset of a circle drawing from it//s center, based on angle
            Center.X = (int)(Center.X - Diameter / 2);
            Center.Y = (int)(Center.Y - Diameter / 2);
            return Center;
        }

        public static bool AzRangeCheck(double LeftAz, double RightAz, double AzR)
        {
            //returns true if Az is between Upper and Lower Az, which is tricky because of circular nature of angles
            if (LeftAz >= RightAz)
            {
                if ((RightAz <= AzR) && (AzR <= LeftAz))
                { return true; }
                else
                { return false; }
            }
            else //LeftAz <= RightAz
            {
                if ((LeftAz <= AzR) && (AzR <= RightAz))
                { return false; }
                else
                { return true; }
            }
        }

        public static Point TriPoint(Point C, double circleradius, double Alpha, double ht)
        {
            //Calculates the coordinations (point) for the third point of a isocolese triangle with
            // a height of ht and rotated to an angle (radians)
            double P = Math.Sqrt(Math.Pow(ht, 2) + Math.Pow((circleradius / 2), 2));
            double Beta = Math.Sin(ht / P);
            Point T = new Point((int)(C.X + P * Math.Cos(Alpha + Beta)), (int)(C.Y + P * Math.Sin(Alpha + Beta)));
            return T;
        }

        public static double NormalizeAngle(double angle)
        {
            int newangle = (int)(angle * (180 / Math.PI));
            if (angle < 0)
            { newangle = newangle + 360; }
            if (newangle > 360)
            {
                newangle = newangle % 360;
            }
            return (DegToRad(newangle));
        }

        public static double DegToRad(double Deg)
        {
            return (Deg * Math.PI / 180);
        }


        public static double RadToDeg(double Rad)
        {
            return (Rad * 180 / Math.PI);
        }

        public static double CanvasToAzimuth(double angle)
        {
            return NormalizeAngle(angle + DegToRad(90));
        }

        public static double AzimuthToCanvas(double angle)
        {
            return NormalizeAngle(angle + DegToRad(270));
        }

    }
}
