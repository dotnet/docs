using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Xml;

namespace SDKSample
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

        TextBox tb = new TextBox();
        void OnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            if ((sender as ListBox).SelectedItem != null)
                tb1.Text = ((sender as ListBox).SelectedItem as XmlNode).InnerText;
        }
    }
}