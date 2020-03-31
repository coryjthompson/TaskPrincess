using System;
using TaskPrincess.DomainLanguage.DateParser.Interfaces;

namespace TaskPrincess.DomainLanguage.DateParser.Behaviors
{
    /// <summary>
    /// Parses a few special dates from algorithm.
    /// The time will be returned as 00:00:00 local.
    /// </summary>
    public class CalculatedDatesBehavior : IDateParserBehavior
    {
        public DateTime? Parse(string namedDate, DateTime now, DateParserConfig config)
        {
            switch (namedDate.ToLower())
            {
                case "later":
                case "someday":
                    return new DateTime(2038, 01, 18, 0, 0, 0);
                default:
                    return null;
            }
        }
    }
}
