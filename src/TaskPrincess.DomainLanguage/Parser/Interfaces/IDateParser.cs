using System;

namespace TaskPrincess.DomainLanguage.Parser
{
    public interface IDateParser
    {
        DateTime Parse(string namedDate);
    }
}
