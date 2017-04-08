// <SnippetMultipleEffectAnimationExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace SDKSample
{
    public partial class MultipleEffectAnimationExample : Page
    {
        public MultipleEffectAnimationExample()
        {
            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            Button myButton = new Button();
            myButton.Content = "Click Me to Animate Drop Shadow!";
            myButton.Margin = new Thickness(50);
            myButton.Width = 300;

            ScaleTransform myScaleTransform = new ScaleTransform();

            // Assign the ScaleTransform a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName("MyAnimatedScaleTransform", myScaleTransform);

            myScaleTransform.ScaleX = 1;
            myScaleTransform.ScaleY = 1;
            myScaleTransform.CenterX = 100;

            // Associate the transform to the button.
            myButton.RenderTransform = myScaleTransform;

            // Create BitmapEffects that will be animated.
            BlurBitmapEffect myBlurBitmapEffect = new BlurBitmapEffect();

            // Assign the BlurBitmapEffect a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName("myBlurBitmapEffect", myBlurBitmapEffect);

            myBlurBitmapEffect.Radius = 0;
            myBlurBitmapEffect.KernelType = KernelType.Box;

            DropShadowBitmapEffect myDropShadowBitmapEffect = new DropShadowBitmapEffect();

            // Assign the BlurBitmapEffect a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName("myDropShadowBitmapEffect", myDropShadowBitmapEffect);

            myDropShadowBitmapEffect.Color = Colors.Black;
            myDropShadowBitmapEffect.ShadowDepth = 0;

            BitmapEffectGroup myBitmapEffectGroup = new BitmapEffectGroup();
            myBitmapEffectGroup.Children.Add(myBlurBitmapEffect);
            myBitmapEffectGroup.Children.Add(myDropShadowBitmapEffect);

            myButton.BitmapEffect = myBitmapEffectGroup;

            // Create an animation to animate the ScaleX property of the 
            // ScaleTransform applied to the button.
            DoubleAnimation myDoubleAnimationScaleX = new DoubleAnimation();
            myDoubleAnimationScaleX.Duration = TimeSpan.FromSeconds(1);
            myDoubleAnimationScaleX.AutoReverse = true;
            myDoubleAnimationScaleX.To = 5;

            // Set the animation to target the ScaleX property of 
            // the object named "MyAnimatedScaleTransform. This makes the
            // button get larger and smaller on the horizontal axis."
            Storyboard.SetTargetName(myDoubleAnimationScaleX, "MyAnimatedScaleTransform");
            Storyboard.SetTargetProperty(
                myDoubleAnimationScaleX, new PropertyPath(ScaleTransform.ScaleXProperty));

            // Set the animation to target the ScaleY property of 
            // the object named "MyAnimatedScaleTransform. This makes the
            // button get larger and smaller on the vertical axis."
            DoubleAnimation myDoubleAnimationScaleY = new DoubleAnimation();
            myDoubleAnimationScaleY.Duration = TimeSpan.FromSeconds(1);
            myDoubleAnimationScaleY.AutoReverse = true;
            myDoubleAnimationScaleY.To = 5;

            Storyboard.SetTargetName(myDoubleAnimationScaleY, "MyAnimatedScaleTransform");
            Storyboard.SetTargetProperty(
                myDoubleAnimationScaleY, new PropertyPath(ScaleTransform.ScaleYProperty));

            // Set the animation to target the ShadowDepth property of 
            // the object named "myDropShadowBitmapEffect. This makes the
            // button appear to be lifting off the screen as its shadow moves."
            DoubleAnimation myDoubleAnimationShadowDepth = new DoubleAnimation();
            myDoubleAnimationShadowDepth.Duration = TimeSpan.FromSeconds(1);
            myDoubleAnimationShadowDepth.AutoReverse = true;
            myDoubleAnimationShadowDepth.From = 0;
            myDoubleAnimationShadowDepth.To = 50;

            Storyboard.SetTargetName(myDoubleAnimationShadowDepth, "myDropShadowBitmapEffect");
            Storyboard.SetTargetProperty(
                myDoubleAnimationShadowDepth, new PropertyPath(DropShadowBitmapEffect.ShadowDepthProperty));

            // Animate the blur to make the object appear to
            // be comming out of the screen. Use a spline key
            // frame to make the blur animate suddenly at the 
            // very end of the animation.
            DoubleAnimationUsingKeyFrames myDoubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();
            myDoubleAnimationUsingKeyFrames.AutoReverse = true;

            // Set the animation to target the Radius property
            // of the object named "myBlurBitmapEffect."
            Storyboard.SetTargetName(myDoubleAnimationUsingKeyFrames, "myBlurBitmapEffect");
            Storyboard.SetTargetProperty(
                myDoubleAnimationUsingKeyFrames, new PropertyPath(BlurBitmapEffect.RadiusProperty));
            myDoubleAnimationUsingKeyFrames.KeyFrames.Add(
                new SplineDoubleKeyFrame(
                    30, // Target value (KeyValue)
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)), // KeyTime
                    new KeySpline(0.6, 0.0, 0.9, 0.0) // KeySpline
                    )
                );

            // Create a storyboard and add the animations to it.
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimationScaleX);
            myStoryboard.Children.Add(myDoubleAnimationScaleY);
            myStoryboard.Children.Add(myDoubleAnimationShadowDepth);
            myStoryboard.Children.Add(myDoubleAnimationUsingKeyFrames);

            // Start the storyboard when button is clicked.
            myButton.Click += delegate(object sender, RoutedEventArgs e)
            {
                myStoryboard.Begin(this);
            };

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Children.Add(myButton);
            this.Content = myStackPanel;

        }      
    }
}
// </SnippetMultipleEffectAnimationExampleWholePage>