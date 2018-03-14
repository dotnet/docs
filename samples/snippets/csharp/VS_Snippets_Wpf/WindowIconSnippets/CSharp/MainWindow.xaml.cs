using System;
using System.Windows;

using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using System.IO;
using System.Windows.Resources;

namespace SDKSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
//<SnippetSetWindowIconInCode>
// Set an icon using code
Uri iconUri = new Uri("pack://application:,,,/WPFIcon2.ico", UriKind.RelativeOrAbsolute);
this.Icon = BitmapFrame.Create(iconUri);
//</SnippetSetWindowIconInCode>
        }

    }
}