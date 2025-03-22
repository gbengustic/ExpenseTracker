using System;

namespace ExpenseTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpenseManager manager = new ExpenseManager(); // Create an instance of ExpenseManager
            bool running = true;  // Flag to control the application loop

            while (running)
            {
                // Display menu options
                Console.WriteLine("\n--- Expense Tracker Menu ---");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. Delete Expense");
                Console.WriteLine("4. Generate Monthly Report");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add a new expense
                        Console.Write("Enter Date (yyyy-mm-dd): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Category (e.g., Food, Travel): ");
                        string category = Console.ReadLine();

                        Console.Write("Enter Amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Description: ");
                        string description = Console.ReadLine();

                        // Create and add the expense
                        Expense expense = new Expense(date, category, amount, description);
                        manager.AddExpense(expense);
                        break;

                    case "2":
                        // View all expenses
                        manager.ViewExpenses();
                        break;

                    case "3":
                        // Delete an expense based on the date
                        Console.Write("Enter Date of Expense to Delete (yyyy-mm-dd): ");
                        DateTime delDate = DateTime.Parse(Console.ReadLine());
                        manager.DeleteExpense(delDate);
                        break;

                    case "4":
                        // Generate a report for a specific month and year
                        Console.Write("Enter Month (1-12): ");
                        int month = int.Parse(Console.ReadLine());

                        Console.Write("Enter Year: ");
                        int year = int.Parse(Console.ReadLine());

                        manager.GenerateMonthlyReport(month, year);
                        break;

                    case "5":
                        running = false;  // Exit the application
                        Console.WriteLine("Exiting... Thank you for using the Expense Tracker!");
                        break;

                    default:
                        // Handle invalid inputs
                        Console.WriteLine("Invalid option! Please try again.");
                        break;
                }
            }
        }
    }
}
