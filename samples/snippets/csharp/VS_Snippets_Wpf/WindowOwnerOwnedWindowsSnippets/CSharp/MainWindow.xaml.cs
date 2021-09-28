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

        void createOwnedWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: this commented section goes between the following two
            //       lines of code:
            //         ownedWindow.Owner = this;
            //         <-- goes here -->
            //         ownedWindow.Show();
            //ownedWindow.Title = "OwnedWindow" + (this.OwnedWindows.Count + 1).ToString();
            //ownedWindow.Loaded += delegate
            //{
            //    MessageBox.Show(ownedWindow.Owner.Title);
            //};

            //<SnippetSetWindowOwnerCODE>
            // Create a window and make this window its owner
            Window ownedWindow = new Window();
            ownedWindow.Owner = this;
            ownedWindow.Show();
            //</SnippetSetWindowOwnerCODE>
        }

        void enumerateOwnedWindowsButton_Click(object sender, RoutedEventArgs e)
        {
            // Enumerate the windows owned by this window
            //<SnippetGetWindowOwnedWindowsCODE>
            foreach (Window ownedWindow in this.OwnedWindows)
            {
                Console.WriteLine(ownedWindow.Title);
            }
            //</SnippetGetWindowOwnedWindowsCODE>
        }
    }
}