using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections;

namespace SDKSample
{

    public partial class Window1 : Window
    {
        AdornerLayer _myAdornerLayer;

        public Window1()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            //<Snippet_AdornSingleElement>
            _myAdornerLayer = AdornerLayer.GetAdornerLayer(MyTextBox);
            _myAdornerLayer.Add(new SimpleCircleAdorner(MyTextBox));
            //</Snippet_AdornSingleElement>

            //<Snippet_AdornChildren>
            foreach (UIElement toAdorn in MyStackPanel.Children)
            {
                _myAdornerLayer.Add(new SimpleCircleAdorner(toAdorn));
            }
            //</Snippet_AdornChildren>
        }

        // Sample event handler:
        // private void ButtonClick(object sender, RoutedEventArgs e) {}

        //<Snippet_SimpleCircleAdornerBody>
        // Adorners must subclass the abstract base class Adorner.
        public class SimpleCircleAdorner : Adorner
        {
            // Be sure to call the base class constructor.
            public SimpleCircleAdorner(UIElement adornedElement)
              : base(adornedElement)
            {
            }

            // A common way to implement an adorner's rendering behavior is to override the OnRender
            // method, which is called by the layout system as part of a rendering pass.
            protected override void OnRender(DrawingContext drawingContext)
            {
                Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);

                // Some arbitrary drawing implements.
                SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
                renderBrush.Opacity = 0.2;
                Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
                double renderRadius = 5.0;

                // Draw a circle at each corner.
                drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
                drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
                drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
                drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
            }
        }
        //</Snippet_SimpleCircleAdornerBody>
    }
}
