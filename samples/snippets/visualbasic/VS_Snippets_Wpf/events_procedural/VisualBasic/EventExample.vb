Imports System.Windows.Media.Animation


Namespace Microsoft.Samples.Animation.TimingBehaviors


	Public Class EventExample
		Inherits Page

		Public Sub New()
			createExample()
		End Sub

		Private myRectangle As Rectangle

		Private Sub createExample()

			NameScope.SetNameScope(Me, New NameScope())
			myRectangle = New Rectangle()
			myRectangle.Width = 500
			myRectangle.Height = 500
			myRectangle.Fill = Brushes.Blue
			Me.RegisterName("myRectangle", myRectangle)

			Dim panel As New StackPanel()
			panel.Children.Add(myRectangle)


			Dim badExampleButton As New Button()
			badExampleButton.Content = "Bad Example"
			AddHandler badExampleButton.Click, Sub(sender As Object, e As RoutedEventArgs) initialExample()
			panel.Children.Add(badExampleButton)

			Dim goodExampleButton As New Button()
			goodExampleButton.Content = "Good Example"
			AddHandler goodExampleButton.Click, Sub(sender As Object, e As RoutedEventArgs) betterExample()
			panel.Children.Add(goodExampleButton)



			Me.Content = panel
		End Sub

		Private Sub initialExample()


			Dim myStoryboard As New Storyboard()
			myStoryboard.Begin(myRectangle, True)

			' <SnippetNeedForEventsFragment>
			myStoryboard.Stop(myRectangle)

			' This statement might execute
			' before the storyboard has stopped.
			myRectangle.Fill = Brushes.Blue
			' </SnippetNeedForEventsFragment>



		End Sub

		Private Sub betterExample()

			Dim myStoryboard As New Storyboard()

			' <SnippetRegisterForStoryboardCurrentStateInvalidatedEvent>
			' Register for the CurrentStateInvalidated timing event.
			AddHandler myStoryboard.CurrentStateInvalidated, AddressOf myStoryboard_CurrentStateInvalidated
			' </SnippetRegisterForStoryboardCurrentStateInvalidatedEvent>

		End Sub

		' <SnippetStoryboardCurrentStateInvalidatedEvent2>
		' Change the rectangle's color after the storyboard stops. 
		Private Sub myStoryboard_CurrentStateInvalidated(ByVal sender As Object, ByVal e As EventArgs)
			Dim myStoryboardClock As Clock = CType(sender, Clock)
			If myStoryboardClock.CurrentState = ClockState.Stopped Then
				myRectangle.Fill = Brushes.Blue
			End If
		End Sub
		' </SnippetStoryboardCurrentStateInvalidatedEvent2>


	End Class

End Namespace
