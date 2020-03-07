using System.Collections.Generic;
using TaskPrincess.Application.Common.Interfaces;
using TaskPrincess.Domain.Entities;

namespace TaskPrincess.Infrastructure.Persistence
{
    public class FileTodoRepository : ITodoRepository
    {
        private readonly IFileProvider _fileHandler;
        private readonly ITodoSerializer _todoSerializer;

        public FileTodoRepository(IFileProvider fileHandler, ITodoSerializer todoSerializer)
        {
            _fileHandler = fileHandler;
            _todoSerializer = todoSerializer;
        }

        public void Add(Todo todo)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Todo todo)
        {
            throw new System.NotImplementedException();
        }

        public Todo FindTodoById()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Todo> GetTodos()
        {
            foreach (var line in _fileHandler.ReadLines())
            {
                yield return _todoSerializer.Deserialize(line);
            }
        }

        public void Remove(Todo todo)
        {
            throw new System.NotImplementedException();
        }
    }
}
