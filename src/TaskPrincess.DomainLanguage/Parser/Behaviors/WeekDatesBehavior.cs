using System;
using TaskPrincess.DomainLanguage.Parser.Extensions;
using TaskPrincess.DomainLanguage.Parser.Interfaces;
using TaskPrincess.DomainLanguage.Parser.Models;

namespace TaskPrincess.DomainLanguage.Parser.Behaviors
{
    /// <summary>
    /// Week named Dates are calculated bounderies of dates that occur within a week.
    /// This includes start of week, start of day, etc
    /// </summary>
    public class WeekDatesBehavior : IDateParserBehavior
    {
        public DateTime? Parse(string namedDate, DateTime now, DateParserConfig config)
        {
            switch (namedDate.ToLower())
            {
                case "socw":
                    return now.NextDayOfWeek(config.StartOfWeek).AddDays(-7);
                case "sow":
                    return now.NextDayOfWeek(config.StartOfWeek);
                case "soww":
                    return now.NextDayOfWeek(config.StartOfWorkWeek);
                case "eoww":
                    return now.NextDayOfWeek(config.EndOfWorkWeek).EndOfDay();
                case "eocw":
                case "eow":
                    return now.NextDayOfWeek(config.EndOfWeek).EndOfDay();
                case "sod":
                case "today":
                    return now.StartOfDay();
                case "eod":
                    return now.EndOfDay();
                case "yesterday":
                    return now.AddDays(-1).StartOfDay();
                case "now":
                    return now;
                default:
                    return null;
            }
        }
    }
}
