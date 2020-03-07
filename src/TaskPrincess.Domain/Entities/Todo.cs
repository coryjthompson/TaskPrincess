using System;
using System.Collections.Generic;

namespace TaskPrincess.Domain.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Project { get; set; }
        public string Priority { get; set; }
        public ICollection<string> Tags { get; set; }
        public DateTime? Due { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
