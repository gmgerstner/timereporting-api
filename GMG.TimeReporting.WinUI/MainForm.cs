using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GMG.TimeReporting.Library;
using GMG.TimeReporting.Library.Data;

namespace GMG.TimeReporting.WinUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeStartTime();
        }

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshTitleField();
            RefreshSchedule();
            RefreshTimesheet();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var dt = GetStartDateTime();
            SetCurrentTask(TitleField.Text, dt);
            RefreshTitleField();
            RefreshSchedule();
            RefreshTimesheet();

            //MessageBox.Show(
            //    this,
            //    $"Current Task: {TitleField.Text}, Started at: {dt.TimeOfDay}",
            //    "Task Set",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
        }

        private void SetNowButton_Click(object sender, EventArgs e)
        {
            SetStartDateTime();
        }

        private void ScheduleListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshButtonAvailability();
        }

        private void RefreshButtonAvailability()
        {
            if (ScheduleListView.SelectedItems.Count > 0)
            {
                ResumeSelectedButton.Enabled = true;
                EditSelectedButton.Enabled = true;
                DeleteSelectedButton.Enabled = true;
            }
            else
            {
                ResumeSelectedButton.Enabled = false;
                EditSelectedButton.Enabled = false;
                DeleteSelectedButton.Enabled = false;
            }
        }

        private void ResumeSelectedButton_Click(object sender, EventArgs e)
        {
            if (ScheduleListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Select an item to resume", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var li = ScheduleListView.SelectedItems[0];
            var title = li.SubItems[1].Text;
            SetCurrentTask(title);
            RefreshSchedule();
            RefreshTimesheet();
        }

        private void EditSelectedButton_Click(object sender, EventArgs e)
        {
            if (ScheduleListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Select an item to edit", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var li = ScheduleListView.SelectedItems[0];
            var id = int.Parse(li.SubItems[0].Text);
            using (var db = new TimeEntryDbContext())
            {
                var frm = new TimeEntryEditForm();
                frm.TimeEntry = db.TimeEntries.Single(te => te.TimeEntryId == id);
                frm.Populate();
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    frm.Collect();
                    db.SaveChanges();
                    RefreshSchedule();
                    RefreshTimesheet();
                }
            }
        }

        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            if (ScheduleListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Select an item to delete", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var li = ScheduleListView.SelectedItems[0];
            var id = int.Parse(li.SubItems[0].Text);
            DeleteTimeEntry(id);
        }

        private void RefreshScheduleButton_Click(object sender, EventArgs e)
        {
            RefreshSchedule();
            RefreshTimesheet();
        }

        private void StopClockButton_Click(object sender, EventArgs e)
        {
            var endTime = GetStartDateTime();
            StopClock(endTime);
            RefreshScheduleButton_Click(sender, e);
        }

        private void ScheduleListView_DoubleClick(object sender, EventArgs e)
        {
            if (ScheduleListView.SelectedItems.Count > 0)
            {
                EditSelectedButton_Click(sender, e);
            }
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
            SetStartDateTime();
        }

        private void RefreshSchedule()
        {
            ScheduleListView.Items.Clear();
            using (var db = new TimeEntryDbContext())
            {
                var list = db.TimeEntries
                     .Where(te => te.StartTime >= DateTime.Today)
                     .OrderBy(te => te.StartTime)
                     .ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    var endTime = "";
                    if (item.EndTime.HasValue)
                    {
                        endTime = item.EndTime.Value.TimeOfDay.ToString();
                    }
                    else if (i + 1 < list.Count)
                    {
                        endTime = list[i + 1].StartTime.TimeOfDay.ToString();
                    }
                    var li = new ListViewItem(new string[]
                        {
                            item.TimeEntryId.ToString(),
                            item.Title,
                            item.StartTime.TimeOfDay.ToString(),
                            endTime
                        });
                    if (i % 2 == 0) li.BackColor = Color.LightGray;
                    ScheduleListView.Items.Add(li);

                }
            }
        }

        private void RefreshTimesheet()
        {
            TimeSheetListView.Items.Clear();
            decimal totalHours = 0.0m;
            using (var db = new TimeEntryDbContext())
            {
                var list = db.GetDailyTimesheet(DateTime.Today);
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    var li = new ListViewItem(new string[]
                    {
                            item.Title,
                            item.TotalHours?.ToString("0.00")
                    });
                    if (item.TotalHours.HasValue)
                        totalHours += item.TotalHours.Value;
                    if (i % 2 == 0) li.BackColor = Color.LightGray;
                    TimeSheetListView.Items.Add(li);
                }
            }
            TotalHoursField.Text = totalHours.ToString("0.00");
            RefreshButtonAvailability();
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

        private DateTime GetStartDateTime()
        {
            var text = $"{DateTime.Today.ToShortDateString()} {StartHourField.Text}:{StartMinuteField.Text} {StartAMPMField.Text}";
            var dt = DateTime.Parse(text);
            return dt;
        }

        private void SetStartDateTime()
        {
            var dt = DateTime.Now.RoundToNearestQuarter();
            SetTimeDisplay(dt);
        }

        private void SetTimeDisplay(DateTime dt)
        {
            var mins = dt.TimeOfDay.Minutes.ToString();
            if (mins.Length == 1) mins = "0" + mins;
            StartMinuteField.Text = mins;

            if (dt.TimeOfDay.Hours == 0)
            {
                StartAMPMField.Text = "AM";
                StartHourField.Text = "12";
            }
            else if (dt.TimeOfDay.Hours <= 12)
            {
                StartAMPMField.Text = dt.TimeOfDay.Hours == 12 ? "PM" : "AM";
                StartHourField.Text = dt.TimeOfDay.Hours.ToString();
            }
            else
            {
                StartAMPMField.Text = "PM";
                StartHourField.Text = (dt.TimeOfDay.Hours - 12).ToString();
            }
        }

        private void SetCurrentTask(string title, DateTime? startTime = null)
        {
            using (var db = new TimeEntryDbContext())
            {
                if (!startTime.HasValue)
                {
                    startTime = DateTime.Now.RoundToNearestQuarter();
                }
                else
                {
                    startTime = startTime?.RoundToNearestQuarter();
                }
                var te = new TimeEntry
                {
                    StartTime = startTime.Value,
                    EndTime = null,
                    Title = title,
                };
                db.TimeEntries.Add(te);
                db.SaveChanges();
            }
        }

        private void StopClock(DateTime? endTime = null)
        {
            if (!endTime.HasValue) endTime = DateTime.Now.RoundToNearestQuarter();
            using (var db = new TimeEntryDbContext())
            {
                var lastid = db.TimeEntries.OrderByDescending(te => te.StartTime).First().TimeEntryId;
                var timeEntry = db.TimeEntries.Find(lastid);
                timeEntry.EndTime = endTime.Value;
                db.SaveChanges();
                RefreshSchedule();
            }
        }

        private void DeleteTimeEntry(int id)
        {
            using (var db = new TimeEntryDbContext())
            {
                var item = db.TimeEntries.Where(te => te.TimeEntryId == id).Single();
                db.TimeEntries.Remove(item);
                db.SaveChanges();
                RefreshSchedule();
            }
        }

        #endregion

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //https://www.c-sharpcorner.com/UploadFile/f9f215/how-to-minimize-your-application-to-system-tray-in-C-Sharp/
            //if the form is minimized  
            //hide it from the task bar  
            //always show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                //NotifyIcon.Visible = true;
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            //NotifyIcon.Visible = false;
        }

        private void Plus15Button_Click(object sender, EventArgs e)
        {
            var dt = GetStartDateTime().RoundToNearestQuarter();
            dt = dt.AddMinutes(15);
            SetTimeDisplay(dt);
        }

        private void Minus15Button_Click(object sender, EventArgs e)
        {
            var dt = GetStartDateTime().RoundToNearestQuarter();
            dt = dt.AddMinutes(-15);
            SetTimeDisplay(dt);
        }

        private void TimeSheetListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TimeSheetListView.SelectedItems.Count == 1)
            {
                CopySelectedTimesheetItemButton.Enabled = true;
            }
            else
            {
                CopySelectedTimesheetItemButton.Enabled = false;
            }
        }

        private void CopySelectedTimesheetItemButton_Click(object sender, EventArgs e)
        {
            if (TimeSheetListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Select an item to copy", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var li = TimeSheetListView.SelectedItems[0];
            var title = li.SubItems[0].Text;
            //Clipboard.SetText(title);
            Clipboard.Clear();
            Clipboard.SetData(DataFormats.Text, title);
            //MessageBox.Show(this, "Item copied", "Item copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
