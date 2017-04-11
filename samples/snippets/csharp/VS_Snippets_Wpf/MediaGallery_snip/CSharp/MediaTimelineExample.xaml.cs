// <SnippetCodeBehindMediaTimelineExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{

    public partial class MediaTimelineExample : Page
	{
        // <SnippetCodeBehindMediaTimelineExampleInline1>
        // When the media opens, initialize the "Seek To" slider maximum value
        // to the total number of miliseconds in the length of the media clip.
        private void Element_MediaOpened(object sender, EventArgs e)
        {
            timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void MediaTimeChanged(object sender, EventArgs e)
        {
            timelineSlider.Value = myMediaElement.Position.TotalMilliseconds;
        }
        // </SnippetCodeBehindMediaTimelineExampleInline1>

    }
}
// </SnippetCodeBehindMediaTimelineExampleWholePage>