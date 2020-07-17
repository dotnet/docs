' <SnippetSeekStoryboardSynchronouslyCodeBehindExampleWholePage>

Imports System.Media
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Animation

Namespace SDKSample

	Partial Public Class SeekStoryboardSynchronouslyExample
		Inherits Page
		Private Sub OnSliderValueChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim sliderValue As Integer = CInt(SeekSlider.Value)

			' The SeekAlignedToLastTick method should be used to seek a Storyboard synchronously.
			myStoryboard.SeekAlignedToLastTick(myRectangle, New TimeSpan(0, 0, 0, 0, sliderValue), TimeSeekOrigin.BeginTime)
			PositionTextBlock.Text = sliderValue.ToString()
		End Sub
	End Class

End Namespace
' </SnippetSeekStoryboardSynchronouslyCodeBehindExampleWholePage>