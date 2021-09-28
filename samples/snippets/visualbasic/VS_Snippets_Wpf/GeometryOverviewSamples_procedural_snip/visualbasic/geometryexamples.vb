'This is a list of commonly used namespaces for a window.

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Collections
Imports System.Threading
Namespace GeoOvwSample
		''' <summary>
		''' Interaction logic for Window1.xaml
		''' </summary>

	Public Class GeometryExamples
		Inherits Page
		Public Sub New()

			Dim scroller As New ScrollViewer()
			Dim mainPanel As New StackPanel()

			Dim graphBorder As New Border()
			graphBorder.Style = CType(Application.Current.Resources("GraphBorderStyle"), Style)
			graphBorder.Width = 200
			graphBorder.Height = 150
			graphBorder.Child = CreateLineGeometryExample()
			mainPanel.Children.Add(graphBorder)

			graphBorder = New Border()
			graphBorder.Style = CType(Application.Current.Resources("GraphBorderStyle"), Style)
			graphBorder.Width = 200
			graphBorder.Height = 150
			graphBorder.Child = CreateEllipseGeometryExample()
			mainPanel.Children.Add(graphBorder)

			graphBorder = New Border()
			graphBorder.Style = CType(Application.Current.Resources("GraphBorderStyle"), Style)
			graphBorder.Width = 200
			graphBorder.Height = 150
			graphBorder.Child = CreateRectangleGeometryExample()
			mainPanel.Children.Add(graphBorder)

			graphBorder = New Border()
			graphBorder.Style = CType(Application.Current.Resources("GraphBorderStyle"), Style)
			graphBorder.Width = 200
			graphBorder.Height = 150
			graphBorder.Child = CreateImageClipGeometryExample()
			mainPanel.Children.Add(graphBorder)

			graphBorder = New Border()
			graphBorder.Style = CType(Application.Current.Resources("GraphBorderStyle"), Style)
			graphBorder.Width = 200
			graphBorder.Height = 150
			graphBorder.Child = CreatePathGeometryLineExample()
			mainPanel.Children.Add(graphBorder)

			graphBorder = New Border()
			graphBorder.Style = CType(Application.Current.Resources("GraphBorderStyle"), Style)
			graphBorder.Width = 450
			graphBorder.Height = 250
			graphBorder.Child = CreatePathGeometryComplexExample()
			mainPanel.Children.Add(graphBorder)

			graphBorder = New Border()
			graphBorder.Style = CType(Application.Current.Resources("GraphBorderStyle"), Style)
			graphBorder.Width = 450
			graphBorder.Height = 250
			graphBorder.Child = CreatePathGeometryComplexMultiExample()
			mainPanel.Children.Add(graphBorder)

			scroller.Content = mainPanel
			Me.Content = scroller


		End Sub


		Public Function CreateLineGeometryExample() As FrameworkElement

			' <SnippetGraphicsMMLineGeometryExample>
			Dim myLineGeometry As New LineGeometry()
			myLineGeometry.StartPoint = New Point(10,20)
			myLineGeometry.EndPoint = New Point(100,130)

			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myLineGeometry
			' </SnippetGraphicsMMLineGeometryExample>

			Return myPath
		End Function

		Public Function CreateEllipseGeometryExample() As FrameworkElement

			' <SnippetGraphicsMMEllipseGeometryExample>
			Dim myEllipseGeometry As New EllipseGeometry()
			myEllipseGeometry.Center = New Point(50, 50)
			myEllipseGeometry.RadiusX = 50
			myEllipseGeometry.RadiusY = 50

			Dim myPath As New Path()
			myPath.Fill = Brushes.Gold
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myEllipseGeometry
			' </SnippetGraphicsMMEllipseGeometryExample>

			Return myPath
		End Function

		Public Function CreateRectangleGeometryExample() As FrameworkElement

			' <SnippetGraphicsMMRectangleGeometryExample>
			Dim myRectangleGeometry As New RectangleGeometry()
			myRectangleGeometry.Rect = New Rect(50,50,25,25)

			Dim myPath As New Path()
			myPath.Fill = Brushes.LemonChiffon
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myRectangleGeometry
			' </SnippetGraphicsMMRectangleGeometryExample>

			Return myPath
		End Function

		Public Function CreateImageClipGeometryExample() As FrameworkElement

			' <SnippetGraphicsMMImageClipGeometryExample>

			' Create the image to clip.
			Dim myImage As New Image()
			Dim imageUri As New Uri("C:\\Documents and Settings\\All Users\\Documents\My Pictures\\Sample Pictures\\Water lilies.jpg", UriKind.Relative)
			myImage.Source = New BitmapImage(imageUri)
			myImage.Width = 200
			myImage.Height = 150
			myImage.HorizontalAlignment = HorizontalAlignment.Left

			' Use an EllipseGeometry to define the clip region. 
			Dim myEllipseGeometry As New EllipseGeometry()
			myEllipseGeometry.Center = New Point(100, 75)
			myEllipseGeometry.RadiusX = 100
			myEllipseGeometry.RadiusY = 75
			myImage.Clip = myEllipseGeometry

			' </SnippetGraphicsMMImageClipGeometryExample>

			Return myImage
		End Function


		Public Function CreatePathGeometryLineExample() As FrameworkElement

			' <SnippetGraphicsMMPathGeometryLineExample>

			' Create a figure that describes a 
			' line from (10,20) to (100,130).
			Dim myPathFigure As New PathFigure()
			myPathFigure.StartPoint = New Point(10,20)
			myPathFigure.Segments.Add(New LineSegment(New Point(100,130), True)) ' IsStroked 

			''' Create a PathGeometry to contain the figure.
			Dim myPathGeometry As New PathGeometry()
			myPathGeometry.Figures.Add(myPathFigure)

			' Display the PathGeometry. 
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myPathGeometry
			' </SnippetGraphicsMMPathGeometryLineExample>

			Return myPath
		End Function

		Public Function CreatePathGeometryComplexExample() As FrameworkElement

			' <SnippetGraphicsMMPathGeometryComplexExample>

			' Create a figure.
			Dim myPathFigure As New PathFigure()
			myPathFigure.StartPoint = New Point(10,50)
			myPathFigure.Segments.Add(New BezierSegment(New Point(100,0), New Point(200,200), New Point(300,100), True)) ' IsStroked 
			myPathFigure.Segments.Add(New LineSegment(New Point(400,100), True)) ' IsStroked 
			myPathFigure.Segments.Add(New ArcSegment(New Point(200,100), New Size(50,50), 45, True, SweepDirection.Clockwise, True)) ' IsStroked  -  IsLargeArc 

			''' Create a PathGeometry to contain the figure.
			Dim myPathGeometry As New PathGeometry()
			myPathGeometry.Figures.Add(myPathFigure)

			' Display the PathGeometry. 
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myPathGeometry
			' </SnippetGraphicsMMPathGeometryComplexExample>

			Return myPath
		End Function

		Public Function CreatePathGeometryComplexMultiExample() As FrameworkElement

			' <SnippetGraphicsMMPathGeometryComplexMultiExample>

			Dim myPathGeometry As New PathGeometry()

			' Create a figure.
			Dim pathFigure1 As New PathFigure()
			pathFigure1.StartPoint = New Point(10,50)
			pathFigure1.Segments.Add(New BezierSegment(New Point(100,0), New Point(200,200), New Point(300,100), True)) ' IsStroked 
			pathFigure1.Segments.Add(New LineSegment(New Point(400,100), True)) ' IsStroked 
			pathFigure1.Segments.Add(New ArcSegment(New Point(200,100), New Size(50,50), 45, True, SweepDirection.Clockwise, True)) ' IsStroked  -  IsLargeArc 
			myPathGeometry.Figures.Add(pathFigure1)

			' Create another figure.
			Dim pathFigure2 As New PathFigure()
			pathFigure2.StartPoint = New Point(10,100)
			Dim polyLinePointArray() As Point = { New Point(50, 100), New Point(50, 150)}
			Dim myPolyLineSegment As New PolyLineSegment()
			myPolyLineSegment.Points = New PointCollection(polyLinePointArray)
			pathFigure2.Segments.Add(myPolyLineSegment)
			pathFigure2.Segments.Add(New QuadraticBezierSegment(New Point(200,200), New Point(300,100), True)) ' IsStroked 
			myPathGeometry.Figures.Add(pathFigure2)

			' Display the PathGeometry. 
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.StrokeThickness = 1
			myPath.Data = myPathGeometry
			' </SnippetGraphicsMMPathGeometryComplexMultiExample>

			Return myPath
		End Function


	End Class
End Namespace