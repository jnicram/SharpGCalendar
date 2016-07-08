using NUnit.Framework;
using SharpGCalendar.Domain;
using SharpGCalendar.Domain.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGCalendar.Tests.Scheduler
{
    [TestFixture]
    [Category("MonthlyScheduler")]
    public class MonthlySchedulerTest
    {
        [Test]
        public void ShouldReturnsDatesWithTheSameDayInJulyAndSeptember()
        {
            ISchedule scheduler = new MonthlyScheduler(RepeatFrequency.DayOfMonth, 2);
            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 7, 7), new DateTime(2016, 11, 1));

            Assert.AreEqual(2, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 7, 7),
                new DateTime(2016, 9, 7)
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }

        [Test]
        public void ShouldReturnsFirstThursdayInJulyAndSeptember()
        {
            ISchedule scheduler = new MonthlyScheduler(RepeatFrequency.DayOfWeek, 2);
            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 7, 7), new DateTime(2016, 11, 1));

            Assert.AreEqual(2, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 7, 7), // first Thursday in July
                new DateTime(2016, 9, 1)  // first Thursday in September
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }
    }
}
