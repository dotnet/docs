Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSample
	Public Class RotateTransformExample
		Inherits Page
		Public Sub New()
			WindowTitle = "RotateTransform Example"

			' <SnippetRotatePolylineAboutTopLeft>
			' Create a Polyline.
			Dim polyline1 As New Polyline()
			polyline1.Points.Add(New Point(25, 25))
			polyline1.Points.Add(New Point(0, 50))
			polyline1.Points.Add(New Point(25, 75))
			polyline1.Points.Add(New Point(50, 50))
			polyline1.Points.Add(New Point(25, 25))
			polyline1.Points.Add(New Point(25, 0))
			polyline1.Stroke = Brushes.Blue
			polyline1.StrokeThickness = 10

			' Create a RotateTransform to rotate
			' the Polyline 45 degrees about its
			' top-left corner.
			Dim rotateTransform1 As New RotateTransform(45)
			polyline1.RenderTransform = rotateTransform1

			' Create a Canvas to contain the Polyline.
			Dim canvas1 As New Canvas()
			canvas1.Width = 200
			canvas1.Height = 200
			Canvas.SetLeft(polyline1, 75)
			Canvas.SetTop(polyline1, 50)
			canvas1.Children.Add(polyline1)
			' </SnippetRotatePolylineAboutTopLeft>

			Dim border1 As New Border()
			border1.BorderBrush = Brushes.Black
			border1.BorderThickness = New Thickness(1)
			border1.HorizontalAlignment = HorizontalAlignment.Left
			border1.Background = CType(Application.Current.Resources("MyBlueGridBrushResource"), Brush)
			border1.Child = canvas1

			Dim mainPanel As New StackPanel()
			mainPanel.Margin = New Thickness(20)
			mainPanel.Children.Add(border1)

			' <SnippetRotatePolylineAboutCenter>
			' Create a Polyline.
			Dim polyline2 As New Polyline()
			polyline2.Points = polyline1.Points
			polyline2.Stroke = Brushes.Blue
			polyline2.StrokeThickness = 10

			' Create a RotateTransform to rotate
			' the Polyline 45 degrees about the
			' point (25,50).
			Dim rotateTransform2 As New RotateTransform(45)
			rotateTransform2.CenterX = 25
			rotateTransform2.CenterY = 50
			polyline2.RenderTransform = rotateTransform2

			' Create a Canvas to contain the Polyline.
			Dim canvas2 As New Canvas()
			canvas2.Width = 200
			canvas2.Height = 200
			Canvas.SetLeft(polyline2, 75)
			Canvas.SetTop(polyline2, 50)
			canvas2.Children.Add(polyline2)
			' </SnippetRotatePolylineAboutCenter>

			Dim border2 As New Border()
			border2.BorderBrush = Brushes.Black
			border2.BorderThickness = New Thickness(1)
			border2.HorizontalAlignment = HorizontalAlignment.Left
			border2.Background = CType(Application.Current.Resources("MyBlueGridBrushResource"), Brush)
			border2.Child = canvas2
			mainPanel.Children.Add(border2)

			Me.Content = mainPanel



		End Sub
	End Class
End Namespace


