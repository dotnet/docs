using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class TransparentObject : Window
    {

        public TransparentObject()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            Border b = myBorder;
            string s = "";
        }

        //<SnippetTransparentVisualSnippet3>
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Retrieve the coordinate of the mouse position.
           Point pt = e.GetPosition((UIElement)sender);

           // Get the parent of the Border object, since it is also the parent of the other objects.
           DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)sender);

            // Set up a callback to receive the hit test result enumeration.
            VisualTreeHelper.HitTest(((Visual)parent), null,
                new HitTestResultCallback(MyHitTestResult),
                new PointHitTestParameters(pt));
        }

        // Return the result of the hit test to the callback.
        public HitTestResultBehavior MyHitTestResult(HitTestResult result)
        {
            Visual visual = (Visual)result.VisualHit;

            // Ignore the transparent Border object.
            if (visual.GetType() == typeof(Border))
            {
                // Set the behavior to return visuals at all z-order levels.
                return HitTestResultBehavior.Continue;
            }

            // Display the type value of the object hit.
            myTextBlock.Text = visual.GetType().ToString() + " clicked";

            // Stop the hit test enumeration of the visual tree.
            return HitTestResultBehavior.Stop;
        }
        //</SnippetTransparentVisualSnippet3>
    }
}