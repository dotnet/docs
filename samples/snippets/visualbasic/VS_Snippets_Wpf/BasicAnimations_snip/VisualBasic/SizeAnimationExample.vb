' <SnippetSizeAnimationWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Namespace SDKSamples
	Public Class SizeAnimationExample
		Inherits Page
		Public Sub New()

			' Create a NameScope for this page so that
			' Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

			' Create an ArcSegment to define the geometry of the path.
			' The Size property of this segment is animated.
            Dim myArcSegment As New ArcSegment()
            With myArcSegment
                .Size = New Size(90, 80)
                .SweepDirection = SweepDirection.Clockwise
                .Point = New Point(500, 200)
            End With

            ' Assign the segment a name so that
            ' it can be targeted by a Storyboard.
            Me.RegisterName("myArcSegment", myArcSegment)

            Dim myPathSegmentCollection As New PathSegmentCollection()
            myPathSegmentCollection.Add(myArcSegment)

            ' Create a PathFigure to be used for the PathGeometry of myPath.
            Dim myPathFigure As New PathFigure()

            ' Set the starting point for the PathFigure specifying that the
            ' geometry starts at point 100,200.
            myPathFigure.StartPoint = New Point(100, 200)

            myPathFigure.Segments = myPathSegmentCollection

            Dim myPathFigureCollection As New PathFigureCollection()
            myPathFigureCollection.Add(myPathFigure)

            Dim myPathGeometry As New PathGeometry()
            myPathGeometry.Figures = myPathFigureCollection

            ' Create a path to draw a geometry with.
            Dim myPath As New Path()
            With myPath
                .Stroke = Brushes.Black
                .StrokeThickness = 1

                ' specify the shape of the path using the path geometry.
                .Data = myPathGeometry
            End With

            Dim mySizeAnimation As New SizeAnimation()
            With mySizeAnimation
                .Duration = TimeSpan.FromSeconds(2)

                ' Set the animation to repeat forever. 
                .RepeatBehavior = RepeatBehavior.Forever

                ' Set the From and To properties of the animation.
                .From = New Size(90, 80)
                .To = New Size(200, 200)
            End With

            ' Set the animation to target the Size property
            ' of the object named "myArcSegment."
            Storyboard.SetTargetName(mySizeAnimation, "myArcSegment")
            Storyboard.SetTargetProperty(mySizeAnimation, New PropertyPath(ArcSegment.SizeProperty))

            ' Create a storyboard to apply the animation.
            Dim ellipseStoryboard As New Storyboard()
            ellipseStoryboard.Children.Add(mySizeAnimation)

            ' Start the storyboard when the Path loads.
            AddHandler myPath.Loaded, Sub(sender As Object, e As RoutedEventArgs) ellipseStoryboard.Begin(Me)

            Dim containerCanvas As New Canvas()
            containerCanvas.Children.Add(myPath)

            Content = containerCanvas
        End Sub
	End Class
End Namespace
' </SnippetSizeAnimationWholePage>

