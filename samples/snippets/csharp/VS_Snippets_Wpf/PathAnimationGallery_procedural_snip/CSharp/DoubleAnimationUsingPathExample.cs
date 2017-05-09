// <SnippetDoubleAnimationUsingPathWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SDKSample
{


    public class DoubleAnimationUsingPathExample : Page
    {

        public DoubleAnimationUsingPathExample()
        {

            // Create a NameScope for the page so that
            // we can use Storyboards.
            NameScope.SetNameScope(this, new NameScope());

            // Create a rectangle.
            Rectangle aRectangle = new Rectangle();
            aRectangle.Width = 30;
            aRectangle.Height = 30;
            aRectangle.Fill = Brushes.Blue;

            // Create a transform. This transform
            // will be used to move the rectangle.
            TranslateTransform animatedTranslateTransform = 
                new TranslateTransform();

            // Register the transform's name with the page
            // so that they it be targeted by a Storyboard.
            this.RegisterName("AnimatedTranslateTransform", animatedTranslateTransform);    

            aRectangle.RenderTransform = animatedTranslateTransform;

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
// </SnippetDoubleAnimationUsingPathWholePage>





