// <SnippetRotateAnimationUsingPathWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SDKSample
{


    public class RotateAnimationUsingPathExample : Page
    {

        public RotateAnimationUsingPathExample()
        {

            // Create a NameScope for the page so that
            // we can use Storyboards.
            NameScope.SetNameScope(this, new NameScope());

            // Create a rectangle.
            Rectangle aRectangle = new Rectangle();
            aRectangle.Width = 30;
            aRectangle.Height = 30;
            aRectangle.Fill = Brushes.Blue;

            // Create some transforms. These transforms
            // will be used to move and rotate the rectangle.
            RotateTransform animatedRotateTransform = 
                new RotateTransform();
            TranslateTransform animatedTranslateTransform = 
                new TranslateTransform();

            // Register the transforms' names with the page
            // so that they can be targeted by a Storyboard.
            this.RegisterName("AnimatedRotateTransform", animatedRotateTransform);
            this.RegisterName("AnimatedTranslateTransform", animatedTranslateTransform);    

            // Create a TransformGroup to contain the transforms
            // and apply the TransformGroup to the rectangle.
            TransformGroup tGroup = new TransformGroup();
            tGroup.Children.Add(animatedRotateTransform);
            tGroup.Children.Add(animatedTranslateTransform);
            aRectangle.RenderTransform = tGroup;

            // Create a Canvas to contain the rectangle
            // and add it to the page.
            Canvas mainPanel = new Canvas();
            mainPanel.Width = 400;
            mainPanel.Height = 400;
            mainPanel.Children.Add(aRectangle);
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

            // Create a DoubleAnimationUsingPath to rotate the
            // rectangle with the path by animating 
            // its RotateTransform.
            DoubleAnimationUsingPath angleAnimation = 
                new DoubleAnimationUsingPath();
            angleAnimation.PathGeometry = animationPath;
            angleAnimation.Duration = TimeSpan.FromSeconds(5);

            // Set the Source property to Angle. This makes
            // the animation generate angle values from
            // the path information. 
            angleAnimation.Source = PathAnimationSource.Angle;

            // Set the animation to target the Angle property
            // of the RotateTransform named "AnimatedRotateTransform".
            Storyboard.SetTargetName(angleAnimation, "AnimatedRotateTransform");
            Storyboard.SetTargetProperty(angleAnimation, 
                new PropertyPath(RotateTransform.AngleProperty));

            // Create a DoubleAnimationUsingPath to move the
            // rectangle horizontally along the path by animating 
            // its TranslateTransform.
            DoubleAnimationUsingPath translateXAnimation =
                new DoubleAnimationUsingPath();
            translateXAnimation.PathGeometry = animationPath;
            translateXAnimation.Duration = TimeSpan.FromSeconds(5);

            // Set the Source property to X. This makes
            // the animation generate horizontal offset values from
            // the path information. 
            translateXAnimation.Source = PathAnimationSource.X;

            // Set the animation to target the X property
            // of the TranslateTransform named "AnimatedTranslateTransform".
            Storyboard.SetTargetName(translateXAnimation, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(translateXAnimation,
                new PropertyPath(TranslateTransform.XProperty));

            // Create a DoubleAnimationUsingPath to move the
            // rectangle vertically along the path by animating 
            // its TranslateTransform.
            DoubleAnimationUsingPath translateYAnimation =
                new DoubleAnimationUsingPath();
            translateYAnimation.PathGeometry = animationPath;
            translateYAnimation.Duration = TimeSpan.FromSeconds(5);

            // Set the Source property to Y. This makes
            // the animation generate vertical offset values from
            // the path information. 
            translateYAnimation.Source = PathAnimationSource.Y;

            // Set the animation to target the Y property
            // of the TranslateTransform named "AnimatedTranslateTransform".
            Storyboard.SetTargetName(translateYAnimation, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(translateYAnimation,
                new PropertyPath(TranslateTransform.YProperty)); 
      
            // Create a Storyboard to contain and apply the animations.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.RepeatBehavior = RepeatBehavior.Forever;
            pathAnimationStoryboard.AutoReverse = true;
            pathAnimationStoryboard.Children.Add(angleAnimation);
            pathAnimationStoryboard.Children.Add(translateXAnimation);
            pathAnimationStoryboard.Children.Add(translateYAnimation);

            // Start the animations when the rectangle is loaded.
            aRectangle.Loaded += delegate(object sender, RoutedEventArgs e)
            {
                // Start the storyboard.
                pathAnimationStoryboard.Begin(this);
            };

        }
    
    }

}
// </SnippetRotateAnimationUsingPathWholePage>


