using System;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using ExpenseTrackerWPF.Models;

namespace ExpenseTrackerWPF.Services
{
    public class ExpenseManager
    {
        // File path for saving and loading expenses
        private const string FilePath = "expenses.json";

        // Collection to store expenses and support data binding
        public ObservableCollection<Expense> Expenses { get; private set; }

        // Constructor: Load existing expenses from the JSON file
        public ExpenseManager()
        {
            Expenses = LoadExpenses();
        }

        // Load expenses from the JSON file
        private ObservableCollection<Expense> LoadExpenses()
        {
            // Check if the JSON file exists
            if (File.Exists(FilePath))
            {
                // Read and deserialize JSON data into the expense collection
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<ObservableCollection<Expense>>(json)
                       ?? new ObservableCollection<Expense>();
            }

            // If the file doesn't exist, return an empty collection
            return new ObservableCollection<Expense>();
        }

        // Add a new expense to the collection and save to file
        public void AddExpense(Expense expense)
        {
            Expenses.Add(expense);
            SaveExpenses();  // Save updated data to the JSON file
        }

        // Delete a selected expense and update the JSON file
        public void DeleteExpense(Expense expense)
        {
            Expenses.Remove(expense);
            SaveExpenses();
        }

        // Save the current expenses to the JSON file
        private void SaveExpenses()
        {
            string json = JsonConvert.SerializeObject(Expenses, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
