' <SnippetRectAnimationWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Namespace SDKSamples
	Public Class RectAnimationExample
		Inherits Page
		Public Sub New()

			' Create a NameScope for this page so that
			' Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

			Dim myRectangleGeometry As New RectangleGeometry()
			myRectangleGeometry.Rect = New Rect(0, 200, 100, 100)

			' Assign the geometry a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("MyAnimatedRectangleGeometry", myRectangleGeometry)

            Dim myPath As New Path()
            With myPath
                .Fill = Brushes.LemonChiffon
                .StrokeThickness = 1
                .Stroke = Brushes.Black
                .Data = myRectangleGeometry
            End With

            Dim myRectAnimation As New RectAnimation()
            With myRectAnimation
                .Duration = TimeSpan.FromSeconds(2)
                .FillBehavior = FillBehavior.HoldEnd

                ' Set the animation to repeat forever. 
                .RepeatBehavior = RepeatBehavior.Forever

                ' Set the From and To properties of the animation.
                .From = New Rect(0, 200, 100, 100)
                .To = New Rect(600, 50, 200, 50)
            End With

            ' Set the animation to target the Rect property
            ' of the object named "MyAnimatedRectangleGeometry."
            Storyboard.SetTargetName(myRectAnimation, "MyAnimatedRectangleGeometry")
            Storyboard.SetTargetProperty(myRectAnimation, New PropertyPath(RectangleGeometry.RectProperty))

            ' Create a storyboard to apply the animation.
            Dim ellipseStoryboard As New Storyboard()
            ellipseStoryboard.Children.Add(myRectAnimation)

            ' Start the storyboard when the Path loads.
            AddHandler myPath.Loaded, Sub(sender As Object, e As RoutedEventArgs) ellipseStoryboard.Begin(Me)

            Dim containerCanvas As New Canvas()
            containerCanvas.Children.Add(myPath)

            Content = containerCanvas
		End Sub
	End Class
End Namespace
' </SnippetRectAnimationWholePage>

