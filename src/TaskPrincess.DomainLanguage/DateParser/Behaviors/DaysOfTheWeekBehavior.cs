using System;
using TaskPrincess.DomainLanguage.DateParser.Extensions;
using TaskPrincess.DomainLanguage.DateParser.Interfaces;

namespace TaskPrincess.DomainLanguage.DateParser.Behaviors
{
    /// <summary>
    /// Parses a named day of the week (e.g. "monday") into the the closest future date.
    /// If input day of the week matches current day of the week the following week day will be returned.
    /// The time will be returned as 00:00:00 local.
    /// Handles three letter abbreviations and full day name
    /// </summary>
    public class DaysOfTheWeekBehavior : IDateParserBehavior
    {
        public DateTime? Parse(string namedDate, DateTime now, DateParserConfig config)
        {
            switch (namedDate.ToLower())
            {
                case "mon":
                case "monday":
                    return now.NextDayOfWeek(DayOfWeek.Monday);
                case "tue":
                case "tuesday":
                    return now.NextDayOfWeek(DayOfWeek.Tuesday);
                case "wed":
                case "wednesday":
                    return now.NextDayOfWeek(DayOfWeek.Wednesday);
                case "thu":
                case "thursday":
                    return now.NextDayOfWeek(DayOfWeek.Thursday);
                case "fri":
                case "friday":
                    return now.NextDayOfWeek(DayOfWeek.Friday);
                case "sat":
                case "saturday":
                    return now.NextDayOfWeek(DayOfWeek.Saturday);
                case "sun":
                case "sunday":
                    return now.NextDayOfWeek(DayOfWeek.Sunday);
                default:
                    return null;
            }
        }
    }
}
