' <SnippetFrameworkContentElementControlStoryboardExampleUsingWholePage>
'
'    This example shows how to control
'    a storyboard after it has started.
'
'


Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Documents


Namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
	Public Class FrameworkContentElementControlStoryboardExample
		Inherits FlowDocument

		Private myStoryboard As Storyboard

		Public Sub New()

			' Create a name scope for the document.
			NameScope.SetNameScope(Me, New NameScope())
			Me.Background = Brushes.White

			' Create a run of text.
			Dim theText As New Run("Lorem ipsum dolor sit amet, consectetuer adipiscing elit." & "Ut non lacus. Nullam a ligula id leo adipiscing ornare." & " Duis mattis. ")

			' Create a TextEffect
			Dim animatedSpecialEffect As New TextEffect()
			animatedSpecialEffect.Foreground = Brushes.OrangeRed
			animatedSpecialEffect.PositionStart = 0
			animatedSpecialEffect.PositionCount = 0

			' Assign the TextEffect a name by 
			' registering it with the page, so that
			' it can be targeted by storyboard
			' animations            
			Me.RegisterName("animatedSpecialEffect", animatedSpecialEffect)

			' Apply the text effect to the run.
			theText.TextEffects = New TextEffectCollection()
			theText.TextEffects.Add(animatedSpecialEffect)

			' Create a paragraph to contain the run.
			Dim animatedParagraph As New Paragraph(theText)
			animatedParagraph.Background = Brushes.LightGray
			animatedParagraph.Padding = New Thickness(20)

			Me.Blocks.Add(animatedParagraph)
			Dim controlsContainer As New BlockUIContainer()

			'
			' Create an animation and a storyboard to animate the
			' text effect.
			'
			Dim countAnimation As New Int32Animation(0, 127, TimeSpan.FromSeconds(10))
			Storyboard.SetTargetName(countAnimation, "animatedSpecialEffect")
			Storyboard.SetTargetProperty(countAnimation, New PropertyPath(TextEffect.PositionCountProperty))
			myStoryboard = New Storyboard()
			myStoryboard.Children.Add(countAnimation)

			'
			' Create some buttons to control the storyboard
			' and a panel to contain them.
			'
			Dim buttonPanel As New StackPanel()
			buttonPanel.Orientation = Orientation.Vertical
			Dim beginButton As New Button()
			beginButton.Content = "Begin"
			AddHandler beginButton.Click, AddressOf beginButton_Clicked
			buttonPanel.Children.Add(beginButton)
			Dim pauseButton As New Button()
			pauseButton.Content = "Pause"
			AddHandler pauseButton.Click, AddressOf pauseButton_Clicked
			buttonPanel.Children.Add(pauseButton)
			Dim resumeButton As New Button()
			resumeButton.Content = "Resume"
			AddHandler resumeButton.Click, AddressOf resumeButton_Clicked
			buttonPanel.Children.Add(resumeButton)
			Dim skipToFillButton As New Button()
			skipToFillButton.Content = "Skip to Fill"
			AddHandler skipToFillButton.Click, AddressOf skipToFillButton_Clicked
			buttonPanel.Children.Add(skipToFillButton)
			Dim setSpeedRatioButton As New Button()
			setSpeedRatioButton.Content = "Triple Speed"
			AddHandler setSpeedRatioButton.Click, AddressOf setSpeedRatioButton_Clicked
			buttonPanel.Children.Add(setSpeedRatioButton)
			Dim stopButton As New Button()
			stopButton.Content = "Stop"
			AddHandler stopButton.Click, AddressOf stopButton_Clicked
			buttonPanel.Children.Add(stopButton)
			Dim removeButton As New Button()
			removeButton.Content = "Remove"
			AddHandler removeButton.Click, AddressOf removeButton_Clicked
			buttonPanel.Children.Add(removeButton)

			controlsContainer.Child = buttonPanel
			Me.Blocks.Add(controlsContainer)

		End Sub

		' Begins the storyboard.
		Private Sub beginButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			' Specifying "true" as the second Begin parameter
			' makes this storyboard controllable.
			myStoryboard.Begin(Me, True)

		End Sub

		' Pauses the storyboard.
		Private Sub pauseButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			 myStoryboard.Pause(Me)

		End Sub

		' Resumes the storyboard.
		Private Sub resumeButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			 myStoryboard.Resume(Me)

		End Sub

		' Advances the storyboard to its fill period.
		Private Sub skipToFillButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			 myStoryboard.SkipToFill(Me)

		End Sub

		' Updates the storyboard's speed.
		Private Sub setSpeedRatioButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			' Makes the storyboard progress three times as fast as normal.
			myStoryboard.SetSpeedRatio(Me, 3)

		End Sub

		' Stops the storyboard.
		Private Sub stopButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			 myStoryboard.Stop(Me)

		End Sub

		' Removes the storyboard.
		Private Sub removeButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			 myStoryboard.Remove(Me)

		End Sub

	End Class
End Namespace
' </SnippetFrameworkContentElementControlStoryboardExampleUsingWholePage>
