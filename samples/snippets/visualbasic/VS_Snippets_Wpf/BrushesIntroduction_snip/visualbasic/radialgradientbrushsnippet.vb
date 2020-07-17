' <SnippetSimpleRadialGradientExampleWholePage>


Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Namespace BrushesIntroduction
	Public Class RadialGradientBrushSnippet
		Inherits Page
		Public Sub New()
			Title = "RadialGradientBrush Example"
			Background = Brushes.White
			Margin = New Thickness(20)

			'
			' Create a RadialGradientBrush with four gradient stops.
			'
			Dim radialGradient As New RadialGradientBrush()

			' Set the GradientOrigin to the center of the area being painted.
			radialGradient.GradientOrigin = New Point(0.5, 0.5)

			' Set the gradient center to the center of the area being painted.
			radialGradient.Center = New Point(0.5, 0.5)

			' Set the radius of the gradient circle so that it extends to
			' the edges of the area being painted.
			radialGradient.RadiusX = 0.5
			radialGradient.RadiusY = 0.5

			' Create four gradient stops.
			radialGradient.GradientStops.Add(New GradientStop(Colors.Yellow, 0.0))
			radialGradient.GradientStops.Add(New GradientStop(Colors.Red, 0.25))
			radialGradient.GradientStops.Add(New GradientStop(Colors.Blue, 0.75))
			radialGradient.GradientStops.Add(New GradientStop(Colors.LimeGreen, 1.0))

			' Freeze the brush (make it unmodifiable) for performance benefits.
			radialGradient.Freeze()

			' Create a rectangle and paint it with the 
			' RadialGradientBrush.
			Dim aRectangle As New Rectangle()
			aRectangle.Width = 200
			aRectangle.Height = 100
			aRectangle.Fill = radialGradient

			Dim mainPanel As New StackPanel()
			mainPanel.Children.Add(aRectangle)
			Content = mainPanel

		End Sub

	End Class
End Namespace


' </SnippetSimpleRadialGradientExampleWholePage>

