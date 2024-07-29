using System;
using System.Security.Cryptography.X509Certificates;

namespace TaskManager
{
    // MenuOption enumeration
    public enum MenuOption
    {
        AddCat = 1,
        DeleteCat = 2,
        AddTask = 3,
        DeleteTask = 4,
        MoveWithin = 5,
        MoveTo = 6,
        Highlight = 7,
        Exit = 8
    }

    // Actual program
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of categories
            List<Category> categories = new List<Category>();

            // While the user hasn't quit yet...
            while (true)
            {
                // Create UI
                Console.Clear();
                Console.WriteLine(new string(' ', 12) + "CATEGORIES");
                Console.WriteLine(new string(' ', 10) + new string('-', 94));
                Console.WriteLine("{0,10}|{1,-30}|{2,-30}|{3,-30}|", "Item #", "Task", "Due Date", "Importance");
                Console.WriteLine(new string(' ', 10) + new string('-', 94));

                // Printing out list of categories and tasks within
                foreach (var category in categories)
                {
                    Console.WriteLine("{0,-10} {1}", "Category:", category.Name);
                    for (int i = 0; i < category.TaskCount; i++)
                    {
                        var task = category.GetTask(i);
                        Console.Write("{0,10}|", i);
                        if (task.IsImportant)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write("{0,-30}|{1,-30}|{2,-30}|", task.Name, task.DueDate.ToString("yyyy-MM-dd"), task.IsImportant ? "Important" : "Normal");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    Console.WriteLine(new string(' ', 10) + new string('-', 94));
                }

                // Printing out menu options
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add new category");
                Console.WriteLine("2. Delete existing category");
                Console.WriteLine("3. Add new task");
                Console.WriteLine("4. Delete existing task");
                Console.WriteLine("5. Move task within category");
                Console.WriteLine("6. Move task to another category");
                Console.WriteLine("7. Highlight task");
                Console.WriteLine("8. Exit");

                // User input
                MenuOption choice = (MenuOption)Convert.ToInt32(Console.ReadLine());

                // Switch statement for each menu option - each case has a try-catch for seamless error-handling
                switch (choice)
                {
                    case MenuOption.AddCat:
                        CategoryManager.AddCategory(categories);
                        break;
                    case MenuOption.DeleteCat:
                        CategoryManager.DeleteCategory(categories);
                        break;
                    case MenuOption.AddTask:
                        CategoryManager.AddTask(categories);
                        break;
                    case MenuOption.DeleteTask:
                        CategoryManager.DeleteTask(categories);
                        break;
                    case MenuOption.MoveWithin:
                        CategoryManager.MoveTaskWithinCategory(categories);
                        break;
                    case MenuOption.MoveTo:
                        CategoryManager.MoveTaskToAnotherCategory(categories);
                        break;
                    case MenuOption.Highlight:
                        CategoryManager.HighlightTask(categories);
                        break;
                    case MenuOption.Exit:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    } 
}

