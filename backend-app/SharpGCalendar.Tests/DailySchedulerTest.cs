using System;
using NUnit.Framework;
using SharpGCalendar.Domain.Scheduler;
using SharpGCalendar.Domain;
using System.Linq;
using System.Collections.Generic;

namespace SharpGCalendar.Tests
{
    [TestFixture]
    public class DailySchedulerTest
    {
        [Test]
        public void ShouldThrowsExceptionDuringSchedulerCreation()
        {
            Assert.Throws<ArgumentException>(() => new DailyScheduler(FrequencyPart.None, 0));
        }

        [Test]
        public void ShouldThrowsExceptionWhenIncorrectDatesGiven()
        {
            DailyScheduler scheduler = new DailyScheduler(FrequencyPart.None, 1);

            Assert.Throws<ArgumentException>(() => scheduler.GetOccurrences(new DateTime(2016, 7, 7), new DateTime(2016, 6, 8)));
        }

        [Test]
        public void ShouldReturnsOneEventInOneDayRange()
        {
            DailyScheduler scheduler = new DailyScheduler(FrequencyPart.None, 1);

            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 7, 7), new DateTime(2016, 7, 8));

            Assert.AreEqual(1, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 7, 7)
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }

        [Test]
        public void ShouldReturnsTwoEventsInTwoDaysRange()
        {
            DailyScheduler scheduler = new DailyScheduler(FrequencyPart.None, 1);

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
        public void ShouldReturnsThreeEventsInDaysRangeWithThreeDaysInterval()
        {
            DailyScheduler scheduler = new DailyScheduler(FrequencyPart.None, 3);

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
