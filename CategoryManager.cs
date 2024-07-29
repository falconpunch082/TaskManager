using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class CategoryManager
    {
        public static void AddCategory(List<Category> categories)
        {
            try
            {
                Console.Write("Enter new category name: ");
                string categoryName = Console.ReadLine();
                categories.Add(new Category(categoryName)); // Adds new Category object into the categories list
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding category: {ex.Message}");
            }
        }

        public static void DeleteCategory(List<Category> categories)
        {
            try
            {
                Console.Write("Enter category name to delete: ");
                string categoryName = Console.ReadLine();
                var category = categories.FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)); // Tries to determine if the category exists
                if (category != null) // If category exists
                {
                    categories.Remove(category);
                }
                else
                {
                    Console.WriteLine("Category not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting category: {ex.Message}");
            }
        }

        public static void AddTask(List<Category> categories)
        {
            try
            {
                Console.Write("Enter category name to add task: ");
                string categoryName = Console.ReadLine();
                var category = categories.FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)); // Tries to determine if the category exists
                if (category != null)
                {
                    // Gathering data required to create a task
                    Console.Write("Enter task name: ");
                    string taskName = Console.ReadLine();
                    Console.Write("Enter task due date (dd/mm/yyyy): ");
                    DateTime dueDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Is the task important? (yes/no): ");
                    bool isImportant = Console.ReadLine().ToLower() == "yes";

                    // Adds task with provided info
                    category.AddTask(new Task(taskName, dueDate, isImportant));
                }
                else
                {
                    Console.WriteLine("Category not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding task: {ex.Message}");
            }
        }

        public static void DeleteTask(List<Category> categories)
        {
            try
            {
                Console.Write("Enter category name to delete task: ");
                string categoryName = Console.ReadLine();
                var category = categories.FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)); // Tries to determine if the category exists
                if (category != null)
                {
                    Console.Write("Enter task index to delete: "); // Provided on UI
                    int taskIndex = Convert.ToInt32(Console.ReadLine());
                    category.DeleteTask(taskIndex);
                }
                else
                {
                    Console.WriteLine("Category not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting task: {ex.Message}");
            }
        }

        public static void MoveTaskWithinCategory(List<Category> categories)
        {
            try
            {
                Console.Write("Enter category name to move task within: ");
                string categoryName = Console.ReadLine();
                var category = categories.FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)); // Tries to determine if the category exists
                if (category != null)
                {
                    // Gathering transfer details
                    Console.Write("Enter task index to move: ");
                    int fromIndex = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter new index for the task: ");
                    int toIndex = Convert.ToInt32(Console.ReadLine());

                    //Moves task with provided details
                    category.MoveTask(fromIndex, toIndex);
                }
                else
                {
                    Console.WriteLine("Category not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving task within category: {ex.Message}");
            }
        }

        public static void MoveTaskToAnotherCategory(List<Category> categories)
        {
            try
            {
                Console.Write("Enter source category name to move task from: ");
                string sourceCategoryName = Console.ReadLine();
                var sourceCategory = categories.FirstOrDefault(c => c.Name.Equals(sourceCategoryName, StringComparison.OrdinalIgnoreCase)); // Tries to determine if the category exists
                if (sourceCategory != null)
                {
                    Console.Write("Enter task index to move: ");
                    int taskIndex = Convert.ToInt32(Console.ReadLine());
                    if (taskIndex >= 0 && taskIndex < sourceCategory.TaskCount) // Tries to check if the tasks exists
                    {
                        Console.Write("Enter destination category name to move task to: ");
                        string destCategoryName = Console.ReadLine();
                        var destCategory = categories.FirstOrDefault(c => c.Name.Equals(destCategoryName, StringComparison.OrdinalIgnoreCase)); // Tries to determine if the category exists
                        if (destCategory != null)
                        {
                            var task = sourceCategory.GetTask(taskIndex); // First get the Task object to move
                            sourceCategory.DeleteTask(taskIndex); // Then delete said Task from the source category
                            destCategory.AddTask(task); // Finally add Task into the destination category
                        }
                        else
                        {
                            Console.WriteLine("Destination category not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid task index.");
                    }
                }
                else
                {
                    Console.WriteLine("Source category not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving task between categories: {ex.Message}");
            }
        }

        public static void HighlightTask(List<Category> categories)
        {
            try
            {
                Console.Write("Enter category name to highlight task: ");
                string categoryName = Console.ReadLine();
                var category = categories.FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)); // Tries to determine if the category exists
                if (category != null)
                {
                    Console.Write("Enter task index to highlight: ");
                    int taskIndex = Convert.ToInt32(Console.ReadLine());
                    if (taskIndex >= 0 && taskIndex < category.TaskCount)
                    {
                        var task = category.GetTask(taskIndex);
                        task.IsImportant = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid task index.");
                    }
                }
                else
                {
                    Console.WriteLine("Category not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error highlighting task: {ex.Message}");
            }
        }
    }
}
