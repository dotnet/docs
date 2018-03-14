' <SnippetPenExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Namespace SDKSample
	Partial Public Class PenExample
		Inherits Page
		Public Sub New()
			' Create several geometries.
			Dim myRectangleGeometry As New RectangleGeometry()
			myRectangleGeometry.Rect = New Rect(0, 0, 50, 50)
			Dim myEllipseGeometry As New EllipseGeometry()
			myEllipseGeometry.Center = New Point(75, 75)
			myEllipseGeometry.RadiusX = 50
			myEllipseGeometry.RadiusY = 50
			Dim myLineGeometry As New LineGeometry()
			myLineGeometry.StartPoint = New Point(75, 75)
			myLineGeometry.EndPoint = New Point(75, 0)

			' Create a GeometryGroup and add the geometries to it.
			Dim myGeometryGroup As New GeometryGroup()
			myGeometryGroup.Children.Add(myRectangleGeometry)
			myGeometryGroup.Children.Add(myEllipseGeometry)
			myGeometryGroup.Children.Add(myLineGeometry)

			' Create a GeometryDrawing and use the GeometryGroup to specify
			' its geometry.
			Dim myGeometryDrawing As New GeometryDrawing()
			myGeometryDrawing.Geometry = myGeometryGroup

			' Add the GeometryDrawing to a DrawingGroup.
			Dim myDrawingGroup As New DrawingGroup()
			myDrawingGroup.Children.Add(myGeometryDrawing)

			' Create a Pen to add to the GeometryDrawing created above.
			Dim myPen As New Pen()
			myPen.Thickness = 10
			myPen.LineJoin = PenLineJoin.Round
			myPen.EndLineCap = PenLineCap.Round

			' Create a gradient to use as a value for the Pen's Brush property.
			Dim firstStop As New GradientStop()
			firstStop.Offset = 0.0
			Dim c1 As New Color()
			c1.A = 255
			c1.R = 204
			c1.G = 204
			c1.B = 255
			firstStop.Color = c1
			Dim secondStop As New GradientStop()
			secondStop.Offset = 1.0
			secondStop.Color = Colors.Purple

			Dim myLinearGradientBrush As New LinearGradientBrush()
			myLinearGradientBrush.GradientStops.Add(firstStop)
			myLinearGradientBrush.GradientStops.Add(secondStop)

			myPen.Brush = myLinearGradientBrush
			myGeometryDrawing.Pen = myPen

			' Create an Image and set its DrawingImage to the Geometry created above.
			Dim myImage As New Image()
			myImage.Stretch = Stretch.None
			myImage.Margin = New Thickness(10)

			Dim myDrawingImage As New DrawingImage()
			myDrawingImage.Drawing = myDrawingGroup
			myImage.Source = myDrawingImage

			Me.Content = myImage

		End Sub
	End Class
End Namespace
' </SnippetPenExampleWholePage>