using System;
using TaskPrincess.DomainLanguage.Parser.Models;

namespace TaskPrincess.DomainLanguage.Parser.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfDay(this DateTime value)
        {
            return value.Date;
        }

        public static DateTime EndOfDay(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 23, 59, 59);
        }

        public static DateTime NextDayOfWeek(this DateTime value, DayOfWeek? day = null)
        {
            value = value.AddDays(1);

            if (day.HasValue)
            {
                var diff = (7 + (day.Value - value.DayOfWeek)) % 7;
                value = value.AddDays(diff);
            }

            return value.Date;
        }

        public static DateTime StartOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }

        public static DateTime EndOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.DaysInMonth(), 23, 59, 59);
        }

        public static DateTime NextMonth(this DateTime value, Month? month = null)
        {
            value = value.AddMonths(1);
            if (month.HasValue)
            {
                var diff = (12 + ((int)month - value.Month)) % 12;
                value = value.AddMonths(diff);
            }

            return value.StartOfMonth();
        }

        public static int DaysInMonth(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }

        public static DateTime StartOfQuarter(this DateTime value)
        {
            var month = (3 * (value.CurrentQuarter() - 1)) + 1;
            return new DateTime(value.Year, month, 1);
        }

        public static DateTime EndOfQuarter(this DateTime value)
        {
            var month = 3 * value.CurrentQuarter();
            return new DateTime(value.Year, month, DateTime.DaysInMonth(value.Year, month), 23, 59, 59);
        }

        public static int CurrentQuarter(this DateTime now)
        {
            return (now.Month + 2) / 3;
        }

        public static DateTime StartOfYear(this DateTime value)
        {
            return new DateTime(value.Year, 1, 1);
        }

        public static DateTime EndOfYear(this DateTime value)
        {
            return new DateTime(value.Year, 12, 31, 23, 59, 59);
        }
    }
}
