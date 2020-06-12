' <SnippetControllableStoryboardExampleWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace SDKSample

	Public Class ControllableStoryboardExample
		Inherits Page
		Private myStoryboard As Storyboard

		Public Sub New()

			' Create a name scope for the page.

			NameScope.SetNameScope(Me, New NameScope())

			Me.WindowTitle = "Controllable Storyboard Example"
			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(10)

			' Create a rectangle.
			Dim myRectangle As New Rectangle()
			myRectangle.Name = "myRectangle"

			' Assign the rectangle a name by 
			' registering it with the page, so that
			' it can be targeted by storyboard
			' animations.
			Me.RegisterName(myRectangle.Name, myRectangle)
			myRectangle.Width = 100
			myRectangle.Height = 100
			myRectangle.Fill = Brushes.Blue
			myStackPanel.Children.Add(myRectangle)

			'
			' Create an animation and a storyboard to animate the
			' rectangle.
			'
			Dim myDoubleAnimation As New DoubleAnimation()
			myDoubleAnimation.From = 1.0
			myDoubleAnimation.To = 0.0
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(5000))
			myDoubleAnimation.AutoReverse = True

			' Create the storyboard.
			myStoryboard = New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)
			Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name)
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.OpacityProperty))

			'
			' Create some buttons to control the storyboard
			' and a panel to contain them.
			'
			Dim buttonPanel As New StackPanel()
			buttonPanel.Orientation = Orientation.Horizontal
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
			myStackPanel.Children.Add(buttonPanel)
			Me.Content = myStackPanel


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

	End Class

End Namespace
' </SnippetControllableStoryboardExampleWholePage>