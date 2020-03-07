using TaskPrincess.Domain.Entities;

namespace TaskPrincess.Application.Common.Interfaces
{
    public interface ITodoSerializer
    {
       string Serialize(Todo obj);
       Todo Deserialize(string serializedText);
    }
}
