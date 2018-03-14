using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Xml;
using System.Globalization;

namespace ExpenseIt
{
// TODO: MJW - Validation and OK button
// TODO: MJW - tooltip styling

    public partial class HomePage : Page
    {
        private void Init(object sender, System.EventArgs args)
        {
            this.employeeTypeOptions.SelectedIndex = 0;
        }

        private void CreateReport(object sender, RoutedEventArgs args)
        {
            this.NavigationService.Navigate(new Uri("AddExpensesPage.xaml", UriKind.Relative));
        }

        private void OnEmployeeTypeChanged(object sender, SelectionChangedEventArgs args)
        {
            if (args.AddedItems.Count > 0)
            {
                ListBoxItem item = args.AddedItems[0] as ListBoxItem;
                string query = string.Format(CultureInfo.InvariantCulture, "/Employees/Employee[@Type='{0}']", item.Content);

                XmlDataProvider employeesDataSrc = (XmlDataProvider)root.FindResource("Employees");
                employeesDataSrc.XPath = query;
                employeesDataSrc.Refresh();
            }
        }
    }
}

