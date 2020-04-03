using System;
using TaskPrincess.DomainLanguage.Parser.Extensions;
using TaskPrincess.DomainLanguage.Parser.Interfaces;
using TaskPrincess.DomainLanguage.Parser.Models;

namespace TaskPrincess.DomainLanguage.Parser.Behaviors
{
    /// <summary>
    /// Year named Dates are calculated bounderies of dates that occur within a year.
    /// This includes start of year, start of quarter, etc
    /// </summary>
    public class YearDatesBehavior : IDateParserBehavior
    {
        public DateTime? Parse(string namedDate, DateTime now, DateParserConfig config)
        {
            switch (namedDate.ToLower())
            {
                case "socy":
                    return now.StartOfYear();
                case "soy":
                    return now.AddYears(1).StartOfYear();
                case "eocy":
                case "eoy":
                    return now.EndOfYear();
                case "socq":
                    return now.StartOfQuarter();
                case "eocq":
                case "eoq":
                    return now.EndOfQuarter();
                case "soq":
                    return now.AddMonths(4).StartOfQuarter();
                case "socm":
                    return now.StartOfMonth();
                case "som":
                    return now.AddMonths(1).StartOfMonth();
                case "eocm":
                case "eom":
                    return now.EndOfMonth();
                default:
                    return null;
            }
        }
    }
}
