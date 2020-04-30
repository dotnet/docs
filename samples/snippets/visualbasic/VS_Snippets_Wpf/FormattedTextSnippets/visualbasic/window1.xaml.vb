Imports System.Globalization
Imports System.Windows
Imports System.Windows.Media

Namespace SDKSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			Dim myControl1 As New MyControl()
			myCanvas.Children.Add(myControl1)
		End Sub
	End Class

	Public Class MyControl
		Inherits FrameworkElement
		' <SnippetFormattedTextSnippets1>
		Protected Overrides Sub OnRender(ByVal drawingContext As DrawingContext)
			Dim testString As String = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor"

			' Create the initial formatted text string.
			Dim formattedText As New FormattedText(testString, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, New Typeface("Verdana"), 32, Brushes.Black)

			' Set a maximum width and height. If the text overflows these values, an ellipsis "..." appears.
			formattedText.MaxTextWidth = 300
			formattedText.MaxTextHeight = 240

			' Use a larger font size beginning at the first (zero-based) character and continuing for 5 characters.
			' <SnippetFormattedTextSnippets2>
			' The font size is calculated in terms of points -- not as device-independent pixels.
			formattedText.SetFontSize(36 * (96.0 / 72.0), 0, 5)
			' </SnippetFormattedTextSnippets2>

			' Use a Bold font weight beginning at the 6th character and continuing for 11 characters.
			formattedText.SetFontWeight(FontWeights.Bold, 6, 11)

			' Use a linear gradient brush beginning at the 6th character and continuing for 11 characters.
			formattedText.SetForegroundBrush(New LinearGradientBrush(Colors.Orange, Colors.Teal, 90.0), 6, 11)

			' Use an Italic font style beginning at the 28th character and continuing for 28 characters.
			formattedText.SetFontStyle(FontStyles.Italic, 28, 28)

			' Draw the formatted text string to the DrawingContext of the control.
			drawingContext.DrawText(formattedText, New Point(10, 0))
		End Sub
		' </SnippetFormattedTextSnippets1>

		' Provide a required override for the MeasureOverride method.
		Protected Overrides Function MeasureOverride(ByVal availableSize As Size) As Size
			' Return the value of the parameter.
			Return MyBase.MeasureOverride(availableSize)
		End Function

		' Provide a required override for the ArrangeOverride method.
		Protected Overrides Function ArrangeOverride(ByVal finalSize As Size) As Size
			' Return the value of the parameter.
			Return MyBase.ArrangeOverride(finalSize)
		End Function
	End Class

	Public Class MyControl02
		Inherits FrameworkElement
		Protected Overrides Sub OnRender(ByVal drawingContext As DrawingContext)
			Dim testString As String = "The quick red fox jumps over the lazy brown dog."

			' Create the initial formatted text string.
			Dim formattedText As New FormattedText(testString, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, New Typeface("Narkism"), 24, Brushes.Black)

			' <SnippetFormattedTextSnippets3>
			' Get the minimimum line width for the text content -- that is, the widest word.
			Dim minWidth As Double = formattedText.MinWidth

			' Set the maximum text width to the widest word in the text content.
			formattedText.MaxTextWidth = minWidth
			' </SnippetFormattedTextSnippets3>

            ' Set a maximum height. If the text overflows this value, an ellipsis "..." appears.
			formattedText.MaxTextHeight = 400

			' Draw the formatted text string to the DrawingContext of the control.
			drawingContext.DrawText(formattedText, New Point(10, 0))
		End Sub

		' Provide a required override for the MeasureOverride method.
		Protected Overrides Function MeasureOverride(ByVal availableSize As Size) As Size
			' Return the value of the parameter.
			Return MyBase.MeasureOverride(availableSize)
		End Function

		' Provide a required override for the ArrangeOverride method.
		Protected Overrides Function ArrangeOverride(ByVal finalSize As Size) As Size
			' Return the value of the parameter.
			Return MyBase.ArrangeOverride(finalSize)
		End Function
	End Class
End Namespace
