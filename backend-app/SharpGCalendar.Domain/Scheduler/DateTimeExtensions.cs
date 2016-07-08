using System;

namespace SharpGCalendar.Domain.Scheduler
{
    public static class DateTimeExtensions
    {
        ///<summary>Gets the first week day following a date.</summary>
        ///<param name="date">The date.</param>
        ///<param name="dayOfWeek">The day of week to return.</param>
        ///<returns>The first dayOfWeek day following date, or date if it is on dayOfWeek.</returns>
        ////
        public static DateTime Next(this DateTime date, DayOfWeek dayOfWeek)
        {
            return date.AddDays((dayOfWeek < date.DayOfWeek ? 7 : 0) + dayOfWeek - date.DayOfWeek);
        }

        ///<summary>Gets the next week day following a date.</summary>
        ///<param name="date">The date.</param>
        ///<param name="dayOfWeek">The day of week to return.</param>
        ///<param name="nth">The number of nth day.</param>
        ///<returns>The next dayOfWeek day following date.</returns>
        ////
        public static DateTime GetNthWeekday(this DateTime date, DayOfWeek dayOfWeek, int nth)
        {
            int daysToAdd = ((int)dayOfWeek - (int)date.DayOfWeek + 7) % 7;

            return date.AddDays(daysToAdd).AddDays(Math.Abs(nth - 1) * 7);
        }
    }
}
