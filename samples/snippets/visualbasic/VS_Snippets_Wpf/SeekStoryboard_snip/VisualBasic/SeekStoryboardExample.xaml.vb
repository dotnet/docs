' <SnippetSeekStoryboardCodeBehindExampleWholePage>

Imports System.Media
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Animation

Namespace SDKSample

	Partial Public Class SeekStoryboardExample
		Inherits Page
		Private Sub OnSliderValueChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim sliderValue As Integer = CInt(SeekSlider.Value)

			' Use the value of the slider to seek to a duration value of the Storyboard (in milliseconds).
			myStoryboard.Seek(myRectangle, New TimeSpan(0, 0, 0, 0, sliderValue), TimeSeekOrigin.BeginTime)
		End Sub
	End Class

End Namespace
' </SnippetSeekStoryboardCodeBehindExampleWholePage>