using System;
using System.Windows;
using ExpenseTrackerWPF.Models;
using ExpenseTrackerWPF.Services;

namespace ExpenseTrackerWPF
{
    public partial class AddExpenseWindow : Window
    {
        // Reference to the expense manager for adding new expenses
        private ExpenseManager expenseManager;

        public AddExpenseWindow(ExpenseManager manager)
        {
            InitializeComponent();
            expenseManager = manager;
        }

        // Event handler to save a new expense
        private void SaveExpense_Click(object sender, RoutedEventArgs e)
        {
            // Validate the amount input
            if (decimal.TryParse(AmountInput.Text, out decimal amount))
            {
                // Create a new expense object with the provided inputs
                Expense expense = new Expense
                {
                    Date = DateTime.Now,  // Automatically set the date to today
                    Category = CategoryInput.Text,
                    Amount = amount,
                    Description = DescriptionInput.Text
                };

                // Add the expense to the manager
                expenseManager.AddExpense(expense);
                Close();  // Close the AddExpenseWindow
            }
            else
            {
                MessageBox.Show("Invalid amount entered. Please enter a valid number.");
            }
        }
    }
}
