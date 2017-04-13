using System.Windows;
using System.Collections.ObjectModel;

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

        // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        // private void WindowLoaded(object sender, RoutedEventArgs e) {}

        // Sample event handler:  
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

    }
}