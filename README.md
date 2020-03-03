# QuickPick
Astro-imaging target selection tool using TheSkyX
Quick Pick Description

Overview:
 
Quick Pick facilitates a rapid sort through a set of currently available imaging targets using just TSX.  First, the app utilizes a custom TSX Database Query to generate a list of non-stellar objects which are currently above 30 degrees of altitude.  Simple sliders and a custom direction gauge are used to narrow down the objects of a selected type based on size, altitude, remaining time above the horizon and azimuth range.  Each object can be displayed on the Star Chart and details displayed in the Find window.  If I want to spend an extra minute, I can drop into CCD Auto Pilot, and pick up displayed target (and guider rotation information) using the CCDAP “Get” capability to quickly build and run a session.  Or, I can fire off Autoguide and run Take Series while I get some sleep.  Either way works.  Obviously, the same chore can be performed in the TSX Observing List Manager (as “What’s Up” does), but this makes it a lot quicker to sort through multiple criteria to find and compare targets.

Requirements:  

Quick Pick is a Windows Forms executable, written in Visual Basic.  The application runs as an uncertified, standalone application under Windows 7, 8 and 10.  The application requires TSX Pro.

Installation:  

Download the "publish" directory.  Run the "Setup.exe" application.  Upon completion, an application icon will have been added to the start menu under the category "TSXToolkit" with the name “Quick Pick".  This application can be pinned to the Start if desired.  Upon launch, Quick Pick will install a database search file, “QuickPick.dbq)” in the user’s Software Bisque ”Database Queries” folder.  If desired, this query can be modified and saved in the Observing List Manager and will not be reset by this application after the first installation.  

Operation:  

Upon launch, Quick Pick will open The Sky X and cause a database query to run.  The query, QuickPick.dbq, lists all NGC and Messier entries (non-stellar) currently at an altitude over 30 degrees up to the maximum number of objects allowed in Advanced Preferences (by default, 2000).  A list of all types found will show in the Target Types box.  When a target type is selected, then the names of all entries of that type are listed on the right.  Selection of a target causes it to be displayed in the Find window in TSX as well on the Star Chart, at its current zoom setting.
support:  

This application was written as freeware for the public domain and as such is unsupported. The developer wishes you his best and hopes everything works out, but recommends learning Visual Basic (it's really not hard and the tools are free from Microsoft) if you find a problem or want to add features.  The source is supplied as a Visual Studio project.
