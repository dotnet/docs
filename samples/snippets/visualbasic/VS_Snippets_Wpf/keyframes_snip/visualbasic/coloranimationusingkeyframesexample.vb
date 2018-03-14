' <SnippetColorAnimationUsingKeyFramesWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Namespace Microsoft.Samples.KeyFrameExamples
	Public Class ColorAnimationUsingKeyFramesExample
		Inherits Page
		Public Sub New()
			Title = "BooleanAnimationUsingKeyFrames Example"
			Background = Brushes.White
			Margin = New Thickness(20)

			' Create a NameScope for this page so that
			' Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

			Dim myStackPanel As New StackPanel()
			myStackPanel.Orientation = Orientation.Vertical
			myStackPanel.HorizontalAlignment = HorizontalAlignment.Center

			' Create the Border that is the target of the animation.
			Dim animatedBrush As New SolidColorBrush()
			animatedBrush.Color = Color.FromArgb(255, 0, 255, 0)
			Dim myBorder As New Border()

			' Set the initial color of the border to green.
			myBorder.BorderBrush = animatedBrush
			myBorder.BorderThickness = New Thickness(28)
			myBorder.Padding = New Thickness(20)
			myStackPanel.Children.Add(myBorder)

			' Create a TextBlock to host inside the Border.
			Dim myTextBlock As New TextBlock()
			myTextBlock.Text = "This example shows how to use the ColorAnimationUsingKeyFrames" & " to create an animation on the BorderBrush property of a Border."
			myBorder.Child = myTextBlock

			' Assign the Brush a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("AnimatedBrush", animatedBrush)

			' Create a ColorAnimationUsingKeyFrames to
			' animate the BorderBrush property of the Button.
			Dim colorAnimation As New ColorAnimationUsingKeyFrames()
			colorAnimation.Duration = TimeSpan.FromSeconds(6)

			' Create brushes to use as animation values.
			Dim redColor As New Color()
			redColor = Color.FromArgb(255, 255, 0, 0)
			Dim yellowColor As New Color()
			yellowColor = Color.FromArgb(255, 255, 255, 0)
			Dim greenColor As New Color()
			greenColor = Color.FromArgb(255, 0, 255, 0)

			' Go from green to red in the first 2 seconds. LinearColorKeyFrame creates
			' a smooth, linear animation between values.
			colorAnimation.KeyFrames.Add(New LinearColorKeyFrame(redColor, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.0)))) ' KeyTime -  Target value (KeyValue)

			' In the next half second, go to yellow. DiscreteColorKeyFrame creates a 
			' sudden jump between values.
			colorAnimation.KeyFrames.Add(New DiscreteColorKeyFrame(yellowColor, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.5)))) ' KeyTime -  Target value (KeyValue)

			' In the final 2 seconds of the animation, go from yellow back to green. SplineColorKeyFrame 
			' creates a variable transition between values depending on the KeySpline property. In this example,
			' the animation starts off slow but toward the end of the time segment, it speeds up exponentially.
			colorAnimation.KeyFrames.Add(New SplineColorKeyFrame(greenColor, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4.5)), New KeySpline(0.6, 0.0, 0.9, 0.0))) ' KeySpline -  KeyTime -  Target value (KeyValue)

			' Set the animation to repeat forever. 
			colorAnimation.RepeatBehavior = RepeatBehavior.Forever

			' Set the animation to target the Color property
			' of the object named "AnimatedBrush".
			Storyboard.SetTargetName(colorAnimation, "AnimatedBrush")
			Storyboard.SetTargetProperty(colorAnimation, New PropertyPath(SolidColorBrush.ColorProperty))

			' Create a storyboard to apply the animation.
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(colorAnimation)

			' Start the storyboard when the Border loads.
			AddHandler myBorder.Loaded, Sub(sender As Object, e As RoutedEventArgs) myStoryboard.Begin(Me)

			Content = myStackPanel
		End Sub

	End Class
End Namespace
' </SnippetColorAnimationUsingKeyFramesWholePage>





