using System;

namespace SharpGCalendar.Domain
{
    [Flags]
    public enum RepeatFrequency
    {
        None = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64,
        DayOfMonth = 128,
        DayOfWeek = 256
    }
}
