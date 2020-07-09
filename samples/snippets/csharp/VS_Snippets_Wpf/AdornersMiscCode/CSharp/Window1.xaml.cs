using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AdornersMiscCode
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

    AdornerLayer myAdornerLayer;

    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
      {
        myAdornerLayer = AdornerLayer.GetAdornerLayer(myTextBox);
        // myAdornerLayer.Add(new SimpleCircleAdorner(myTextBox));

        // <Snippet_RemoveSpecificAdornerLong>
        Adorner[] toRemoveArray = myAdornerLayer.GetAdorners(myTextBox);
        Adorner toRemove;
        if (toRemoveArray != null)
        {
          toRemove = toRemoveArray[0];
          myAdornerLayer.Remove(toRemove);
        }
        // </Snippet_RemoveSpecificAdornerLong>

        // <Snippet_RemoveSpecificAdornerShort>
        try { myAdornerLayer.Remove((myAdornerLayer.GetAdorners(myTextBox))[0]); } catch { }
        // </Snippet_RemoveSpecificAdornerShort>
      }
      {
        foreach (UIElement toAdorn in myStackPanel.Children)
          myAdornerLayer.Add(new SimpleCircleAdorner(toAdorn));

        // <Snippet_RemoveAllAdornersLong>
        Adorner[] toRemoveArray = myAdornerLayer.GetAdorners(myTextBox);
        if (toRemoveArray != null)
        {
          for (int x = 0; x < toRemoveArray.Length; x++)
          {
            myAdornerLayer.Remove(toRemoveArray[x]);
          }
        }
        // </Snippet_RemoveAllAdornersLong>

        // <Snippet_RemoveAllAdornersShort>
        try { foreach (Adorner toRemove in myAdornerLayer.GetAdorners(myTextBox)) myAdornerLayer.Remove(toRemove); } catch { }
        // </Snippet_RemoveAllAdornersShort>
      }
    }

    // Sample event handler:
    // private void ButtonClick(object sender, RoutedEventArgs e) {}

    // Adorners must subclass the abstract base class Adorner.
    public class SimpleCircleAdorner : Adorner
    {
      // Be sure to call the base class constructor.
      public SimpleCircleAdorner(UIElement adornedElement)
        : base(adornedElement)
      {
        // Any constructor implementation...
      }

      // A common way to implement an adorner's rendering behavior is to override the OnRender
      // method, which is called by the layout subsystem as part of a rendering pass.
//<SnippetUIElementDesiredSize>
      protected override void OnRender(DrawingContext drawingContext)
      {
        // Get a rectangle that represents the desired size of the rendered element
        // after the rendering pass.  This will be used to draw at the corners of the
        // adorned element.
        Rect adornedElementRect = new Rect(this.AdornedElement.RenderSize);

        // Some arbitrary drawing implements.
        SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
        renderBrush.Opacity = 0.2;
        Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
        double renderRadius = 5.0;

        // Just draw a circle at each corner.
        drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
        drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
        drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
        drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
      }
//</SnippetUIElementDesiredSize>
    }
  }
}