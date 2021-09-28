using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SDKSample
{
    public partial class Window1 : Window
    {
        // Handle the Click event for the button.
        private void OnClick(object sender, EventArgs e)
        {
            Stub01();
        }

        // <SnippetPerformanceSnippet1>
        private void OnBuildTreeTopDown(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Default";

            DockPanel parentPanel = new DockPanel();
            DockPanel childPanel;

            myCanvas.Children.Add(parentPanel);
            myCanvas.Children.Add(textBlock);

            for (int i = 0; i < 150; i++)
            {
                textBlock = new TextBlock();
                textBlock.Text = "Default";
                parentPanel.Children.Add(textBlock);

                childPanel = new DockPanel();
                parentPanel.Children.Add(childPanel);
                parentPanel = childPanel;
            }
        }
        // </SnippetPerformanceSnippet1>

        public void Stub01()
        {
            Brush myBrush = Brushes.Blue;
            Rectangle rectangle_1 = new Rectangle();
            Rectangle rectangle_2 = new Rectangle();
            Rectangle rectangle_3 = new Rectangle();
            Rectangle rectangle_10 = new Rectangle();

            // <SnippetPerformanceSnippet2>
            rectangle_1.Fill = myBrush;
            rectangle_2.Fill = myBrush;
            rectangle_3.Fill = myBrush;
            // ...
            rectangle_10.Fill = myBrush;
            // </SnippetPerformanceSnippet2>
        }

        public void Stub02()
        {
            // <SnippetPerformanceSnippet3>
            Brush frozenBrush = new SolidColorBrush(Colors.Blue);
            frozenBrush.Freeze();
            Brush nonFrozenBrush = new SolidColorBrush(Colors.Blue);

            for (int i = 0; i < 10; i++)
            {
                // Create a Rectangle using a non-frozed Brush.
                Rectangle rectangleNonFrozen = new Rectangle();
                rectangleNonFrozen.Fill = nonFrozenBrush;

                // Create a Rectangle using a frozed Brush.
                Rectangle rectangleFrozen = new Rectangle();
                rectangleFrozen.Fill = frozenBrush;
            }
            // </SnippetPerformanceSnippet3>
        }

        public void Stub03()
        {
            // <SnippetPerformanceSnippet4>
            Brush myBrush = new SolidColorBrush(Colors.Red);
            Rectangle myRectangle = new Rectangle();
            myRectangle.Fill = myBrush;
            // </SnippetPerformanceSnippet4>

            // <SnippetPerformanceSnippet5>
            myRectangle = null;
            // </SnippetPerformanceSnippet5>

            // <SnippetPerformanceSnippet6>
            myRectangle.Fill = null;
            myRectangle = null;
            // </SnippetPerformanceSnippet6>
        }
    }
}