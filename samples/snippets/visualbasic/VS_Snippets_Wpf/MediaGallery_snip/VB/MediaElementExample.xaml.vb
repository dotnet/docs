 ' <SnippetCodeBehindMediaElementExampleWholePage>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Input

Namespace SDKSample

    Partial Class MediaElementExample
        Inherits Page

        ' Play the media.
        Sub OnMouseDownPlayMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)

            ' The Play method will begin the media if it is not currently active or 
            ' resume media if it is paused. This has no effect if the media is
            ' already running.
            myMediaElement.Play()

            ' Initialize the MediaElement property values.
            InitializePropertyValues()

        End Sub 'OnMouseDownPlayMedia


        ' Pause the media.
        Sub OnMouseDownPauseMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)

            ' The Pause method pauses the media if it is currently running.
            ' The Play method can be used to resume.
            myMediaElement.Pause()

        End Sub 'OnMouseDownPauseMedia


        ' Stop the media.
        Sub OnMouseDownStopMedia(ByVal sender As Object, ByVal args As MouseButtonEventArgs)

            ' The Stop method stops and resets the media to be played from
            ' the beginning.
            myMediaElement.Stop()

        End Sub 'OnMouseDownStopMedia


        ' Change the volume of the media.
        Private Sub ChangeMediaVolume(ByVal sender As Object, ByVal args As RoutedPropertyChangedEventArgs(Of Double))
            myMediaElement.Volume = System.Convert.ToDouble(volumeSlider.Value)

        End Sub 'ChangeMediaVolume

        ' Change the speed of the media.
        Private Sub ChangeMediaSpeedRatio(ByVal sender As Object, ByVal args As RoutedPropertyChangedEventArgs(Of Double))
            myMediaElement.SpeedRatio = System.Convert.ToDouble(speedRatioSlider.Value)
            
        End Sub 'ChangeMediaSpeedRatio

        ' When the media opens, initialize the "Seek To" slider maximum value
        ' to the total number of miliseconds in the length of the media clip.
        Private Sub Element_MediaOpened(ByVal sender As Object, ByVal args As RoutedEventArgs)
            timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds
        End Sub

        '<SnippetCodeBehindMediaElementExampleMediaEnded>
        ' When the media playback is finished. Stop() the media to seek to media start.
        Private Sub Element_MediaEnded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            myMediaElement.Stop()
        End Sub
        '</SnippetCodeBehindMediaElementExampleMediaEnded>

        ' Jump to different parts of the media (seek to). 
        Private Sub SeekToMediaPosition(ByVal sender As Object, ByVal args As RoutedPropertyChangedEventArgs(Of Double))
            Dim SliderValue As Integer = CType(timelineSlider.Value, Integer)

            ' Overloaded constructor takes the arguments days, hours, minutes, seconds, miniseconds.
            ' Create a TimeSpan with miliseconds equal to the slider value.
            Dim ts As New TimeSpan(0, 0, 0, 0, SliderValue)
            myMediaElement.Position = ts
        End Sub

        ' Set the media's starting Volume and SpeedRatio to the current value of the
        ' their respective slider controls.
        Private Sub InitializePropertyValues()
            myMediaElement.Volume = System.Convert.ToDouble(volumeSlider.Value)
            myMediaElement.SpeedRatio = System.Convert.ToDouble(speedRatioSlider.Value)
        End Sub
    End Class 'MediaElementExample
End Namespace 'SDKSample
' </SnippetCodeBehindMediaElementExampleWholePage>
