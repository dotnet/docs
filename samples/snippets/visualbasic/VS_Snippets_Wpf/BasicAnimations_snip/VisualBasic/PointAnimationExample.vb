' <SnippetPointAnimationWholePage>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Namespace SDKSamples
	' This example shows how to use PointAnimation to animate the
	' position of an ellipse by animating the Center property of an 
	' EllipseGeometry. PointAnimation is used because the Center property
	' takes a Point value.
	Public Class PointAnimationExample
		Inherits Page
		Public Sub New()

			' Create a NameScope for this page so that
			' Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

            Dim myEllipseGeometry As New EllipseGeometry()
            With myEllipseGeometry
                .Center = New Point(200, 100)
                .RadiusX = 15
                .RadiusY = 15
            End With

			' Assign the EllipseGeometry a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("MyAnimatedEllipseGeometry", myEllipseGeometry)

            Dim myPath As New Path()
            With myPath
                .Fill = Brushes.Blue
                .Margin = New Thickness(15)
                .Data = myEllipseGeometry
            End With

            Dim myPointAnimation As New PointAnimation()
            With myPointAnimation
                .Duration = TimeSpan.FromSeconds(2)

                ' Set the animation to repeat forever. 
                .RepeatBehavior = RepeatBehavior.Forever

                ' Set the From and To properties of the animation.
                .From = New Point(200, 100)
                .To = New Point(450, 250)
            End With

            ' Set the animation to target the Center property
            ' of the object named "MyAnimatedEllipseGeometry."
            Storyboard.SetTargetName(myPointAnimation, "MyAnimatedEllipseGeometry")
            Storyboard.SetTargetProperty(myPointAnimation, New PropertyPath(EllipseGeometry.CenterProperty))

            ' Create a storyboard to apply the animation.
            Dim ellipseStoryboard As New Storyboard()
            ellipseStoryboard.Children.Add(myPointAnimation)

            ' Start the storyboard when the Path loads.
            AddHandler myPath.Loaded, Sub(sender As Object, e As RoutedEventArgs) ellipseStoryboard.Begin(Me)

            Dim containerCanvas As New Canvas()
            containerCanvas.Children.Add(myPath)

            Content = containerCanvas
		End Sub

	End Class
End Namespace
' </SnippetPointAnimationWholePage>

