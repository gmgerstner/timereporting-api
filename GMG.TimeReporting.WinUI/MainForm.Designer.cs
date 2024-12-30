namespace GMG.TimeReporting.WinUI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TitleField = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartHourField = new System.Windows.Forms.ComboBox();
            this.StartMinuteField = new System.Windows.Forms.ComboBox();
            this.StartAMPMField = new System.Windows.Forms.ComboBox();
            this.SetNowButton = new System.Windows.Forms.Button();
            this.StartClockButton = new System.Windows.Forms.Button();
            this.ScheduleListView = new System.Windows.Forms.ListView();
            this.timeEntryIdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.titleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ResumeSelectedButton = new System.Windows.Forms.Button();
            this.EditSelectedButton = new System.Windows.Forms.Button();
            this.DeleteSelectedButton = new System.Windows.Forms.Button();
            this.RefreshScheduleButton = new System.Windows.Forms.Button();
            this.StopClockButton = new System.Windows.Forms.Button();
            this.TimeSheetListView = new System.Windows.Forms.ListView();
            this.TimesheetTitleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeSheetTotalHoursolumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalHoursField = new System.Windows.Forms.Label();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Plus15Button = new System.Windows.Forms.Button();
            this.Minus15Button = new System.Windows.Forms.Button();
            this.CopySelectedTimesheetItemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleField
            // 
            this.TitleField.FormattingEnabled = true;
            this.TitleField.Location = new System.Drawing.Point(12, 29);
            this.TitleField.Name = "TitleField";
            this.TitleField.Size = new System.Drawing.Size(745, 21);
            this.TitleField.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start/End Time";
            // 
            // StartHourField
            // 
            this.StartHourField.FormattingEnabled = true;
            this.StartHourField.Location = new System.Drawing.Point(12, 74);
            this.StartHourField.Name = "StartHourField";
            this.StartHourField.Size = new System.Drawing.Size(39, 21);
            this.StartHourField.TabIndex = 3;
            this.StartHourField.Text = "00";
            // 
            // StartMinuteField
            // 
            this.StartMinuteField.FormattingEnabled = true;
            this.StartMinuteField.Location = new System.Drawing.Point(57, 74);
            this.StartMinuteField.Name = "StartMinuteField";
            this.StartMinuteField.Size = new System.Drawing.Size(39, 21);
            this.StartMinuteField.TabIndex = 4;
            this.StartMinuteField.Text = "00";
            // 
            // StartAMPMField
            // 
            this.StartAMPMField.FormattingEnabled = true;
            this.StartAMPMField.Location = new System.Drawing.Point(113, 74);
            this.StartAMPMField.Name = "StartAMPMField";
            this.StartAMPMField.Size = new System.Drawing.Size(38, 21);
            this.StartAMPMField.TabIndex = 5;
            this.StartAMPMField.Text = "TT";
            // 
            // SetNowButton
            // 
            this.SetNowButton.Location = new System.Drawing.Point(157, 72);
            this.SetNowButton.Name = "SetNowButton";
            this.SetNowButton.Size = new System.Drawing.Size(75, 23);
            this.SetNowButton.TabIndex = 6;
            this.SetNowButton.Text = "Now";
            this.SetNowButton.UseVisualStyleBackColor = true;
            this.SetNowButton.Click += new System.EventHandler(this.SetNowButton_Click);
            // 
            // StartClockButton
            // 
            this.StartClockButton.Location = new System.Drawing.Point(12, 101);
            this.StartClockButton.Name = "StartClockButton";
            this.StartClockButton.Size = new System.Drawing.Size(75, 23);
            this.StartClockButton.TabIndex = 7;
            this.StartClockButton.Text = "Start Clock";
            this.StartClockButton.UseVisualStyleBackColor = true;
            this.StartClockButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ScheduleListView
            // 
            this.ScheduleListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScheduleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeEntryIdColumn,
            this.titleColumn,
            this.startTimeColumn,
            this.endTimeColumn});
            this.ScheduleListView.FullRowSelect = true;
            this.ScheduleListView.GridLines = true;
            this.ScheduleListView.HideSelection = false;
            this.ScheduleListView.Location = new System.Drawing.Point(12, 130);
            this.ScheduleListView.Name = "ScheduleListView";
            this.ScheduleListView.Size = new System.Drawing.Size(745, 276);
            this.ScheduleListView.TabIndex = 8;
            this.ScheduleListView.UseCompatibleStateImageBehavior = false;
            this.ScheduleListView.View = System.Windows.Forms.View.Details;
            this.ScheduleListView.SelectedIndexChanged += new System.EventHandler(this.ScheduleListView_SelectedIndexChanged);
            this.ScheduleListView.DoubleClick += new System.EventHandler(this.ScheduleListView_DoubleClick);
            // 
            // timeEntryIdColumn
            // 
            this.timeEntryIdColumn.Text = "Time Entry ID";
            this.timeEntryIdColumn.Width = 100;
            // 
            // titleColumn
            // 
            this.titleColumn.Text = "Title";
            this.titleColumn.Width = 400;
            // 
            // startTimeColumn
            // 
            this.startTimeColumn.Text = "Start Time";
            this.startTimeColumn.Width = 100;
            // 
            // endTimeColumn
            // 
            this.endTimeColumn.Text = "End Time";
            this.endTimeColumn.Width = 100;
            // 
            // ResumeSelectedButton
            // 
            this.ResumeSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResumeSelectedButton.Enabled = false;
            this.ResumeSelectedButton.Location = new System.Drawing.Point(763, 130);
            this.ResumeSelectedButton.Name = "ResumeSelectedButton";
            this.ResumeSelectedButton.Size = new System.Drawing.Size(129, 23);
            this.ResumeSelectedButton.TabIndex = 9;
            this.ResumeSelectedButton.Text = "Resume Selected";
            this.ResumeSelectedButton.UseVisualStyleBackColor = true;
            this.ResumeSelectedButton.Click += new System.EventHandler(this.ResumeSelectedButton_Click);
            // 
            // EditSelectedButton
            // 
            this.EditSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditSelectedButton.Enabled = false;
            this.EditSelectedButton.Location = new System.Drawing.Point(763, 160);
            this.EditSelectedButton.Name = "EditSelectedButton";
            this.EditSelectedButton.Size = new System.Drawing.Size(129, 23);
            this.EditSelectedButton.TabIndex = 10;
            this.EditSelectedButton.Text = "Edit Selected";
            this.EditSelectedButton.UseVisualStyleBackColor = true;
            this.EditSelectedButton.Click += new System.EventHandler(this.EditSelectedButton_Click);
            // 
            // DeleteSelectedButton
            // 
            this.DeleteSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteSelectedButton.Enabled = false;
            this.DeleteSelectedButton.Location = new System.Drawing.Point(763, 189);
            this.DeleteSelectedButton.Name = "DeleteSelectedButton";
            this.DeleteSelectedButton.Size = new System.Drawing.Size(129, 23);
            this.DeleteSelectedButton.TabIndex = 11;
            this.DeleteSelectedButton.Text = "Delete Selected";
            this.DeleteSelectedButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedButton.Click += new System.EventHandler(this.DeleteSelectedButton_Click);
            // 
            // RefreshScheduleButton
            // 
            this.RefreshScheduleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshScheduleButton.Location = new System.Drawing.Point(763, 219);
            this.RefreshScheduleButton.Name = "RefreshScheduleButton";
            this.RefreshScheduleButton.Size = new System.Drawing.Size(129, 23);
            this.RefreshScheduleButton.TabIndex = 12;
            this.RefreshScheduleButton.Text = "Refresh Schedule";
            this.RefreshScheduleButton.UseVisualStyleBackColor = true;
            this.RefreshScheduleButton.Click += new System.EventHandler(this.RefreshScheduleButton_Click);
            // 
            // StopClockButton
            // 
            this.StopClockButton.Location = new System.Drawing.Point(93, 101);
            this.StopClockButton.Name = "StopClockButton";
            this.StopClockButton.Size = new System.Drawing.Size(75, 23);
            this.StopClockButton.TabIndex = 13;
            this.StopClockButton.Text = "Stop Clock";
            this.StopClockButton.UseVisualStyleBackColor = true;
            this.StopClockButton.Click += new System.EventHandler(this.StopClockButton_Click);
            // 
            // TimeSheetListView
            // 
            this.TimeSheetListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeSheetListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TimesheetTitleColumnHeader,
            this.TimeSheetTotalHoursolumnHeader});
            this.TimeSheetListView.FullRowSelect = true;
            this.TimeSheetListView.GridLines = true;
            this.TimeSheetListView.HideSelection = false;
            this.TimeSheetListView.Location = new System.Drawing.Point(12, 425);
            this.TimeSheetListView.Name = "TimeSheetListView";
            this.TimeSheetListView.Size = new System.Drawing.Size(745, 208);
            this.TimeSheetListView.TabIndex = 14;
            this.TimeSheetListView.UseCompatibleStateImageBehavior = false;
            this.TimeSheetListView.View = System.Windows.Forms.View.Details;
            this.TimeSheetListView.SelectedIndexChanged += new System.EventHandler(this.TimeSheetListView_SelectedIndexChanged);
            // 
            // TimesheetTitleColumnHeader
            // 
            this.TimesheetTitleColumnHeader.Text = "Title";
            this.TimesheetTitleColumnHeader.Width = 400;
            // 
            // TimeSheetTotalHoursolumnHeader
            // 
            this.TimeSheetTotalHoursolumnHeader.Text = "Total Hours";
            this.TimeSheetTotalHoursolumnHeader.Width = 100;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Timesheet";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 636);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Total Hours";
            // 
            // TotalHoursField
            // 
            this.TotalHoursField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalHoursField.AutoSize = true;
            this.TotalHoursField.Location = new System.Drawing.Point(80, 636);
            this.TotalHoursField.Name = "TotalHoursField";
            this.TotalHoursField.Size = new System.Drawing.Size(28, 13);
            this.TotalHoursField.TabIndex = 17;
            this.TotalHoursField.Text = "0.00";
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Time Reporting";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // Plus15Button
            // 
            this.Plus15Button.Location = new System.Drawing.Point(238, 72);
            this.Plus15Button.Name = "Plus15Button";
            this.Plus15Button.Size = new System.Drawing.Size(35, 23);
            this.Plus15Button.TabIndex = 18;
            this.Plus15Button.Text = "+15";
            this.Plus15Button.UseVisualStyleBackColor = true;
            this.Plus15Button.Click += new System.EventHandler(this.Plus15Button_Click);
            // 
            // Minus15Button
            // 
            this.Minus15Button.Location = new System.Drawing.Point(279, 72);
            this.Minus15Button.Name = "Minus15Button";
            this.Minus15Button.Size = new System.Drawing.Size(35, 23);
            this.Minus15Button.TabIndex = 19;
            this.Minus15Button.Text = "-15";
            this.Minus15Button.UseVisualStyleBackColor = true;
            this.Minus15Button.Click += new System.EventHandler(this.Minus15Button_Click);
            // 
            // CopySelectedTimesheetItemButton
            // 
            this.CopySelectedTimesheetItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CopySelectedTimesheetItemButton.Enabled = false;
            this.CopySelectedTimesheetItemButton.Location = new System.Drawing.Point(763, 425);
            this.CopySelectedTimesheetItemButton.Name = "CopySelectedTimesheetItemButton";
            this.CopySelectedTimesheetItemButton.Size = new System.Drawing.Size(129, 23);
            this.CopySelectedTimesheetItemButton.TabIndex = 9;
            this.CopySelectedTimesheetItemButton.Text = "Copy Selected";
            this.CopySelectedTimesheetItemButton.UseVisualStyleBackColor = true;
            this.CopySelectedTimesheetItemButton.Click += new System.EventHandler(this.CopySelectedTimesheetItemButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 658);
            this.Controls.Add(this.Minus15Button);
            this.Controls.Add(this.Plus15Button);
            this.Controls.Add(this.TotalHoursField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TimeSheetListView);
            this.Controls.Add(this.StopClockButton);
            this.Controls.Add(this.RefreshScheduleButton);
            this.Controls.Add(this.DeleteSelectedButton);
            this.Controls.Add(this.EditSelectedButton);
            this.Controls.Add(this.CopySelectedTimesheetItemButton);
            this.Controls.Add(this.ResumeSelectedButton);
            this.Controls.Add(this.ScheduleListView);
            this.Controls.Add(this.StartClockButton);
            this.Controls.Add(this.SetNowButton);
            this.Controls.Add(this.StartAMPMField);
            this.Controls.Add(this.StartMinuteField);
            this.Controls.Add(this.StartHourField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Time Reporting";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TitleField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox StartHourField;
        private System.Windows.Forms.ComboBox StartMinuteField;
        private System.Windows.Forms.ComboBox StartAMPMField;
        private System.Windows.Forms.Button SetNowButton;
        private System.Windows.Forms.Button StartClockButton;
        private System.Windows.Forms.ListView ScheduleListView;
        private System.Windows.Forms.ColumnHeader timeEntryIdColumn;
        private System.Windows.Forms.ColumnHeader titleColumn;
        private System.Windows.Forms.ColumnHeader startTimeColumn;
        private System.Windows.Forms.ColumnHeader endTimeColumn;
        private System.Windows.Forms.Button ResumeSelectedButton;
        private System.Windows.Forms.Button EditSelectedButton;
        private System.Windows.Forms.Button DeleteSelectedButton;
        private System.Windows.Forms.Button RefreshScheduleButton;
        private System.Windows.Forms.Button StopClockButton;
        private System.Windows.Forms.ListView TimeSheetListView;
        private System.Windows.Forms.ColumnHeader TimesheetTitleColumnHeader;
        private System.Windows.Forms.ColumnHeader TimeSheetTotalHoursolumnHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TotalHoursField;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.Button Plus15Button;
        private System.Windows.Forms.Button Minus15Button;
        private System.Windows.Forms.Button CopySelectedTimesheetItemButton;
    }
}

