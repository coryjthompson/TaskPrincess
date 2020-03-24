using System;

namespace TaskPrincess.FilterDsl.DateTime
{
    public class DateTimeProvider : IDateTimeProvider
    {
        private readonly DayOfWeek _weekStart;
        private readonly DayOfWeek _weekEnd;

        public DateTimeProvider(string weekStart)
        {
            if (weekStart.ToLower().StartsWith("mon"))
            {
                _weekStart = DayOfWeek.Monday;
                _weekEnd = DayOfWeek.Sunday;
            }
            else
            {
                _weekStart = DayOfWeek.Sunday;
                _weekEnd = DayOfWeek.Saturday;
            }
        }

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
                case "socw":
                    return GetPreviousDayOfWeek(now, _weekStart);
                case "sow":
                    return GetNextDayOfWeek(now, _weekStart);
                case "soww":
                    return GetNextDayOfWeek(now, DayOfWeek.Monday);
                case "eoww":
                    return GetNextDayOfWeek(now, DayOfWeek.Friday);
                case "eocw":
                case "eow":
                    return EndOfDay(GetNextDayOfWeek(now, _weekEnd));
                case "sod":
                case "today":
                    return StartOfDay(now);
                case "eod":
                    return EndOfDay(now);
                case "yesterday":
                    return Yesterday(now);
                case "now":
                    return now;
                default:
                    break;
            }

            throw new Exception();
        }

        protected virtual System.DateTime Now()
        {
            return System.DateTime.Now;
        }

        protected System.DateTime Yesterday(System.DateTime now) 
        {
            return now.AddDays(-1).Date;
        }

        protected System.DateTime StartOfDay(System.DateTime now)
        {
            return now.Date;
        }

        protected System.DateTime EndOfDay(System.DateTime now)
        {
            return now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }
        protected System.DateTime GetPreviousDayOfWeek(System.DateTime now, DayOfWeek day)
        {
            var diff = (7 + (now.DayOfWeek - day)) % 7;
            return now.AddDays(diff * -1).Date;
        }

        protected System.DateTime GetNextDayOfWeek(System.DateTime now, DayOfWeek day)
        {
            var diff = (7 + (day - now.DayOfWeek)) % 7;
            diff = (diff == 0) ? 7 : diff;
            return now.AddDays(diff).Date; //Date will ensure sod
        }
    }
}
