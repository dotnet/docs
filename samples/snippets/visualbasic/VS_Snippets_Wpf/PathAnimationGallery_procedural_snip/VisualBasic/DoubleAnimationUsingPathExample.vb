' <SnippetDoubleAnimationUsingPathWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Windows.Shapes


Namespace SDKSample


	Public Class DoubleAnimationUsingPathExample
		Inherits Page

		Public Sub New()

			' Create a NameScope for the page so that
			' we can use Storyboards.
			NameScope.SetNameScope(Me, New NameScope())

			' Create a rectangle.
			Dim aRectangle As New Rectangle()
			aRectangle.Width = 30
			aRectangle.Height = 30
			aRectangle.Fill = Brushes.Blue

			' Create a transform. This transform
			' will be used to move the rectangle.
			Dim animatedTranslateTransform As New TranslateTransform()

			' Register the transform's name with the page
			' so that they it be targeted by a Storyboard.
			Me.RegisterName("AnimatedTranslateTransform", animatedTranslateTransform)

			aRectangle.RenderTransform = animatedTranslateTransform

			' Create a Canvas to contain the rectangle
			' and add it to the page.
			Dim mainPanel As New Canvas()
			mainPanel.Width = 400
			mainPanel.Height = 400
			mainPanel.Children.Add(aRectangle)
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

			' Create a DoubleAnimationUsingPath to move the
			' rectangle horizontally along the path by animating 
			' its TranslateTransform.
			Dim translateXAnimation As New DoubleAnimationUsingPath()
			translateXAnimation.PathGeometry = animationPath
			translateXAnimation.Duration = TimeSpan.FromSeconds(5)

			' Set the Source property to X. This makes
			' the animation generate horizontal offset values from
			' the path information. 
			translateXAnimation.Source = PathAnimationSource.X

			' Set the animation to target the X property
			' of the TranslateTransform named "AnimatedTranslateTransform".
			Storyboard.SetTargetName(translateXAnimation, "AnimatedTranslateTransform")
			Storyboard.SetTargetProperty(translateXAnimation, New PropertyPath(TranslateTransform.XProperty))

			' Create a DoubleAnimationUsingPath to move the
			' rectangle vertically along the path by animating 
			' its TranslateTransform.
			Dim translateYAnimation As New DoubleAnimationUsingPath()
			translateYAnimation.PathGeometry = animationPath
			translateYAnimation.Duration = TimeSpan.FromSeconds(5)

			' Set the Source property to Y. This makes
			' the animation generate vertical offset values from
			' the path information. 
			translateYAnimation.Source = PathAnimationSource.Y

			' Set the animation to target the Y property
			' of the TranslateTransform named "AnimatedTranslateTransform".
			Storyboard.SetTargetName(translateYAnimation, "AnimatedTranslateTransform")
			Storyboard.SetTargetProperty(translateYAnimation, New PropertyPath(TranslateTransform.YProperty))

			' Create a Storyboard to contain and apply the animations.
			Dim pathAnimationStoryboard As New Storyboard()
			pathAnimationStoryboard.RepeatBehavior = RepeatBehavior.Forever
			pathAnimationStoryboard.Children.Add(translateXAnimation)
			pathAnimationStoryboard.Children.Add(translateYAnimation)

			' Start the animations when the rectangle is loaded.
			AddHandler aRectangle.Loaded, Sub(sender As Object, e As RoutedEventArgs) pathAnimationStoryboard.Begin(Me)

		End Sub

	End Class

End Namespace
' </SnippetDoubleAnimationUsingPathWholePage>





