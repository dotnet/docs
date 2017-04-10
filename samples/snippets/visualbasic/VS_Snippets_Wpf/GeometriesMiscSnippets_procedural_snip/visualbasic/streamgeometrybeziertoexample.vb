' <SnippetStreamGeometryBezierToExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class StreamGeometryBezierToExample
		Inherits Page
		Public Sub New()

			' Create a StreamGeometry to use to specify myPath.
			Dim geometry As New StreamGeometry()
			geometry.FillRule = FillRule.EvenOdd

			' Open a StreamGeometryContext that can be used to describe this StreamGeometry 
			' object's contents.
			Using ctx As StreamGeometryContext = geometry.Open()
				' Set the begin point of the shape.
				ctx.BeginFigure(New Point(10, 100), True, False) ' is closed  -  is filled 

				' Create a Bezier curve using the 3 specifed points where the first two points
				' are control points and the last point is the destination point for the curve.
				ctx.BezierTo(New Point(100, 0), New Point(200,200), New Point(300,100), True, False) ' is smooth join  -  is stroked 

			End Using

			' Create a path to draw a geometry with.
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1

			' Freeze the geometry (make it unmodifiable)
			' for additional performance benefits.
			geometry.Freeze()

			' specify the shape (Bezier Curve) of the path using the StreamGeometry.
			myPath.Data = geometry

			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(myPath)
			Me.Content = mainPanel
		End Sub
	End Class
End Namespace
' </SnippetStreamGeometryBezierToExampleWholePage>