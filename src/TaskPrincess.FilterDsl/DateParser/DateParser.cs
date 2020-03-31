using System;
using System.Collections.Generic;
using TaskPrincess.FilterDsl.DateParser.Interfaces;

namespace TaskPrincess.FilterDsl.DateParser
{
    public class DateTimeProvider : IDateParser
    {
        private readonly IEnumerable<IDateParserBehavior> _behaviors;
        private readonly DateParserConfig _config;

        public DateTimeProvider(IEnumerable<IDateParserBehavior> dateParserBehaviors, DateParserConfig config)
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

        // Moved to a seperate method so that it can be mocked.
        protected virtual DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
