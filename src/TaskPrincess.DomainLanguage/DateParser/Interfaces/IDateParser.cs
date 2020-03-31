using System;

namespace TaskPrincess.DomainLanguage.DateParser
{
    public interface IDateParser
    {
        DateTime Parse(string dateTime);
    }
}
