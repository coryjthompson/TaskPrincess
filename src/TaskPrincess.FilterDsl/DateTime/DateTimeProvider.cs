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
                case "jan":
                case "january":
                    return GetUpcomingMonth(now, Month.January);
                case "feb":
                case "february":
                    return GetUpcomingMonth(now, Month.Febuary);
                case "mar":
                case "march":
                    return GetUpcomingMonth(now, Month.March);
                case "apr":
                case "april":
                    return GetUpcomingMonth(now, Month.April);
                case "may":
                    return GetUpcomingMonth(now, Month.May);
                case "jun":
                case "june":
                    return GetUpcomingMonth(now, Month.June);
                case "jul":
                case "july":
                    return GetUpcomingMonth(now, Month.July);
                case "aug":
                case "august":
                    return GetUpcomingMonth(now, Month.August);
                case "sep":
                case "september":
                    return GetUpcomingMonth(now, Month.September);
                case "oct":
                case "october":
                    return GetUpcomingMonth(now, Month.October);
                case "nov":
                case "november":
                    return GetUpcomingMonth(now, Month.November);
                case "dec":
                case "december":
                    return GetUpcomingMonth(now, Month.December);
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
                case "later":
                case "someday":
                    return new System.DateTime(2038, 01, 18, 0, 0, 0);
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

        protected System.DateTime GetUpcomingMonth(System.DateTime now, Month month)
        {
            now = StartOfMonth(now);

            var diff = (12 + ((int)month - now.Month)) % 12;
            diff = (diff == 0) ? 12 : diff;

            return now.AddMonths(diff);
        }
        
        protected System.DateTime StartOfMonth(System.DateTime date) 
        {
            return new System.DateTime(date.Year, date.Month, 1);
        }
    }
}
