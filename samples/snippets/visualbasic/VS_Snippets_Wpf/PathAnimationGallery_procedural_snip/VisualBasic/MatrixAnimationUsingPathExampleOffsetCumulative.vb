' <SnippetMatrixAnimationUsingPathOffsetCumulativeWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Windows.Shapes


Namespace SDKSample

	''' <summary>
	''' Shows how to use the MatrixAnimationUsingPath.IsOffsetCumulative
	''' property to make a MatrixAnimatioinUsingPath accumulate
	''' its values when it repeats.
	''' </summary>
	Public Class MatrixAnimationUsingPathExampleOffsetCumulative
		Inherits Page

		Public Sub New()
			Me.Margin = New Thickness(20)

			' Create a NameScope for the page so that
			' we can use Storyboards.
			NameScope.SetNameScope(Me, New NameScope())

			' Create a button.
			Dim aButton As New Button()
			aButton.MinWidth = 100
			aButton.Content = "A Button"

			' Create a MatrixTransform. This transform
			' will be used to move the button.
			Dim buttonMatrixTransform As New MatrixTransform()
			aButton.RenderTransform = buttonMatrixTransform

			' Register the transform's name with the page
			' so that it can be targeted by a Storyboard.
			Me.RegisterName("ButtonMatrixTransform", buttonMatrixTransform)

			' Create a Canvas to contain the button
			' and add it to the page.
			' Although this example uses a Canvas,
			' any type of panel will work.
			Dim mainPanel As New Canvas()
			mainPanel.Width = 400
			mainPanel.Height = 400
			mainPanel.Children.Add(aButton)
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

			' Create a MatrixAnimationUsingPath to move the
			' button along the path by animating
			' its MatrixTransform.
			Dim matrixAnimation As New MatrixAnimationUsingPath()
			matrixAnimation.PathGeometry = animationPath

			' Set IsOffsetCumulative to true so that the animation
			' values accumulate when its repeats. 
			matrixAnimation.IsOffsetCumulative = True
			matrixAnimation.Duration = TimeSpan.FromSeconds(5)
			matrixAnimation.RepeatBehavior = New RepeatBehavior(2)

			' Set the animation to target the Matrix property
			' of the MatrixTransform named "ButtonMatrixTransform".
			Storyboard.SetTargetName(matrixAnimation, "ButtonMatrixTransform")
			Storyboard.SetTargetProperty(matrixAnimation, New PropertyPath(MatrixTransform.MatrixProperty))

			' Create a Storyboard to contain and apply the animation.
			Dim pathAnimationStoryboard As New Storyboard()
			pathAnimationStoryboard.Children.Add(matrixAnimation)

			' Start the animation when the button is clicked.
			AddHandler aButton.Click, Sub(sender As Object, e As RoutedEventArgs) pathAnimationStoryboard.Begin(Me)

		End Sub
	End Class
End Namespace
' </SnippetMatrixAnimationUsingPathOffsetCumulativeWholePage>







