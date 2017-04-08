'<Snippet1>

' <SnippetSolidColorBrushAnimationExample> 

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Input

Namespace Microsoft.Samples.Animation
	''' <summary>
	''' This example shows how to animate the Opacity and Color 
	''' properties of a SolidColorBrush.
	''' </summary>
	Public Class SolidColorBrushExample
		Inherits Page

		Public Sub New()
			Title = "SolidColorBrush Animation Example"
			Background = Brushes.White

			' Create a NameScope for the page so
			' that Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

			' Create a Rectangle.
			Dim aRectangle As New Rectangle()
			aRectangle.Width = 100
			aRectangle.Height = 100

			' Create a SolidColorBrush to paint
			' the rectangle's fill. The Opacity
			' and Color properties of the brush
			' will be animated.
			Dim myAnimatedBrush As New SolidColorBrush()
			myAnimatedBrush.Color = Colors.Orange
			aRectangle.Fill = myAnimatedBrush

			' Register the brush's name with the page
			' so that it can be targeted by storyboards.
			Me.RegisterName("MyAnimatedBrush", myAnimatedBrush)

			'
			' Animate the brush's color to gray when
			' the mouse enters the rectangle.
			'
			Dim mouseEnterColorAnimation As New ColorAnimation()
			mouseEnterColorAnimation.To = Colors.Gray
			mouseEnterColorAnimation.Duration = TimeSpan.FromSeconds(1)
			Storyboard.SetTargetName(mouseEnterColorAnimation, "MyAnimatedBrush")
			Storyboard.SetTargetProperty(mouseEnterColorAnimation, New PropertyPath(SolidColorBrush.ColorProperty))
			Dim mouseEnterStoryboard As New Storyboard()
			mouseEnterStoryboard.Children.Add(mouseEnterColorAnimation)
			AddHandler aRectangle.MouseEnter, Sub(sender As Object, e As MouseEventArgs) mouseEnterStoryboard.Begin(Me)

			'
			' Animate the brush's color to orange when
			' the mouse leaves the rectangle.
			'
			Dim mouseLeaveColorAnimation As New ColorAnimation()
			mouseLeaveColorAnimation.To = Colors.Orange
			mouseLeaveColorAnimation.Duration = TimeSpan.FromSeconds(1)
			Storyboard.SetTargetName(mouseLeaveColorAnimation, "MyAnimatedBrush")
			Storyboard.SetTargetProperty(mouseLeaveColorAnimation, New PropertyPath(SolidColorBrush.ColorProperty))
			Dim mouseLeaveStoryboard As New Storyboard()
			mouseLeaveStoryboard.Children.Add(mouseLeaveColorAnimation)
			AddHandler aRectangle.MouseLeave, Sub(sender As Object, e As MouseEventArgs) mouseLeaveStoryboard.Begin(Me)

			'
			' Animate the brush's opacity to 0 and back when
			' the left mouse button is pressed over the rectangle.
			'
			Dim opacityAnimation As New DoubleAnimation()
			opacityAnimation.To = 0.0
			opacityAnimation.Duration = TimeSpan.FromSeconds(0.5)
			opacityAnimation.AutoReverse = True
			Storyboard.SetTargetName(opacityAnimation, "MyAnimatedBrush")
			Storyboard.SetTargetProperty(opacityAnimation, New PropertyPath(SolidColorBrush.OpacityProperty))
			Dim mouseLeftButtonDownStoryboard As New Storyboard()
			mouseLeftButtonDownStoryboard.Children.Add(opacityAnimation)
			AddHandler aRectangle.MouseLeftButtonDown, Sub(sender As Object, e As MouseButtonEventArgs) mouseLeftButtonDownStoryboard.Begin(Me)

			Dim mainPanel As New StackPanel()
			mainPanel.Margin = New Thickness(20)
			mainPanel.Children.Add(aRectangle)
			Content = mainPanel
		End Sub

	End Class
End Namespace
' </SnippetSolidColorBrushAnimationExample> 


'</Snippet1>
