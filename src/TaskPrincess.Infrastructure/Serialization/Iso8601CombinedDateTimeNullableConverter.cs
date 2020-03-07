using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskPrincess.Infrastructure.Serilization
{
    public class Iso8601CombinedDateTimeNullableConverter : JsonConverter<DateTime?>
    {
        private const string FormatString = @"yyyyMMddTHHmmssK";

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var result = reader.GetString();
            return string.IsNullOrEmpty(result) ? null : (DateTime?)DateTime.ParseExact(result, FormatString, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteStringValue("");
                return;
            }

            writer.WriteStringValue(value.Value.ToString(FormatString));
        }
    }
}
