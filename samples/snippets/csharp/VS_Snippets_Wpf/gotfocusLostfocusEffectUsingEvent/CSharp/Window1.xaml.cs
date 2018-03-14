using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Input;


namespace SDKSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    //<SnippetGotLostFocusSampleEventHandlers>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        // Raised when Button gains focus.
        // Changes the color of the Button to Red.
        private void OnGotFocusHandler(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Background = Brushes.Red;
        }
        // Raised when Button losses focus. 
        // Changes the color of the Button back to white.
        private void OnLostFocusHandler(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Background = Brushes.White;
        }
    }
    //</SnippetGotLostFocusSampleEventHandlers>

}