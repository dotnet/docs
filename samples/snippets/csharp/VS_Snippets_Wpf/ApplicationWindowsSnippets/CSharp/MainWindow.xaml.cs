//<SnippetMainWindowSetWindowsCODEBEHIND1>
using System;
using System.Windows;
using System.Windows.Controls;

namespace CSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //</SnippetMainWindowSetWindowsCODEBEHIND1>
        void newWindowMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
        }

        void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //<SnippetMainWindowSetWindowsCODEBEHIND2>
        void MainWindow_Activated(object sender, EventArgs e)
        {
            this.windowMenuItem.Items.Clear();
            int windowCount = 0;
            foreach (Window window in Application.Current.Windows)
            {
                ++windowCount;
                WindowMenuItem menuItem = new WindowMenuItem();
                menuItem.Window = window;
                menuItem.Header = "_" + windowCount.ToString() + " Window " + windowCount.ToString();
                menuItem.Click += new RoutedEventHandler(menuItem_Click);
                this.windowMenuItem.Items.Add(menuItem);
            }
        }

        void menuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowMenuItem menuItem = (WindowMenuItem)sender;
            menuItem.Window.Activate();
        }
    }
}
//</SnippetMainWindowSetWindowsCODEBEHIND2>