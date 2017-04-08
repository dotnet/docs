' <SnippetGraphicsMMGradientAnimationExamplesWholePage>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Namespace BrushesIntroduction
	Public Class GradientStopAnimationExample
		Inherits Page
		Public Sub New()
			Title = "GradientStop Animation Example"
			Background = Brushes.White

			' Create a NameScope for the page so that
			' Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

			' Create a rectangle. This rectangle will
			' be painted with a gradient.
			Dim aRectangle As New Rectangle()
			aRectangle.Width = 200
			aRectangle.Height = 100
			aRectangle.Stroke = Brushes.Black
			aRectangle.StrokeThickness = 1

			' Create a LinearGradientBrush to paint
			' the rectangle's fill.
			Dim gradientBrush As New LinearGradientBrush()

			' Create gradient stops for the brush.
			Dim stop1 As New GradientStop(Colors.MediumBlue, 0.0)
			Dim stop2 As New GradientStop(Colors.Purple, 0.5)
			Dim stop3 As New GradientStop(Colors.Red, 1.0)

			' Register a name for each gradient stop with the
			' page so that they can be animated by a storyboard.
			Me.RegisterName("GradientStop1", stop1)
			Me.RegisterName("GradientStop2", stop2)
			Me.RegisterName("GradientStop3", stop3)

			' Add the stops to the brush.
			gradientBrush.GradientStops.Add(stop1)
			gradientBrush.GradientStops.Add(stop2)
			gradientBrush.GradientStops.Add(stop3)

			' Apply the brush to the rectangle.
			aRectangle.Fill = gradientBrush

			'
			' Animate the first gradient stop's offset from
			' 0.0 to 1.0 and then back to 0.0.
			'
			Dim offsetAnimation As New DoubleAnimation()
			offsetAnimation.From = 0.0
			offsetAnimation.To = 1.0
			offsetAnimation.Duration = TimeSpan.FromSeconds(1.5)
			offsetAnimation.AutoReverse = True
			Storyboard.SetTargetName(offsetAnimation, "GradientStop1")
			Storyboard.SetTargetProperty(offsetAnimation, New PropertyPath(GradientStop.OffsetProperty))

			'
			' Animate the second gradient stop's color from
			' Purple to Yellow and then back to Purple.
			'
			Dim gradientStopColorAnimation As New ColorAnimation()
			gradientStopColorAnimation.From = Colors.Purple
			gradientStopColorAnimation.To = Colors.Yellow
			gradientStopColorAnimation.Duration = TimeSpan.FromSeconds(1.5)
			gradientStopColorAnimation.AutoReverse = True
			Storyboard.SetTargetName(gradientStopColorAnimation, "GradientStop2")
			Storyboard.SetTargetProperty(gradientStopColorAnimation, New PropertyPath(GradientStop.ColorProperty))

			' Set the animation to begin after the first animation
			' ends.
			gradientStopColorAnimation.BeginTime = TimeSpan.FromSeconds(3)

			'
			' Animate the third gradient stop's color so
			' that it becomes transparent.
			'
			Dim opacityAnimation As New ColorAnimation()

			' Reduces the target color's alpha value by 1, 
			' making the color transparent.
			opacityAnimation.By = Color.FromScRgb(-1.0F, 0F, 0F, 0F)
			opacityAnimation.Duration = TimeSpan.FromSeconds(1.5)
			opacityAnimation.AutoReverse = True
			Storyboard.SetTargetName(opacityAnimation, "GradientStop3")
			Storyboard.SetTargetProperty(opacityAnimation, New PropertyPath(GradientStop.ColorProperty))

			' Set the animation to begin after the first two
			' animations have ended. 
			opacityAnimation.BeginTime = TimeSpan.FromSeconds(6)

			' Create a Storyboard to apply the animations.
			Dim gradientStopAnimationStoryboard As New Storyboard()
			gradientStopAnimationStoryboard.Children.Add(offsetAnimation)
			gradientStopAnimationStoryboard.Children.Add(gradientStopColorAnimation)
			gradientStopAnimationStoryboard.Children.Add(opacityAnimation)

			' Begin the storyboard when the left mouse button is
			' pressed over the rectangle.
			AddHandler aRectangle.MouseLeftButtonDown, Sub(sender As Object, e As MouseButtonEventArgs) gradientStopAnimationStoryboard.Begin(Me)

			Dim mainPanel As New StackPanel()
			mainPanel.Margin = New Thickness(10)
			mainPanel.Children.Add(aRectangle)
			Content = mainPanel
		End Sub
	End Class
End Namespace
' </SnippetGraphicsMMGradientAnimationExamplesWholePage>


