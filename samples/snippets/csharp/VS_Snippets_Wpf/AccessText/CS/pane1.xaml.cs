using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AccessTextSimple
{
	partial class Pane1 : StackPanel
	{
        public Pane1()
        {
            InitializeComponent();
            //button1.Click += new RoutedEventHandler(edit_Click);
        }

        void edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit button");
        }
        void cut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cut button");
        }

        void hello_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello button");
        }
    }
}
