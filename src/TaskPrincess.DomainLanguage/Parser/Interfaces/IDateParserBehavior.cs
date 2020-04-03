using System;
using TaskPrincess.DomainLanguage.Parser.Models;

namespace TaskPrincess.DomainLanguage.Parser.Interfaces
{
    /// <summary>
    /// Behaviors to parse a named date into a DateTime object.
    /// </summary>
    public interface IDateParserBehavior
    {
        /// <summary>
        /// Parse a named date into a DateTime object.
        /// Unhandled named dates will return a null object.
        /// </summary>
        DateTime? Parse(string namedDate, DateTime now, DateParserConfig config);
    }
}
