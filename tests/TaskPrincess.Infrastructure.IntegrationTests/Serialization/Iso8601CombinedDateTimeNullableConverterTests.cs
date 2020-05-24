using System;
using System.IO;
using System.Text;
using System.Text.Json;
using TaskPrincess.Infrastructure.Serilization;
using Xunit;

namespace TaskPrincess.InfrastructureTest.Serilization
{
    public class Iso8601CombinedDateTimeNullableConverterTests
    {
        [Fact]
        public void TestRead_ParseDate()
        {
            var utf8JsonReader = CreateJsonReader("\"20200414T085247Z\"");
            var jsonConverter = new Iso8601CombinedDateTimeNullableConverter();

            utf8JsonReader.Read();
            var results = jsonConverter.Read(ref utf8JsonReader, typeof(DateTime?), null);

            var expected = DateTime.SpecifyKind(new DateTime(2020, 4, 14, 08, 52, 47), DateTimeKind.Utc);
            Assert.Equal(expected, results.Value);
        }

        [Fact]
        public void TestRead_ParseNull()
        {
            var utf8JsonReader = CreateJsonReader("null");
            var jsonConverter = new Iso8601CombinedDateTimeNullableConverter();

            utf8JsonReader.Read();
            var results = jsonConverter.Read(ref utf8JsonReader, typeof(DateTime?), null);

            Assert.False(results.HasValue);
        }

        [Fact]
        public void TestWrite_Date()
        {
            using var ms = new MemoryStream();
            using var writer = new Utf8JsonWriter(ms);
            var jsonConverter = new Iso8601CombinedDateTimeNullableConverter();
            var date = DateTime.SpecifyKind(new DateTime(2020, 4, 14, 08, 52, 47), DateTimeKind.Utc);

            jsonConverter.Write(writer, date, null);
            writer.Flush();

            ms.Position = 0;
            var reader = new StreamReader(ms);
            var result = reader.ReadToEnd();
            Assert.Equal("\"20200414T085247Z\"", result);
        }

        [Fact]
        public void TestWrite_Null()
        {
            using var ms = new MemoryStream();
            using var writer = new Utf8JsonWriter(ms);
            var jsonConverter = new Iso8601CombinedDateTimeNullableConverter();

            jsonConverter.Write(writer, null, null);
            writer.Flush();

            ms.Position = 0;
            var reader = new StreamReader(ms);
            var result = reader.ReadToEnd();
            Assert.Equal("\"\"", result);
        }


        private Utf8JsonReader CreateJsonReader(string json)
            => new Utf8JsonReader(Encoding.UTF8.GetBytes(json));
    }
}
