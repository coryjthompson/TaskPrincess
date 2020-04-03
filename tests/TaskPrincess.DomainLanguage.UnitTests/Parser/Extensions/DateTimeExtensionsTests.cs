using System;
using TaskPrincess.DomainLanguage.Parser.Extensions;
using TaskPrincess.DomainLanguage.Parser.Models;
using Xunit;

namespace TaskPrincess.DomainLanguageTests.Parser.Extensions
{
    public class DateTimeExtensionsTests
    {

        private const string DateTimeFormat = @"yyyy-MM-dd HH:mm:ss";

        [Fact]
        public void TestStartOfDay()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.StartOfDay();

            Assert.Equal("2021-03-05 00:00:00", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestEndOfDay()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.EndOfDay();

            Assert.Equal("2021-03-05 23:59:59", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestNextDayOfWeek_EmptyIsTomorrow()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.NextDayOfWeek();

            Assert.Equal("2021-03-06 00:00:00", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestNextDayOfWeek_SameDayIsNextWeek()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.NextDayOfWeek(DayOfWeek.Friday);

            Assert.Equal("2021-03-12 00:00:00", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestNextDayOfWeek()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.NextDayOfWeek(DayOfWeek.Monday);

            Assert.Equal("2021-03-08 00:00:00", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestStartOfMonth()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.StartOfMonth();

            Assert.Equal("2021-03-01 00:00:00", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestEndOfMonth()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.EndOfMonth();

            Assert.Equal("2021-03-31 23:59:59", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestEndOfMonth_LeapYear()
        {
            var date = new DateTime(2020, 02, 05, 3, 15, 30);
            var result = date.EndOfMonth();

            Assert.Equal("2020-02-29 23:59:59", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestNextMonth()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.NextMonth(Month.January);

            Assert.Equal("2022-01-01 00:00:00", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestNextMonth_SameIsNextOccurrence()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.NextMonth(Month.March);

            Assert.Equal("2022-03-01 00:00:00", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestNextMonth_EmptyIsNextMonth()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.NextMonth();

            Assert.Equal("2021-04-01 00:00:00", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestDaysInMonth_March()
        {
            var date = new DateTime(2021, 03, 05, 3, 15, 30);
            var result = date.DaysInMonth();

            Assert.Equal(31, result);
        }

        [Fact]
        public void TestDaysInMonth_LeapYear()
        {
            var date = new DateTime(2020, 02, 05, 3, 15, 30);
            var result = date.DaysInMonth();

            Assert.Equal(29, result);
        }

        [Fact]
        public void TestStartOfQuarter_4th()
        {
            var date = new DateTime(2021, 12, 05, 10, 15, 30);
            var result = date.StartOfQuarter();

            Assert.Equal("2021-10-01 00:00:00", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestEndOfQuarter_4th()
        {
            var date = new DateTime(2021, 12, 05, 10, 15, 30);
            var result = date.EndOfQuarter();

            Assert.Equal("2021-12-31 23:59:59", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestCurrentQuarter_2nd()
        {
            var date = new DateTime(2021, 05, 01);
            var result = date.CurrentQuarter();

            Assert.Equal(2, result);
        }

        [Fact]
        public void TestStartOfYear()
        {
            var date = new DateTime(2021, 05, 01);
            var result = date.StartOfYear();

            Assert.Equal("2021-01-01 00:00:00", result.ToString(DateTimeFormat));
        }

        [Fact]
        public void TestEndOfYear()
        {
            var date = new DateTime(2021, 05, 01);
            var result = date.EndOfYear();

            Assert.Equal("2021-12-31 23:59:59", result.ToString(DateTimeFormat));
        }
    }
}
