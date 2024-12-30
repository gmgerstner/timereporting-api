namespace GMG.TimeReporting.WinUI
{
    partial class TimeEntryEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TitleField = new System.Windows.Forms.ComboBox();
            this.StartAMPMField = new System.Windows.Forms.ComboBox();
            this.StartMinuteField = new System.Windows.Forms.ComboBox();
            this.StartHourField = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EndAMPMField = new System.Windows.Forms.ComboBox();
            this.EndMinuteField = new System.Windows.Forms.ComboBox();
            this.EndHourField = new System.Windows.Forms.ComboBox();
            this.SetEndField = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.StartTimeMinus15Button = new System.Windows.Forms.Button();
            this.StartTimePlus15Button = new System.Windows.Forms.Button();
            this.StartTimeSetNowButton = new System.Windows.Forms.Button();
            this.EndTimeMinus15Button = new System.Windows.Forms.Button();
            this.EndTimePlus15Button = new System.Windows.Forms.Button();
            this.EndTimeSetNowButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title";
            // 
            // TitleField
            // 
            this.TitleField.FormattingEnabled = true;
            this.TitleField.Location = new System.Drawing.Point(11, 25);
            this.TitleField.Name = "TitleField";
            this.TitleField.Size = new System.Drawing.Size(414, 21);
            this.TitleField.TabIndex = 2;
            // 
            // StartAMPMField
            // 
            this.StartAMPMField.FormattingEnabled = true;
            this.StartAMPMField.Location = new System.Drawing.Point(113, 66);
            this.StartAMPMField.Name = "StartAMPMField";
            this.StartAMPMField.Size = new System.Drawing.Size(38, 21);
            this.StartAMPMField.TabIndex = 9;
            this.StartAMPMField.Text = "TT";
            // 
            // StartMinuteField
            // 
            this.StartMinuteField.FormattingEnabled = true;
            this.StartMinuteField.Location = new System.Drawing.Point(57, 66);
            this.StartMinuteField.Name = "StartMinuteField";
            this.StartMinuteField.Size = new System.Drawing.Size(39, 21);
            this.StartMinuteField.TabIndex = 8;
            this.StartMinuteField.Text = "00";
            // 
            // StartHourField
            // 
            this.StartHourField.FormattingEnabled = true;
            this.StartHourField.Location = new System.Drawing.Point(12, 66);
            this.StartHourField.Name = "StartHourField";
            this.StartHourField.Size = new System.Drawing.Size(39, 21);
            this.StartHourField.TabIndex = 7;
            this.StartHourField.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Start Time";
            // 
            // EndAMPMField
            // 
            this.EndAMPMField.Enabled = false;
            this.EndAMPMField.FormattingEnabled = true;
            this.EndAMPMField.Location = new System.Drawing.Point(295, 66);
            this.EndAMPMField.Name = "EndAMPMField";
            this.EndAMPMField.Size = new System.Drawing.Size(38, 21);
            this.EndAMPMField.TabIndex = 13;
            this.EndAMPMField.Text = "TT";
            // 
            // EndMinuteField
            // 
            this.EndMinuteField.Enabled = false;
            this.EndMinuteField.FormattingEnabled = true;
            this.EndMinuteField.Location = new System.Drawing.Point(239, 66);
            this.EndMinuteField.Name = "EndMinuteField";
            this.EndMinuteField.Size = new System.Drawing.Size(39, 21);
            this.EndMinuteField.TabIndex = 12;
            this.EndMinuteField.Text = "00";
            // 
            // EndHourField
            // 
            this.EndHourField.Enabled = false;
            this.EndHourField.FormattingEnabled = true;
            this.EndHourField.Location = new System.Drawing.Point(194, 66);
            this.EndHourField.Name = "EndHourField";
            this.EndHourField.Size = new System.Drawing.Size(39, 21);
            this.EndHourField.TabIndex = 11;
            this.EndHourField.Text = "00";
            // 
            // SetEndField
            // 
            this.SetEndField.AutoSize = true;
            this.SetEndField.Location = new System.Drawing.Point(194, 48);
            this.SetEndField.Name = "SetEndField";
            this.SetEndField.Size = new System.Drawing.Size(71, 17);
            this.SetEndField.TabIndex = 14;
            this.SetEndField.Text = "End Time";
            this.SetEndField.UseVisualStyleBackColor = true;
            this.SetEndField.CheckedChanged += new System.EventHandler(this.SetEndField_CheckedChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.Location = new System.Drawing.Point(15, 131);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(96, 131);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 16;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // StartTimeMinus15Button
            // 
            this.StartTimeMinus15Button.Location = new System.Drawing.Point(134, 93);
            this.StartTimeMinus15Button.Name = "StartTimeMinus15Button";
            this.StartTimeMinus15Button.Size = new System.Drawing.Size(35, 23);
            this.StartTimeMinus15Button.TabIndex = 22;
            this.StartTimeMinus15Button.Text = "-15";
            this.StartTimeMinus15Button.UseVisualStyleBackColor = true;
            this.StartTimeMinus15Button.Click += new System.EventHandler(this.StartTimeMinus15Button_Click);
            // 
            // StartTimePlus15Button
            // 
            this.StartTimePlus15Button.Location = new System.Drawing.Point(93, 93);
            this.StartTimePlus15Button.Name = "StartTimePlus15Button";
            this.StartTimePlus15Button.Size = new System.Drawing.Size(35, 23);
            this.StartTimePlus15Button.TabIndex = 21;
            this.StartTimePlus15Button.Text = "+15";
            this.StartTimePlus15Button.UseVisualStyleBackColor = true;
            this.StartTimePlus15Button.Click += new System.EventHandler(this.StartTimePlus15Button_Click);
            // 
            // StartTimeSetNowButton
            // 
            this.StartTimeSetNowButton.Location = new System.Drawing.Point(12, 93);
            this.StartTimeSetNowButton.Name = "StartTimeSetNowButton";
            this.StartTimeSetNowButton.Size = new System.Drawing.Size(75, 23);
            this.StartTimeSetNowButton.TabIndex = 20;
            this.StartTimeSetNowButton.Text = "Now";
            this.StartTimeSetNowButton.UseVisualStyleBackColor = true;
            this.StartTimeSetNowButton.Click += new System.EventHandler(this.StartTimeSetNowButton_Click);
            // 
            // EndTimeMinus15Button
            // 
            this.EndTimeMinus15Button.Enabled = false;
            this.EndTimeMinus15Button.Location = new System.Drawing.Point(316, 93);
            this.EndTimeMinus15Button.Name = "EndTimeMinus15Button";
            this.EndTimeMinus15Button.Size = new System.Drawing.Size(35, 23);
            this.EndTimeMinus15Button.TabIndex = 25;
            this.EndTimeMinus15Button.Text = "-15";
            this.EndTimeMinus15Button.UseVisualStyleBackColor = true;
            this.EndTimeMinus15Button.Click += new System.EventHandler(this.EndTimeMinus15Button_Click);
            // 
            // EndTimePlus15Button
            // 
            this.EndTimePlus15Button.Enabled = false;
            this.EndTimePlus15Button.Location = new System.Drawing.Point(275, 93);
            this.EndTimePlus15Button.Name = "EndTimePlus15Button";
            this.EndTimePlus15Button.Size = new System.Drawing.Size(35, 23);
            this.EndTimePlus15Button.TabIndex = 24;
            this.EndTimePlus15Button.Text = "+15";
            this.EndTimePlus15Button.UseVisualStyleBackColor = true;
            this.EndTimePlus15Button.Click += new System.EventHandler(this.EndTimePlus15Button_Click);
            // 
            // EndTimeSetNowButton
            // 
            this.EndTimeSetNowButton.Enabled = false;
            this.EndTimeSetNowButton.Location = new System.Drawing.Point(194, 93);
            this.EndTimeSetNowButton.Name = "EndTimeSetNowButton";
            this.EndTimeSetNowButton.Size = new System.Drawing.Size(75, 23);
            this.EndTimeSetNowButton.TabIndex = 23;
            this.EndTimeSetNowButton.Text = "Now";
            this.EndTimeSetNowButton.UseVisualStyleBackColor = true;
            this.EndTimeSetNowButton.Click += new System.EventHandler(this.EndTimeSetNowButton_Click);
            // 
            // TimeEntryEditForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 166);
            this.ControlBox = false;
            this.Controls.Add(this.EndTimeMinus15Button);
            this.Controls.Add(this.EndTimePlus15Button);
            this.Controls.Add(this.EndTimeSetNowButton);
            this.Controls.Add(this.StartTimeMinus15Button);
            this.Controls.Add(this.StartTimePlus15Button);
            this.Controls.Add(this.StartTimeSetNowButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SetEndField);
            this.Controls.Add(this.EndAMPMField);
            this.Controls.Add(this.EndMinuteField);
            this.Controls.Add(this.EndHourField);
            this.Controls.Add(this.StartAMPMField);
            this.Controls.Add(this.StartMinuteField);
            this.Controls.Add(this.StartHourField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TimeEntryEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Time Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TitleField;
        private System.Windows.Forms.ComboBox StartAMPMField;
        private System.Windows.Forms.ComboBox StartMinuteField;
        private System.Windows.Forms.ComboBox StartHourField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox EndAMPMField;
        private System.Windows.Forms.ComboBox EndMinuteField;
        private System.Windows.Forms.ComboBox EndHourField;
        private System.Windows.Forms.CheckBox SetEndField;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button StartTimeMinus15Button;
        private System.Windows.Forms.Button StartTimePlus15Button;
        private System.Windows.Forms.Button StartTimeSetNowButton;
        private System.Windows.Forms.Button EndTimeMinus15Button;
        private System.Windows.Forms.Button EndTimePlus15Button;
        private System.Windows.Forms.Button EndTimeSetNowButton;
    }
}