Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Partial Public Class CombiningGeometriesExample
		Inherits Page
		Public Sub New()
			' Add path shape to the UI.
			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(CompositeShape1())
			mainPanel.Children.Add(CompositeShape2())
			mainPanel.Children.Add(CompositeShape3())
			mainPanel.Children.Add(CompositeShape4())
			mainPanel.Children.Add(CompositeShape5())
			mainPanel.Children.Add(CompositeShape6())
			Me.Content = mainPanel

		End Sub

		Private Function CompositeShape1() As Path
			' <Snippet19>
			Dim myPathFigure As New PathFigure()
			myPathFigure.StartPoint = New Point(10, 50)
			Dim myLineGeometry As New LineGeometry()
			myLineGeometry.StartPoint = New Point(10, 10)
			myLineGeometry.EndPoint = New Point(50, 30)

			Dim myEllipseGeometry As New EllipseGeometry()
			myEllipseGeometry.Center = New Point(40, 70)
			myEllipseGeometry.RadiusX = 30
			myEllipseGeometry.RadiusY = 30

			Dim myRectangleGeometry As New RectangleGeometry()
			myRectangleGeometry.Rect = New Rect(30,55, 100,30)

			Dim myGeometryGroup As New GeometryGroup()
			myGeometryGroup.FillRule = FillRule.EvenOdd
			myGeometryGroup.Children.Add(myLineGeometry)
			myGeometryGroup.Children.Add(myEllipseGeometry)
			myGeometryGroup.Children.Add(myRectangleGeometry)



			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255)
			myPath.Fill = mySolidColorBrush
			myPath.Data = myGeometryGroup
			' </Snippet19>
			Return myPath

		End Function

		Private Function CompositeShape2() As Path
			' <Snippet20>
			Dim myPathFigure As New PathFigure()

			Dim myEllipseGeometry1 As New EllipseGeometry()
			myEllipseGeometry1.Center = New Point(75, 75)
			myEllipseGeometry1.RadiusX = 50
			myEllipseGeometry1.RadiusY = 50

			Dim myEllipseGeometry2 As New EllipseGeometry()
			myEllipseGeometry2.Center = New Point(125, 75)
			myEllipseGeometry2.RadiusX = 50
			myEllipseGeometry2.RadiusY = 50


			Dim myGeometryGroup As New GeometryGroup()
			myGeometryGroup.FillRule = FillRule.Nonzero
			myGeometryGroup.Children.Add(myEllipseGeometry1)
			myGeometryGroup.Children.Add(myEllipseGeometry2)

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255)
			myPath.Fill = mySolidColorBrush
			myPath.Data = myGeometryGroup
			' </Snippet20>
			Return myPath

		End Function

		Private Function CompositeShape3() As Path
			' <Snippet21>
			Dim myPathFigure As New PathFigure()

			Dim myEllipseGeometry1 As New EllipseGeometry()
			myEllipseGeometry1.Center = New Point(75, 75)
			myEllipseGeometry1.RadiusX = 50
			myEllipseGeometry1.RadiusY = 50

			Dim myEllipseGeometry2 As New EllipseGeometry()
			myEllipseGeometry2.Center = New Point(125, 75)
			myEllipseGeometry2.RadiusX = 50
			myEllipseGeometry2.RadiusY = 50

			Dim myCombinedGeometry As New CombinedGeometry()

			' Combines two geometries using the Exclude combine mode.
			myCombinedGeometry.GeometryCombineMode = GeometryCombineMode.Exclude
			myCombinedGeometry.Geometry1 = myEllipseGeometry1
			myCombinedGeometry.Geometry2 = myEllipseGeometry2

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255)
			myPath.Fill = mySolidColorBrush
			myPath.Data = myCombinedGeometry
			' </Snippet21>
			Return myPath

		End Function

		Private Function CompositeShape4() As Path
			' <Snippet22>
			Dim myPathFigure As New PathFigure()

			Dim myEllipseGeometry1 As New EllipseGeometry()
			myEllipseGeometry1.Center = New Point(75, 75)
			myEllipseGeometry1.RadiusX = 50
			myEllipseGeometry1.RadiusY = 50

			Dim myEllipseGeometry2 As New EllipseGeometry()
			myEllipseGeometry2.Center = New Point(125, 75)
			myEllipseGeometry2.RadiusX = 50
			myEllipseGeometry2.RadiusY = 50

			Dim myCombinedGeometry As New CombinedGeometry()

			' Combines two geometries using the Intersect combine mode.
			myCombinedGeometry.GeometryCombineMode = GeometryCombineMode.Intersect
			myCombinedGeometry.Geometry1 = myEllipseGeometry1
			myCombinedGeometry.Geometry2 = myEllipseGeometry2

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255)
			myPath.Fill = mySolidColorBrush
			myPath.Data = myCombinedGeometry
			' </Snippet22>
			Return myPath

		End Function

		Private Function CompositeShape5() As Path
			' <Snippet23>
			Dim myPathFigure As New PathFigure()

			Dim myEllipseGeometry1 As New EllipseGeometry()
			myEllipseGeometry1.Center = New Point(75, 75)
			myEllipseGeometry1.RadiusX = 50
			myEllipseGeometry1.RadiusY = 50

			Dim myEllipseGeometry2 As New EllipseGeometry()
			myEllipseGeometry2.Center = New Point(125, 75)
			myEllipseGeometry2.RadiusX = 50
			myEllipseGeometry2.RadiusY = 50

			Dim myCombinedGeometry As New CombinedGeometry()

			' Combines two geometries using the Union combine mode.
			myCombinedGeometry.GeometryCombineMode = GeometryCombineMode.Union
			myCombinedGeometry.Geometry1 = myEllipseGeometry1
			myCombinedGeometry.Geometry2 = myEllipseGeometry2

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255)
			myPath.Fill = mySolidColorBrush
			myPath.Data = myCombinedGeometry
			' </Snippet23>
			Return myPath

		End Function

		Private Function CompositeShape6() As Path
			' <Snippet24>
			Dim myPathFigure As New PathFigure()

			Dim myEllipseGeometry1 As New EllipseGeometry()
			myEllipseGeometry1.Center = New Point(75, 75)
			myEllipseGeometry1.RadiusX = 50
			myEllipseGeometry1.RadiusY = 50

			Dim myEllipseGeometry2 As New EllipseGeometry()
			myEllipseGeometry2.Center = New Point(125, 75)
			myEllipseGeometry2.RadiusX = 50
			myEllipseGeometry2.RadiusY = 50

			Dim myCombinedGeometry As New CombinedGeometry()

			' Combines two geometries using the XOR combine mode.
			myCombinedGeometry.GeometryCombineMode = GeometryCombineMode.Xor
			myCombinedGeometry.Geometry1 = myEllipseGeometry1
			myCombinedGeometry.Geometry2 = myEllipseGeometry2

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			Dim mySolidColorBrush As New SolidColorBrush()
			mySolidColorBrush.Color = Color.FromArgb(255, 204, 204, 255)
			myPath.Fill = mySolidColorBrush
			myPath.Data = myCombinedGeometry
			' </Snippet24>
			Return myPath

		End Function

	End Class
End Namespace