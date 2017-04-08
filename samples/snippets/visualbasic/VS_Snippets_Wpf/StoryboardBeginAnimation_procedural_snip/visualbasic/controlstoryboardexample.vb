' <SnippetControlStoryboardExampleUsingWholePage>
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



Namespace Microsoft.Samples.Animation.AnimatingWithStoryboards
	Partial Public Class ControlStoryboardExample
		Inherits Page

		Private myStoryboard As Storyboard

		Public Sub New()

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			Me.WindowTitle = "Controlling a Storyboard"
			Me.Background = Brushes.White

			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20)

			' Create a rectangle.
			Dim myRectangle As New Rectangle()
			myRectangle.Width = 100
			myRectangle.Height = 20
			myRectangle.Margin = New Thickness(12,0,0,5)
			myRectangle.Fill = New SolidColorBrush(Color.FromArgb(170, 51, 51, 255))
			myRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(myRectangle)

			' Assign the rectangle a name by 
			' registering it with the page, so that
			' it can be targeted by storyboard
			' animations.
			Me.RegisterName("myRectangle", myRectangle)

			'
			' Create an animation and a storyboard to animate the
			' rectangle.
			'
			Dim myDoubleAnimation As New DoubleAnimation(100, 500, New Duration(TimeSpan.FromSeconds(5)))
			Storyboard.SetTargetName(myDoubleAnimation, "myRectangle")
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myStoryboard = New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)

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
			Dim removeButton As New Button()
			removeButton.Content = "Remove"
			AddHandler removeButton.Click, AddressOf removeButton_Clicked
			buttonPanel.Children.Add(removeButton)

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

		' Removes the storyboard.
		Private Sub removeButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			 myStoryboard.Remove(Me)

		End Sub



	End Class
End Namespace
' </SnippetControlStoryboardExampleUsingWholePage>
