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
using System.Xml;

namespace ListViewHowTos
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        //<Snippet6>
        void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            XmlElement book = ((ListViewItem) sender).Content as XmlElement;

            if (book == null)
            {
                return;
            }

            if (book.GetAttribute("Stock") == "out")
            {
                MessageBox.Show("Time to order more copies of " + book["Title"].InnerText);
            }
            else
            {
                MessageBox.Show(book["Title"].InnerText + " is available.");
            }
        }
        //</Snippet6>
    }
}
