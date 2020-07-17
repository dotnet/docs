' <SnippetPolyQuadraticBezierSegmentCodeExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class PolyQuadraticBezierSegmentExample
		Inherits Page
		Public Sub New()

			' Create a PathFigure to be used for the PathGeometry of myPath.
			Dim myPathFigure As New PathFigure()

			' Set the starting point for the PathFigure specifying that the
			' geometry starts at point 10,100.
			myPathFigure.StartPoint = New Point(10, 100)

			' Create a PointCollection that holds the Points used to specify 
			' the points of the PolyQuadraticBezierSegment below.
			Dim myPointCollection As New PointCollection(4)
			myPointCollection.Add(New Point(200, 200))
			myPointCollection.Add(New Point(300, 100))
			myPointCollection.Add(New Point(0, 200))
			myPointCollection.Add(New Point(30, 400))

			' The PolyQuadraticBezierSegment specifies two Bezier curves.
			' The first curve is from 10,100 (start point specified above)
			' to 300,100 with a control point of 200,200. The second curve
			' is from 200,200 (end of the last curve) to 30,400 with a 
			' control point of 0,200.
			Dim myBezierSegment As New PolyQuadraticBezierSegment()
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
' </SnippetPolyQuadraticBezierSegmentCodeExampleWholePage>