using System;

namespace TaskPrincess.FilterDsl.DateTime
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public System.DateTime Parse(string dateTime)
        {
            var now = Now();
            switch (dateTime.ToLower())
            {
                case "mon":
                case "monday":
                    return GetNextDayOfWeek(now, DayOfWeek.Monday);
                case "tue":
                case "tuesday":
                    return GetNextDayOfWeek(now, DayOfWeek.Tuesday);
                case "wed":
                case "wednesday":
                    return GetNextDayOfWeek(now, DayOfWeek.Wednesday);
                case "thu":
                case "thursday":
                    return GetNextDayOfWeek(now, DayOfWeek.Thursday);
                case "fri":
                case "friday":
                    return GetNextDayOfWeek(now, DayOfWeek.Friday);
                case "sat":
                case "saturday":
                    return GetNextDayOfWeek(now, DayOfWeek.Saturday);
                case "sun":
                case "sunday":
                    return GetNextDayOfWeek(now, DayOfWeek.Sunday);
                default:
                    break;
            }

            throw new Exception();
        }

        protected virtual System.DateTime Now()
        {
            return System.DateTime.Now;
        }

        protected System.DateTime GetNextDayOfWeek(System.DateTime now, DayOfWeek day)
        {
            var diff = (7 + (day - now.DayOfWeek)) % 7;
            diff = (diff == 0) ? 7 : diff;
            return now.AddDays(diff).Date; //Date will ensure sod
        }
    }
}
