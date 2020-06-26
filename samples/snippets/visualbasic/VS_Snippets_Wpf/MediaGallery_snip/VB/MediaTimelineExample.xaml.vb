 ' <SnippetCodeBehindMediaTimelineExampleWholePage>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media


Namespace SDKSample

    Partial Class MediaTimelineExample
        Inherits Page
        ' <SnippetCodeBehindMediaTimelineExampleInline1>
        ' When the media opens, initialize the "Seek To" slider maximum value
        ' to the total number of miliseconds in the length of the media clip.
        Private Sub Element_MediaOpened(ByVal sender As Object, ByVal e As RoutedEventArgs)
            timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds

        End Sub


        Private Sub MediaTimeChanged(ByVal sender As Object, ByVal e As EventArgs)
            timelineSlider.Value = myMediaElement.Position.TotalMilliseconds

        End Sub
        '</SnippetCodeBehindMediaTimelineExampleInline1>
    End Class
End Namespace 'SDKSample
' </SnippetCodeBehindMediaTimelineExampleWholePage>