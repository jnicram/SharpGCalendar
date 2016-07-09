using NUnit.Framework;
using SharpGCalendar.Domain;
using SharpGCalendar.Domain.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpGCalendar.Tests.Scheduler
{
    [TestFixture]
    [Category("WeeklyScheduler")]
    public class WeeklySchedulerTest
    {
        [Test]
        public void ShouldReturnsProperNumberOfOccurrencesWhenRepeatFrequencyIsNone()
        {
            ISchedule scheduler = new WeeklyScheduler(WeeklyRepeatType.None, 1);        
            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 6, 1), new DateTime(2016, 6, 30));

            Assert.AreEqual(5, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 6, 1),
                new DateTime(2016, 6, 8),
                new DateTime(2016, 6, 15),
                new DateTime(2016, 6, 22),
                new DateTime(2016, 6, 29)
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }

        [Test]
        public void ShouldReturnsOnlyOneElementWhenRangeIsSmallerThanInterval()
        {
            ISchedule scheduler = new WeeklyScheduler(WeeklyRepeatType.None, 1);
            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 7, 1), new DateTime(2016, 7, 5));

            Assert.AreEqual(1, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 7, 1)
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }

        [Test]
        public void ShouldReturnsProperNumberOfOccurrencesWhenRepeatFrequencyIsTuesdayAndWednesday()
        {
            ISchedule scheduler = new WeeklyScheduler(WeeklyRepeatType.Tuesday | WeeklyRepeatType.Wednesday, 2);
            IEnumerable<DateTime> occurrences = scheduler.GetOccurrences(new DateTime(2016, 7, 1), new DateTime(2016, 8, 1)).OrderBy(o => o);

            Assert.AreEqual(4, occurrences.Count());

            IEnumerable<DateTime> expectedOccurrences = new List<DateTime>
            {
                new DateTime(2016, 7, 12),
                new DateTime(2016, 7, 13),
                new DateTime(2016, 7, 26),
                new DateTime(2016, 7, 27)
            };

            CollectionAssert.AreEqual(expectedOccurrences, occurrences);
        }   
    }
}
