// <!-- <SnippetTimelineCompletedExampleCodeBehindUsingWholePage> -->
// TimelineCompletedExample.xaml.cs
// Handles the ZoomOutStoryboard's Completed event.
// See the TimelienCompletedExample.xaml file
// for the markup that creates the images and storyboards.

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace SDKSample
{

    public partial class TimelineCompletedExample : Page
    {

        private Storyboard zoomInStoryboard;
        private ImageSource currentImageSource;
        private ImageSource nextImageSource;

        public TimelineCompletedExample()
        {
            InitializeComponent();
        }

        private void exampleLoaded(object sender, RoutedEventArgs e)
        {
            // Cache the zoom-out storyboard resource.
            zoomInStoryboard =
                (Storyboard) this.Resources["ZoomInStoryboardResource"];

            // Cache the ImageSource resources.
            currentImageSource =
                (ImageSource) this.Resources["RectangleDrawingImage"];
            nextImageSource =
                (ImageSource) this.Resources["CircleDrawingImage"];

            // Display the current image source.
            AnimatedImage.Source = currentImageSource;
        }

        // Handles the zoom-out storyboard's completed event.
        private void zoomOutStoryboardCompleted(object sender, EventArgs e)
        {
            AnimatedImage.Source = nextImageSource;
            nextImageSource = currentImageSource;
            currentImageSource = AnimatedImage.Source;
            zoomInStoryboard.Begin(AnimatedImage, HandoffBehavior.SnapshotAndReplace);
        }
    }
}
// <!-- </SnippetTimelineCompletedExampleCodeBehindUsingWholePage> -->