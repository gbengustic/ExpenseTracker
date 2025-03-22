using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker
{
    // Manages the list of expenses and operations on them
    public class ExpenseManager
    {
        // A list to store all expense records
        private List<Expense> Expenses = new List<Expense>();

        // Adds a new expense to the list
        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
            Console.WriteLine("Expense added successfully!");
        }

        // Displays all recorded expenses
        public void ViewExpenses()
        {
            Console.WriteLine("\n--- All Expenses ---");

            // Check if there are no expenses yet
            if (Expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded yet.");
                return;
            }

            // Loop through and display each expense
            foreach (var exp in Expenses)
            {
                Console.WriteLine(exp);
            }
        }

        // Deletes an expense based on the provided date
        public void DeleteExpense(DateTime date)
        {
            // Find the expense by matching the date
            var expense = Expenses.FirstOrDefault(e => e.Date == date);

            if (expense != null)
            {
                Expenses.Remove(expense);
                Console.WriteLine("Expense deleted successfully!");
            }
            else
            {
                Console.WriteLine("Expense not found!");
            }
        }

        // Generates a report for a specific month and year
        public void GenerateMonthlyReport(int month, int year)
        {
            // Filter expenses for the specified month and year
            var monthlyExpenses = Expenses.Where(e => e.Date.Month == month && e.Date.Year == year);

            Console.WriteLine($"\n--- Expense Report for {month}/{year} ---");

            // If no expenses found, notify the user
            if (!monthlyExpenses.Any())
            {
                Console.WriteLine("No expenses found for the specified period.");
                return;
            }

            // Calculate the total amount spent
            decimal total = 0;
            foreach (var exp in monthlyExpenses)
            {
                Console.WriteLine(exp);
                total += exp.Amount;
            }

            Console.WriteLine($"Total Expenses: ${total}");
        }
    }
}
