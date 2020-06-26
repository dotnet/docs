'<SnippetTimelineCurrentGlobalSpeedInvalidatedExampleWholePage>
'
'
'   This example shows how to register for the
'   CurrentGlobalSpeedInvalidated event
'   using a Timeline. 
'
'

Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls
Imports System.Windows.Input

Namespace Microsoft.Samples.Animation.TimingBehaviors


	Public Class TimelineCurrentGlobalSpeedInvalidatedExample
		Inherits Page


		Private currentTimeTextBlock As TextBlock
		Public Sub New()

			' Create a name scope.
			NameScope.SetNameScope(Me, New NameScope())

			WindowTitle = "GetAnimationBaseValue Example"
			Dim myPanel As New StackPanel()
			myPanel.Margin = New Thickness(20)

			' Create a rectangle.
            Dim animatedRectangle As New Rectangle()
            With animatedRectangle
                .Width = 100
                .Height = 50
                .Margin = New Thickness(50)
                .Fill = Brushes.Orange
                .Stroke = Brushes.Gray
                .StrokeThickness = 2
            End With

            ' Create a RotateTransform.
            Dim animatedTransform As New RotateTransform()
            animatedTransform.Angle = 0
            Me.RegisterName("animatedTransform", animatedTransform)
            animatedRectangle.RenderTransform = animatedTransform
            animatedRectangle.RenderTransformOrigin = New Point(0.5, 0.5)
            myPanel.Children.Add(animatedRectangle)
            Me.Content = myPanel

            ' Create a TextBlock to show the storyboard's current time.
            currentTimeTextBlock = New TextBlock()
            myPanel.Children.Add(currentTimeTextBlock)

            ' Animate the RotateTransform's angle using a Storyboard.
            Dim angleAnimation As New DoubleAnimation(0, 360, TimeSpan.FromSeconds(5))
            angleAnimation.RepeatBehavior = RepeatBehavior.Forever
            angleAnimation.AutoReverse = True
            Storyboard.SetTargetName(angleAnimation, "animatedTransform")
            Storyboard.SetTargetProperty(angleAnimation, New PropertyPath(RotateTransform.AngleProperty))

            Dim theStoryboard As New Storyboard()
            theStoryboard.Children.Add(angleAnimation)

            ' Register the CurrentGlobalSpeedInvalidated event.
            ' You must register for events before you begin 
            ' the storyboard.
            AddHandler angleAnimation.CurrentGlobalSpeedInvalidated, AddressOf angleAnimation_CurrentGlobalSpeedInvalidated

            ' Start the storyboard.
            theStoryboard.Begin(animatedRectangle, True)

		End Sub

		Private Sub angleAnimation_CurrentGlobalSpeedInvalidated(ByVal sender As Object, ByVal e As EventArgs)

			' Sender is the clock that was created for the DoubleAnimation.
			Dim doubleAnimationClock As Clock = CType(sender, Clock)

			' Update the TextBlock with the time of its parent.
			currentTimeTextBlock.Text = doubleAnimationClock.Parent.CurrentTime.ToString()
		End Sub



	End Class

End Namespace
'</SnippetTimelineCurrentGlobalSpeedInvalidatedExampleWholePage>