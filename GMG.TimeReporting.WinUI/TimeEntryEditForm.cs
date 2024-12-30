using System;
using System.Linq;
using System.Windows.Forms;
using GMG.TimeReporting.Library;
using GMG.TimeReporting.Library.Data;

namespace GMG.TimeReporting.WinUI
{
    public partial class TimeEntryEditForm : Form
    {
        public TimeEntry TimeEntry { get; set; }

        public TimeEntryEditForm()
        {
            InitializeComponent();
            InitializeStartTime();
            InitializeEndTime();
            RefreshTitleField();
        }

        #region Events

        private void SetEndField_CheckedChanged(object sender, EventArgs e)
        {
            var value = SetEndField.Checked;
            EndHourField.Enabled = value;
            EndMinuteField.Enabled = value;
            EndAMPMField.Enabled = value;
            EndTimeSetNowButton.Enabled = value;
            EndTimePlus15Button.Enabled = value;
            EndTimeMinus15Button.Enabled = value;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region Logic

        private void InitializeStartTime()
        {
            for (int i = 0; i < 12; i++)
            {
                StartHourField.Items.Add(i + 1);
            }
            StartMinuteField.Items.Add("00");
            StartMinuteField.Items.Add("15");
            StartMinuteField.Items.Add("30");
            StartMinuteField.Items.Add("45");
            StartAMPMField.Items.Add("AM");
            StartAMPMField.Items.Add("PM");
        }
        private void InitializeEndTime()
        {
            for (int i = 0; i < 12; i++)
            {
                EndHourField.Items.Add(i + 1);
            }
            EndMinuteField.Items.Add("00");
            EndMinuteField.Items.Add("15");
            EndMinuteField.Items.Add("30");
            EndMinuteField.Items.Add("45");
            EndAMPMField.Items.Add("AM");
            EndAMPMField.Items.Add("PM");
        }

        public void Populate()
        {
            //title
            TitleField.Text = TimeEntry.Title;

            //start
            PopulateStartTime(TimeEntry.StartTime);

            //end
            if (!TimeEntry.EndTime.HasValue)
            {
                SetEndField.Checked = false;
                PopulateEndTime(DateTime.Now.RoundToNearestQuarter());
            }
            else
            {
                SetEndField.Checked = true;
                PopulateEndTime(TimeEntry.EndTime.Value);
            }
        }

        private void PopulateStartTime(DateTime startTime)
        {
            if (startTime.Hour == 0)
            {
                StartHourField.Text = "12";
                StartAMPMField.Text = "AM";
            }
            else if (startTime.Hour < 12)
            {
                StartHourField.Text = startTime.Hour.ToString().PadLeft(2, '0');
                StartAMPMField.Text = "AM";
            }
            else
            {
                StartHourField.Text = (startTime.Hour - 12).ToString().PadLeft(2, '0');
                StartAMPMField.Text = "PM";
            }
            StartMinuteField.Text = startTime.Minute.ToString().PadLeft(2, '0');
        }

        private void PopulateEndTime(DateTime dateTime)
        {
            if (dateTime.Hour == 0)
            {
                SetEndField.Checked = true;
                EndHourField.Text = "12";
                EndAMPMField.Text = "AM";
            }
            else if (dateTime.Hour < 12)
            {
                EndHourField.Text = dateTime.Hour.ToString().PadLeft(2, '0');
                EndAMPMField.Text = "AM";
            }
            else
            {
                EndHourField.Text = (dateTime.Hour - 12).ToString().PadLeft(2, '0');
                EndAMPMField.Text = "PM";
            }
            EndMinuteField.Text = dateTime.Minute.ToString().PadLeft(2, '0');
        }

        public void Collect()
        {
            //title
            TimeEntry.Title = TitleField.Text;

            //start
            TimeEntry.StartTime = GetStartDateTime();

            //end
            TimeEntry.EndTime = GetEndDateTime();
        }

        private DateTime GetStartDateTime()
        {
            var text = $"{DateTime.Today.ToShortDateString()} {StartHourField.Text}:{StartMinuteField.Text} {StartAMPMField.Text}";
            var dt = DateTime.Parse(text);
            return dt;
        }

        private DateTime? GetEndDateTime()
        {
            if (SetEndField.Checked)
            {
                var text = $"{DateTime.Today.ToShortDateString()} {EndHourField.Text}:{EndMinuteField.Text} {EndAMPMField.Text}";
                var dt = DateTime.Parse(text);
                return dt;
            }
            else
            {
                return null;
            }
        }

        private void RefreshTitleField()
        {
            using (var db = new TimeEntryDbContext())
            {
                var oldestLastStarted = DateTime.Today.AddDays(-7 * 4);
                var list = db.TimeEntries
                    .GroupBy(te => new
                    {
                        te.Title
                    })
                    .Select(te => new
                    {
                        te.Key.Title,
                        LastStarted = te.Max(t => t.StartTime)
                    })
                    .Where(te => te.LastStarted >= oldestLastStarted)
                    .OrderByDescending(te => te.LastStarted)
                    .ToList();

                TitleField.Items.Clear();
                foreach (var item in list)
                {
                    TitleField.Items.Add(item.Title);
                }
            }
            TitleField.SelectedIndex = 0;
        }

        #endregion

        private void StartTimeSetNowButton_Click(object sender, EventArgs e)
        {
            PopulateStartTime(DateTime.Now.RoundToNearestQuarter());
        }

        private void EndTimeSetNowButton_Click(object sender, EventArgs e)
        {
            PopulateEndTime(DateTime.Now.RoundToNearestQuarter());
        }

        private void StartTimePlus15Button_Click(object sender, EventArgs e)
        {
            var dt = GetStartDateTime().RoundToNearestQuarter();
            dt = dt.AddMinutes(15);
            PopulateStartTime(dt);
        }

        private void StartTimeMinus15Button_Click(object sender, EventArgs e)
        {
            var dt = GetStartDateTime().RoundToNearestQuarter();
            dt = dt.AddMinutes(-15);
            PopulateStartTime(dt);
        }

        private void EndTimePlus15Button_Click(object sender, EventArgs e)
        {
            var dt = GetEndDateTime().Value.RoundToNearestQuarter();
            dt = dt.AddMinutes(15);
            PopulateEndTime(dt);
        }

        private void EndTimeMinus15Button_Click(object sender, EventArgs e)
        {
            var dt = GetEndDateTime().Value.RoundToNearestQuarter();
            dt = dt.AddMinutes(-15);
            PopulateEndTime(dt);
        }
    }
}
