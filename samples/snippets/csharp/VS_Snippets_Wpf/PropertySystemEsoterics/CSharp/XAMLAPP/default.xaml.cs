
using System;
using System.Windows;
using System.Collections;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Text;

namespace SDKSample {
    public partial class XAMLAPP{
      void ReportState(object sender, EventArgs e)
      {
        StringBuilder sb = new StringBuilder();
        TextBlock tb = new TextBlock();
        //<SnippetGetMetadataInit>
        PropertyMetadata pm;
        //</SnippetGetMetadataInit>
        sb.Append("MyStateControl State default = ");
        //<SnippetGetMetadataType>
        pm = MyStateControl.StateProperty.GetMetadata(typeof(MyStateControl));
        //</SnippetGetMetadataType>
        sb.Append(pm.DefaultValue.ToString());
        sb.Append("\n");
        sb.Append("UnrelatedStateControl State default = ");
        //<SnippetGetMetadataDOType>
        DependencyObjectType dt = unrelatedInstance.DependencyObjectType;
        pm = UnrelatedStateControl.StateProperty.GetMetadata(dt);
        //</SnippetGetMetadataDOType>
        sb.Append(pm.DefaultValue.ToString());
        sb.Append("\n");
        sb.Append("MyAdvancedStateControl State default = ");
        //<SnippetGetMetadataDOInstance>
        pm = MyAdvancedStateControl.StateProperty.GetMetadata(advancedInstance);
        //</SnippetGetMetadataDOInstance>
        sb.Append(pm.GetType().ToString());
        sb.Append("\n");
        //</SnippetDefaultMetadataDOInstance>
        tb.Text = sb.ToString();
        root.Children.Add(tb);
      }
      void NavPage2(object sender, RoutedEventArgs e)
      {
        Application currentApp = Application.Current;
        NavigationWindow nw = currentApp.Windows[0] as NavigationWindow;
        nw.Source = new Uri("page2.xaml", UriKind.RelativeOrAbsolute);
      }
  }
}