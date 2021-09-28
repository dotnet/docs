' <SnippetRectAnimationUsingKeyFramesWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Namespace Microsoft.Samples.KeyFrameExamples
	''' <summary>
	''' This example shows how to use the RectAnimationUsingKeyFrames class to
	''' animate the position and size of a rectangle.
	''' Key frame animations enable you to create complex animations 
	''' by specifying multiple destination values
	''' and controlling the animation's interpolation method.
	''' </summary>
	Public Class RectAnimationUsingKeyFramesExample
		Inherits Page
		Public Sub New()
			Title = "RectAnimationUsingKeyFrames Example"
			Background = Brushes.White
			Margin = New Thickness(20)

			' Create a NameScope for this page so that
			' Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

			Dim myStackPanel As New StackPanel()
			myStackPanel.Orientation = Orientation.Vertical
			myStackPanel.HorizontalAlignment = HorizontalAlignment.Center

			'Add the Path Element
			Dim myPath As New Path()
			myPath.Stroke = Brushes.Black
			myPath.Fill = Brushes.LemonChiffon
			myPath.StrokeThickness = 1

			' Create a RectangleGeometry to specify the Path data.
			Dim myRectangleGeometry As New RectangleGeometry()
			myRectangleGeometry.Rect = New Rect(0, 200, 100, 100)
			myPath.Data = myRectangleGeometry

			myStackPanel.Children.Add(myPath)

			' Assign the TranslateTransform a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("AnimatedRectangleGeometry", myRectangleGeometry)

			' Create a RectAnimationUsingKeyFrames to
			' animate the RectangleGeometry.
			Dim rectAnimation As New RectAnimationUsingKeyFrames()
			rectAnimation.Duration = TimeSpan.FromSeconds(6)

			' Set the animation to repeat forever. 
			rectAnimation.RepeatBehavior = RepeatBehavior.Forever

			' Animate position, width, and height in first 2 seconds. LinearRectKeyFrame creates
			' a smooth, linear animation between values.
			rectAnimation.KeyFrames.Add(New LinearRectKeyFrame(New Rect(600,50,200,50), KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)))) ' KeyTime -  Target value (KeyValue)

			' In the next half second, change height to 10. DiscreteRectKeyFrame creates a 
			' sudden "jump" between values.
			rectAnimation.KeyFrames.Add(New DiscreteRectKeyFrame(New Rect(600, 50, 200, 10), KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.5)))) ' KeyTime -  Target value (KeyValue)

			' In the final 2 seconds of the animation, go back to the starting position, width, and height.  
			' Spline key frames like SplineRectKeyFrame creates a variable transition between values depending 
			' on the KeySpline property. In this example, the animation starts off slow but toward the end of 
			' the time segment, it speeds up exponentially.
			rectAnimation.KeyFrames.Add(New SplineRectKeyFrame(New Rect(0, 200, 100, 100), KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4.5)), New KeySpline(0.6, 0.0, 0.9, 0.0))) ' KeySpline -  KeyTime -  Target value (KeyValue)

			' Set the animation to target the Rect property
			' of the object named "AnimatedRectangleGeometry."
			Storyboard.SetTargetName(rectAnimation, "AnimatedRectangleGeometry")
			Storyboard.SetTargetProperty(rectAnimation, New PropertyPath(RectangleGeometry.RectProperty))

			' Create a storyboard to apply the animation.
			Dim rectStoryboard As New Storyboard()
			rectStoryboard.Children.Add(rectAnimation)

			' Start the storyboard after the rectangle loads.
			AddHandler myPath.Loaded, Sub(sender As Object, e As RoutedEventArgs) rectStoryboard.Begin(Me)

			Content = myStackPanel
		End Sub

	End Class
End Namespace
' </SnippetRectAnimationUsingKeyFramesWholePage>

