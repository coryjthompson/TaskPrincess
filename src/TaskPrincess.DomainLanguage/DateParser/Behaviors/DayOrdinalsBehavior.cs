using System;
using System.Text.RegularExpressions;
using TaskPrincess.DomainLanguage.DateParser.Extensions;
using TaskPrincess.DomainLanguage.DateParser.Interfaces;

namespace TaskPrincess.DomainLanguage.DateParser.Behaviors
{
    /// <summary>
    /// </summary>
    public class DayOrdinalsBehavior : IDateParserBehavior
    {
        public DateTime? Parse(string namedDate, DateTime now, DateParserConfig config)
        {
            var ordinalRegex = new Regex("^([1-3]*[0-9])(th|nd|rd|st)*$");
            var matches = ordinalRegex.Match(namedDate.ToLower());

            if (!matches.Success)
            {
                return null;
            }

            var dayOrdinal = int.Parse(matches.Groups[1].Value);
            if (dayOrdinal <= now.Day)
            {
                now = now.AddMonths(1);
            }

            if (dayOrdinal > now.DaysInMonth())
            {
                throw new Exception($"Month does not contain {dayOrdinal} days");
            }

            return new DateTime(now.Year, now.Month, dayOrdinal);
        }
    }
}
