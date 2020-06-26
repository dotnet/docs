' <SnippetGraphicsMMClockControllerExample>
'
'  This example shows how to interactively control 
'  a root clock.
'

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.Animation.TimingBehaviors
	Public Class ClockControllerExample
		Inherits Page

        Private ReadOnly myControllableClock As AnimationClock
        Private ReadOnly seekButton As Button
        Private ReadOnly seekAmountTextBox As TextBox
        Private ReadOnly timeSeekOriginListBox As ListBox

        Public Sub New()
			Dim mainPanel As New StackPanel()

            ' Create a rectangle to animate.
            Dim animatedRectangle As New Rectangle With {
                .Width = 100,
                .Height = 100,
                .Fill = Brushes.Orange
            }
            mainPanel.Children.Add(animatedRectangle)

			' Create a DoubleAnimation to
			' animate its width.
			Dim widthAnimation As New DoubleAnimation(100, 500, New Duration(TimeSpan.FromSeconds(5)))

			' Create a clock from the animation.
			myControllableClock = widthAnimation.CreateClock()

			' Apply the clock to the rectangle's Width property.
			animatedRectangle.ApplyAnimationClock(Rectangle.WidthProperty, myControllableClock)
			myControllableClock.Controller.Stop()

            '
            ' Create some buttons to control the clock.
            '

            ' Create a button to begin the clock.
            Dim beginButton As New Button With {
                .Content = "Begin"
            }
            AddHandler beginButton.Click, AddressOf beginButton_Clicked
			mainPanel.Children.Add(beginButton)

            ' Create a button to pause the clock. 
            Dim pauseButton As New Button With {
                .Content = "Pause"
            }
            AddHandler pauseButton.Click, AddressOf pauseButton_Clicked
			mainPanel.Children.Add(pauseButton)

            ' Create a button to resume the clock. 
            Dim resumeButton As New Button With {
                .Content = "Resume"
            }
            AddHandler resumeButton.Click, AddressOf resumeButton_Clicked
			mainPanel.Children.Add(resumeButton)

            ' Create a button to advance the clock to
            ' its fill period. 
            Dim skipToFillButton As New Button With {
                .Content = "Skip to Fill"
            }
            AddHandler skipToFillButton.Click, AddressOf skipToFillButton_Clicked
			mainPanel.Children.Add(skipToFillButton)

            ' Create a button to stop the clock.
            Dim stopButton As New Button With {
                .Content = "Stop"
            }
            AddHandler stopButton.Click, AddressOf stopButton_Clicked
			mainPanel.Children.Add(stopButton)

            '
            ' Create some controls the enable the user to
            ' seek the clock. 
            '

            Dim seekDetailsPanel As New StackPanel With {
                .Margin = New Thickness(0, 20, 0, 20),
                .Orientation = Orientation.Horizontal
            }
            Dim seekAmountLabel As New Label With {
                .Content = "Seek amount:"
            }
            seekDetailsPanel.Children.Add(seekAmountLabel)

            ' Create a text box so that the user can
            ' specify the amount by which to seek.
            seekAmountTextBox = New TextBox With {
                .Text = "0:0:1",
                .VerticalAlignment = VerticalAlignment.Top
            }
            AddHandler seekAmountTextBox.TextChanged, AddressOf seekAmountTextBox_TextChanged
			seekDetailsPanel.Children.Add(seekAmountTextBox)

            Dim timeSeekOriginLabel As New Label With {
                .Content = "Seek Origin:"
            }
            seekDetailsPanel.Children.Add(timeSeekOriginLabel)

			' Create a ListBox so the user can
			' select whether the seek time is relative
			' to the clock's BeginTime or Duration.
			timeSeekOriginListBox = New ListBox()
			timeSeekOriginListBox.Items.Add("BeginTime")
			timeSeekOriginListBox.Items.Add("Duration")
			timeSeekOriginListBox.Padding = New Thickness(5)
			timeSeekOriginListBox.SelectedIndex = 0
			seekDetailsPanel.Children.Add(timeSeekOriginListBox)

            ' Create a button to seek the clock.
            seekButton = New Button With {
                .Content = "Seek"
            }
            AddHandler seekButton.Click, AddressOf seekButton_Clicked
			seekDetailsPanel.Children.Add(seekButton)
			mainPanel.Children.Add(seekDetailsPanel)

			Content = mainPanel
		End Sub

        ' Starts the clock.
        Private Sub beginButton_Clicked(sender As Object, e As RoutedEventArgs)
            myControllableClock.Controller.Begin()
        End Sub

        ' Pauses the clock.
        Private Sub pauseButton_Clicked(sender As Object, e As RoutedEventArgs)
            myControllableClock.Controller.Pause()
        End Sub

        ' Resumes the clock.
        Private Sub resumeButton_Clicked(sender As Object, e As RoutedEventArgs)
            myControllableClock.Controller.Resume()
        End Sub

        ' Adances the clock to its fill period.
        Private Sub skipToFillButton_Clicked(sender As Object, e As RoutedEventArgs)
            myControllableClock.Controller.SkipToFill()
        End Sub

        ' Stops the clock.
        Private Sub stopButton_Clicked(sender As Object, e As RoutedEventArgs)
            myControllableClock.Controller.Stop()
        End Sub

        ' Seeks the clock.
        Private Sub seekButton_Clicked(sender As Object, e As RoutedEventArgs)


            Try

                ' Obtain the seek amount from the seekAmountTextBox TextBox.
                Dim seekAmount As TimeSpan = TimeSpan.Parse(seekAmountTextBox.Text)

                ' Determine the seek origin by reading the selected value
                ' from the timeSeekOriginListBox ListBox.
                Dim selectedOrigin As TimeSeekOrigin = CType(System.Enum.Parse(GetType(TimeSeekOrigin), CStr(timeSeekOriginListBox.SelectedItem)), TimeSeekOrigin)

                ' Seek to the specified location.
                myControllableClock.Controller.Seek(seekAmount, selectedOrigin)

            Catch formatEx As FormatException
                MessageBox.Show(seekAmountTextBox.Text & " is not a valid TimeSpan. Please enter another value.")

                ' Disable the seek button until the user enters another value.
                seekButton.IsEnabled = False
            End Try
        End Sub

        ' Verifies that seekAmountTextBox has text content.
        ' If there is no text, disable the seek button.
        Private Sub seekAmountTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
            Dim theTextBox As TextBox = CType(e.Source, TextBox)
            If theTextBox.Text Is Nothing OrElse theTextBox.Text.Length < 1 Then
                seekButton.IsEnabled = False
            Else
                seekButton.IsEnabled = True
            End If


        End Sub

    End Class
End Namespace
' </SnippetGraphicsMMClockControllerExample>
