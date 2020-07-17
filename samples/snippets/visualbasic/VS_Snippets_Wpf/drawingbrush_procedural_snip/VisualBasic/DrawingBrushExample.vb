' <SnippetDrawingBrushExampleWholePage>

Imports System.Windows.Media.Animation


Namespace Microsoft.Samples.DrawingBrushExamples
	''' <summary>
	''' Paints a Rectangle element with a DrawingBrush.
	''' </summary>
	Public Class DrawingBrushExample
		Inherits Page
		Public Sub New()
			Background = Brushes.White
			Dim mainPanel As New StackPanel()

			' Create a drawing of two ellipses.
			Dim aDrawing As New GeometryDrawing()

			' Use geometries to describe two overlapping ellipses.
			Dim ellipse1 As New EllipseGeometry()
			ellipse1.RadiusX = 20
			ellipse1.RadiusY = 45
			ellipse1.Center = New Point(50, 50)
			Dim ellipse2 As New EllipseGeometry()
			ellipse2.RadiusX = 45
			ellipse2.RadiusY = 20
			ellipse2.Center = New Point(50, 50)
			Dim ellipses As New GeometryGroup()
			ellipses.Children.Add(ellipse1)
			ellipses.Children.Add(ellipse2)

			' Add the geometry to the drawing.
			aDrawing.Geometry = ellipses

			' Specify the drawing's fill.
			aDrawing.Brush = Brushes.Blue

			' Specify the drawing's stroke.
			Dim stroke As New Pen()
			stroke.Thickness = 10.0
			stroke.Brush = New LinearGradientBrush(Colors.Black, Colors.Gray, New Point(0, 0), New Point(1, 1))
			aDrawing.Pen = stroke

			' Create a DrawingBrush
			Dim myDrawingBrush As New DrawingBrush()
			myDrawingBrush.Drawing = aDrawing

			' Create a Rectangle element.
			Dim aRectangle As New Rectangle()
			aRectangle.Width = 150
			aRectangle.Height = 150
			aRectangle.Stroke = Brushes.Black
			aRectangle.StrokeThickness = 1.0

			' Use the DrawingBrush to paint the rectangle's
			' background.
			aRectangle.Fill = myDrawingBrush

			mainPanel.Children.Add(aRectangle)

			Me.Content = mainPanel

		End Sub
	End Class
End Namespace
' </SnippetDrawingBrushExampleWholePage>

