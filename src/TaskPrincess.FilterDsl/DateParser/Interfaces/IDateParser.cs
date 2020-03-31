using System;

namespace TaskPrincess.FilterDsl.DateParser
{
    public interface IDateParser
    {
        DateTime Parse(string dateTime);
    }
}
