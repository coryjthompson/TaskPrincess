using System;
using TaskPrincess.DomainLanguage.DateParser;
using TaskPrincess.DomainLanguage.DateParser.Behaviors;
using Xunit;

namespace TaskPrincess.DomainLanguageTest.DateParser.Behaviors
{
    public class CalculatedDatesBehaviorTests
    {
        [Fact]
        public void TestParse_Someday()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("someday", dateTime);
            Assert.Equal("2038-01-18 00:00:00", results);
        }

        [Fact]
        public void TestParse_Later()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("later", dateTime);
            Assert.Equal("2038-01-18 00:00:00", results);
        }

        public string BuildParse(string parse, DateTime now, DateParserConfig config = null)
        {
            var behavior = new CalculatedDatesBehavior();
            var result = behavior.Parse(parse, now, config);
            return result.HasValue ? result.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
        }
    }
}
