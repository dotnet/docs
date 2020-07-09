// <SnippetPointAnimationUsingPathWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SDKSample
{

    public class PointAnimationUsingPathExample : Page
    {

        public PointAnimationUsingPathExample()
        {

            // Create a NameScope for the page so that
            // we can use Storyboards.
            NameScope.SetNameScope(this, new NameScope());

            // Create the EllipseGeometry to animate.
            EllipseGeometry animatedEllipseGeometry =
                new EllipseGeometry(new Point(10, 100), 15, 15);

            // Register the EllipseGeometry's name with
            // the page so that it can be targeted by a
            // storyboard.
            this.RegisterName("AnimatedEllipseGeometry", animatedEllipseGeometry);

            // Create a Path element to display the geometry.
            Path ellipsePath = new Path();
            ellipsePath.Data = animatedEllipseGeometry;
            ellipsePath.Fill = Brushes.Blue;
            ellipsePath.Margin = new Thickness(15);

            // Create a Canvas to contain ellipsePath
            // and add it to the page.
            Canvas mainPanel = new Canvas();
            mainPanel.Width = 400;
            mainPanel.Height = 400;
            mainPanel.Children.Add(ellipsePath);
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

            // Create a PointAnimationgUsingPath to move
            // the EllipseGeometry along the animation path.
            PointAnimationUsingPath centerPointAnimation =
                new PointAnimationUsingPath();
            centerPointAnimation.PathGeometry = animationPath;
            centerPointAnimation.Duration = TimeSpan.FromSeconds(5);
            centerPointAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Set the animation to target the Center property
            // of the EllipseGeometry named "AnimatedEllipseGeometry".
            Storyboard.SetTargetName(centerPointAnimation, "AnimatedEllipseGeometry");
            Storyboard.SetTargetProperty(centerPointAnimation,
                new PropertyPath(EllipseGeometry.CenterProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.RepeatBehavior = RepeatBehavior.Forever;
            pathAnimationStoryboard.AutoReverse = true;
            pathAnimationStoryboard.Children.Add(centerPointAnimation);

            // Start the Storyboard when ellipsePath is loaded.
            ellipsePath.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                // Start the storyboard.
                pathAnimationStoryboard.Begin(this);
            };
        }
    }
}
// </SnippetPointAnimationUsingPathWholePage>
