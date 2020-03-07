using System.Text.Json;
using TaskPrincess.Application.Common.Interfaces;
using TaskPrincess.Domain.Entities;

namespace TaskPrincess.Infrastructure.Serilization
{
    public class TaskWarriorSerializer : ITodoSerializer
    {
        private readonly JsonSerializerOptions _options;

        public TaskWarriorSerializer()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new TaskWarriorNamingPolicy()
            };
            _options.Converters.Add(new Iso8601CombinedDateTimeNullableConverter());
        }

        public Todo Deserialize(string serializedText)
        {
            return JsonSerializer.Deserialize<Todo>(serializedText, _options);
        }

        public string Serialize(Todo obj)
        {
            return JsonSerializer.Serialize(obj, _options);
        }
    }
}
