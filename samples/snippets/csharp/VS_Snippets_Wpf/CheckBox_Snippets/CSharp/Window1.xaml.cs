using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CheckBox_Snippets
{
    partial class Window1 : Window
    {
        public Window1()
            : base()
        {
            InitializeComponent();

        }

        //<Snippet3>
        void chkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            textBlock1.FontStyle = FontStyles.Normal;
        }

        void chkbox_Checked(object sender, RoutedEventArgs e)
        {
            textBlock1.FontStyle = FontStyles.Italic;
        }
        //</Snippet3>

        //<Snippet5>
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox is checked.";
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox is unchecked.";
        }

        private void HandleThirdState(object sender, RoutedEventArgs e)
        {
            text1.Text = "The CheckBox is in the indeterminate state.";
        }
        //</Snippet5>
    }
}
