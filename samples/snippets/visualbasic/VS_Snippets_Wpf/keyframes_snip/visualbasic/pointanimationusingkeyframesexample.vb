' <SnippetPointAnimationUsingKeyFramesWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Namespace Microsoft.Samples.KeyFrameExamples
	''' <summary>
	''' This example shows how to use the PointAnimationUsingKeyFrames class
	''' to animate the position of an object.
	''' </summary>
	Public Class PointAnimationUsingKeyFramesExample
		Inherits Page
		Public Sub New()
			Title = "PointAnimationUsingKeyFrames Example"
			Background = Brushes.White
			Margin = New Thickness(20)

			' Create a NameScope for this page so that
			' Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

			' Create an EllipseGeometry.
			Dim myAnimatedEllipseGeometry As New EllipseGeometry(New Point(200,100), 15, 15)

			' Assign the EllipseGeometry a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("MyAnimatedEllipseGeometry", myAnimatedEllipseGeometry)

			' Create a Path element to display the geometry.
			Dim aPath As New Path()
			aPath.Fill = Brushes.Blue
			aPath.Data = myAnimatedEllipseGeometry

			' Create a Canvas to contain the path.
			Dim containerCanvas As New Canvas()
			containerCanvas.Width = 500
			containerCanvas.Height = 400
			containerCanvas.Children.Add(aPath)

			' Create a PointAnimationUsingKeyFrames to
			' animate the EllipseGeometry.
			Dim centerPointAnimation As New PointAnimationUsingKeyFrames()
			centerPointAnimation.Duration = TimeSpan.FromSeconds(5)

			' Animate from the starting position to (100,300)
			' over the first half-second using linear
			' interpolation.
			centerPointAnimation.KeyFrames.Add(New LinearPointKeyFrame(New Point(100, 300), KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.5)))) ' KeyTime -  Target value (KeyValue)

			' Animate from (100,300) (the value of the previous key frame) 
			' to (400,300) at 1 second using discrete interpolation.
			' Because the interpolation is discrete, the ellipse will appear
			' to "jump" to (400,300) at 1 second.
			centerPointAnimation.KeyFrames.Add(New DiscretePointKeyFrame(New Point(400, 300), KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)))) ' KeyTime -  Target value (KeyValue)

			' Animate from (400,300) (the value of the previous key frame) to (200,100)
			' over two seconds, starting at 1 second (the key time of the
			' last key frame) and ending at 3 seconds.
			centerPointAnimation.KeyFrames.Add(New SplinePointKeyFrame(New Point(200, 100), KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3)), New KeySpline(0.6, 0.0, 0.9, 0.0))) ' KeySpline -  KeyTime -  Target value (KeyValue)

			' Set the animation to repeat forever. 
			centerPointAnimation.RepeatBehavior = RepeatBehavior.Forever

			' Set the animation to target the Center property
			' of the object named "MyAnimatedEllipseGeometry".
			Storyboard.SetTargetName(centerPointAnimation, "MyAnimatedEllipseGeometry")
			Storyboard.SetTargetProperty(centerPointAnimation, New PropertyPath(EllipseGeometry.CenterProperty))

			' Create a storyboard to apply the animation.
			Dim ellipseStoryboard As New Storyboard()
			ellipseStoryboard.Children.Add(centerPointAnimation)

			' Start the storyboard when the Path loads.
			AddHandler aPath.Loaded, Sub(sender As Object, e As RoutedEventArgs) ellipseStoryboard.Begin(Me)

			Content = containerCanvas
		End Sub

	End Class
End Namespace
' </SnippetPointAnimationUsingKeyFramesWholePage>





