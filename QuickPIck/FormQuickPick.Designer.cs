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
            this.HelpButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DurationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AltitudeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(600, 42);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(43, 13);
            this.Label9.TabIndex = 68;
            this.Label9.Text = "Targets";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(44, 42);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(70, 13);
            this.Label8.TabIndex = 67;
            this.Label8.Text = "Target Types";
            // 
            // Closebutton
            // 
            this.Closebutton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Closebutton.Location = new System.Drawing.Point(598, 409);
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
            this.NGCTypesList.Location = new System.Drawing.Point(25, 80);
            this.NGCTypesList.Name = "NGCTypesList";
            this.NGCTypesList.Size = new System.Drawing.Size(114, 290);
            this.NGCTypesList.Sorted = true;
            this.NGCTypesList.TabIndex = 51;
            this.NGCTypesList.SelectedIndexChanged += new System.EventHandler(this.NGCTypesList_SelectedIndexChanged);
            // 
            // NGCList
            // 
            this.NGCList.FormattingEnabled = true;
            this.NGCList.Location = new System.Drawing.Point(571, 77);
            this.NGCList.Name = "NGCList";
            this.NGCList.Size = new System.Drawing.Size(107, 303);
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
            // HelpButton
            // 
            this.HelpButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HelpButton.Location = new System.Drawing.Point(57, 404);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(45, 29);
            this.HelpButton.TabIndex = 71;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Cyan;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(401, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 72;
            this.textBox1.Text = "Sector";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Cyan;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(444, 115);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(19, 13);
            this.textBox2.TabIndex = 73;
            this.textBox2.Text = "N";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Cyan;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(342, 222);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(18, 13);
            this.textBox3.TabIndex = 74;
            this.textBox3.Text = "W";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Cyan;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(444, 317);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(27, 13);
            this.textBox4.TabIndex = 75;
            this.textBox4.Text = "S";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Cyan;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(543, 222);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(22, 13);
            this.textBox5.TabIndex = 76;
            this.textBox5.Text = "E";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormQuickPick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(699, 450);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.HelpButton);
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
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormQuickPick";
            this.Text = "QuickPick";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.DurationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AltitudeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeTrackBar)).EndInit();
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
        internal System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
    }
}

