using System;

namespace ExpenseTrackerWPF.Models
{
    // Represents an expense record
    public class Expense
    {
        // Date of the expense
        public DateTime Date { get; set; }

        // Category of the expense (e.g., Food, Transport)
        public string Category { get; set; }

        // Amount spent
        public decimal Amount { get; set; }

        // Short description of the expense
        public string Description { get; set; }
    }
}
