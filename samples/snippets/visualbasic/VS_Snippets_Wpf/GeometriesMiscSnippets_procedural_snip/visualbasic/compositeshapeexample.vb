' <SnippetCompositeShapeCodeExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class CompositeShapeExample
		Inherits Page
		Public Sub New()
			' <SnippetCompositeShapeCodeExampleInline1>
			' Create a Path to be drawn to the screen.
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255)
			myPath.Fill = mySolidColorBrush

			' Create the line geometry to add to the Path
			Dim myLineGeometry As New LineGeometry()
			myLineGeometry.StartPoint = New Point(10, 10)
			myLineGeometry.EndPoint = New Point(50, 30)

			' Create the ellipse geometry to add to the Path
			Dim myEllipseGeometry As New EllipseGeometry()
			myEllipseGeometry.Center = New Point(40, 70)
			myEllipseGeometry.RadiusX = 30
			myEllipseGeometry.RadiusY = 30

			' Create a rectangle geometry to add to the Path
			Dim myRectGeometry As New RectangleGeometry()
			myRectGeometry.Rect = New Rect(30, 55, 100, 30)

			' Add all the geometries to a GeometryGroup.
			Dim myGeometryGroup As New GeometryGroup()
			myGeometryGroup.Children.Add(myLineGeometry)
			myGeometryGroup.Children.Add(myEllipseGeometry)
			myGeometryGroup.Children.Add(myRectGeometry)

			myPath.Data = myGeometryGroup

			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(myPath)
			Me.Content = mainPanel
			' </SnippetCompositeShapeCodeExampleInline1>

		End Sub
	End Class

End Namespace
' </SnippetCompositeShapeCodeExampleWholePage>
