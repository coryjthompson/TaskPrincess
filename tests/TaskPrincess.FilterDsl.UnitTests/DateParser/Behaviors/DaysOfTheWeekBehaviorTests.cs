using System;
using TaskPrincess.FilterDsl.DateParser.Behaviors;
using Xunit;

namespace TaskPrincess.FilterDslTest.DateParser.Behaviors
{
    public class DaysOfTheWeekBehaviorTests
    {
        [Fact]
        public void TestParse_Monday()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultMon = BuildParse("mon", dateTime);
            var resultMonday = BuildParse("mOnDaY", dateTime);
            Assert.Equal("2020-01-06 00:00:00", resultMon);
            Assert.Equal("2020-01-06 00:00:00", resultMonday);
        }

        [Fact]
        public void TestParse_Tuesday()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultTue = BuildParse("tue", dateTime);
            var resultTuesday = BuildParse("TuEsDaY", dateTime);
            Assert.Equal("2020-01-07 00:00:00", resultTue);
            Assert.Equal("2020-01-07 00:00:00", resultTuesday);
        }

        [Fact]
        public void TestParse_Wednesday()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultWed = BuildParse("wed", dateTime);
            var resultWednesday = BuildParse("wEdNeSdAy", dateTime);
            Assert.Equal("2020-01-08 00:00:00", resultWed);
            Assert.Equal("2020-01-08 00:00:00", resultWednesday);
        }

        [Fact]
        public void TestParse_Thursday()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultThu = BuildParse("thu", dateTime);
            var resultThursday = BuildParse("tHuRsDaY", dateTime);
            Assert.Equal("2020-01-02 00:00:00", resultThu);
            Assert.Equal("2020-01-02 00:00:00", resultThursday);
        }

        [Fact]
        public void TestParse_Friday()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultFri = BuildParse("fRi", dateTime);
            var resultFriday = BuildParse("friday", dateTime);
            Assert.Equal("2020-01-03 00:00:00", resultFri);
            Assert.Equal("2020-01-03 00:00:00", resultFriday);
        }

        [Fact]
        public void TestParse_Saturday()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultSat = BuildParse("sat", dateTime);
            var resultSaturday = BuildParse("saturdaY", dateTime);
            Assert.Equal("2020-01-04 00:00:00", resultSat);
            Assert.Equal("2020-01-04 00:00:00", resultSaturday);
        }

        [Fact]
        public void TestParse_Sunday()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);

            var resultSun = BuildParse("sun", dateTime);
            var resultSunday = BuildParse("sUnday", dateTime);
            Assert.Equal("2020-01-05 00:00:00", resultSun);
            Assert.Equal("2020-01-05 00:00:00", resultSunday);
        }

        [Fact]
        public void TestParse_UnhandledWillReturnNull()
        {
            var dateTime = new DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("unhandled", dateTime);
            Assert.Null(results);
        }

        public string BuildParse(string parse, DateTime now)
        {
            var behavior = new DaysOfTheWeekBehavior();
            var result = behavior.Parse(parse, now, null);
            return result.HasValue ? result.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
        }
    }
}
