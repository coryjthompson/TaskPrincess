using System.Collections.Generic;
using TaskPrincess.Domain.Entities;

namespace TaskPrincess.Application.Common.Interfaces
{
    public interface ITodoRepository
    {
        void Add(Todo todo);
        void Edit(Todo todo);
        void Remove(Todo todo);

        IEnumerable<Todo> GetTodos();
        Todo FindTodoById();
    }
}
