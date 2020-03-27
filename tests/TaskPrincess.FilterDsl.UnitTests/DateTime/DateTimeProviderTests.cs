using Moq;
using Moq.Protected;
using TaskPrincess.FilterDsl.DateTime;
using Xunit;
namespace TaskPrincess.FilterDslTest.DateTime
{
    public class DateTimeProviderTests
    {
        [Fact]
        public void TestParse_Monday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultMon = BuildParse("mon", dateTime);
            var resultMonday = BuildParse("mOnDaY", dateTime);
            Assert.Equal("2020-01-06 00:00:00", resultMon);
            Assert.Equal("2020-01-06 00:00:00", resultMonday);
        }

        [Fact]
        public void TestParse_Tuesday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultTue = BuildParse("tue", dateTime);
            var resultTuesday = BuildParse("TuEsDaY", dateTime);
            Assert.Equal("2020-01-07 00:00:00", resultTue);
            Assert.Equal("2020-01-07 00:00:00", resultTuesday);
        }

        [Fact]
        public void TestParse_Wednesday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultWed = BuildParse("wed", dateTime);
            var resultWednesday = BuildParse("wEdNeSdAy", dateTime);
            Assert.Equal("2020-01-08 00:00:00", resultWed);
            Assert.Equal("2020-01-08 00:00:00", resultWednesday);
        }

        [Fact]
        public void TestParse_Thursday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultThu = BuildParse("thu", dateTime);
            var resultThursday = BuildParse("tHuRsDaY", dateTime);
            Assert.Equal("2020-01-02 00:00:00", resultThu);
            Assert.Equal("2020-01-02 00:00:00", resultThursday);
        }

        [Fact]
        public void TestParse_Friday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultFri = BuildParse("fRi", dateTime);
            var resultFriday = BuildParse("friday", dateTime);
            Assert.Equal("2020-01-03 00:00:00", resultFri);
            Assert.Equal("2020-01-03 00:00:00", resultFriday);
        }

        [Fact]
        public void TestParse_Saturday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultSat = BuildParse("sat", dateTime);
            var resultSaturday = BuildParse("saturdaY", dateTime);
            Assert.Equal("2020-01-04 00:00:00", resultSat);
            Assert.Equal("2020-01-04 00:00:00", resultSaturday);
        }

        [Fact]
        public void TestParse_Sunday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultSun = BuildParse("sun", dateTime);
            var resultSunday = BuildParse("sUnday", dateTime);
            Assert.Equal("2020-01-05 00:00:00", resultSun);
            Assert.Equal("2020-01-05 00:00:00", resultSunday);
        }


        [Fact]
        public void TestParse_StartOfCurrentWeek()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultSocwDowSun = BuildParse("socw", dateTime);
            var resultSocwDowMon = BuildParse("socw", dateTime, "monday");

            Assert.Equal("2019-12-29 00:00:00", resultSocwDowSun);
            Assert.Equal("2019-12-30 00:00:00", resultSocwDowMon);
        }

        [Fact]
        public void TestParse_StartOfWeek()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultSowDowSun = BuildParse("sow", dateTime);
            var resultSowDowMon = BuildParse("sow", dateTime, "monday");

            Assert.Equal("2020-01-05 00:00:00", resultSowDowSun);
            Assert.Equal("2020-01-06 00:00:00", resultSowDowMon);
        }

        [Fact]
        public void TestParse_StartOfWorkWeek()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("soww", dateTime);
            Assert.Equal("2020-01-06 00:00:00", results);
        }

        [Fact]
        public void TestParse_EndOfCurrentWeek()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultEocwDowSun = BuildParse("eocw", dateTime);
            var resultEocwDowMon = BuildParse("eocw", dateTime, "monday");

            Assert.Equal("2020-01-04 23:59:59", resultEocwDowSun);
            Assert.Equal("2020-01-05 23:59:59", resultEocwDowMon);
        }

        [Fact]
        public void TestParse_EndOfWeek()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultEowDowSun = BuildParse("eow", dateTime);
            var resultEowDowMon = BuildParse("eow", dateTime, "monday");

            Assert.Equal("2020-01-04 23:59:59", resultEowDowSun);
            Assert.Equal("2020-01-05 23:59:59", resultEowDowMon);
        }

        [Fact]
        public void TestParse_EndOfWorkWeek()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("eoww", dateTime);
            Assert.Equal("2020-01-03 00:00:00", results);
        }

        [Fact]
        public void TestParse_StartOfDay()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("sod", dateTime);
            Assert.Equal("2020-01-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_EndOfDay()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("eod", dateTime);
            Assert.Equal("2020-01-01 23:59:59", results);
        }

        [Fact]
        public void TestParse_Today()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("today", dateTime);
            Assert.Equal("2020-01-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_Yesterday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("yesterday", dateTime);
            Assert.Equal("2019-12-31 00:00:00", results);
        }

        [Fact]
        public void TestParse_Now()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("now", dateTime);
            Assert.Equal("2020-01-01 03:15:00", results);
        }

        [Fact]
        public void TestParse_Someday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("someday", dateTime);
            Assert.Equal("2038-01-18 00:00:00", results);
        }

        [Fact]
        public void TestParse_Later()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);
            var results = BuildParse("later", dateTime);
            Assert.Equal("2038-01-18 00:00:00", results);
        }

        [Fact]
        public void TestParse_January()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("jan", dateTime);
            var resultsLong = BuildParse("january", dateTime);
            Assert.Equal("2021-01-01 00:00:00", resultsShort);
            Assert.Equal("2021-01-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_February()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("feb", dateTime);
            var resultsLong = BuildParse("february", dateTime);
            Assert.Equal("2021-02-01 00:00:00", resultsShort);
            Assert.Equal("2021-02-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_March()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("mar", dateTime);
            var resultsLong = BuildParse("march", dateTime);
            Assert.Equal("2021-03-01 00:00:00", resultsShort);
            Assert.Equal("2021-03-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_April()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("apr", dateTime);
            var resultsLong = BuildParse("april", dateTime);
            Assert.Equal("2020-04-01 00:00:00", resultsShort);
            Assert.Equal("2020-04-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_May()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var results = BuildParse("may", dateTime);
            Assert.Equal("2020-05-01 00:00:00", results);
        }

        [Fact]
        public void TestParse_June()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("jun", dateTime);
            var resultsLong = BuildParse("june", dateTime);
            Assert.Equal("2020-06-01 00:00:00", resultsShort);
            Assert.Equal("2020-06-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_July()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("jul", dateTime);
            var resultsLong = BuildParse("july", dateTime);
            Assert.Equal("2020-07-01 00:00:00", resultsShort);
            Assert.Equal("2020-07-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_August()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("aug", dateTime);
            var resultsLong = BuildParse("august", dateTime);
            Assert.Equal("2020-08-01 00:00:00", resultsShort);
            Assert.Equal("2020-08-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_September()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("sep", dateTime);
            var resultsLong = BuildParse("september", dateTime);
            Assert.Equal("2020-09-01 00:00:00", resultsShort);
            Assert.Equal("2020-09-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_October()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("oct", dateTime);
            var resultsLong = BuildParse("october", dateTime);
            Assert.Equal("2020-10-01 00:00:00", resultsShort);
            Assert.Equal("2020-10-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_November()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("nov", dateTime);
            var resultsLong = BuildParse("november", dateTime);
            Assert.Equal("2020-11-01 00:00:00", resultsShort);
            Assert.Equal("2020-11-01 00:00:00", resultsLong);
        }

        [Fact]
        public void TestParse_December()
        {
            var dateTime = new System.DateTime(2020, 3, 1, 3, 15, 0);
            var resultsShort = BuildParse("dec", dateTime);
            var resultsLong = BuildParse("december", dateTime);
            Assert.Equal("2020-12-01 00:00:00", resultsShort);
            Assert.Equal("2020-12-01 00:00:00", resultsLong);
        }

        public string BuildParse(string parse, System.DateTime now, string soc = "sunday")
        {
            var mock = new Mock<DateTimeProvider>(soc);
            mock.Protected().Setup<System.DateTime>("Now").Returns(now);

            var dateTimeProvider = mock.Object;
            return dateTimeProvider.Parse(parse).ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
