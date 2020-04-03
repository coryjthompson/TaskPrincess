using System;

namespace TaskPrincess.DomainLanguage.Parser.Models
{
    public class DateParserConfig
    {
        public string WeekStart { get; set; }

        public DayOfWeek StartOfWeek
        {
            get
            {
                return WeekStart == "monday" ? DayOfWeek.Monday : DayOfWeek.Sunday;
            }
        }

        public DayOfWeek EndOfWeek
        {
            get
            {
                return WeekStart == "monday" ? DayOfWeek.Sunday : DayOfWeek.Saturday;
            }
        }

        public DayOfWeek StartOfWorkWeek { get; } = DayOfWeek.Monday;
        public DayOfWeek EndOfWorkWeek { get; } = DayOfWeek.Friday;
    }
}
