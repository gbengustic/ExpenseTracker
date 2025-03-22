using System;

namespace ExpenseTracker
{
    // Represents an individual expense record
    public class Expense
    {
        public DateTime Date { get; set; }     // Date of the expense
        public string Category { get; set; }   // Expense category (e.g., Food, Travel)
        public decimal Amount { get; set; }    // Amount spent
        public string Description { get; set; } // Short description of the expense

        // Constructor to initialize the expense object
        public Expense(DateTime date, string category, decimal amount, string description)
        {
            Date = date;
            Category = category;
            Amount = amount;
            Description = description;
        }

        // Overrides the default ToString method for a readable display
        public override string ToString()
        {
            return $"{Date.ToShortDateString()} | {Category} | ${Amount} | {Description}";
        }
    }
}
