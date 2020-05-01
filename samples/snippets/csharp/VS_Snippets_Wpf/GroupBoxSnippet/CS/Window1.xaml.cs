using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GroupBoxSnippet
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
     private void SubmitCode(object sender, RoutedEventArgs e) {
     //dummy handler since this is just snippet code
     }
  }
}