' <SnippetStreamGeometryPolyQuadraticBezierToExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Collections.Generic

Namespace SDKSample
	Partial Public Class StreamGeometryPolyQuadraticBezierToExample
		Inherits Page
		Public Sub New()
			' Create a path to draw a geometry with.
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1

			' Create a StreamGeometry to use to specify myPath.
			Dim geometry As New StreamGeometry()
			geometry.FillRule = FillRule.EvenOdd

			' Open a StreamGeometryContext that can be used to describe this StreamGeometry object's contents. 
			Using ctx As StreamGeometryContext = geometry.Open()
				' Set the begin point of the shape.
				ctx.BeginFigure(New Point(10, 100), True, False) ' is closed  -  is filled 

				' Create a collection of Point structures that will be used with the PolyQuadraticBezierTo 
				' Method to create two quadratic Bezier curves.
				Dim pointList As New List(Of Point)()

				' First quadratic Bezier curve is specified with these two points.

				' Control point for first quadratic Bezier curve.
				pointList.Add(New Point(100, 0))

				' End point for first quadratic Bezier curve.
				pointList.Add(New Point(200, 200))

				' Second quadratic Bezier curve is specified with these two points.

				' Control point for second quadratic Bezier curve.
				pointList.Add(New Point(300, 300))

				' End point for second quadratic Bezier curve.
				pointList.Add(New Point(400, 100))

				' Create a Bezier curve using the collection of Point Structures.
				ctx.PolyQuadraticBezierTo(pointList, True, False) ' is smooth join  -  is stroked 

			End Using

			' Freeze the geometry (make it unmodifiable)
			' for additional performance benefits.
			geometry.Freeze()

			' specify the shape (quadratic Benzier curve) of the path using the StreamGeometry.
			myPath.Data = geometry

			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(myPath)
			Me.Content = mainPanel
		End Sub
	End Class
End Namespace
' </SnippetStreamGeometryPolyQuadraticBezierToExampleWholePage>