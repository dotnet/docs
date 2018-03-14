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
using System.Windows.Shapes;

namespace FlowDocSelection
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        //<Snippet4>
        private void ShowSelection_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(flowdocScrollViewer1.Selection.Text);
        }
        //</Snippet4>
    }
}
