using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class PropertiesOvw : StackPanel
    {
      void NavTo1(object sender, RoutedEventArgs args)
      {
        Application currentApp = Application.Current;
        NavigationWindow nw = currentApp.Windows[0] as NavigationWindow;
        nw.Source = new Uri("page1.xaml", UriKind.RelativeOrAbsolute);
      }
      void NavTo2(object sender, RoutedEventArgs args)
      {
        Application currentApp = Application.Current;
        NavigationWindow nw = currentApp.Windows[0] as NavigationWindow;
        nw.Source = new Uri("page2.xaml",UriKind.RelativeOrAbsolute);
      }
      void NavTo3(object sender, RoutedEventArgs args)
      {
        Application currentApp = Application.Current;
        NavigationWindow nw = currentApp.Windows[0] as NavigationWindow;
        nw.Source = new Uri("page3.xaml", UriKind.RelativeOrAbsolute);
      }
      void NavTo4(object sender, RoutedEventArgs args)
      {
          this.browserFrame.Navigate(new Uri("page4.xaml#Fragment3", UriKind.RelativeOrAbsolute));
      }
      //<SnippetFEBringIntoView>
      void browserFrame_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
      {
          object content = ((ContentControl)e.Navigator).Content;
          FrameworkContentElement fragmentElement = LogicalTreeHelper.FindLogicalNode((DependencyObject)content, e.Fragment) as FrameworkContentElement;
          if (fragmentElement != null)
          {
              // Go to fragment if found
              fragmentElement.BringIntoView();
          }
          e.Handled = true;
      }
      //</SnippetFEBringIntoView>
    }
}