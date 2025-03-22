using System.Windows;
using ExpenseTrackerWPF.Models;
using ExpenseTrackerWPF.Services;

namespace ExpenseTrackerWPF
{
    public partial class MainWindow : Window
    {
        // Instance of ExpenseManager to manage expense data
        private ExpenseManager expenseManager;

        public MainWindow()
        {
            InitializeComponent();
            expenseManager = new ExpenseManager();  // Initialize the manager
            ExpensesDataGrid.ItemsSource = expenseManager.Expenses;  // Bind data to DataGrid
        }

        // Event handler to open the Add Expense window
        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            // Open the AddExpenseWindow and pass the expense manager for data synchronization
            var addExpenseWindow = new AddExpenseWindow(expenseManager);
            addExpenseWindow.ShowDialog();
        }

        // Event handler to delete the selected expense
        private void DeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            // Check if an expense is selected in the DataGrid
            if (ExpensesDataGrid.SelectedItem is Expense selectedExpense)
            {
                expenseManager.DeleteExpense(selectedExpense);
            }
            else
            {
                MessageBox.Show("Please select an expense to delete.");
            }
        }
    }
}
