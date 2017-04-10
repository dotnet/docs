using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace SDKSample
{
    public partial class RoutedEventHandle : StackPanel
    {
		StringBuilder eventstr = new StringBuilder();
      void NavTo2(object sender, RoutedEventArgs args)
      {
        Application currentApp = Application.Current;
        NavigationWindow nw = currentApp.Windows[0] as NavigationWindow;
        nw.Source = new Uri("page2.xaml",UriKind.RelativeOrAbsolute);
      }
//<SnippetSimpleHandlerA>      
      void b1SetColor(object sender, RoutedEventArgs args)
      {
        //logic to handle the Click event
//</SnippetSimpleHandlerA>

//<SnippetSimpleHandlerB>
      }
//</SnippetSimpleHandlerB>
//<SnippetGroupButtonCodeBehind>
      private void CommonClickHandler(object sender, RoutedEventArgs e)
      {
        FrameworkElement feSource = e.Source as FrameworkElement;
        switch (feSource.Name)
        {
          case "YesButton":
            // do something here ...
            break;
          case "NoButton":
            // do something ...
            break;
          case "CancelButton":
            // do something ...
            break;
        }
        e.Handled=true;
      }
//</SnippetGroupButtonCodeBehind>
//<SnippetAddHandlerCode>
       void MakeButton()
        {
            Button b2 = new Button();
            b2.AddHandler(Button.ClickEvent, new RoutedEventHandler(Onb2Click));
        }
        void Onb2Click(object sender, RoutedEventArgs e)
        {
            //logic to handle the Click event     
        }
//</SnippetAddHandlerCode>
//<SnippetAddHandlerPlusEquals>
        void MakeButton2()
        {
          Button b2 = new Button();
          b2.Click += new RoutedEventHandler(Onb2Click2);
        }
        void Onb2Click2(object sender, RoutedEventArgs e)
        {
          //logic to handle the Click event     
        }
//</SnippetAddHandlerPlusEquals>
    }
}