using System;
using System.Windows;
using System.Windows.Media;

namespace SDKSample
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            TranslateTransform translate = new TranslateTransform(0, 0);
            myDrawing.RenderTransform = translate;
        }

        private void OnClick(object sender, EventArgs e)
        {
            Stub01();
            Stub02();
            Stub03();
            Stub04();
            Stub05();
            Stub06();
            Stub07();
            Stub08();
            Snippets.SnippetGetRenderTier();
        }

        private void Stub01()
        {
            //<SnippetVisualSnippet2>
            // Return the offset vector for the TextBlock object.
            Vector vector = VisualTreeHelper.GetOffset(myTextBlock);

            // Convert the vector to a point value.
            Point currentPoint = new Point(vector.X, vector.Y);
            //</SnippetVisualSnippet2>
        }

        private void Stub02()
        {
            //<SnippetVisualSnippet3>
            // Return the general transform for the specified visual object.
            GeneralTransform generalTransform1 = myTextBlock.TransformToAncestor((Visual)myTextBlock.Parent);

            // Retrieve the point value relative to the parent.
            Point currentPoint = generalTransform1.Transform(new Point(0, 0));
            //</SnippetVisualSnippet3>
        }

        private void Stub03()
        {
            //<SnippetVisualSnippet5>
            // Return the general transform for the specified visual object.
            GeneralTransform generalTransform1 = myTextBlock.TransformToAncestor(this);

            // Retrieve the point value relative to the parent.
            Point currentPoint = generalTransform1.Transform(new Point(0, 0));
            //</SnippetVisualSnippet5>
        }

        private void Stub04()
        {
            //<SnippetVisualSnippet6>
            // Return the transform for the specified visual object.
            Transform transform = VisualTreeHelper.GetTransform(myDrawing);

            // If there is no transform defined for the object, the return value is null.
            if (transform != null)
            {
                // Return the offset of the returned transform. The offset is relative to the parent of the visual object.
                Point pt = transform.Transform(new Point(0, 0));
            }
            //</SnippetVisualSnippet6>
        }

        private void Stub05()
        {
            TranslateTransform translate = (TranslateTransform)myDrawing.RenderTransform;
            translate.X += 10;
            translate.Y += 10;
        }

        private void Stub06()
        {
            //<SnippetVisualSnippet8>
            // Return the general transform for the specified visual object.
            GeneralTransform generalTransform1 = myStackPanel.TransformToVisual(myTextBlock);

            // Retrieve the point value relative to the child.
            Point currentPoint = generalTransform1.Transform(new Point(0, 0));
            //</SnippetVisualSnippet8>
        }

        private void Stub07()
        {
            //<SnippetVisualSnippet9>
            // Return the general transform for the specified visual object.
            GeneralTransform generalTransform1 = myStackPanel.TransformToDescendant(myTextBlock);

            // Retrieve the point value relative to the child.
            Point currentPoint = generalTransform1.Transform(new Point(0, 0));
            //</SnippetVisualSnippet9>
        }

        private void Stub08()
        {
            MyVisual myVisual = new MyVisual();
            myStackPanel.Children.Add(myVisual);
        }
    }

    //<SnippetVisualSnippet10>
    public class MyVisual : UIElement
    {
        // Class member definitions
        // ...

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            // Perform actions based on OnVisualParentChanged event.
            // ...

            // Call base class to perform standard event handling.
            base.OnVisualParentChanged(oldParent);
        }
    }
    //</SnippetVisualSnippet10>
}