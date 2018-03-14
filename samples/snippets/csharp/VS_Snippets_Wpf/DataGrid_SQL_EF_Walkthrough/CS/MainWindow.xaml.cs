// <snippet2>
using System.Data.Objects;
using System.Linq;
using System.Windows;

namespace DataGridSQLExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdventureWorksLT2008Entities dataEntities = new AdventureWorksLT2008Entities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectQuery<Product> products = dataEntities.Products;

            var query =
            from product in products
            where product.Color == "Red"
            orderby product.ListPrice
            select new { product.Name, product.Color, CategoryName = product.ProductCategory.Name, product.ListPrice };

            dataGrid1.ItemsSource = query.ToList();
        }
    }
}
// </snippet2>
