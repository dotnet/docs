using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Collections;

namespace ExpenseIt
{
    public partial class AddExpensesPage : Page
    {
        private void AddExpense(object sender, RoutedEventArgs args)
        {
            Application app = (Application)System.Windows.Application.Current;
            ExpenseReport expenseReport = (ExpenseReport)app.FindResource("ExpenseData");
            expenseReport.LineItems.Add(new LineItem());
        }

        private void ViewChart(object sender, RoutedEventArgs args)
        {
            // Navigate to page
            this.NavigationService.Navigate(new Uri("ViewChartPage.xaml", UriKind.Relative));
        }
    }
}

