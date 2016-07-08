using NUnit.Framework;
using SharpGCalendar.Domain;
using SharpGCalendar.Domain.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpGCalendar.Tests.Scheduler
{
    [TestFixture]
    [Category("YearlyScheduler")]
    public class YearlySchedulerTest
    {
        [Test]
        public void ShouldThrowsExceptionWhenIncorrectDatesGiven()
        {
            ISchedule scheduler = new YearlyScheduler(1);

            Assert.Throws<ArgumentException>(() => scheduler.GetOccurrences(new DateTime(2016, 7, 7), new DateTime(2016, 6, 8)));
        }

        [Test]
        public void ShouldReturnsOneDateInYear()
        {
            ISchedule scheduler = new YearlyScheduler(1);       
            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 7, 7), new DateTime(2017, 2, 7));

            Assert.AreEqual(1, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 7, 7)
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }

        [Test]
        public void ShouldReturnsFiveDatesInThirtyFourYearsRangeWithSevenYearsInterval()
        {
            ISchedule scheduler = new YearlyScheduler(7);
            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 1, 1), new DateTime(2050, 1, 1));

            Assert.AreEqual(5, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 1, 1),
                new DateTime(2023, 1, 1),
                new DateTime(2030, 1, 1),
                new DateTime(2037, 1, 1),
                new DateTime(2044, 1, 1)
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }
    }
}
