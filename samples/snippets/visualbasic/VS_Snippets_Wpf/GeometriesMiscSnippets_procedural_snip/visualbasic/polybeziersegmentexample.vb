' <SnippetPolyBezierSegmentCodeExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class PolyBezierSegmentExample
		Inherits Page
		Public Sub New()

			' Create a PathFigure to be used for the PathGeometry of myPath.
			Dim myPathFigure As New PathFigure()

			' Set the starting point for the PathFigure specifying that the
			' geometry starts at point 10,100.
			myPathFigure.StartPoint = New Point(10, 100)

			' Create a PointCollection that holds the Points used to specify 
			' the points of the PolyBezierSegment below.
			Dim myPointCollection As New PointCollection(6)
			myPointCollection.Add(New Point(0, 0))
			myPointCollection.Add(New Point(200, 0))
			myPointCollection.Add(New Point(300, 100))
			myPointCollection.Add(New Point(300, 0))
			myPointCollection.Add(New Point(400, 0))
			myPointCollection.Add(New Point(600, 100))

			' The PolyBezierSegment specifies two cubic Bezier curves.
			' The first curve is from 10,100 (start point specified by the PathFigure)
			' to 300,100 with a control point of 0,0 and another control point 
			' of 200,0. The second curve is from 300,100 (end of the last curve) to 
			' 600,100 with a control point of 300,0 and another control point of 400,0.
			Dim myBezierSegment As New PolyBezierSegment()
			myBezierSegment.Points = myPointCollection

			Dim myPathSegmentCollection As New PathSegmentCollection()
			myPathSegmentCollection.Add(myBezierSegment)

			myPathFigure.Segments = myPathSegmentCollection

			Dim myPathFigureCollection As New PathFigureCollection()
			myPathFigureCollection.Add(myPathFigure)

			Dim myPathGeometry As New PathGeometry()
			myPathGeometry.Figures = myPathFigureCollection

			' Create a path to draw a geometry with.
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1

			' specify the shape (quadratic Bezier curve) of the path using the StreamGeometry.
			myPath.Data = myPathGeometry

			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(myPath)
			Me.Content = mainPanel
		End Sub
	End Class
End Namespace
' </SnippetPolyBezierSegmentCodeExampleWholePage>