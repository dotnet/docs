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

namespace WebUserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        //<snippet11>
        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WebFrame.Source = new Uri(this.UserSource.Text, UriKind.Absolute);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        //</snippet11>

        private void WebFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
