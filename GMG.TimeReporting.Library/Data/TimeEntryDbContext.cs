using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GMG.TimeReporting.Library.Data
{
    public partial class TimeEntryDbContext : DbContext
    {
        public TimeEntryDbContext()
            : base("name=TimeEntryDbContext")
        {
        }

        public virtual DbSet<TimeEntry> TimeEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeEntry>()
                .Property(e => e.Title)
                .IsUnicode(false);
        }

        public List<TimeSheetEntry> GetDailyTimesheet(DateTime? date)
        {
            if (!date.HasValue) date = DateTime.Today;
            object[] parameters = new object[] { date };
            var results = this.Database.SqlQuery<TimeSheetEntry>("GetDailyTimesheet", parameters);
            return results.ToList();
        }

        public class TimeSheetEntry
        {
            public string Title { get; set; }

            public decimal? TotalHours { get; set; }
        }
    }
}
