//<snippet10>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFWithWFAndDatabinding
{
    public partial class MainWindow : Window
    {
        //<snippet11>
        private System.Windows.Forms.BindingSource nwBindingSource;
        private NorthwindDataSet nwDataSet;
        private NorthwindDataSetTableAdapters.CustomersTableAdapter customersTableAdapter =
            new NorthwindDataSetTableAdapters.CustomersTableAdapter();
        private NorthwindDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter =
            new NorthwindDataSetTableAdapters.OrdersTableAdapter();
        //</snippet11>

        //<snippet12>
        public MainWindow()
        {
            InitializeComponent();

            // Create a DataSet for the Customers data.
            this.nwDataSet = new NorthwindDataSet();
            this.nwDataSet.DataSetName = "nwDataSet";

            // Create a BindingSource for the Customers data.
            this.nwBindingSource = new System.Windows.Forms.BindingSource();
            this.nwBindingSource.DataMember = "Customers";
            this.nwBindingSource.DataSource = this.nwDataSet;
        }
        //</snippet12>

        //<snippet13>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Fill the Customers table adapter with data.
            this.customersTableAdapter.ClearBeforeFill = true;
            this.customersTableAdapter.Fill(this.nwDataSet.Customers);

            // Fill the Orders table adapter with data.
            this.ordersTableAdapter.Fill(this.nwDataSet.Orders);

            // Assign the BindingSource to
            // the data context of the main grid.
            this.mainGrid.DataContext = this.nwBindingSource;

            // Assign the BindingSource to
            // the data source of the list box.
            this.listBox1.ItemsSource = this.nwBindingSource;

            // Because this is a master/details form, the DataGridView
            // requires the foreign key relating the tables.
            this.dataGridView1.DataSource = this.nwBindingSource;
            this.dataGridView1.DataMember = "FK_Orders_Customers";

            // Handle the currency management aspect of the data models.
            // Attach an event handler to detect when the current item
            // changes via the WPF ListBox. This event handler synchronizes
            // the list collection with the BindingSource.
            //

            BindingListCollectionView cv = CollectionViewSource.GetDefaultView(
                this.nwBindingSource) as BindingListCollectionView;

            cv.CurrentChanged += new EventHandler(WPF_CurrentChanged);
        }
        //</snippet13>

        //<snippet14>
        // This event handler updates the current item
        // of the data binding.
        void WPF_CurrentChanged(object sender, EventArgs e)
        {
            BindingListCollectionView cv = sender as BindingListCollectionView;
            this.nwBindingSource.Position = cv.CurrentPosition;
        }
        //</snippet14>
    }
}
//</snippet10>