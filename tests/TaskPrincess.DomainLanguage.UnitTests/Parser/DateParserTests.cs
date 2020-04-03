using System;
using System.Collections.Generic;
using Moq;
using TaskPrincess.DomainLanguage.Parser;
using TaskPrincess.DomainLanguage.Parser.Interfaces;
using TaskPrincess.DomainLanguage.Parser.Models;
using Xunit;

namespace TaskPrincess.DomainLanguageTests.Parser
{
    public class DateParserTests
    {

        [Fact]
        public void TestParse_TestHandledDateFound()
        {
            var expectedDateTime = new DateTime(2019, 01, 01);

            var mockDateParser = new Mock<IDateParserBehavior>();
            mockDateParser.Setup(e => e.Parse("now", expectedDateTime, null)).Returns(expectedDateTime);

            var dateParser = new DateParser(new List<IDateParserBehavior>() { mockDateParser.Object }, null);
            Assert.Equal(expectedDateTime, dateParser.Parse("now"), TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void TestParse_NotHandledThrowsException()
        {
            var mockDateParser = new Mock<IDateParserBehavior>();
            mockDateParser.Setup(e => e.Parse("not exists", It.IsAny<DateTime>(), It.IsAny<DateParserConfig>())).Returns<DateTime?>(null);

            var dateParser = new DateParser(new List<IDateParserBehavior>() { mockDateParser.Object }, null);
            Assert.Throws<Exception>(() => dateParser.Parse("not exists"));
        }
    }
}
