// <SnippetSeekStoryboardSynchronouslyCodeBehindExampleWholePage>
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SDKSample
{

    public partial class SeekStoryboardSynchronouslyExample : Page
    {
        private void OnSliderValueChanged(object sender, RoutedEventArgs e)
        {
            int sliderValue = (int)SeekSlider.Value;
            
            // The SeekAlignedToLastTick method should be used to seek a Storyboard synchronously.
            myStoryboard.SeekAlignedToLastTick(myRectangle, new TimeSpan(0, 0, 0, 0, sliderValue), TimeSeekOrigin.BeginTime);
            PositionTextBlock.Text = sliderValue.ToString();
        }
    }
    
}
// </SnippetSeekStoryboardSynchronouslyCodeBehindExampleWholePage>