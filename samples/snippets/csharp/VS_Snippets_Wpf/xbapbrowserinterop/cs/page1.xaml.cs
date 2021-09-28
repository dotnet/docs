using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Interop;

namespace WpfBrowserApplication1
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        //<snippet10>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the script object. The XBAP must be hosted in a frame or
            // the HostScript object will be null.
            var scriptObject = BrowserInteropHelper.HostScript;

            // Call close to close the browser window.
            scriptObject.Close();
        }
        //</snippet10>
    }
}
