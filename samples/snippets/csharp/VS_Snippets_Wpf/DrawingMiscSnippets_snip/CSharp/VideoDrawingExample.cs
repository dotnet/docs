// <SnippetVideoDrawingExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace SDKSample
{
    public class VideoDrawingExample : Page
    {
        public VideoDrawingExample()
        {

            // <SnippetVideoDrawingExampleInline>
            //
            // Create a VideoDrawing.
            //
            // <SnippetVideoDrawingExampleInline1>
            MediaPlayer player = new MediaPlayer();
            // </SnippetVideoDrawingExampleInline1>

            // <SnippetVideoDrawingExampleInline2>
            player.Open(new Uri(@"sampleMedia\xbox.wmv", UriKind.Relative));
            // </SnippetVideoDrawingExampleInline2>

            // <SnippetVideoDrawingExampleInline3>
            VideoDrawing aVideoDrawing = new VideoDrawing();
            // </SnippetVideoDrawingExampleInline3>

            // <SnippetVideoDrawingExampleInline4>
            aVideoDrawing.Rect = new Rect(0, 0, 100, 100);
            // </SnippetVideoDrawingExampleInline4>

            // <SnippetVideoDrawingExampleInline5>
            aVideoDrawing.Player = player;
            // </SnippetVideoDrawingExampleInline5>

            // <SnippetVideoDrawingExampleInline6>
            // Play the video once.
            player.Play();
            // </SnippetVideoDrawingExampleInline6>

            // </SnippetVideoDrawingExampleInline>

            // <SnippetRepeatingVideoDrawingExampleInline>
            //
            // Create a VideoDrawing that repeats.
            //

            // <SnippetRepeatingVideoDrawingExampleInline1>
            // Create a MediaTimeline.
            MediaTimeline mTimeline =
                new MediaTimeline(new Uri(@"sampleMedia\xbox.wmv", UriKind.Relative));

            // Set the timeline to repeat.
            mTimeline.RepeatBehavior = RepeatBehavior.Forever;
            // </SnippetRepeatingVideoDrawingExampleInline1>

            // <SnippetRepeatingVideoDrawingExampleInline2>
            // Create a clock from the MediaTimeline.
            MediaClock mClock = mTimeline.CreateClock();
            // </SnippetRepeatingVideoDrawingExampleInline2>

            // <SnippetRepeatingVideoDrawingExampleInline3>
            MediaPlayer repeatingVideoDrawingPlayer = new MediaPlayer();
            repeatingVideoDrawingPlayer.Clock = mClock;
            // </SnippetRepeatingVideoDrawingExampleInline3>

            // <SnippetRepeatingVideoDrawingExampleInline4>
            VideoDrawing repeatingVideoDrawing = new VideoDrawing();
            repeatingVideoDrawing.Rect = new Rect(150, 0, 100, 100);
            repeatingVideoDrawing.Player = repeatingVideoDrawingPlayer;
            // </SnippetRepeatingVideoDrawingExampleInline4>
            // </SnippetRepeatingVideoDrawingExampleInline>

            // Create a DrawingGroup to combine the drawings.
            DrawingGroup videoDrawings = new DrawingGroup();
            videoDrawings.Children.Add(aVideoDrawing);
            videoDrawings.Children.Add(repeatingVideoDrawing);

            //
            // Use a DrawingImage and an Image control
            // to display the drawing.
            //
            DrawingImage exampleDrawingImage = new DrawingImage(videoDrawings);

            // Freeze the DrawingImage for performance benefits.
            exampleDrawingImage.Freeze();

            Image anImage = new Image();
            anImage.Source = exampleDrawingImage;
            anImage.Stretch = Stretch.None;
            anImage.HorizontalAlignment = HorizontalAlignment.Left;

            //
            // Place the image inside a border and
            // add it to the page.
            //
            Border exampleBorder = new Border();
            exampleBorder.Child = anImage;
            exampleBorder.BorderBrush = Brushes.Gray;
            exampleBorder.BorderThickness = new Thickness(1);
            exampleBorder.HorizontalAlignment = HorizontalAlignment.Left;
            exampleBorder.VerticalAlignment = VerticalAlignment.Top;
            exampleBorder.Margin = new Thickness(10);

            this.Margin = new Thickness(20);
            this.Background = Brushes.White;
            this.Content = exampleBorder;
        }
    }
}
// </SnippetVideoDrawingExampleWholePage>