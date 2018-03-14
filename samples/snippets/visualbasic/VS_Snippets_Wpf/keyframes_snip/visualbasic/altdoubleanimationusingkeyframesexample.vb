' <SnippetAltDoubleAnimationUsingKeyFramesWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Namespace Microsoft.Samples.KeyFrameExamples
	''' <summary>
	''' This example shows how to use the DoubleAnimationUsingKeyFrames class to
	''' animate the position of an object.
	''' Key frame animations enable you to create complex animations 
	''' by specifying multiple destination values
	''' and controlling the animation's interpolation method.
	''' </summary>
	Public Class AltDoubleAnimationUsingKeyFramesExample
		Inherits Page
		Public Sub New()
			Title = "DoubleAnimationUsingKeyFrames Example"
			Background = Brushes.White
			Margin = New Thickness(20)

			' Create a NameScope for this page so that
			' Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

			' Create a rectangle.
			Dim aRectangle As New Rectangle()
			aRectangle.Width = 100
			aRectangle.Height = 100
			aRectangle.Stroke = Brushes.Black
			aRectangle.StrokeThickness = 5

			' Create a Canvas to contain and
			' position the rectangle.
			Dim containerCanvas As New Canvas()
			containerCanvas.Width = 610
			containerCanvas.Height = 300
			containerCanvas.Children.Add(aRectangle)
			Canvas.SetTop(aRectangle, 100)
			Canvas.SetLeft(aRectangle, 10)

			' Create a TranslateTransform to 
			' move the rectangle.
			Dim animatedTranslateTransform As New TranslateTransform()
			aRectangle.RenderTransform = animatedTranslateTransform

			' Assign the TranslateTransform a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("AnimatedTranslateTransform", animatedTranslateTransform)

			' Create a DoubleAnimationUsingKeyFrames to
			' animate the TranslateTransform.
			Dim translationAnimation As New DoubleAnimationUsingKeyFrames()
			translationAnimation.Duration = TimeSpan.FromSeconds(6)

			' Animate from the starting position to 500
			' over the first second using linear
			' interpolation.
			translationAnimation.KeyFrames.Add(New LinearDoubleKeyFrame(500, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3)))) ' KeyTime -  Target value (KeyValue)

			' Animate from 500 (the value of the previous key frame) 
			' to 400 at 4 seconds using discrete interpolation.
			' Because the interpolation is discrete, the rectangle will appear
			' to "jump" from 500 to 400.
			translationAnimation.KeyFrames.Add(New DiscreteDoubleKeyFrame(400, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)))) ' KeyTime -  Target value (KeyValue)

			' Animate from 400 (the value of the previous key frame) to 0
			' over two seconds, starting at 4 seconds (the key time of the
			' last key frame) and ending at 6 seconds.
			translationAnimation.KeyFrames.Add(New SplineDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6)), New KeySpline(0.6,0.0,0.9,0.0))) ' KeySpline -  KeyTime -  Target value (KeyValue)

			' Set the animation to repeat forever. 
			translationAnimation.RepeatBehavior = RepeatBehavior.Forever

			' Set the animation to target the X property
			' of the object named "AnimatedTranslateTransform."
			Storyboard.SetTargetName(translationAnimation, "AnimatedTranslateTransform")
			Storyboard.SetTargetProperty(translationAnimation, New PropertyPath(TranslateTransform.XProperty))

			' Create a storyboard to apply the animation.
			Dim translationStoryboard As New Storyboard()
			translationStoryboard.Children.Add(translationAnimation)

			' Start the storyboard after the rectangle loads.
			AddHandler aRectangle.Loaded, Sub(sender As Object, e As RoutedEventArgs) translationStoryboard.Begin(Me)

			Content = containerCanvas
		End Sub

	End Class
End Namespace
' </SnippetAltDoubleAnimationUsingKeyFramesWholePage>

