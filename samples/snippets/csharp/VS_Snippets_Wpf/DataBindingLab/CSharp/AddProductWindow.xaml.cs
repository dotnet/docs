using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DataBindingLab
{
    public partial class AddProductWindow : Window
    {

        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void OnInit(object sender, RoutedEventArgs e)
        {
            this.DataContext = new AuctionItem("Type your description here",
                ProductCategory.DVDs, 1, DateTime.Now, ((DataBindingLabApp)Application.Current).CurrentUser,
                SpecialFeatures.None);
        }

        private void SubmitProduct(object sender, RoutedEventArgs e)
        {
            AuctionItem item = (AuctionItem)(this.DataContext);
            ((DataBindingLabApp)Application.Current).AuctionItems.Add(item);
            this.Close();
        }
    }
}