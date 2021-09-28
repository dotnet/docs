using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HOWTOWindowManagementSnippets
{
    public partial class CustomWindow : Window
    {
        public CustomWindow()
        {
            InitializeComponent();

            //<SnippetSettingMainWindowInCodeCODEBEHIND>
            NotTheFirstWindow mainWindow = new NotTheFirstWindow();
            Application.Current.MainWindow = mainWindow;
            //</SnippetSettingMainWindowInCodeCODEBEHIND>

            //<SnippetGetAllWindows>
            foreach( Window window in Application.Current.Windows ) {
              Console.WriteLine(window.Title);
            }
            //</SnippetGetAllWindows>
        }
    }
}