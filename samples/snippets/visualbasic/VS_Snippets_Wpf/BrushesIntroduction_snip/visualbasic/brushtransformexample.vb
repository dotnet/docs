' <SnippetBrushTransformExampleWholePage> 

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Media.Imaging

Namespace BrushesIntroduction
	Public Class BrushTransformExample
		Inherits Page
		Public Sub New()
			' <SnippetImageBrushNoTransform>
			' Create an ImageBrush with no transform.
			Dim noTransformImageBrush As New ImageBrush()
			noTransformImageBrush.ImageSource = New BitmapImage(New Uri("sampleImages\pinkcherries.jpg", UriKind.Relative))

			' Use the brush to paint a rectangle.
			Dim noTransformImageBrushRectangle As New Rectangle()
			noTransformImageBrushRectangle.Width = 175
			noTransformImageBrushRectangle.Height = 90
			noTransformImageBrushRectangle.Stroke = Brushes.Black
			noTransformImageBrushRectangle.Fill = noTransformImageBrush
			' </SnippetImageBrushNoTransform>

			' <SnippetImageBrushRelativeTransformExample>
			'
			' Create an ImageBrush with a relative transform and
			' use it to paint a rectangle.
			'
			Dim relativeTransformImageBrush As New ImageBrush()
			relativeTransformImageBrush.ImageSource = New BitmapImage(New Uri("sampleImages\pinkcherries.jpg", UriKind.Relative))

			' Create a 45 rotate transform about the brush's center
			' and apply it to the brush's RelativeTransform property.
			Dim aRotateTransform As New RotateTransform()
			aRotateTransform.CenterX = 0.5
			aRotateTransform.CenterY = 0.5
			aRotateTransform.Angle = 45
			relativeTransformImageBrush.RelativeTransform = aRotateTransform

			' Use the brush to paint a rectangle.
			Dim relativeTransformImageBrushRectangle As New Rectangle()
			relativeTransformImageBrushRectangle.Width = 175
			relativeTransformImageBrushRectangle.Height = 90
			relativeTransformImageBrushRectangle.Stroke = Brushes.Black
			relativeTransformImageBrushRectangle.Fill = relativeTransformImageBrush

			' </SnippetImageBrushRelativeTransformExample>

			' <SnippetImageBrushTransformExample>
			'
			' Create an ImageBrush with a transform and
			' use it to paint a rectangle.
			'
			Dim transformImageBrush As New ImageBrush()
			transformImageBrush.ImageSource = New BitmapImage(New Uri("sampleImages\pinkcherries.jpg", UriKind.Relative))

			' Create a 45 rotate transform about the brush's center
			' and apply it to the brush's Transform property.
			Dim anotherRotateTransform As New RotateTransform()
			anotherRotateTransform.CenterX = 87.5
			anotherRotateTransform.CenterY = 45
			anotherRotateTransform.Angle = 45
			transformImageBrush.Transform = anotherRotateTransform

			' Use the brush to paint a rectangle.
			Dim transformImageBrushRectangle As New Rectangle()
			transformImageBrushRectangle.Width = 175
			transformImageBrushRectangle.Height = 90
			transformImageBrushRectangle.Stroke = Brushes.Black
			transformImageBrushRectangle.Fill = transformImageBrush

			' </SnippetImageBrushTransformExample>


			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(noTransformImageBrushRectangle)
			mainPanel.Children.Add(relativeTransformImageBrushRectangle)
			mainPanel.Children.Add(transformImageBrushRectangle)

			Content = mainPanel
			Title = "Transforming Brushes"
			Background = Brushes.White


		End Sub


	End Class
End Namespace
' </SnippetBrushTransformExampleWholePage> 


