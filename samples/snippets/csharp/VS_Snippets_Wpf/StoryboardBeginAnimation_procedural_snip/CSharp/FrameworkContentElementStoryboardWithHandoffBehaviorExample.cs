// <SnippetFrameworkContentElementStoryboardWithHandoffBehaviorExampleWholePage>
/*
    This example shows how to animate
    a FrameworkContentElement with a storyboard.

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Documents;
using System.Windows.Input;

namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
{
    public class FrameworkContentElementStoryboardWithHandoffBehaviorExample :
        FlowDocument
    {

        private Storyboard myStoryboard;
        DoubleAnimation xAnimation;
        DoubleAnimation yAnimation;

        public FrameworkContentElementStoryboardWithHandoffBehaviorExample()
        {

            // Create a name scope for the document.
            NameScope.SetNameScope(this, new NameScope());
            this.Background = Brushes.Orange;

            // Create a run of text.
            Run theText = new Run(
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");

            // Create a TextEffect
            TextEffect animatedSpecialEffect = new TextEffect();
            animatedSpecialEffect.Foreground = Brushes.OrangeRed;
            animatedSpecialEffect.PositionStart = 0;
            animatedSpecialEffect.PositionCount = 20;

            TranslateTransform animatedTransform =
                new TranslateTransform();

            // Assign the transform a name by
            // registering it with the page, so that
            // it can be targeted by storyboard
            // animations.
            this.RegisterName("animatedTransform", animatedTransform);
            animatedSpecialEffect.Transform = animatedTransform;

            // Apply the text effect to the run.
            theText.TextEffects = new TextEffectCollection();
            theText.TextEffects.Add(animatedSpecialEffect);

            // Create a paragraph to contain the run.
            Paragraph animatedParagraph = new Paragraph(theText);
            animatedParagraph.Background = Brushes.LightGray;

            this.Blocks.Add(animatedParagraph);

            //
            // Create a storyboard to animate the
            // text effect's transform.
            //
            myStoryboard = new Storyboard();

            xAnimation = new DoubleAnimation();
            xAnimation.Duration = TimeSpan.FromSeconds(5);
            Storyboard.SetTargetName(xAnimation, "animatedTransform");
            Storyboard.SetTargetProperty(xAnimation,
                new PropertyPath(TranslateTransform.XProperty));
            myStoryboard.Children.Add(xAnimation);

            yAnimation = new DoubleAnimation();
            yAnimation.Duration = TimeSpan.FromSeconds(5);
            Storyboard.SetTargetName(yAnimation, "animatedTransform");
            Storyboard.SetTargetProperty(yAnimation,
                new PropertyPath(TranslateTransform.YProperty));
            myStoryboard.Children.Add(yAnimation);

            this.MouseLeftButtonDown +=
                new MouseButtonEventHandler(document_mouseLeftButtonDown);
            this.MouseRightButtonDown +=
                new MouseButtonEventHandler(document_mouseRightButtonDown);
        }

        // When the user left-clicks, use the
        // SnapshotAndReplace HandoffBehavior when applying the animation.
        private void document_mouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Point clickPoint = Mouse.GetPosition(this);

            // Animate to the target point.
            xAnimation.To = clickPoint.X;
            yAnimation.To = clickPoint.Y;

            try
            {
                myStoryboard.Begin(this, HandoffBehavior.SnapshotAndReplace);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // When the user right-clicks, use the
        // Compose HandoffBehavior when applying the animation.
        private void document_mouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            Point clickPoint = Mouse.GetPosition(this);

            // Animate to the target point.
            xAnimation.To = clickPoint.X;
            yAnimation.To = clickPoint.Y;
            myStoryboard.Begin(this, HandoffBehavior.Compose);
        }
    }
}
// </SnippetFrameworkContentElementStoryboardWithHandoffBehaviorExampleWholePage>
