using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Animation.TimingBehaviors
{

    public partial class AnimateThenSetPropertyExample : Page
    {
        public AnimateThenSetPropertyExample()
        {
            InitializeComponent();
        }

        // <SnippetGraphicsMMButton1Handler>
        private void setButton1BackgroundBrushColor(object sender, EventArgs e)
        {

            // Does not appear to have any effect:
            // the brush remains yellow.
            Button1BackgroundBrush.Color = Colors.Blue;
        }
        // </SnippetGraphicsMMButton1Handler>

        // <SnippetGraphicsMMButton2Handler>
        private void setButton2BackgroundBrushColor(object sender, EventArgs e)
        {

            // This appears to work:
            // the brush changes to blue.
            Button2BackgroundBrush.Color = Colors.Blue;
        }
        // </SnippetGraphicsMMButton2Handler>

        // <SnippetGraphicsMMButton3Handler>
        private void setButton3BackgroundBrushColor(object sender, EventArgs e)
        {

             // This appears to work:
            // the brush changes to blue.
            MyStoryboard.Remove(Button3);
            Button3BackgroundBrush.Color = Colors.Blue;
        }
        // </SnippetGraphicsMMButton3Handler>

        // <SnippetGraphicsMMButton4Handler>
        private void setButton4BackgroundBrushColor(object sender, EventArgs e)
        {

             // This appears to work:
            // the brush changes to blue.
            Button4BackgroundBrush.BeginAnimation(SolidColorBrush.ColorProperty, null);
            Button4BackgroundBrush.Color = Colors.Blue;
        }
        // </SnippetGraphicsMMButton4Handler>
    }
}
