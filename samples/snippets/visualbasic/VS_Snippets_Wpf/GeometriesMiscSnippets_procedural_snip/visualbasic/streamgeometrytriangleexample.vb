' <SnippetStreamGeometryTriangleExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	' Use StreamGeometry with StreamGeometryContext to define a triangle shape.
	Partial Public Class StreamGeometryTriangleExample
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

				' Begin the triangle at the point specified. Notice that the shape is set to 
				' be closed so only two lines need to be specified below to make the triangle.
				ctx.BeginFigure(New Point(10, 100), True, True) ' is closed  -  is filled 

				' Draw a line to the next specified point.
				ctx.LineTo(New Point(100, 100), True, False) ' is smooth join  -  is stroked 

				' Draw another line to the next specified point.
				ctx.LineTo(New Point(100, 50), True, False) ' is smooth join  -  is stroked 
			End Using

			' Freeze the geometry (make it unmodifiable)
			' for additional performance benefits.
			geometry.Freeze()

			' Specify the shape (triangle) of the Path using the StreamGeometry.
			myPath.Data = geometry

			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(myPath)
			Me.Content = mainPanel
		End Sub
	End Class
End Namespace
' </SnippetStreamGeometryTriangleExampleWholePage>