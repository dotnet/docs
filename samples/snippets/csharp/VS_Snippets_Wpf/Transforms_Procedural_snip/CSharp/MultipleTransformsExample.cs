// <SnippetMultipleTransformsCodeExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class MultipleTransformsExample : Page
    {
        public MultipleTransformsExample()
        {
            // Create a Button that will have two transforms applied to it.
            Button myButton = new Button();
            myButton.Content = "Click";
            
            // Set the center point of the transforms.
            myButton.RenderTransformOrigin = new Point(0.5,0.5);

            // Create a transform to scale the size of the button.
            ScaleTransform myScaleTransform = new ScaleTransform();

            // Set the transform to triple the scale in the Y direction.
            myScaleTransform.ScaleY = 3;

            // Create a transform to rotate the button
            RotateTransform myRotateTransform = new RotateTransform();

            // Set the rotation of the transform to 45 degrees.
            myRotateTransform.Angle = 45;

            // Create a TransformGroup to contain the transforms
            // and add the transforms to it.
            TransformGroup myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(myScaleTransform);
            myTransformGroup.Children.Add(myRotateTransform);

            // Associate the transforms to the button.
            myButton.RenderTransform = myTransformGroup;

            // Create a StackPanel which will contain the Button.
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(50);
            myStackPanel.Children.Add(myButton);
            this.Content = myStackPanel;

        }
    }
}
// </SnippetMultipleTransformsCodeExampleWholePage>