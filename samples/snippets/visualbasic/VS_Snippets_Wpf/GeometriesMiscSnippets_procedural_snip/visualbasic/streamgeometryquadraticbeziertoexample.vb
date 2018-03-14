' <SnippetStreamGeometryQuadraticBezierToExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class StreamGeometryQuadraticBezierToExample
		Inherits Page
		Public Sub New()
			' Create a path to draw a geometry with.
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1

			' Create a StreamGeometry to use to specify myPath.
			Dim geometry As New StreamGeometry()

			' Open a StreamGeometryContext that can be used to describe this StreamGeometry 
			' object's contents.
			Using ctx As StreamGeometryContext = geometry.Open()
				' Set the begin point of the shape.
				ctx.BeginFigure(New Point(10, 100), True, False) ' is closed  -  is filled 

				' Create a Quadratic Bezier curve using the 2 specifed points. The first point
				' specifies the control point while the second point specifies the end point 
				' of the curve.
				ctx.QuadraticBezierTo(New Point(100, 0), New Point(200, 200), True, False) ' is smooth join  -  is stroked 

			End Using

			' Freeze the geometry (make it unmodifiable)
			' for additional performance benefits.
			geometry.Freeze()

			' specify the shape (quadratic Bezier curve) of the path using the StreamGeometry.
			myPath.Data = geometry

			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(myPath)
			Me.Content = mainPanel
		End Sub
	End Class
End Namespace
' </SnippetStreamGeometryQuadraticBezierToExampleWholePage>