using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResourcesSample
{
    /// <summary>
    /// Interaction logic for UriClassSnippetPage.xaml
    /// </summary>

    public partial class UriClassSnippetPage : Page
    {
        public UriClassSnippetPage()
        {
            InitializeComponent();

        }

        void bob(object sender, RoutedEventArgs e)
        {
            //Uri uri = new Uri("pack://application:,,,/File.xaml"); // Absolute
            //Uri uri = new Uri("/File.xaml", UriKind.Absolute);// Relative
            
            TextBox userProvidedUriTextBox = new TextBox();
            userProvidedUriTextBox.Text = "pack://application:,,,/File.xaml";
            Uri uri = new Uri(userProvidedUriTextBox.Text, UriKind.RelativeOrAbsolute);// RelativeOrAbsoluteAbsolute
            this.NavigationService.Navigate(uri);
        }

    }
}