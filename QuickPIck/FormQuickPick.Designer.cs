namespace QuickPIck
{
    partial class FormQuickPick
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Closebutton = new System.Windows.Forms.Button();
            this.DurationTrackBar = new System.Windows.Forms.TrackBar();
            this.DurationTBMax = new System.Windows.Forms.Label();
            this.DurationTBMin = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.AltitudeTrackBar = new System.Windows.Forms.TrackBar();
            this.AltitudeTBMax = new System.Windows.Forms.Label();
            this.AltitudeTBMin = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.NGCTypesList = new System.Windows.Forms.ListBox();
            this.NGCList = new System.Windows.Forms.ListBox();
            this.SizeTrackBar = new System.Windows.Forms.TrackBar();
            this.SizeTBMax = new System.Windows.Forms.Label();
            this.SizeTBMin = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.DurationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AltitudeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(383, 9);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(43, 13);
            this.Label9.TabIndex = 68;
            this.Label9.Text = "Targets";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(25, 69);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(70, 13);
            this.Label8.TabIndex = 67;
            this.Label8.Text = "Target Types";
            // 
            // Closebutton
            // 
            this.Closebutton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Closebutton.Location = new System.Drawing.Point(59, 407);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(45, 29);
            this.Closebutton.TabIndex = 66;
            this.Closebutton.Text = "Close";
            this.Closebutton.UseVisualStyleBackColor = true;
            // 
            // DurationTrackBar
            // 
            this.DurationTrackBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DurationTrackBar.Location = new System.Drawing.Point(230, 80);
            this.DurationTrackBar.Maximum = 1000;
            this.DurationTrackBar.Name = "DurationTrackBar";
            this.DurationTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.DurationTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DurationTrackBar.Size = new System.Drawing.Size(45, 294);
            this.DurationTrackBar.TabIndex = 59;
            this.DurationTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DurationTrackBar_Change);
            // 
            // DurationTBMax
            // 
            this.DurationTBMax.AutoSize = true;
            this.DurationTBMax.Location = new System.Drawing.Point(229, 53);
            this.DurationTBMax.Name = "DurationTBMax";
            this.DurationTBMax.Size = new System.Drawing.Size(27, 13);
            this.DurationTBMax.TabIndex = 58;
            this.DurationTBMax.Text = "Max";
            // 
            // DurationTBMin
            // 
            this.DurationTBMin.AutoSize = true;
            this.DurationTBMin.Location = new System.Drawing.Point(232, 391);
            this.DurationTBMin.Name = "DurationTBMin";
            this.DurationTBMin.Size = new System.Drawing.Size(24, 13);
            this.DurationTBMin.TabIndex = 57;
            this.DurationTBMin.Text = "Min";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(209, 13);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(77, 26);
            this.Label10.TabIndex = 56;
            this.Label10.Text = "Remainig Time\r\n(hh:mm)";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AltitudeTrackBar
            // 
            this.AltitudeTrackBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AltitudeTrackBar.Location = new System.Drawing.Point(291, 80);
            this.AltitudeTrackBar.Maximum = 1000;
            this.AltitudeTrackBar.Name = "AltitudeTrackBar";
            this.AltitudeTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.AltitudeTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AltitudeTrackBar.Size = new System.Drawing.Size(45, 294);
            this.AltitudeTrackBar.TabIndex = 55;
            this.AltitudeTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AltitudeTrackBar_Change);
            // 
            // AltitudeTBMax
            // 
            this.AltitudeTBMax.AutoSize = true;
            this.AltitudeTBMax.Location = new System.Drawing.Point(292, 53);
            this.AltitudeTBMax.Name = "AltitudeTBMax";
            this.AltitudeTBMax.Size = new System.Drawing.Size(27, 13);
            this.AltitudeTBMax.TabIndex = 54;
            this.AltitudeTBMax.Text = "Max";
            // 
            // AltitudeTBMin
            // 
            this.AltitudeTBMin.AutoSize = true;
            this.AltitudeTBMin.Location = new System.Drawing.Point(292, 391);
            this.AltitudeTBMin.Name = "AltitudeTBMin";
            this.AltitudeTBMin.Size = new System.Drawing.Size(24, 13);
            this.AltitudeTBMin.TabIndex = 53;
            this.AltitudeTBMin.Text = "Min";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(292, 13);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(42, 26);
            this.Label2.TabIndex = 52;
            this.Label2.Text = "Altitude\r\n(deg)";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NGCTypesList
            // 
            this.NGCTypesList.FormattingEnabled = true;
            this.NGCTypesList.Location = new System.Drawing.Point(28, 96);
            this.NGCTypesList.Name = "NGCTypesList";
            this.NGCTypesList.Size = new System.Drawing.Size(114, 238);
            this.NGCTypesList.Sorted = true;
            this.NGCTypesList.TabIndex = 51;
            this.NGCTypesList.SelectedIndexChanged += new System.EventHandler(this.NGCTypesList_SelectedIndexChanged);
            // 
            // NGCList
            // 
            this.NGCList.FormattingEnabled = true;
            this.NGCList.Location = new System.Drawing.Point(357, 31);
            this.NGCList.Name = "NGCList";
            this.NGCList.Size = new System.Drawing.Size(107, 407);
            this.NGCList.TabIndex = 50;
            this.NGCList.SelectedIndexChanged += new System.EventHandler(this.NGCList_SelectedIndexChanged);
            // 
            // SizeTrackBar
            // 
            this.SizeTrackBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SizeTrackBar.Location = new System.Drawing.Point(168, 80);
            this.SizeTrackBar.Maximum = 1000;
            this.SizeTrackBar.Name = "SizeTrackBar";
            this.SizeTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SizeTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeTrackBar.Size = new System.Drawing.Size(45, 294);
            this.SizeTrackBar.TabIndex = 49;
            this.SizeTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizeTrackBar_Change);
            // 
            // SizeTBMax
            // 
            this.SizeTBMax.AutoSize = true;
            this.SizeTBMax.Location = new System.Drawing.Point(168, 53);
            this.SizeTBMax.Name = "SizeTBMax";
            this.SizeTBMax.Size = new System.Drawing.Size(27, 13);
            this.SizeTBMax.TabIndex = 48;
            this.SizeTBMax.Text = "Max";
            // 
            // SizeTBMin
            // 
            this.SizeTBMin.AutoSize = true;
            this.SizeTBMin.Location = new System.Drawing.Point(171, 391);
            this.SizeTBMin.Name = "SizeTBMin";
            this.SizeTBMin.Size = new System.Drawing.Size(24, 13);
            this.SizeTBMin.TabIndex = 47;
            this.SizeTBMin.Text = "Min";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(168, 13);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(44, 26);
            this.Label3.TabIndex = 46;
            this.Label3.Text = "Size\r\n(arcmin)";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(168, 413);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 69;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormQuickPick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(619, 450);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Closebutton);
            this.Controls.Add(this.DurationTrackBar);
            this.Controls.Add(this.DurationTBMax);
            this.Controls.Add(this.DurationTBMin);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.AltitudeTrackBar);
            this.Controls.Add(this.AltitudeTBMax);
            this.Controls.Add(this.AltitudeTBMin);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.NGCTypesList);
            this.Controls.Add(this.NGCList);
            this.Controls.Add(this.SizeTrackBar);
            this.Controls.Add(this.SizeTBMax);
            this.Controls.Add(this.SizeTBMin);
            this.Controls.Add(this.Label3);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "FormQuickPick";
            this.Text = "Form1";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.DurationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AltitudeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Button Closebutton;
        internal System.Windows.Forms.TrackBar DurationTrackBar;
        internal System.Windows.Forms.Label DurationTBMax;
        internal System.Windows.Forms.Label DurationTBMin;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TrackBar AltitudeTrackBar;
        internal System.Windows.Forms.Label AltitudeTBMax;
        internal System.Windows.Forms.Label AltitudeTBMin;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ListBox NGCTypesList;
        internal System.Windows.Forms.ListBox NGCList;
        internal System.Windows.Forms.TrackBar SizeTrackBar;
        internal System.Windows.Forms.Label SizeTBMax;
        internal System.Windows.Forms.Label SizeTBMin;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

