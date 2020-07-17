using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bindings
{
    /// <summary>
    /// Interaction logic for CollectionView.xaml
    /// </summary>
    public partial class CollectionView : Window
    {
        public CollectionViewSource listingDataView;

        public CollectionView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listingDataView = (CollectionViewSource)Resources["listingDataView"];
        }

        // <ListingViewFilter>
        private void AddFilteringCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (((CheckBox)sender).IsChecked == true)
                listingDataView.Filter += ListingDataView_Filter;
            else
                listingDataView.Filter -= ListingDataView_Filter;
        }
        // </ListingViewFilter>

        private void AddGroupingCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // <ListingGroupCheck>
            // This groups the items in the view by the property "Category"
            var groupDescription = new PropertyGroupDescription();
            groupDescription.PropertyName = "Category";
            listingDataView.GroupDescriptions.Add(groupDescription);
            // </ListingGroupCheck>
        }

        // <FilterEvent>
        private void ListingDataView_Filter(object sender, FilterEventArgs e)
        {
            // Start with everything excluded
            e.Accepted = false;

            // Only inlcude items with a price less than 25
            if (e.Item is AuctionItem product && product.CurrentPrice < 25)
                e.Accepted = true;
        }
        // </FilterEvent>

        // <AddSortChecked>
        private void AddSortCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Sort the items first by Category and then by StartDate
            listingDataView.SortDescriptions.Add(new SortDescription("Category", ListSortDirection.Ascending));
            listingDataView.SortDescriptions.Add(new SortDescription("StartDate", ListSortDirection.Ascending));
        }
        // </AddSortChecked>
    }
}
