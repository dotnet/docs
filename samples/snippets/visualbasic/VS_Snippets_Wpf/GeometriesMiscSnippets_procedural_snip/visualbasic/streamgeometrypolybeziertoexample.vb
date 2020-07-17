' <SnippetStreamGeometryPolyBezierToExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Collections.Generic

Namespace SDKSample
	Partial Public Class StreamGeometryPolyBezierToExample
		Inherits Page
		Public Sub New()
			' Create a path to draw a geometry with.
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1

			' Create a StreamGeometry to use to specify myPath.
			Dim geometry As New StreamGeometry()
			geometry.FillRule = FillRule.EvenOdd

			' Open a StreamGeometryContext that can be used to describe this StreamGeometry 
			' object's contents.
			Using ctx As StreamGeometryContext = geometry.Open()
				' Set the begin point of the shape.
				ctx.BeginFigure(New Point(10, 100), True, False) ' is closed  -  is filled 

				' Create a collection of Point structures that will be used with the PolyBezierTo 
				' Method to create the Bezier curve.
				Dim pointList As New List(Of Point)()

				' First Bezier curve is specified with these three points.

				' First control point for first Bezier curve.
				pointList.Add(New Point(100,0))

				' Second control point for first Bezier curve.
				pointList.Add(New Point(200, 200))

				' Destination point for first Bezier curve.
				pointList.Add(New Point(300, 100))

				' Second Bezier curve is specified with these three points.

				' First control point for second Bezier curve.
				pointList.Add(New Point(400, 0))

				' Second control point for second Bezier curve.
				pointList.Add(New Point(500, 200))

				' Destination point for second Bezier curve.
				pointList.Add(New Point(600, 100))

				' Create a Bezier curve using the collection of Point Structures.
				ctx.PolyBezierTo(pointList, True, False) ' is smooth join  -  is stroked 

			End Using

			' Freeze the geometry (make it unmodifiable)
			' for additional performance benefits.
			geometry.Freeze()

			' specify the shape (Bezier curve) of the path using the StreamGeometry.
			myPath.Data = geometry

			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(myPath)
			Me.Content = mainPanel
		End Sub
	End Class
End Namespace
' </SnippetStreamGeometryPolyBezierToExampleWholePage>