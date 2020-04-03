using System;
using TaskPrincess.DomainLanguage.Parser.Behaviors;
using Xunit;

namespace TaskPrincess.DomainLanguageTests.Parser.Behaviors
{
    public class MonthsOfTheYearBehaviorTests
    {
        [Fact]
        public void TestParse_January()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("jan", dateTime);
            var resultsLong = BuildParse("january", dateTime);
            Assert.Equal("2021-01-01 00:00:00", resultsShort);
            Assert.Equal("2021-01-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_February()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("feb", dateTime);
            var resultsLong = BuildParse("february", dateTime);
            Assert.Equal("2021-02-01 00:00:00", resultsShort);
            Assert.Equal("2021-02-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_March()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("mar", dateTime);
            var resultsLong = BuildParse("march", dateTime);
            Assert.Equal("2021-03-01 00:00:00", resultsShort);
            Assert.Equal("2021-03-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_April()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("apr", dateTime);
            var resultsLong = BuildParse("april", dateTime);
            Assert.Equal("2020-04-01 00:00:00", resultsShort);
            Assert.Equal("2020-04-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_May()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var results = BuildParse("may", dateTime);
            Assert.Equal("2020-05-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_June()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("jun", dateTime);
            var resultsLong = BuildParse("june", dateTime);
            Assert.Equal("2020-06-01 00:00:00", resultsShort);
            Assert.Equal("2020-06-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_July()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("jul", dateTime);
            var resultsLong = BuildParse("july", dateTime);
            Assert.Equal("2020-07-01 00:00:00", resultsShort);
            Assert.Equal("2020-07-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_August()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("aug", dateTime);
            var resultsLong = BuildParse("august", dateTime);
            Assert.Equal("2020-08-01 00:00:00", resultsShort);
            Assert.Equal("2020-08-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_September()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("sep", dateTime);
            var resultsLong = BuildParse("september", dateTime);
            Assert.Equal("2020-09-01 00:00:00", resultsShort);
            Assert.Equal("2020-09-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_October()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("oct", dateTime);
            var resultsLong = BuildParse("october", dateTime);
            Assert.Equal("2020-10-01 00:00:00", resultsShort);
            Assert.Equal("2020-10-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_November()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("nov", dateTime);
            var resultsLong = BuildParse("november", dateTime);
            Assert.Equal("2020-11-01 00:00:00", resultsShort);
            Assert.Equal("2020-11-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_December()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("dec", dateTime);
            var resultsLong = BuildParse("december", dateTime);
            Assert.Equal("2020-12-01 00:00:00", resultsShort);
            Assert.Equal("2020-12-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_UnhandledShouldReturnNull()
        {
            var dateTime = new DateTime(2020, 3, 1, 3, 15, 0);
            var results = BuildParse("unhandled", dateTime);
            Assert.Null(results);
        }

        public string BuildParse(string parse, DateTime now)
        {
            var behavior = new MonthsOfTheYearBehavior();
            var result = behavior.Parse(parse, now, null);
            return result.HasValue ? result.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
        }
    }
}
