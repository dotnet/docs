using MahApps.Metro.Controls;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebSiteRatings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModels.SiteCollection siteCollection = new ViewModels.SiteCollection();
            siteCollection.Load();
            DataContext = siteCollection;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var siteCollection = (ViewModels.SiteCollection)DataContext;

            if (siteCollection.SelectedSite != null)
                browser.Source = new Uri(siteCollection.SelectedSite.Url);
            else
                browser.NavigateToString("<body></body>");
        }
    }
}
