// <SnippetMatrixAnimationUsingPathOffsetCumulativeWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SDKSample
{

    /// <summary>
    /// Shows how to use the MatrixAnimationUsingPath.IsOffsetCumulative
    /// property to make a MatrixAnimatioinUsingPath accumulate
    /// its values when it repeats.
    /// </summary>
    public class MatrixAnimationUsingPathExampleOffsetCumulative : Page
    {

        public MatrixAnimationUsingPathExampleOffsetCumulative()
        {
            this.Margin = new Thickness(20);

            // Create a NameScope for the page so that
            // we can use Storyboards.
            NameScope.SetNameScope(this, new NameScope());

            // Create a button.
            Button aButton = new Button();
            aButton.MinWidth = 100;
            aButton.Content = "A Button";

            // Create a MatrixTransform. This transform
            // will be used to move the button.
            MatrixTransform buttonMatrixTransform = new MatrixTransform();
            aButton.RenderTransform = buttonMatrixTransform;

            // Register the transform's name with the page
            // so that it can be targeted by a Storyboard.
            this.RegisterName("ButtonMatrixTransform", buttonMatrixTransform);

            // Create a Canvas to contain the button
            // and add it to the page.
            // Although this example uses a Canvas,
            // any type of panel will work.
            Canvas mainPanel = new Canvas();
            mainPanel.Width = 400;
            mainPanel.Height = 400;
            mainPanel.Children.Add(aButton);
            this.Content = mainPanel;

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(10, 100);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            pBezierSegment.Points.Add(new Point(35, 0));
            pBezierSegment.Points.Add(new Point(135, 0));
            pBezierSegment.Points.Add(new Point(160, 100));
            pBezierSegment.Points.Add(new Point(180, 190));
            pBezierSegment.Points.Add(new Point(285, 200));
            pBezierSegment.Points.Add(new Point(310, 100));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a MatrixAnimationUsingPath to move the
            // button along the path by animating
            // its MatrixTransform.
            MatrixAnimationUsingPath matrixAnimation =
                new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = animationPath;

            // Set IsOffsetCumulative to true so that the animation
            // values accumulate when its repeats. 
            matrixAnimation.IsOffsetCumulative = true;
            matrixAnimation.Duration = TimeSpan.FromSeconds(5);
            matrixAnimation.RepeatBehavior = new RepeatBehavior(2);

            // Set the animation to target the Matrix property
            // of the MatrixTransform named "ButtonMatrixTransform".
            Storyboard.SetTargetName(matrixAnimation, "ButtonMatrixTransform");
            Storyboard.SetTargetProperty(matrixAnimation, 
                new PropertyPath(MatrixTransform.MatrixProperty));
      
            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.Children.Add(matrixAnimation);

            // Start the animation when the button is clicked.
            aButton.Click += delegate(object sender, RoutedEventArgs e)
            {
                // Start the storyboard.
                pathAnimationStoryboard.Begin(this);
            };

        }  
    }
}
// </SnippetMatrixAnimationUsingPathOffsetCumulativeWholePage>







