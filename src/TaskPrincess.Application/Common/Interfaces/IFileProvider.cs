using System.Collections.Generic;

namespace TaskPrincess.Application.Common.Interfaces
{
    public interface IFileProvider
    {
        IEnumerable<string> ReadLines();
        void AppendLine(string line);
    }
}
