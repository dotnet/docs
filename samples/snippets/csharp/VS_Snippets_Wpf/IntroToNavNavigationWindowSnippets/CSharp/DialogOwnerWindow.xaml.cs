using System;
using System.Windows;

namespace SDKSample
{
    public partial class DialogOwnerWindow : Window
    {
        public DialogOwnerWindow()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(DialogOwnerWindow_Loaded);
        }

        void DialogOwnerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //<SnippetCreateNWDialogBox>
            // Open a navigation window as a dialog box
            NavigationWindowDialogBox dlg = new NavigationWindowDialogBox();
            dlg.Source = new Uri("HomePage.xaml", UriKind.Relative);
            dlg.Owner = this;
            dlg.ShowDialog();
            //</SnippetCreateNWDialogBox>
        }
    }
}