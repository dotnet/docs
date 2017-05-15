Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Media.Imaging

Namespace BrushesIntroduction
	Public Class BrushTypesExample
		Inherits Page

		Public Sub New()
			Dim mainPanel As New StackPanel()
			createSolidColorBrushExample(mainPanel)
			createLinearGradientBrushExample(mainPanel)
			createRadialGradientBrushExample(mainPanel)
			createImageBrushExample(mainPanel)
			createDrawingBrushExample(mainPanel)
			createVisualBrushExample(mainPanel)

			Me.Content = mainPanel
		End Sub

		Private Sub createSolidColorBrushExample(ByVal examplePanel As Panel)

			' <SnippetGraphicsMMSolidColorBrushExampleInline>
			Dim exampleRectangle As New Rectangle()
			exampleRectangle.Width = 75
			exampleRectangle.Height = 75

			' Create a SolidColorBrush and use it to
			' paint the rectangle.
			Dim myBrush As New SolidColorBrush(Colors.Red)
			exampleRectangle.Fill = myBrush
			' </SnippetGraphicsMMSolidColorBrushExampleInline>

			examplePanel.Children.Add(exampleRectangle)
		End Sub


		Private Sub createLinearGradientBrushExample(ByVal examplePanel As Panel)

			' <SnippetGraphicsMMLinearGradientBrushExampleInline>
			Dim exampleRectangle As New Rectangle()
			exampleRectangle.Width = 75
			exampleRectangle.Height = 75

			' Create a LinearGradientBrush and use it to
			' paint the rectangle.
			Dim myBrush As New LinearGradientBrush()
			myBrush.GradientStops.Add(New GradientStop(Colors.Yellow, 0.0))
			myBrush.GradientStops.Add(New GradientStop(Colors.Orange, 0.5))
			myBrush.GradientStops.Add(New GradientStop(Colors.Red, 1.0))

			exampleRectangle.Fill = myBrush
			' </SnippetGraphicsMMLinearGradientBrushExampleInline>

			examplePanel.Children.Add(exampleRectangle)
		End Sub


		Private Sub createRadialGradientBrushExample(ByVal examplePanel As Panel)

			' <SnippetGraphicsMMRadialGradientBrushExampleInline>
			Dim exampleRectangle As New Rectangle()
			exampleRectangle.Width = 75
			exampleRectangle.Height = 75

			' Create a RadialGradientBrush and use it to
			' paint the rectangle.
			Dim myBrush As New RadialGradientBrush()
			myBrush.GradientOrigin = New Point(0.75, 0.25)
			myBrush.GradientStops.Add(New GradientStop(Colors.Yellow, 0.0))
			myBrush.GradientStops.Add(New GradientStop(Colors.Orange, 0.5))
			myBrush.GradientStops.Add(New GradientStop(Colors.Red, 1.0))

			exampleRectangle.Fill = myBrush
			' </SnippetGraphicsMMRadialGradientBrushExampleInline>

			examplePanel.Children.Add(exampleRectangle)
		End Sub

		Private Sub createImageBrushExample(ByVal examplePanel As Panel)

			' <SnippetGraphicsMMImageBrushExampleInline>
			Dim exampleRectangle As New Rectangle()
			exampleRectangle.Width = 75
			exampleRectangle.Height = 75

			' Create an ImageBrush and use it to
			' paint the rectangle.
			Dim myBrush As New ImageBrush()
			myBrush.ImageSource = New BitmapImage(New Uri("sampleImages\pinkcherries.jpg", UriKind.Relative))

			exampleRectangle.Fill = myBrush
			' </SnippetGraphicsMMImageBrushExampleInline>

			examplePanel.Children.Add(exampleRectangle)
		End Sub


		Private Sub createVisualBrushExample(ByVal examplePanel As Panel)

			' <SnippetGraphicsMMVisualBrushExampleInline>
			Dim exampleRectangle As New Rectangle()
			exampleRectangle.Width = 75
			exampleRectangle.Height = 75

			' Create a VisualBrush and use it
			' to paint the rectangle.
			Dim myBrush As New VisualBrush()

			'
			' Create the brush's contents.
			'
			Dim aPanel As New StackPanel()

			' Create a DrawingBrush and use it to
			' paint the panel.
			Dim myDrawingBrushBrush As New DrawingBrush()
			Dim aGeometryGroup As New GeometryGroup()
			aGeometryGroup.Children.Add(New RectangleGeometry(New Rect(0, 0, 50, 50)))
			aGeometryGroup.Children.Add(New RectangleGeometry(New Rect(50, 50, 50, 50)))
			Dim checkerBrush As New RadialGradientBrush()
			checkerBrush.GradientStops.Add(New GradientStop(Colors.MediumBlue, 0.0))
			checkerBrush.GradientStops.Add(New GradientStop(Colors.White, 1.0))
			Dim checkers As New GeometryDrawing(checkerBrush, Nothing, aGeometryGroup)
			myDrawingBrushBrush.Drawing = checkers
			aPanel.Background = myDrawingBrushBrush

			' Create some text.
			Dim someText As New TextBlock()
			someText.Text = "Hello, World"
			Dim fSizeConverter As New FontSizeConverter()
			someText.FontSize = CDbl(fSizeConverter.ConvertFromString("10pt"))
			someText.Margin = New Thickness(10)

			aPanel.Children.Add(someText)

			myBrush.Visual = aPanel
			exampleRectangle.Fill = myBrush

			' </SnippetGraphicsMMVisualBrushExampleInline>

			examplePanel.Children.Add(exampleRectangle)
		End Sub

		Private Sub createDrawingBrushExample(ByVal examplePanel As Panel)

			' <SnippetGraphicsMMDrawingBrushExampleInline>
			Dim exampleRectangle As New Rectangle()
			exampleRectangle.Width = 75
			exampleRectangle.Height = 75

			' Create a DrawingBrush and use it to
			' paint the rectangle.
			Dim myBrush As New DrawingBrush()

			Dim backgroundSquare As New GeometryDrawing(Brushes.White, Nothing, New RectangleGeometry(New Rect(0, 0, 100, 100)))

			Dim aGeometryGroup As New GeometryGroup()
			aGeometryGroup.Children.Add(New RectangleGeometry(New Rect(0, 0, 50, 50)))
			aGeometryGroup.Children.Add(New RectangleGeometry(New Rect(50, 50, 50, 50)))

			Dim checkerBrush As New LinearGradientBrush()
			checkerBrush.GradientStops.Add(New GradientStop(Colors.Black, 0.0))
			checkerBrush.GradientStops.Add(New GradientStop(Colors.Gray, 1.0))

			Dim checkers As New GeometryDrawing(checkerBrush, Nothing, aGeometryGroup)

			Dim checkersDrawingGroup As New DrawingGroup()
			checkersDrawingGroup.Children.Add(backgroundSquare)
			checkersDrawingGroup.Children.Add(checkers)

			myBrush.Drawing = checkersDrawingGroup
			myBrush.Viewport = New Rect(0, 0, 0.25, 0.25)
			myBrush.TileMode = TileMode.Tile

			exampleRectangle.Fill = myBrush
			' </SnippetGraphicsMMDrawingBrushExampleInline>

			examplePanel.Children.Add(exampleRectangle)
		End Sub



	End Class
End Namespace
