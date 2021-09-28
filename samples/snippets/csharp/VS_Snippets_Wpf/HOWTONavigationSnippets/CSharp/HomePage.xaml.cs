using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HOWTONavigationSnippets
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>

    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            //<SnippetManipulatePageHostWindowProperties>
            // Set host window's Title, Width, and Height
            this.WindowTitle = "New Title Set by a Page!";
            this.WindowWidth = 500;
            this.WindowHeight = 500;
            //</SnippetManipulatePageHostWindowProperties>
        }

        //<SnippetNavigateBackCODE>
        void navigateBackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back one page from this page, if there is an entry
            // in back navigation history
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("No entries in back navigation history.");
            }
        }
        //</SnippetNavigateBackCODE>

        //<SnippetNavigateForwardCODE>
        void navigateForwardButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate forward one page from this page, if there is an entry
            // in forward navigation history
            if (this.NavigationService.CanGoForward)
            {
                this.NavigationService.GoForward();
            }
            else
            {
                MessageBox.Show("No entries in forward navigation history.");
            }
        }
        //</SnippetNavigateForwardCODE>
    }
}