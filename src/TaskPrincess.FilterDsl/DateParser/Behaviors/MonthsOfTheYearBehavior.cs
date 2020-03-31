using System;
using TaskPrincess.FilterDsl.DateParser.Extensions;
using TaskPrincess.FilterDsl.DateParser.Interfaces;

namespace TaskPrincess.FilterDsl.DateParser.Behaviors
{
    /// <summary>
    /// Parses a named month of the year (e.g. "january") into the the closest future date.
    /// If the input month matches the current month, the following month will be returned.
    /// The time will be returned as 00:00:00 local and the date the first of the month.
    /// Handles three letter abbreviations and full month name.
    /// </summary>
    public class MonthsOfTheYearBehavior : IDateParserBehavior
    {
        public DateTime? Parse(string namedDate, DateTime now, DateParserConfig config)
        {
            switch (namedDate.ToLower())
            {
                case "jan":
                case "january":
                    return now.NextMonth(Month.January);
                case "feb":
                case "february":
                    return now.NextMonth(Month.Febuary);
                case "mar":
                case "march":
                    return now.NextMonth(Month.March);
                case "apr":
                case "april":
                    return now.NextMonth(Month.April);
                case "may":
                    return now.NextMonth(Month.May);
                case "jun":
                case "june":
                    return now.NextMonth(Month.June);
                case "jul":
                case "july":
                    return now.NextMonth(Month.July);
                case "aug":
                case "august":
                    return now.NextMonth(Month.August);
                case "sep":
                case "september":
                    return now.NextMonth(Month.September);
                case "oct":
                case "october":
                    return now.NextMonth(Month.October);
                case "nov":
                case "november":
                    return now.NextMonth(Month.November);
                case "dec":
                case "december":
                    return now.NextMonth(Month.December);
                default:
                    return null;
            }
        }
    }
}
