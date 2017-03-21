' <SnippetClockControllerSeekExample>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Data
Imports System.Xml
Imports System.Configuration



Namespace SDKSample
	''' <summary>
	''' Shows how to interactively control a clock.
	''' </summary>

  Public Class SeekAlignedToLastTickExample
	  Inherits Page

		Private myClock As AnimationClock
		Private currentTimeIndicator As TextBlock
		Private seekDestination As TextBox
		Private rectangleWidthIndicator As TextBlock
		Private myRectangle As Rectangle

		Public Sub New()



			Me.WindowTitle = "Controlling a Storyboard"
			Me.Background = Brushes.White

			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20)

			' Create a rectangle.
            myRectangle = New Rectangle()
            With myRectangle
                .Width = 100
                .Height = 20
                .Margin = New Thickness(12, 0, 0, 5)
                .Fill = New SolidColorBrush(Color.FromArgb(170, 51, 51, 255))
                .HorizontalAlignment = HorizontalAlignment.Left
            End With
            myStackPanel.Children.Add(myRectangle)

            '
            ' Create an animation and a storyboard to animate the
            ' rectangle.
            '
            Dim myDoubleAnimation As New DoubleAnimation(100, 500, New Duration(TimeSpan.FromSeconds(60)))
            myClock = myDoubleAnimation.CreateClock()
            myRectangle.ApplyAnimationClock(Rectangle.WidthProperty, myClock)
            myClock.Controller.Stop()


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

            ' Create some controls to display the
            ' storyboard's current time and the
            ' current width of the rectangle.
            Dim seekPanel As New StackPanel()
            seekPanel.Margin = New Thickness(10)
            Dim aPanel As New StackPanel()
            Dim aLabel As New Label()
            aPanel.Orientation = Orientation.Horizontal
            aLabel.Content = "Current Time: "
            aPanel.Children.Add(aLabel)
            currentTimeIndicator = New TextBlock()
            aPanel.Children.Add(currentTimeIndicator)
            seekPanel.Children.Add(aPanel)

            aPanel = New StackPanel()
            aPanel.Orientation = Orientation.Horizontal
            aLabel = New Label()
            aLabel.Content = "Rectangle Width: "
            aPanel.Children.Add(aLabel)
            rectangleWidthIndicator = New TextBlock()
            rectangleWidthIndicator.Text = myRectangle.Width.ToString()
            aPanel.Children.Add(rectangleWidthIndicator)
            seekPanel.Children.Add(aPanel)


            ' Create some controls to enable the
            ' user to specify a seek position.

            aPanel = New StackPanel()
            aPanel.Orientation = Orientation.Horizontal
            aLabel = New Label()
            aLabel.Content = "Seek Offset: "
            aPanel.Children.Add(aLabel)
            seekDestination = New TextBox()
            seekDestination.Text = "0"
            aPanel.Children.Add(seekDestination)
            seekPanel.Children.Add(aPanel)


            Dim seekButton As New Button()
            seekButton.Content = "Seek"
            AddHandler seekButton.Click, AddressOf seekButton_Clicked
            seekPanel.Children.Add(seekButton)
            Dim seekAlignedToLastTickButton As New Button()
            seekAlignedToLastTickButton.Content = "Seek Aligned to Last Tick"
            AddHandler seekAlignedToLastTickButton.Click, AddressOf seekAlignedToLastTickButton_Clicked
            seekPanel.Children.Add(seekAlignedToLastTickButton)

            myStackPanel.Children.Add(seekPanel)

            Me.Content = myStackPanel

            AddHandler myClock.CurrentTimeInvalidated, AddressOf myClock_CurrentTimeInvalidated
		End Sub

		' Begins the clock.
		Private Sub beginButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)

			myClock.Controller.Begin()
		End Sub

		' Pauses the clock.
		Private Sub pauseButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			myClock.Controller.Pause()

		End Sub

		' Resumes the clock.
		Private Sub resumeButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			myClock.Controller.Resume()

		End Sub

		' Advances the clock to its fill period.
		Private Sub skipToFillButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			myClock.Controller.SkipToFill()

		End Sub

		' Updates the clock's speed.
		Private Sub setSpeedRatioButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			' Makes the clock progress three times as fast as normal.
			myClock.Controller.SpeedRatio = 3

		End Sub

		' Stops the clock.
		Private Sub stopButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			myClock.Controller.Stop()

		End Sub

		' Removes the clock.
		Private Sub removeButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			myClock.Controller.Remove()

		End Sub

		Private Sub seekButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)
			Try

				' The rectangle width will probably not be at its new
				' value when this call is made, because the 
				' clock probably hasn't ticked yet.
				Dim seekTime As TimeSpan = TimeSpan.Parse(seekDestination.Text)
				myClock.Controller.Seek(seekTime, TimeSeekOrigin.BeginTime)
				rectangleWidthIndicator.Text = myRectangle.Width.ToString()

			Catch ex As FormatException
				MessageBox.Show("Invalid TimeSpan value.")
				seekDestination.Focus()
			End Try
		End Sub

		Private Sub seekAlignedToLastTickButton_Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)

			Try

				' The rectangle width will be at its new
				' value when this call is made, because SeekAlignedToLastTick 
				' operation immediately updates timeline and animation
				' values.        
				Dim seekTime As TimeSpan = TimeSpan.Parse(seekDestination.Text)
				myClock.Controller.SeekAlignedToLastTick(seekTime, TimeSeekOrigin.BeginTime)
				rectangleWidthIndicator.Text = myRectangle.Width.ToString()

			Catch ex As FormatException
				MessageBox.Show("Invalid TimeSpan value.")
				seekDestination.Focus()
			End Try
		End Sub

		Private Sub myClock_CurrentTimeInvalidated(ByVal sender As Object, ByVal e As EventArgs)

			currentTimeIndicator.Text = myClock.CurrentTime.ToString()

		End Sub



  End Class
End Namespace
' </SnippetClockControllerSeekExample>