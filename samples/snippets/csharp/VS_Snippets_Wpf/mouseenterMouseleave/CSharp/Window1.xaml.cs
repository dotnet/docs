using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace WCSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    //<SnippetMouseEnterLeaveSampleEventHandlers>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        // raised when mouse cursor enters the area occupied by the element
        void OnMouseEnterHandler(object sender, MouseEventArgs e)
        {
            border1.Background = Brushes.Red;
        }

        // raised when mouse cursor leaves the area occupied by the element
        void OnMouseLeaveHandler(object sender, MouseEventArgs e)
        {
            border1.Background = Brushes.White;
        }
    }
    //</SnippetMouseEnterLeaveSampleEventHandlers>
}