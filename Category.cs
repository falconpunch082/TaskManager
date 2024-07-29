using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Category
    {
        // Declaring variables
        public string Name { get; set; }
        private List<Task> tasks; // Each category has a list of Task objects
        public int TaskCount => tasks.Count; // Lambda expression for one-line code of assigning the number of tasks in a category into TaskCount

        // Category constructor
        public Category(string name)
        {
            Name = name;
            tasks = new List<Task>();
        }

        // Adding tasks
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        // Deleting tasks
        public void DeleteTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
            }
        }

        // Getting tasks
        public Task GetTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                return tasks[index];
            }
            return null;
        }

        // Moving tasks within the list of Tasks
        public void MoveTask(int fromIndex, int toIndex)
        {
            if (fromIndex >= 0 && fromIndex < tasks.Count && toIndex >= 0 && toIndex < tasks.Count)
            {
                var task = tasks[fromIndex];
                tasks.RemoveAt(fromIndex);
                tasks.Insert(toIndex, task);
            }
        }

        // Printing list of Task objects
        public void PrintTasks()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                var task = tasks[i];
                Console.Write("{0,10}|", i);
                if (task.IsImportant)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write("{0,-30}|{1,-30}|{2,-30}|", task.Name, task.DueDate.ToString("yyyy-MM-dd"), task.IsImportant ? "Important" : "Normal");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
