using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace StrokeCollectionShadow
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
            : base()
        {
            InitializeComponent();
        }

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, EventArgs e) {}

        // Sample event handler:  
        private void Toggle3d_Click(object sender, RoutedEventArgs e) 
        {
            myInkSelector.Shadowed = !myInkSelector.Shadowed;
        }

    }
}