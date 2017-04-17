using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace CSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        NavigationService NavigationService
        {
            get
            {
                return this.browserFrame.NavigationService;
            }
        }

        void MainWindow_Loaded(object sender, EventArgs e)
        {
            this.NavigationService.LoadCompleted += new LoadCompletedEventHandler(NavigationService_LoadCompleted);
        }

        //<SnippetMainWindowCODE>
        void goButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(this.addressTextBox.Text), DateTime.Now);
        }
        void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            DateTime requestDateTime = (DateTime)e.ExtraData;
            string msg = string.Format("Request started {0}\nRequest completed {1}", requestDateTime, DateTime.Now);
            MessageBox.Show(msg);
        }
        //</SnippetMainWindowCODE>
    }
}