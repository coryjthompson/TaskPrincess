using System;
using System.Collections.Generic;
using TaskPrincess.DomainLanguage.Parser.Interfaces;
using TaskPrincess.DomainLanguage.Parser.Models;

namespace TaskPrincess.DomainLanguage.Parser
{
    /// <summary>
    /// Using the strategy pattern to enumerate registered date parser behaviors.
    /// </summary>
    public class DateParser : IDateParser
    {
        private readonly IEnumerable<IDateParserBehavior> _behaviors;
        private readonly DateParserConfig _config;

        public DateParser(IEnumerable<IDateParserBehavior> dateParserBehaviors, DateParserConfig config)
        {
            _config = config;
            _behaviors = dateParserBehaviors;
        }

        public DateTime Parse(string namedDate)
        {
            var now = Now();
            foreach (var behavior in _behaviors)
            {
                var result = behavior.Parse(namedDate, now, _config);
                if (result.HasValue)
                {
                    return result.Value;
                }
            }

            throw new Exception($"Could not parse named date: {namedDate}");
        }

        // Moved to a separate method so that it can be mocked.
        protected virtual DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
