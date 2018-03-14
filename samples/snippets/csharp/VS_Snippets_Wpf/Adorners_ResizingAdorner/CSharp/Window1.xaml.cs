using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
  public partial class Window1 : Window
  {
    AdornerLayer adornerLayer;

    public Window1()
    {
      InitializeComponent();
    }

    // To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
      adornerLayer = AdornerLayer.GetAdornerLayer(elementsGrid);
      
      foreach (Panel toAdorn in elementsGrid.Children)
        adornerLayer.Add(new ResizingAdorner(toAdorn.Children[0]));
    }
  }
}