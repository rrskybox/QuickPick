// --------------------------------------------------------------------------------
// TSX Helper miniap for rapidly sorting and selecting targets by using an Observing List
// database query and object sortin  Can be used for using to CCDAP.
//
//   On occasion, I like to expedite the selection of a target and get it going.
//   The TSX "What's Up" feature can quickly produce a listing of available targets,
//   but working through object types, sizes, position, meridian flip times, to pick
//   a likely target can be cumbersome.  CCDNav is more user-friendly, but still requires
//   iteration to select targets.  CCDNav does have an additional ability to sort out a guider target
//   star, which is very useful, but only at the end of the selection process. 
//
//   for (instance, supposing I want to quickly find 1) a spiral galaxy, with 2) a reasonably large major axis,
//   with 3) at least 3 hours of visibility, and a 4) south azimuth.  In CCD Navigator,
//   this is mostly possible, but requires a certain amount of iteration because the target
//   lists are generated with single sorting parameters  With each "sorting" the user has to look
//   through the list of potential targets for what might work.  Same with TSX Observing List.  Either 
//   the user must sort and resort the output targets, or iteratively reenter selection criteria, then
//   look through the list.
//
//   This Quick Pick automation allows a user to look through a large observing list based on criteria and ranges
//   to narrow down to a choice or set of choices that can then be decided.  The criteria are:
//       1) object type,
//       2) range of object azimuth (normalized to compass direction), 
//       3) range of object size (based on major axis,
//       4) range of object availability (remaining time for imaging) times, 
//       5) range of object visibility (based on a 30 degree horizon)
//
//   Note that this tool is not a "planning" tool in the sense that CCDNAv, Astroplanner, etc are.  This tool
//   is more of an "aim and fire" tool, intended for a rapid selection of an individual target, presumably
//   immediately before initiating the shot and going to bed.
//
//   This miniapp takes advantage of the TSX Observing List feature, and sorts the target
//   database according to selection parameters. 
////
// Description:	//Operation as follows:
//   Install a database query file, if not already installed, for all NCG and M objects over 30 degrees altitude
//   Use it to produce an observing list in TSX 
//   Narrow the list down by selected object type
//   Optionally:
//       Narrow the list down based on minimum size (slider)
//       Narrow the list down based on minimum remaining time above horizon or dawn (slider)
//       Narrow the list down based on minimum current altitude (slider)
//       Narrow the list down based current azimuth (compass gauge)
//   Perform a Find on selected object -- display in TSX.
//   Reset and resort as needed
//
//// Environment:  Windows 7,8,10 executable, 32 and 64 bit.
//
// Requirements:  TSX Pro (Build 9334 or greater)
//
// Usage:        //Quick Pick is installed and runs as an miniap out of the TSXToolbox group.
//
// Author:		(REM) Rick McAlister, rrskybox@yahoo.com
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// 06-08-16	    REM	1.0.0	Initial implementation
// 06-18-16      REM 1.1.0   Release implementation
// ---------------------------------------------------------------------------------
//
using Microsoft.VisualBasic.PowerPacks;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TheSky64Lib;

namespace QuickPIck
{
    public partial class FormQuickPick : Form
    {
        private ObjectList olist;

        public bool LeftAzimuthSelectFlag = false;
        public bool RightAzimuthSelectFlag = false;

        public string TypePicked;
        public double SizeMax;
        public double SizeMin;
        public double DurationMax;
        public double DurationMin;
        public double AltitudeMax;
        public double AltitudeMin;

        public double AzimuthRight;
        public double AzimuthLeft;
        public double LineAngleLeft;
        public double LineAngleRight;

        public LineShape theLeftLine;
        public LineShape theInnerLeftLine;
        public LineShape theOuterLeftLine;
        public LineShape theRightLine;
        public LineShape theInnerRightLine;
        public LineShape theOuterRightLine;

        public OvalShape theMainCircle; // withevents
        public OvalShape theLeftCircle; // WithEvents
        public OvalShape theRightCircle; //WithEvents

        public Point LeftTip;
        public Point RightPoint;
        public Point RightTip;

        public Point CenterPoint;

        public ShapeContainer canvas;

        const int MainCircleDrawLocationX = 452 - 75;
        const int MainCircleDrawLocationY = 222 - 75;
        const int MainCircleSize = 150;
        const int MainCircleBorder = 20;
        const int PointCircleSize = 15;
        const int CircleRadius = 75;
        const int XCircleCenter = MainCircleDrawLocationX + CircleRadius;
        const int YCircleCenter = MainCircleDrawLocationY + CircleRadius;
        const int TipSize = 10;

        public FormQuickPick()
        {
            InitializeComponent();
            //Set Title of form for name and version
            try
            { this.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(); }
            catch
            {
                //probably in debug mode
                this.Text = " in Debug";
            }
            this.Text = "QuickPick V" + this.Text;
            //Configuration defaults
            QuickPickLaunch();
            //Events
            Closebutton.MouseClick += new System.Windows.Forms.MouseEventHandler(Closebutton_Click);
            theLeftCircle.MouseDown += new MouseEventHandler(LeftCircle_MouseClickDown);
            theRightCircle.MouseDown += new MouseEventHandler(RightCircle_MouseClickDown);
            theMainCircle.MouseUp += new MouseEventHandler(Azimuth_MouseClickUp);
            theLeftCircle.MouseDoubleClick += new MouseEventHandler(LeftCircle_MouseDoubleClick);
            theRightCircle.MouseDoubleClick += new MouseEventHandler(RightCircle_MouseDoubleClick);
            return;
        }

        private void QuickPickLaunch()
        {
            //Upon launch, load and create the required database query, run it and set the object
            //  type list and minimum/maximum values

            olist = new ObjectList();
            //Reset sort max/min
            ResetNonAzCriteria();
            //azReset();

            //for (each entry in the object list, if the TypeName hasn//t already been added to the
            //NGCTypesList then add it  
            this.NGCTypesList.Items.Clear();
            for (int oi = 0; oi < olist.Count; oi++)
            {
                bool cflg = false;
                SetTrackBars(oi);
                for (int typelistindex = 0; typelistindex < NGCTypesList.Items.Count; typelistindex++)
                {
                    if (NGCTypesList.Items[typelistindex].ToString() == olist.TypeName(oi))
                    { cflg = true; }
                }
                if (!cflg)
                { NGCTypesList.Items.Add(olist.TypeName(oi)); }
            }
            ResetThumbPositions();
            SetUpSectorDraw();
            return;
        }

        private void SizeTrackBar_Change(Object sender, EventArgs e)
        {
            //This routine will reset the NGC list to only those items with a size greater than the size indicator
            SizeMin = SizeTrackBar.Value;
            List<DBQObject> sortList = olist.SizeSort();
            SelectCheck(sortList, TypePicked);
            return;
        }

        private void DurationTrackBar_Change(Object sender, EventArgs e)
        //This routine will reset the NGC list to only those items with a size greater than the duration indicator
        {
            DurationMin = DurationTrackBar.Value;
            List<DBQObject> sortList = olist.DurationSort();
            SelectCheck(sortList, TypePicked);
            return;
        }

        private void AltitudeTrackBar_Change(Object sender, EventArgs e)
        //This routine will reset the NGC list to only those items with a size greater than the altitude indicator
        {
            AltitudeMin = AltitudeTrackBar.Value;
            List<DBQObject> sortList = olist.AltitudeSort();
            SelectCheck(sortList, TypePicked);
            return;
        }

        private void NGCList_SelectedIndexChanged(Object sender, EventArgs e)
        {
            //Upon selection of an object, center the star chart on the RA/Dec and run a Find on the name.
            sky6StarChart tsxsc = new sky6StarChart();
            int oi = olist.TgtFind(NGCList.SelectedItem.ToString());
            tsxsc.Declination = olist.TgtDec(oi);
            tsxsc.RightAscension = olist.TgtRA(oi);
            tsxsc.Find(NGCList.SelectedItem.ToString());
            tsxsc = null;
            return;
        }

        private void NGCTypesList_SelectedIndexChanged(Object sender, EventArgs e)
        {
            //Upon selection of an object type, clear the object list and reset criteria,
            //  then relist all objects of that type.  Then sort, etc.
            NGCList.Items.Clear();
            ResetNonAzCriteria();
            TypePicked = NGCTypesList.SelectedItem.ToString();
            for (int oi = 0; oi < olist.Count; oi++)
            {
                if (olist.TypeName(oi) == TypePicked)
                { SetTrackBars(oi); }
            }
            //ResetThumbPositions();
            List<DBQObject> sortList = olist.SizeSort();
            SelectCheck(sortList, NGCTypesList.SelectedItem.ToString());
            ResetThumbPositions();
            AzReset();
            return;
        }

        private void LeftCircle_MouseClickDown(Object sender, EventArgs e)
        {
            //Handles theLeftCircle.MouseDown
            //When  a click hits the left circle tip, turn on the left flag and turn off the right (if it was on)
            LeftAzimuthSelectFlag = true;
            RightAzimuthSelectFlag = false;
            return;
        }

        private void RightCircle_MouseClickDown(object sender, EventArgs e)
        {
            //Handles theRightCircle.MouseDown
            //When a click hits the right circle tip, turn on the right flag and turn off the left (if it was on)
            RightAzimuthSelectFlag = true;
            LeftAzimuthSelectFlag = false;
            return;
        }

        private void Azimuth_MouseClickUp(object sender, EventArgs e)
        {
            //Handles theMainCircle.MouseUp
            //When the click is released, (left or right) on the main circle then this handles it
            //  IF the left flag is set then change the azimuth compass point to the new location
            //       and reconstruct that side of the indicator
            //  Otherwise do the same thing on the right
            //Then resot the object list for the new azimuth range
            //
            if (LeftAzimuthSelectFlag)
            {
                Point offset = new Point(CircleRadius, CircleRadius);
                Point v = theMainCircle.PointToClient(System.Windows.Forms.Control.MousePosition);
                v.X -= offset.X;
                v.Y -= offset.Y;
                LineAngleLeft = Utilities.NormalizeAngle(Math.Atan2(v.Y, v.X));
                SetAzimuthLeft(LineAngleLeft);
                SelectCheck();
            }
            else if (RightAzimuthSelectFlag)
            {
                Point offset = new Point(CircleRadius, CircleRadius);
                Point v = theMainCircle.PointToClient(System.Windows.Forms.Control.MousePosition);
                v.X -= offset.X;
                v.Y -= offset.Y;
                LineAngleRight = Utilities.NormalizeAngle(Math.Atan2(v.Y, v.X));
                SetAzimuthRight(LineAngleRight);
                SelectCheck();
            }
            return;
        }

        private void LeftCircle_MouseDoubleClick(object sender, EventArgs e)
        {
            //Handles theLeftCircle.DoubleClick
            //When the left azimuth circle tip is double clicked, bring the right circle tip so it shows over the left
            theRightCircle.BringToFront();
            return;
        }

        private void RightCircle_MouseDoubleClick(object sender, EventArgs e)
        {
            //Handles theRightCircle.DoubleClick
            //When the right azimuth circle tip is double clicked, bring the left circle tip so it shows over the left
            theLeftCircle.BringToFront();
            return;
        }

        private void Closebutton_Click(Object sender, EventArgs e) // Handles Closebutton.Click
        {
            //Handles Close button: close window, end Quick Pick
            Close();
            return;
        }

        private void ResetNonAzCriteria()
        {
            //Zero out all the slider max and min
            TypePicked = null;
            SizeMax = 0;
            SizeMin = 1000;
            DurationMax = 0;
            DurationMin = 24;
            AltitudeMax = 0;
            AltitudeMin = 90;
            return;
        }

        private void ResetThumbPositions()
        {
            //Reset slider thumbs to minimum position
            SizeTrackBar.Value = (int)SizeMin;
            AltitudeTrackBar.Value = (int)AltitudeMin;
            DurationTrackBar.Value = (int)DurationMin;
            return;
        }

        //This is where the beef is...

        private void SetTrackBars(int oindex)
        {
            //This subroutine resets the maximum and minimum values for the size, duration and altitude sliders
            //  without moving the current indicator value, for the object out of the object list based on oindex

            double targetduration;
            double targetaltitude;

            //Get the target size(major axis) for the object
            double targetsize = olist.TgtSize(oindex);

            //If it is larger than the current max, then up the current max and display
            if (targetsize > SizeMax)
            {
                SizeMax = targetsize;
                SizeTrackBar.Maximum = (int)SizeMax;
                SizeTBMax.Text = SizeMax.ToString("0.0");
            }
            //If it is smaller than the trackbar indicator, then lower the minimum and display
            if (targetsize < SizeMin)
            {
                SizeMin = targetsize;
                SizeTrackBar.Minimum = (int)SizeMin;
                SizeTBMin.Text = SizeMin.ToString("0.0");
                //SizeTrackBar.Value = (int)SizeMin;
            }

            //Get the target duration (time before setting or dawn
            targetduration = olist.TgtDuration(oindex);

            //If it is larger than the current max, then up the current max and display
            if (targetduration > DurationMax)
            {
                DurationMax = targetduration;
                DurationTrackBar.Maximum = (int)DurationMax;
                DurationTBMax.Text = Utilities.HourString(DurationMax);
            }
            //If it is smaller than the trackbar indicator, then lower the minimum and display
            if (targetduration < DurationMin)
            {
                DurationMin = targetduration;
                DurationTrackBar.Minimum = (int)DurationMin;
                DurationTBMin.Text = Utilities.HourString(DurationMin);
                //DurationTrackBar.Value = (int)DurationMin;
            }
            //Get the target altitude
            targetaltitude = olist.TgtAltitude(oindex);
            //If it is larger than the current max, then up the current max and display
            if (targetaltitude > AltitudeMax)
            {
                AltitudeMax = targetaltitude;
                AltitudeTrackBar.Maximum = (int)AltitudeMax;
                AltitudeTBMax.Text = AltitudeMax.ToString("0.0");
            }
            //If it is smaller than the trackbar indicator, then lower the minimum and display
            if (targetaltitude < AltitudeMin)
            {
                AltitudeMin = targetaltitude;
                AltitudeTrackBar.Minimum = (int)AltitudeMin;
                AltitudeTBMin.Text = AltitudeMin.ToString("0.0");
                //AltitudeTrackBar.Value = (int)AltitudeMin;
            }
            return;
        }

        private void SelectCheck(List<DBQObject> sortList, string typePicked)
        {
            //clears the object list, then builds a new one for all objects that
            // meet the critera for output to sort list
            NGCList.Items.Clear();
            //            for (int tid = 0; tid < olist.Count; tid++)
            foreach (DBQObject tgt in sortList)
            {
                string typeName = tgt.TypeName;
                double tgtSize = tgt.Size;
                double tgtDuration = tgt.Duration;
                double tgtAltitude = tgt.Alt;
                if ((typeName == typePicked)
                  &&
                  (tgtSize >= SizeMin)
                  &&
                  (tgtDuration >= DurationMin)
                  &&
                  (tgtAltitude >= AltitudeMin))
                {
                    NGCList.Items.Add(tgt.Name);
                }
            }
            return;
        }

        private void SelectCheck()
        {
            //clears the object list, then builds a new one for all objects that
            //meet the critera for output to sort list
            NGCList.Items.Clear();
            for (int oi = 0; oi < olist.Count; oi++)
            {
                if ((olist.TypeName(oi) == TypePicked) &&
                           (olist.TgtSize(oi) > SizeTrackBar.Value) &&
                           (olist.TgtDuration(oi) > DurationTrackBar.Value) &&
                           (olist.TgtAltitude(oi) > AltitudeTrackBar.Value) &&
                           (Utilities.AzRangeCheck(AzimuthLeft, AzimuthRight, Utilities.DegToRad(olist.TgtAzimuth(oi)))))
                {
                    NGCList.Items.Add(olist.TgtName(oi));
                }
            }
            return;
        }


        private void SetUpSectorDraw()
        {
            //Routine that constructs the azimuth compass gauge in all its glory
            //Basically, a canvas is set up then a circle drawn around the center of the canvas
            //Each indicator is build from three lines that form a triangle and a filled circle
            //The triangle points left or right depending upon the indicator.  And, left is red; right is green.

            canvas = new ShapeContainer();
            canvas.Parent = this;

            CenterPoint.X = MainCircleDrawLocationX + MainCircleSize / 2;
            CenterPoint.Y = MainCircleDrawLocationY + MainCircleSize / 2;
            CenterPoint = new Point(MainCircleDrawLocationX + (MainCircleSize / 2), MainCircleDrawLocationY + (MainCircleSize / 2));

            theMainCircle = new OvalShape();
            theLeftCircle = new OvalShape();
            theRightCircle = new OvalShape();
            theLeftLine = new LineShape();
            theRightLine = new LineShape();
            theInnerLeftLine = new LineShape();
            theInnerRightLine = new LineShape();
            theOuterLeftLine = new LineShape();
            theOuterRightLine = new LineShape();

            theMainCircle.Parent = canvas;
            theMainCircle.Size = new System.Drawing.Size(MainCircleSize, MainCircleSize);
            theMainCircle.Location = new System.Drawing.Point(MainCircleDrawLocationX, MainCircleDrawLocationY);
            theMainCircle.BorderWidth = MainCircleBorder;
            theMainCircle.BorderColor = Color.LightBlue;

            theLeftLine.Parent = canvas;
            theLeftLine.BorderColor = Color.Red;
            theLeftLine.BorderWidth = 2;
            theInnerLeftLine.Parent = canvas;
            theInnerLeftLine.BorderColor = Color.Red;
            theInnerLeftLine.BorderWidth = 2;
            theOuterLeftLine.Parent = canvas;
            theOuterLeftLine.BorderColor = Color.Red;
            theOuterLeftLine.BorderWidth = 2;
            theInnerRightLine.Parent = canvas;
            theInnerRightLine.BorderColor = Color.Green;
            theInnerRightLine.BorderWidth = 2;
            theOuterRightLine.Parent = canvas;
            theOuterRightLine.BorderColor = Color.Green;
            theOuterRightLine.BorderWidth = 2;

            LineAngleLeft = Utilities.AzimuthToCanvas(AzimuthLeft);
            theLeftLine.StartPoint = CenterPoint;
            theLeftLine.EndPoint = new Point((int)(CircleRadius * Math.Cos(LineAngleLeft) + XCircleCenter),
                                                (int)(CircleRadius * Math.Sin(LineAngleLeft) + YCircleCenter));
            LeftTip = Utilities.TriPoint(CenterPoint, CircleRadius, LineAngleLeft, -TipSize);
            theInnerLeftLine.StartPoint = CenterPoint;
            theInnerLeftLine.EndPoint = LeftTip;
            theOuterLeftLine.StartPoint = LeftTip;
            theOuterLeftLine.EndPoint = theLeftLine.EndPoint;

            theLeftCircle.Parent = canvas;
            theLeftCircle.Size = new System.Drawing.Size(PointCircleSize, PointCircleSize);
            theLeftCircle.Location = Utilities.LocationOffset(theLeftLine.EndPoint, PointCircleSize);
            theLeftCircle.BorderColor = Color.Red;
            theLeftCircle.FillColor = Color.Red;
            theLeftCircle.FillStyle = FillStyle.Solid;
            theLeftCircle.BringToFront();

            theRightLine.Parent = canvas;
            theRightLine.BorderColor = Color.Green;
            theRightLine.BorderWidth = 2;

            LineAngleRight = Utilities.AzimuthToCanvas(AzimuthRight);
            theRightLine.StartPoint = CenterPoint;
            theRightLine.EndPoint = new Point((int)(CircleRadius * Math.Cos(LineAngleRight) + XCircleCenter), (int)(CircleRadius * Math.Sin(LineAngleRight) + YCircleCenter));
            RightTip = Utilities.TriPoint(CenterPoint, CircleRadius, LineAngleRight, TipSize);
            theInnerRightLine.StartPoint = CenterPoint;
            theInnerRightLine.EndPoint = RightTip;
            theOuterRightLine.StartPoint = RightTip;
            theOuterRightLine.EndPoint = theRightLine.EndPoint;

            theRightCircle.Parent = canvas;
            theRightCircle.Size = new System.Drawing.Size(PointCircleSize, PointCircleSize);
            theRightCircle.Location = Utilities.LocationOffset(theRightLine.EndPoint, PointCircleSize);
            theRightCircle.BorderColor = Color.Green;
            theRightCircle.FillColor = Color.Green;
            theRightCircle.FillStyle = FillStyle.Solid;
            theRightCircle.BringToFront();
            return;
        }

        private void HelpTips()
        {
            //Reads in help tips text and presents it as a message box

            //Collect the file contents to be written
            Assembly dassembly = Assembly.GetExecutingAssembly();
            Stream dstream = dassembly.GetManifestResourceStream("QuickPick.Help and Tips.txt");
            StreamReader tsreader = new StreamReader(dstream);
            string via = tsreader.ReadToEnd();
            System.Windows.Forms.MessageBox.Show(via);
            return;
        }

        private void SetAzimuthRight(double newLineAngle)
        {
            LineAngleRight = newLineAngle;
            AzimuthRight = Utilities.CanvasToAzimuth(LineAngleRight);
            theRightLine.EndPoint = new Point((int)(CircleRadius * Math.Cos(LineAngleRight) + XCircleCenter), (int)(CircleRadius * Math.Sin(LineAngleRight) + YCircleCenter));
            RightTip = Utilities.TriPoint(CenterPoint, CircleRadius, LineAngleRight, TipSize);
            theInnerRightLine.EndPoint = RightTip;
            theOuterRightLine.StartPoint = RightTip;
            theOuterRightLine.StartPoint = theInnerRightLine.EndPoint;
            theOuterRightLine.EndPoint = theRightLine.EndPoint;
            theRightCircle.Location = Utilities.LocationOffset(theRightLine.EndPoint, PointCircleSize);
            RightAzimuthSelectFlag = false;
            return;
        }

        private void SetAzimuthLeft(double newLineAngle)
        {
            LineAngleLeft = newLineAngle;
            AzimuthLeft = Utilities.CanvasToAzimuth(LineAngleLeft);
            theLeftLine.EndPoint = new Point((int)(CircleRadius * Math.Cos(LineAngleLeft) + XCircleCenter), (int)(CircleRadius * Math.Sin(LineAngleLeft) + YCircleCenter));
            LeftTip = Utilities.TriPoint(CenterPoint, CircleRadius, LineAngleLeft, -TipSize);
            theInnerLeftLine.EndPoint = LeftTip;
            theOuterLeftLine.StartPoint = LeftTip;
            theOuterLeftLine.StartPoint = theInnerLeftLine.EndPoint;
            theOuterLeftLine.EndPoint = theLeftLine.EndPoint;
            theLeftCircle.Location = Utilities.LocationOffset(theLeftLine.EndPoint, PointCircleSize);
            LeftAzimuthSelectFlag = false;
            return;
        }

        private void AzReset()
        {
            SetAzimuthRight(Math.PI * 270 / 180);
            SetAzimuthLeft(Math.PI * 270 / 180);
            return;
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            //  'Reads in help tips text and presents it as a message box

            Assembly dassembly;
            Stream dstream;
            
            //Collect the file contents to be written
            dassembly = Assembly.GetExecutingAssembly();
            dstream = dassembly.GetManifestResourceStream("QuickPick.Help and Tips.txt");
            StreamReader tsreader = new StreamReader(dstream);
            string via = tsreader.ReadToEnd();
            MessageBox.Show(via);
        }
    }

}
