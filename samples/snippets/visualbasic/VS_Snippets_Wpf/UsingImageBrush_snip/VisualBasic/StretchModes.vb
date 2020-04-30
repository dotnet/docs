' <SnippetImageBrushStretchModesExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace Microsoft.Samples.Graphics.UsingImageBrush
	''' <summary>
	''' Demonstrates different ImageBrush Stretch settings.
	''' </summary>
	Public Class StretchModes
		Inherits Page
		Public Sub New()

			' Create an ImageBrush with its Stretch
			' property set to Uniform. The image it
			' contains will be expanded as much as possible
			' to fill the output area while still
			' preserving its aspect ratio.
			Dim uniformBrush As New ImageBrush()
			uniformBrush.ImageSource = New BitmapImage(New Uri("sampleImages\square.jpg", UriKind.Relative))
			uniformBrush.Stretch = Stretch.Uniform

			' Freeze the brush (make it unmodifiable) for performance benefits.
			uniformBrush.Freeze()

			' Create a rectangle and paint it with the ImageBrush.
            Dim rectangle1 As New Rectangle()
            With rectangle1
                .Width = 300
                .Height = 150
                .Stroke = Brushes.MediumBlue
                .StrokeThickness = 1.0
                .Fill = uniformBrush
            End With

            ' Create an ImageBrush with its Stretch
            ' property set to UniformToFill. The image it
            ' contains will be expanded to completely fill
            ' the rectangle, but its aspect ratio is preserved.
            Dim uniformToFillBrush As New ImageBrush()
            uniformToFillBrush.ImageSource = New BitmapImage(New Uri("sampleImages\square.jpg", UriKind.Relative))
            uniformToFillBrush.Stretch = Stretch.UniformToFill

            ' Freeze the brush (make it unmodifiable) for performance benefits.
            uniformToFillBrush.Freeze()

            ' Create a rectangle and paint it with the ImageBrush.
            Dim rectangle2 As New Rectangle()
            With rectangle2
                .Width = 300
                .Height = 150
                .Stroke = Brushes.MediumBlue
                .StrokeThickness = 1.0
                .Margin = New Thickness(0, 10, 0, 0)
                .Fill = uniformToFillBrush
            End With

            Dim mainPanel As New StackPanel()
            mainPanel.Children.Add(rectangle1)
            mainPanel.Children.Add(rectangle2)

            Content = mainPanel
            Background = Brushes.White
            Margin = New Thickness(20)
            Title = "ImageBrush Stretch Modes"


		End Sub
	End Class
End Namespace
' </SnippetImageBrushStretchModesExampleWholePage>


