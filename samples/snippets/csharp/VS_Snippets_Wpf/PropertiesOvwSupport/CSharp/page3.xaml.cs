using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
namespace MyNamespace
{
  public partial class MyCanvasCode : Canvas
  {
    void DoStuff() {
//<SnippetDPBasicPropSet>
      myCanvas.Background = new SolidColorBrush(Colors.Green);
//</SnippetDPBasicPropSet>
    }
//<SnippetResourceProceduralGet>
    void SetBGByResource(object sender, RoutedEventArgs e)
    {
      Button b = sender as Button;
      b.Background = (Brush)this.FindResource("RainbowBrush");
    }
//</SnippetResourceProceduralGet>
    void WrapsAroundDOTCode()
    {
//<SnippetDOTFromSystemType>
        DependencyObjectType dt =
            DependencyObjectType.FromSystemType(typeof(Window));
//</SnippetDOTFromSystemType>
    }
    void OnTheFlyResource(object sender, RoutedEventArgs e)
    {
      Button b = sender as Button;
      ResourceDictionary rd = new ResourceDictionary();
      SolidColorBrush SecretSauce = new SolidColorBrush(Colors.MediumOrchid);
      rd.Add("SecretSauce", SecretSauce);
      b.Resources = rd;
      b.Background = (Brush)b.FindResource("RainbowBrush");
      //b.Background = (Brush) b.FindResource("SecretSauce");
      WrapsAroundDOTCode();
    }
  }
//<SnippetOverrideMetadata>
  public class SpinnerControl : ItemsControl
  {
      static SpinnerControl()
      {
          DefaultStyleKeyProperty.OverrideMetadata(
              typeof(SpinnerControl), 
              new FrameworkPropertyMetadata(typeof(SpinnerControl))
          );
      }
  }
//</SnippetOverrideMetadata>
}
