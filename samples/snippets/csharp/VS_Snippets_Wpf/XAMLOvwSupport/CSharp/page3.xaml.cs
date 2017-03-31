using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
//<SnippetButtonWithCodeBehindHandler>
namespace ExampleNamespace
{
  public partial class ExamplePage
  {
    void Button_Click(object sender, RoutedEventArgs e)
    {
      Button b = e.Source as Button;
      b.Foreground = Brushes.Red;
    }
  }
}
//</SnippetButtonWithCodeBehindHandler>
