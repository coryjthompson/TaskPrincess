using System.Text.Json;

namespace TaskPrincess.Infrastructure.Serilization
{
    public class TaskWarriorNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            switch (name)
            {
                case "Id":
                    return "uuid";
                case "Created":
                    return "entry";
                default:
                    return name.ToLower();
            }
        }
    }
}
