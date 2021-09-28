' <SnippetStreamGeometryArcToExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class StreamGeometryArcToExample
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

				' Create an arc. Draw the arc from the begin point to 200,100 with the specified parameters.
				ctx.ArcTo(New Point(200, 100), New Size(100, 50), 45, True, SweepDirection.Counterclockwise, True, False) ' is smooth join  -  is stroked  -  is large arc  -  rotation angle 

			End Using

			' Freeze the geometry (make it unmodifiable)
			' for additional performance benefits.
			geometry.Freeze()

			' specify the shape (arc) of the path using the StreamGeometry.
			myPath.Data = geometry

			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(myPath)
			Me.Content = mainPanel
		End Sub
	End Class
End Namespace
' </SnippetStreamGeometryArcToExampleWholePage>