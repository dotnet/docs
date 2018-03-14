using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class ResourcesSH : Page
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
        Application currentApp = Application.Current;
        NavigationWindow nw = currentApp.Windows[0] as NavigationWindow;
        nw.Source = new Uri("page4.xaml", UriKind.RelativeOrAbsolute);
      }
      void NavTo5(object sender, RoutedEventArgs args)
      {
          Application currentApp = Application.Current;
          NavigationWindow nw = currentApp.Windows[0] as NavigationWindow;
          nw.Source = new Uri("page5.xaml", UriKind.RelativeOrAbsolute);
      }
      void NavTo6(object sender, RoutedEventArgs args)
      {
          Application currentApp = Application.Current;
          NavigationWindow nw = currentApp.Windows[0] as NavigationWindow;
          nw.Source = new Uri("page6.xaml", UriKind.RelativeOrAbsolute);
      }
        void NavTo7(object sender, RoutedEventArgs args)
        {
            Application currentApp = Application.Current;
            NavigationWindow nw = currentApp.Windows[0] as NavigationWindow;
            nw.Source = new Uri("page7.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}