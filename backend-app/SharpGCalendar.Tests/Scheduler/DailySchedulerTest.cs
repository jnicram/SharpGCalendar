using System;
using NUnit.Framework;
using SharpGCalendar.Domain.Scheduler;
using SharpGCalendar.Domain;
using System.Linq;
using System.Collections.Generic;

namespace SharpGCalendar.Scheduler.Tests
{
    [TestFixture]
    [Category("DailyScheduler")]
    public class DailySchedulerTest
    {
        [Test]
        public void ShouldThrowsExceptionDuringSchedulerCreation()
        {
            Assert.Throws<ArgumentException>(() => new DailyScheduler(0));
        }

        [Test]
        public void ShouldThrowsExceptionWhenIncorrectDatesGiven()
        {
            ISchedule scheduler = new DailyScheduler(1);

            Assert.Throws<ArgumentException>(() => scheduler.GetOccurrences(new DateTime(2016, 7, 7), new DateTime(2016, 6, 8)));
        }

        [Test]
        public void ShouldReturnsOneDateInOneDayRange()
        {
            ISchedule scheduler = new DailyScheduler(1);
            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 7, 7), new DateTime(2016, 7, 8));

            Assert.AreEqual(1, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 7, 7)
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }

        [Test]
        public void ShouldReturnsTwoDatesInTwoDaysRange()
        {
            ISchedule scheduler = new DailyScheduler(1);
            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 7, 7), new DateTime(2016, 7, 9));

            Assert.AreEqual(2, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 7, 7),
                new DateTime(2016, 7, 8)
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }

        [Test]
        public void ShouldReturnsThreeDatesInDaysRangeWithThreeDaysInterval()
        {
            ISchedule scheduler = new DailyScheduler(3);
            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 7, 7), new DateTime(2016, 7, 15));

            Assert.AreEqual(3, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 7, 7),
                new DateTime(2016, 7, 10),
                new DateTime(2016, 7, 13)
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }
    }
}
