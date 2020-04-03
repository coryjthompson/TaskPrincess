using System;
using TaskPrincess.DomainLanguage.Parser.Behaviors;
using TaskPrincess.DomainLanguage.Parser.Models;
using Xunit;

namespace TaskPrincess.DomainLanguageTests.Parser.Behaviors
{
    public class DayOrdinalsBehaviorTests
    {
        [Fact]
        public void TestParse_1st()
        {
            var dateTime = new DateTime(2020, 3, 3, 3, 15, 0);
            var results = BuildParse("1st", dateTime);
            Assert.Equal("2020-04-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_2nd()
        {
            var dateTime = new DateTime(2020, 3, 3, 3, 15, 0);
            var results = BuildParse("2nd", dateTime);
            Assert.Equal("2020-04-02 00:00:00", results);
        }

        [Fact]
        public void TestParse_3rd()
        {
            var dateTime = new DateTime(2020, 3, 3, 3, 15, 0);
            var results = BuildParse("3rd", dateTime);
            Assert.Equal("2020-04-03 00:00:00", results);
        }

        [Fact]
        public void TestParse_4th()
        {
            var dateTime = new DateTime(2020, 3, 3, 3, 15, 0);
            var results = BuildParse("4th", dateTime);
            Assert.Equal("2020-03-04 00:00:00", results);
        }

        [Fact]
        public void TestParse_15()
        {
            var dateTime = new DateTime(2020, 3, 3, 3, 15, 0);
            var results = BuildParse("15", dateTime);
            Assert.Equal("2020-03-15 00:00:00", results);
        }

        [Fact]
        public void TestParse_31stShouldErrorOnFeb()
        {
            var dateTime = new DateTime(2020, 2, 3, 3, 15, 0);
            Assert.Throws<Exception>(() => BuildParse("31", dateTime));
        }

        [Fact]
        public void TestParse_UnhandledShouldReturnNull()
        {
            var dateTime = new DateTime(2020, 3, 3, 3, 15, 0);
            var results = BuildParse("unhandled", dateTime);
            Assert.Null(results);
        }

        public string BuildParse(string parse, DateTime now, DateParserConfig config = null)
        {
            var behavior = new DayOrdinalsBehavior();
            var result = behavior.Parse(parse, now, config);
            return result.HasValue ? result.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
        }
    }
}
