' <SnippetPointAnimationUsingPathWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Windows.Shapes


Namespace SDKSample


	Public Class PointAnimationUsingPathExample
		Inherits Page

		Public Sub New()

			' Create a NameScope for the page so that
			' we can use Storyboards.
			NameScope.SetNameScope(Me, New NameScope())

			' Create the EllipseGeometry to animate.
			Dim animatedEllipseGeometry As New EllipseGeometry(New Point(10, 100), 15, 15)

			' Register the EllipseGeometry's name with
			' the page so that it can be targeted by a
			' storyboard.
			Me.RegisterName("AnimatedEllipseGeometry", animatedEllipseGeometry)

			' Create a Path element to display the geometry.
			Dim ellipsePath As New Path()
			ellipsePath.Data = animatedEllipseGeometry
			ellipsePath.Fill = Brushes.Blue
			ellipsePath.Margin = New Thickness(15)

			' Create a Canvas to contain ellipsePath
			' and add it to the page.
			Dim mainPanel As New Canvas()
			mainPanel.Width = 400
			mainPanel.Height = 400
			mainPanel.Children.Add(ellipsePath)
			Me.Content = mainPanel

			' Create the animation path.
			Dim animationPath As New PathGeometry()
			Dim pFigure As New PathFigure()
			pFigure.StartPoint = New Point(10, 100)
			Dim pBezierSegment As New PolyBezierSegment()
			pBezierSegment.Points.Add(New Point(35, 0))
			pBezierSegment.Points.Add(New Point(135, 0))
			pBezierSegment.Points.Add(New Point(160, 100))
			pBezierSegment.Points.Add(New Point(180, 190))
			pBezierSegment.Points.Add(New Point(285, 200))
			pBezierSegment.Points.Add(New Point(310, 100))
			pFigure.Segments.Add(pBezierSegment)
			animationPath.Figures.Add(pFigure)

			' Freeze the PathGeometry for performance benefits.
			animationPath.Freeze()

			' Create a PointAnimationgUsingPath to move
			' the EllipseGeometry along the animation path.
			Dim centerPointAnimation As New PointAnimationUsingPath()
			centerPointAnimation.PathGeometry = animationPath
			centerPointAnimation.Duration = TimeSpan.FromSeconds(5)
			centerPointAnimation.RepeatBehavior = RepeatBehavior.Forever

			' Set the animation to target the Center property
			' of the EllipseGeometry named "AnimatedEllipseGeometry".
			Storyboard.SetTargetName(centerPointAnimation, "AnimatedEllipseGeometry")
			Storyboard.SetTargetProperty(centerPointAnimation, New PropertyPath(EllipseGeometry.CenterProperty))

			' Create a Storyboard to contain and apply the animation.
			Dim pathAnimationStoryboard As New Storyboard()
			pathAnimationStoryboard.RepeatBehavior = RepeatBehavior.Forever
			pathAnimationStoryboard.AutoReverse = True
			pathAnimationStoryboard.Children.Add(centerPointAnimation)

			' Start the Storyboard when ellipsePath is loaded.
			AddHandler ellipsePath.Loaded, Sub(sender As Object, e As RoutedEventArgs) pathAnimationStoryboard.Begin(Me)
		End Sub

	End Class

End Namespace
' </SnippetPointAnimationUsingPathWholePage>


