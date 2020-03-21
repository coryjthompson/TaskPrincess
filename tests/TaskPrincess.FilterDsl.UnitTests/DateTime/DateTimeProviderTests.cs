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

            var resultMon = BuildParse(dateTime, "mon");
            var resultMonday = BuildParse(dateTime, "mOnDaY");
            Assert.Equal("2020-01-06 00:00:00", resultMon);
            Assert.Equal("2020-01-06 00:00:00", resultMonday);
        }

        [Fact]
        public void TestParse_Tuesday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultMon = BuildParse(dateTime, "tue");
            var resultMonday = BuildParse(dateTime, "TuEsDaY");
            Assert.Equal("2020-01-07 00:00:00", resultMon);
            Assert.Equal("2020-01-07 00:00:00", resultMonday);
        }

        [Fact]
        public void TestParse_Wednesday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultMon = BuildParse(dateTime, "wed");
            var resultMonday = BuildParse(dateTime, "wEdNeSdAy");
            Assert.Equal("2020-01-08 00:00:00", resultMon);
            Assert.Equal("2020-01-08 00:00:00", resultMonday);
        }

        [Fact]
        public void TestParse_Thursday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultMon = BuildParse(dateTime, "thu");
            var resultMonday = BuildParse(dateTime, "tHuRsDaY");
            Assert.Equal("2020-01-02 00:00:00", resultMon);
            Assert.Equal("2020-01-02 00:00:00", resultMonday);
        }

        [Fact]
        public void TestParse_Friday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultMon = BuildParse(dateTime, "fRi");
            var resultMonday = BuildParse(dateTime, "friday");
            Assert.Equal("2020-01-03 00:00:00", resultMon);
            Assert.Equal("2020-01-03 00:00:00", resultMonday);
        }

        [Fact]
        public void TestParse_Saturday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultMon = BuildParse(dateTime, "sat");
            var resultMonday = BuildParse(dateTime, "saturdaY");
            Assert.Equal("2020-01-04 00:00:00", resultMon);
            Assert.Equal("2020-01-04 00:00:00", resultMonday);
        }

        [Fact]
        public void TestParse_Sunday()
        {
            var dateTime = new System.DateTime(2020, 1, 1, 3, 15, 0);

            var resultMon = BuildParse(dateTime, "sun");
            var resultMonday = BuildParse(dateTime, "sUnday");
            Assert.Equal("2020-01-05 00:00:00", resultMon);
            Assert.Equal("2020-01-05 00:00:00", resultMonday);
        }

        public string BuildParse(System.DateTime now, string parse)
        {
            var mock = new Mock<DateTimeProvider>();
            mock.Protected().Setup<System.DateTime>("Now").Returns(now);

            var dateTimeProvider = mock.Object;
            return dateTimeProvider.Parse(parse).ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
