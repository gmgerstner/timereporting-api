using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using GMG.TimeReporting.Core;
using GMG.TimeReporting.Core.TimeReportingData;

namespace GMG.TimeReporting.UnitTests
{
    public class CoreTests
    {
        private TimeReportingContext context;


        [SetUp]
        public void Setup()
        {
            DbContextOptions<TimeReportingContext> options = new DbContextOptionsBuilder<TimeReportingContext>()
                .UseSqlServer("Data Source=darmik;User ID=sa;Password=*******!;Initial Catalog=TimeReporting;")
                .Options;
            context = new TimeReportingContext(options);
        }

        [Test]
        public void LastFewTimeEntries()
        {
            int cnt = context.TimeEntries.Count();
            Assert.IsTrue(cnt > 0);
        }

        [Test]
        public void RulesTest()
        {
            var dt1 = new DateTime(2021, 1, 1, 11, 15, 0);//11:15 AM
            var dt2 = new DateTime(2021, 1, 1, 11, 18, 0);//11:18 AM
            var dt3 = Rules.RoundToNearestQuarter(dt2);
            Assert.AreEqual(dt1, dt3);
        }
    }
}