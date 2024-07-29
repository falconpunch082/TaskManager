using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Task
    {
        // Declaring variables with read-write perms
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsImportant { get; set; }

        // Task constructor
        public Task(string name, DateTime dueDate, bool isImportant = false) // Default isImporant is false
        {
            Name = name;
            DueDate = dueDate;
            IsImportant = isImportant;
        }
    }
}
