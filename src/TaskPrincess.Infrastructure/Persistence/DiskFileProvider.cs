using System.Collections.Generic;
using System.IO;
using TaskPrincess.Application.Common.Interfaces;

namespace TaskPrincess.Infrastructure.Persistence
{
    public class DiskFileProvider : IFileProvider
    {
        public const string FilePath = @"";

        public IEnumerable<string> ReadLines()
        {
            return File.ReadLines(FilePath);
        }

        public void AppendLine(string line)
        {
            File.AppendAllLines(FilePath, new string[] { line });
        }
    }
}
