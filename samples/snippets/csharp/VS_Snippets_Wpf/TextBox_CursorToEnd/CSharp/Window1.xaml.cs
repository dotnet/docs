using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SDKSample
{
 
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        void OnClickMoveToEnd(object sender, RoutedEventArgs e)
        {
            tbPositionCursor.Focus();
            tbPositionCursor.Select(tbPositionCursor.Text.Length, 0);
        }

//<SnippetUIElementFocus>
        void OnClickMoveToStart(object sender, RoutedEventArgs e)
        {
            tbPositionCursor.Focus();
            tbPositionCursor.Select(0, 0);
        }
//</SnippetUIElementFocus>
    }
}