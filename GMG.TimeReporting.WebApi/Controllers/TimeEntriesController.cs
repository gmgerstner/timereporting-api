using GMG.TimeReporting.Core.TimeReportingData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GMG.TimeReporting.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TimeEntriesController : ControllerBase
    {
        private TimeReportingContext context;

        public TimeEntriesController(TimeReportingContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("StartClock")]
        public int StartClock(string Title, DateTime Time)
        {
            var data = new TimeEntry
            {
                Title = Title,
                StartTime = Time,
                EndTime = null
            };
            context.TimeEntries.Add(data);
            context.SaveChanges();
            return data.TimeEntryId;
        }

        [HttpPost]
        [Route("StopClock")]
        public void StopClock(DateTime Time)
        {
            var data = context.TimeEntries
                .Where(te => te.StartTime >= DateTime.Today)
                .OrderByDescending(te => te.StartTime)
                .First();
            data.EndTime = Time;
            context.SaveChanges();
        }

        [HttpGet]
        [Route("GetTimeEntry")]
        public TimeEntry GetTimeEntry(int id)
        {
            var data = context.TimeEntries.First(te => te.TimeEntryId == id);
            return data;
        }

        [HttpPost]
        [Route("EditTimeEntry")]
        public void EditTimeEntry(int id, string Title, DateTime StartTime, DateTime? EndTime)
        {
            var data = context.TimeEntries.First(te => te.TimeEntryId == id);
            data.Title = Title;
            data.StartTime = StartTime;
            data.EndTime = EndTime;
            context.SaveChanges();
        }

        [HttpDelete]
        [Route("DeleteTimeEntry")]
        public void DeleteTimeEntry(int id)
        {
            var item = context.TimeEntries.Where(te => te.TimeEntryId == id).Single();
            context.TimeEntries.Remove(item);
            context.SaveChanges();
        }

        [HttpGet]
        [Route("GetSchedule")]
        public IEnumerable<TimeEntry> GetSchedule(DateTime? WorkDate = null)
        {
            if (!WorkDate.HasValue) WorkDate = DateTime.Today;
            WorkDate = WorkDate.Value.Date;

            var list = context.TimeEntries
                 .Where(te => te.StartTime >= WorkDate)
                 .OrderBy(te => te.StartTime)
                 .ToList();
            return list;
        }

        [HttpGet]
        [Route("GetDailyTimeSheet")]
        public IEnumerable<TimeReportingContext.TimeSheetEntry> GetDailyTimeSheet(DateTime? WorkDate = null)
        {
            if (!WorkDate.HasValue) WorkDate = DateTime.Today;
            var results = context.GetDailyTimesheet(WorkDate);
            return results.ToList();
        }

        [HttpGet]
        [Route("GetRecentTitles")]
        public IEnumerable<string> GetRecentTitles()
        {
            var cutOff = DateTime.Today.AddDays(-21);
            var favorites = context.CommonTasks.Select(r => r.Title).OrderBy(r => r).ToList();
            var today = DateTime.Now;
            var list = context.TimeEntries
                .Where(te => te.StartTime >= cutOff)
                .Where(te => !favorites.ToList().Contains(te.Title))
                .GroupBy(te => new { te.Title })
                .Select(te => new
                {
                    Title = te.Key.Title,
                    LastStartTime = te.Max(te1 => te1.StartTime)
                })
                .ToList();
            var recent = list
                .OrderByDescending(te => te.LastStartTime)
                .ThenBy(te => te.Title)
                .Select(te => te.Title)
                .ToList();
            return recent;
        }

        [HttpGet]
        [Route("GetCommonTitles")]
        public IEnumerable<string> GetCommonTitles()
        {
            var favorites = context.CommonTasks.Select(r => r.Title).OrderBy(r => r).ToList();
            return favorites;
        }
    }
}
