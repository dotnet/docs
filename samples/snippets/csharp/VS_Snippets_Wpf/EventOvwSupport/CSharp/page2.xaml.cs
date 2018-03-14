using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace SDKSample
{
    public partial class EventOvw2 : StackPanel
    {
//<SnippetEventSetterRef>
      void b1SetColor(object sender, RoutedEventArgs e)
      {
        Button b = e.Source as Button;
        b.Background = new SolidColorBrush(Colors.Azure);
      }

      void HandleThis(object sender, RoutedEventArgs e)
      {
        e.Handled=true;
      }
//</SnippetEventSetterRef>

//<SnippetAddHandlerHandledToo>
      void PrimeHandledToo(object sender, EventArgs e)
      {
          dpanel2.AddHandler(Button.ClickEvent, new RoutedEventHandler(GetHandledToo), true);
      }
//</SnippetAddHandlerHandledToo>
      void GetHandledToo(object sender, RoutedEventArgs e)
      {
         FrameworkElement feSource = e.Source as FrameworkElement;
         MessageBox.Show(feSource.Name + " raised an event with handled=" + e.Handled.ToString());
      }
    }
}