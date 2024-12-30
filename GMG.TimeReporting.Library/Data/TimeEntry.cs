using System;
using System.ComponentModel.DataAnnotations;

namespace GMG.TimeReporting.Library.Data
{
    public partial class TimeEntry
    {
        public int TimeEntryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
