' <SnippetGraphicsMMDrawingBrushAsButtonBackgroundExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace Microsoft.Samples.BrushExamples

	Public Class DrawingBrushExample
		Inherits Page

		Public Sub New()

			Dim mainPanel As New StackPanel()
			canvasBackgroundExample(mainPanel)
			Me.Content = mainPanel

		End Sub


		' <SnippetGraphicsMMDrawingBrushAsButtonBackgroundExample>
		Private Sub canvasBackgroundExample(ByVal mainPanel As Panel)

			' <SnippetGraphicsMMDrawingBrushAsButtonBackgroundExample1>
			' Create a DrawingBrush.
			Dim myDrawingBrush As New DrawingBrush()

			' Create a drawing.
			Dim myGeometryDrawing As New GeometryDrawing()
			myGeometryDrawing.Brush = Brushes.LightBlue
			myGeometryDrawing.Pen = New Pen(Brushes.Gray, 1)
			Dim ellipses As New GeometryGroup()
			ellipses.Children.Add(New EllipseGeometry(New Point(25,50), 12.5, 25))
			ellipses.Children.Add(New EllipseGeometry(New Point(50,50), 12.5, 25))
			ellipses.Children.Add(New EllipseGeometry(New Point(75,50), 12.5, 25))

			myGeometryDrawing.Geometry = ellipses
			myDrawingBrush.Drawing = myGeometryDrawing

			Dim myButton As New Button()
			myButton.Content = "A Button"

			' Use the DrawingBrush to paint the button's background.
			myButton.Background = myDrawingBrush
			' </SnippetGraphicsMMDrawingBrushAsButtonBackgroundExample1>

			mainPanel.Children.Add(myButton)


		End Sub
		' </SnippetGraphicsMMDrawingBrushAsButtonBackgroundExample>

	End Class

End Namespace
' </SnippetGraphicsMMDrawingBrushAsButtonBackgroundExampleWholePage>