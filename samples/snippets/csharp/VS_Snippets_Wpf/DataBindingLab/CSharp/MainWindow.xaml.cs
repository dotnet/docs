using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.ComponentModel;

namespace DataBindingLab
{
    public partial class MainWindow : Window
    {
        //<Snippet4>
        CollectionViewSource listingDataView;

        public MainWindow()
        {
            InitializeComponent();
            listingDataView = (CollectionViewSource)(this.Resources["listingDataView"]);
        }
        //</Snippet4>

        private void OpenAddProductWindow(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
        }

        //<Snippet5>
        private void ShowOnlyBargainsFilter(object sender, FilterEventArgs e)
        {
            AuctionItem product = e.Item as AuctionItem;
            if (product != null)
            {
                // Filter out products with price 25 or above
                if (product.CurrentPrice < 25)
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }
        //</Snippet5>

        private void AddGrouping(object sender, RoutedEventArgs args)
        {
        //<Snippet6>
            // This groups the items in the view by the property "Category"
            PropertyGroupDescription groupDescription = new PropertyGroupDescription();
            groupDescription.PropertyName = "Category";
            listingDataView.GroupDescriptions.Add(groupDescription);
        //</Snippet6>
        }

        //<Snippet7>
        private void RemoveGrouping(object sender, RoutedEventArgs args)
        {
            listingDataView.GroupDescriptions.Clear();
        }
        //</Snippet7>

        //<Snippet8>
        private void AddSorting(object sender, RoutedEventArgs args)
        {
            // This sorts the items first by Category and within each Category,
            // by StartDate. Notice that because Category is an enumeration,
            // the order of the items is the same as in the enumeration declaration
            listingDataView.SortDescriptions.Add(
                new SortDescription("Category", ListSortDirection.Ascending));
            listingDataView.SortDescriptions.Add(
                new SortDescription("StartDate", ListSortDirection.Ascending));
        }
        //</Snippet8>

        //<Snippet9>
        private void RemoveSorting(object sender, RoutedEventArgs args)
        {
            listingDataView.SortDescriptions.Clear();
        }
        //</Snippet9>

        private void AddFiltering(object sender, RoutedEventArgs args)
        {
        //<Snippet10>
            listingDataView.Filter += new FilterEventHandler(ShowOnlyBargainsFilter);
        //</Snippet10>
        }

        //<Snippet11>
        private void RemoveFiltering(object sender, RoutedEventArgs args)
        {
            listingDataView.Filter -= new FilterEventHandler(ShowOnlyBargainsFilter);
        }
        //</Snippet11>
    }
}