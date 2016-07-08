﻿using EnsureThat;
using System;
using System.Collections.Generic;

namespace SharpGCalendar.Domain.Scheduler
{
    public class DailyScheduler : Scheduler
    {
        public DailyScheduler(int interval) : base(RepeatFrequency.None, interval)
        {
        }

        public override IEnumerable<DateTime> GetOccurrences(DateTime startDate, DateTime endDate)
        {
            Ensure.That(() => endDate).IsGte(startDate);

            List<DateTime> occurrences = new List<DateTime>();

            for (DateTime dateTime = startDate; dateTime < endDate; dateTime = dateTime.AddDays(interval))
            {
                occurrences.Add(dateTime);
            }

            return occurrences;
        }
    }
}
