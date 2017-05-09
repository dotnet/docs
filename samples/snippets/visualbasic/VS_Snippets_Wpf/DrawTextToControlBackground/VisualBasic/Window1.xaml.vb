Imports System.Globalization

Namespace SDKSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			MyBase.New()
			InitializeComponent()
		End Sub

		' <SnippetDrawTextToControlBackground1>
		' Handle the WindowLoaded event for the window.
		Private Sub WindowLoaded(ByVal sender As Object, ByVal e As EventArgs)
			' Update the background property of the label and button.
			myLabel.Background = New DrawingBrush(DrawMyText("My Custom Label"))
			myButton.Background = New DrawingBrush(DrawMyText("Display Text"))
		End Sub

		' Convert the text string to a geometry and draw it to the control's DrawingContext.
		Private Function DrawMyText(ByVal textString As String) As Drawing
			' Create a new DrawingGroup of the control.
			Dim drawingGroup As New DrawingGroup()

			' Open the DrawingGroup in order to access the DrawingContext.
			Using drawingContext As DrawingContext = drawingGroup.Open()
				' Create the formatted text based on the properties set.
				Dim formattedText As New FormattedText(textString, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, New Typeface("Comic Sans MS Bold"), 48, Brushes.Black) ' This brush does not matter since we use the geometry of the text.

				' Build the geometry object that represents the text.
				Dim textGeometry As Geometry = formattedText.BuildGeometry(New Point(20, 0))

				' Draw a rounded rectangle under the text that is slightly larger than the text.
				drawingContext.DrawRoundedRectangle(Brushes.PapayaWhip, Nothing, New Rect(New Size(formattedText.Width + 50, formattedText.Height + 5)), 5.0, 5.0)

				' Draw the outline based on the properties that are set.
				drawingContext.DrawGeometry(Brushes.Gold, New Pen(Brushes.Maroon, 1.5), textGeometry)

				' Return the updated DrawingGroup content to be used by the control.
				Return drawingGroup
			End Using
		End Function
		' </SnippetDrawTextToControlBackground1>

		' Handle the Click event for the button.
		Private Sub OnButtonClick(ByVal sender As Object, ByVal e As EventArgs)
			' Update the background property of the canvas.
			myCanvas.Background = New DrawingBrush(DrawMyText(myTextBox.Text))
		End Sub
	End Class
End Namespace