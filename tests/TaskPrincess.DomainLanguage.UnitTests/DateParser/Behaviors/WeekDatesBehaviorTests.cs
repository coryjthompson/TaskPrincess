using System;
using TaskPrincess.DomainLanguage.DateParser;
using TaskPrincess.DomainLanguage.DateParser.Behaviors;
using Xunit;

namespace TaskPrincess.DomainLanguageTest.DateParser.Behaviors
{
    public class WeekDatesBehaviorTests
    {
        [Fact]
        public void TestParse_StartOfCurrentWeek()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultSocwDowSun = BuildParse("socw", dateTime);
            var resultSocwDowMon = BuildParse("socw", dateTime, new DateParserConfig() { WeekStart = "monday" });

            Assert.Equal("2019-12-29 00:00:00", resultSocwDowSun);
            Assert.Equal("2019-12-30 00:00:00", resultSocwDowMon);
        }

        [Fact]
        public void TestParse_StartOfWeek()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultSowDowSun = BuildParse("sow", dateTime);
            var resultSowDowMon = BuildParse("sow", dateTime, new DateParserConfig() { WeekStart = "monday" });

            Assert.Equal("2020-01-05 00:00:00", resultSowDowSun);
            Assert.Equal("2020-01-06 00:00:00", resultSowDowMon);
        }

        [Fact]
        public void TestParse_StartOfWorkWeek()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("soww", dateTime);
            Assert.Equal("2020-01-06 00:00:00", results);
        }

        [Fact]
        public void TestParse_EndOfCurrentWeek()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultEocwDowSun = BuildParse("eocw", dateTime);
            var resultEocwDowMon = BuildParse("eocw", dateTime, new DateParserConfig() { WeekStart = "monday" });

            Assert.Equal("2020-01-04 23:59:59", resultEocwDowSun);
            Assert.Equal("2020-01-05 23:59:59", resultEocwDowMon);
        }

        [Fact]
        public void TestParse_EndOfWeek()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultEowDowSun = BuildParse("eow", dateTime);
            var resultEowDowMon = BuildParse("eow", dateTime, new DateParserConfig() { WeekStart = "monday" });

            Assert.Equal("2020-01-04 23:59:59", resultEowDowSun);
            Assert.Equal("2020-01-05 23:59:59", resultEowDowMon);
        }

        [Fact]
        public void TestParse_EndOfWorkWeek()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("eoww", dateTime);
            Assert.Equal("2020-01-03 23:59:59", results);
        }

        [Fact]
        public void TestParse_StartOfDay()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("sod", dateTime);
            Assert.Equal("2020-01-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_EndOfDay()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("eod", dateTime);
            Assert.Equal("2020-01-01 23:59:59", results);
        }

        [Fact]
        public void TestParse_Today()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("today", dateTime);
            Assert.Equal("2020-01-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_Yesterday()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("yesterday", dateTime);
            Assert.Equal("2019-12-31 00:00:00", results);
        }

        [Fact]
        public void TestParse_Now()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("now", dateTime);
            Assert.Equal("2020-01-01 03:15:00", results);
        }

        [Fact]
        public void TestParse_UnhandledShouldReturnNull()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("unhandled", dateTime);
            Assert.Null(results);
        }

        public string BuildParse(string parse, DateTime now, DateParserConfig config = null)
        {
            if (config == null)
            {
                config = new DateParserConfig();
            }

            var behavior = new WeekDatesBehavior();
            var result = behavior.Parse(parse, now, config);
            return result.HasValue ? result.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
        }
    }
}
