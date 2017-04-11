// <SnippetSeekStoryboardCodeBehindExampleWholePage>
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SDKSample
{

    public partial class SeekStoryboardExample : Page
    {
        private void OnSliderValueChanged(object sender, RoutedEventArgs e)
        {
            int sliderValue = (int)SeekSlider.Value;
            
            // Use the value of the slider to seek to a duration value of the Storyboard (in milliseconds).
            myStoryboard.Seek(myRectangle, new TimeSpan(0, 0, 0, 0, sliderValue), TimeSeekOrigin.BeginTime);
        }
    }
    
}
// </SnippetSeekStoryboardCodeBehindExampleWholePage>