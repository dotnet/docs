' <SnippetBooleanAnimationUsingKeyFramesWholePage>
' Demonstrates a BooleanAnimationUsingKeyFrames. The animation is used to
' animate the IsEnabled property of a button.

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Namespace Microsoft.Samples.KeyFrameExamples
	Public Class BooleanAnimationUsingKeyFramesExample
		Inherits Page
		Public Sub New()
			Title = "BooleanAnimationUsingKeyFrames Example"
			Background = Brushes.White
			Margin = New Thickness(20)

			' Create a NameScope for this page so that
			' Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

			Dim myStackPanel As New StackPanel()
			myStackPanel.Orientation = Orientation.Vertical
			myStackPanel.Margin = New Thickness(20)

			' Create a TextBlock to introduce the example.
			Dim myTextBlock As New TextBlock()
			myTextBlock.Text = "Click the button to animate its IsEnabled property" & " with aBooleanAnimationUsingKeyFrames animation."
			myStackPanel.Children.Add(myTextBlock)

			' Create the Button that is the target of the animation.
			Dim myButton As New Button()
			myButton.Margin = New Thickness(200)
			myButton.Content = "Click Me"

			myStackPanel.Children.Add(myButton)


			' Assign the Button a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("AnimatedButton", myButton)

			' Create a BooleanAnimationUsingKeyFrames to
			' animate the IsEnabled property of the Button.
			Dim booleanAnimation As New BooleanAnimationUsingKeyFrames()
			booleanAnimation.Duration = TimeSpan.FromSeconds(4)


			' All the key frames defined below are DiscreteBooleanKeyFrames. 
			' Discrete key frames create sudden "jumps" between values 
			' (no interpolation). Only discrete key frames can be used 
			' for Boolean key frame animations.

			' Value at the beginning is false
			booleanAnimation.KeyFrames.Add(New DiscreteBooleanKeyFrame(False, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.0)))) ' KeyTime -  Target value (KeyValue)

			' Value becomes true after the first second.
			booleanAnimation.KeyFrames.Add(New DiscreteBooleanKeyFrame(True, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.0)))) ' KeyTime -  Target value (KeyValue)

			' Value becomes false after the 2nd second.
			booleanAnimation.KeyFrames.Add(New DiscreteBooleanKeyFrame(False, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2.0)))) ' KeyTime -  Target value (KeyValue)

			' Value becomes true after the third second.
			booleanAnimation.KeyFrames.Add(New DiscreteBooleanKeyFrame(True, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3.0)))) ' KeyTime -  Target value (KeyValue)

			' Value becomes false after 3 and half seconds.
			booleanAnimation.KeyFrames.Add(New DiscreteBooleanKeyFrame(False, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3.5)))) ' KeyTime -  Target value (KeyValue)

			' Value becomes true after the fourth second.
			booleanAnimation.KeyFrames.Add(New DiscreteBooleanKeyFrame(True, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4.0)))) ' KeyTime -  Target value (KeyValue)

			' Set the animation to target the IsEnabled property
			' of the object named "AnimatedButton".
			Storyboard.SetTargetName(booleanAnimation, "AnimatedButton")
			Storyboard.SetTargetProperty(booleanAnimation, New PropertyPath(Button.IsEnabledProperty))

			' Create a storyboard to apply the animation.
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(booleanAnimation)

			' Start the storyboard when the button is clicked.
			AddHandler myButton.Click, Sub(sender As Object, e As RoutedEventArgs) myStoryboard.Begin(Me)

			Content = myStackPanel
		End Sub

	End Class
End Namespace
' </SnippetBooleanAnimationUsingKeyFramesWholePage>





