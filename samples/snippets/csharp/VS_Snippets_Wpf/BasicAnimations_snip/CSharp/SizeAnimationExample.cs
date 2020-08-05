// <SnippetSizeAnimationWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace SDKSamples
{
    public class SizeAnimationExample : Page
    {
        public SizeAnimationExample()
        {

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            // Create an ArcSegment to define the geometry of the path.
            // The Size property of this segment is animated.
            ArcSegment myArcSegment = new ArcSegment();
            myArcSegment.Size = new Size(90, 80);
            myArcSegment.SweepDirection = SweepDirection.Clockwise;
            myArcSegment.Point = new Point(500, 200);

            // Assign the segment a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "myArcSegment", myArcSegment);

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(myArcSegment);

            // Create a PathFigure to be used for the PathGeometry of myPath.
            PathFigure myPathFigure = new PathFigure();

            // Set the starting point for the PathFigure specifying that the
            // geometry starts at point 100,200.
            myPathFigure.StartPoint = new Point(100, 200);

            myPathFigure.Segments = myPathSegmentCollection;

            PathFigureCollection myPathFigureCollection = new PathFigureCollection();
            myPathFigureCollection.Add(myPathFigure);

            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures = myPathFigureCollection;

            // Create a path to draw a geometry with.
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;

            // specify the shape of the path using the path geometry.
            myPath.Data = myPathGeometry;

            SizeAnimation mySizeAnimation = new SizeAnimation();
            mySizeAnimation.Duration = TimeSpan.FromSeconds(2);

            // Set the animation to repeat forever.
            mySizeAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Set the From and To properties of the animation.
            mySizeAnimation.From = new Size(90, 80);
            mySizeAnimation.To = new Size(200, 200);

            // Set the animation to target the Size property
            // of the object named "myArcSegment."
            Storyboard.SetTargetName(mySizeAnimation, "myArcSegment");
            Storyboard.SetTargetProperty(
                mySizeAnimation, new PropertyPath(ArcSegment.SizeProperty));

            // Create a storyboard to apply the animation.
            Storyboard ellipseStoryboard = new Storyboard();
            ellipseStoryboard.Children.Add(mySizeAnimation);

            // Start the storyboard when the Path loads.
            myPath.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                ellipseStoryboard.Begin(this);
            };

            Canvas containerCanvas = new Canvas();
            containerCanvas.Children.Add(myPath);

            Content = containerCanvas;
        }
    }
}
// </SnippetSizeAnimationWholePage>
