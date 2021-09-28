' <SnippetControlStoryboardExampleUsingWholePage>
'
'    This example shows how to control
'    a storyboard after it has started.
'
'


Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation


Namespace Microsoft.Samples.Animation.TimingBehaviors
	Partial Public Class ControlStoryboardExample
		Inherits Page

        Private ReadOnly myStoryboard As Storyboard

        Public Sub New()

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			WindowTitle = "Controlling a Storyboard"
			Background = Brushes.White

            Dim myStackPanel As New StackPanel With {
                .Margin = New Thickness(20)
            }

                ' Create a rectangle.
            Dim myRectangle As New Rectangle With {
                .Width = 100,
                .Height = 20,
                .Margin = New Thickness(12, 0, 0, 5),
                .Fill = New SolidColorBrush(Color.FromArgb(170, 51, 51, 255)),
                .HorizontalAlignment = HorizontalAlignment.Left
            }
            myStackPanel.Children.Add(myRectangle)

			' Assign the rectangle a name by 
			' registering it with the page, so that
			' it can be targeted by storyboard
			' animations.
			RegisterName("myRectangle", myRectangle)

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
            Dim buttonPanel As New StackPanel With {
                .Orientation = Orientation.Horizontal
            }
            Dim beginButton As New Button With {
                .Content = "Begin"
            }
            AddHandler beginButton.Click, AddressOf beginButton_Clicked
			buttonPanel.Children.Add(beginButton)
            Dim pauseButton As New Button With {
                .Content = "Pause"
            }
            AddHandler pauseButton.Click, AddressOf pauseButton_Clicked
			buttonPanel.Children.Add(pauseButton)
            Dim resumeButton As New Button With {
                .Content = "Resume"
            }
            AddHandler resumeButton.Click, AddressOf resumeButton_Clicked
			buttonPanel.Children.Add(resumeButton)
            Dim skipToFillButton As New Button With {
                .Content = "Skip to Fill"
            }
            AddHandler skipToFillButton.Click, AddressOf skipToFillButton_Clicked
			buttonPanel.Children.Add(skipToFillButton)
            Dim setSpeedRatioButton As New Button With {
                .Content = "Triple Speed"
            }
            AddHandler setSpeedRatioButton.Click, AddressOf setSpeedRatioButton_Clicked
			buttonPanel.Children.Add(setSpeedRatioButton)
            Dim stopButton As New Button With {
                .Content = "Stop"
            }
            AddHandler stopButton.Click, AddressOf stopButton_Clicked
			buttonPanel.Children.Add(stopButton)
			myStackPanel.Children.Add(buttonPanel)
			Content = myStackPanel
		End Sub

        ' Begins the storyboard.
        Private Sub beginButton_Clicked(sender As Object, args As RoutedEventArgs)
            ' Specifying "true" as the second Begin parameter
            ' makes this storyboard controllable.
            myStoryboard.Begin(Me, True)

        End Sub

        ' Pauses the storyboard.
        Private Sub pauseButton_Clicked(sender As Object, args As RoutedEventArgs)
            myStoryboard.Pause(Me)

        End Sub

        ' Resumes the storyboard.
        Private Sub resumeButton_Clicked(sender As Object, args As RoutedEventArgs)
            myStoryboard.Resume(Me)

        End Sub

        ' Advances the storyboard to its fill period.
        Private Sub skipToFillButton_Clicked(sender As Object, args As RoutedEventArgs)
            myStoryboard.SkipToFill(Me)

        End Sub

        ' Updates the storyboard's speed.
        Private Sub setSpeedRatioButton_Clicked(sender As Object, args As RoutedEventArgs)
            ' Makes the storyboard progress three times as fast as normal.
            myStoryboard.SetSpeedRatio(Me, 3)

        End Sub

        ' Stops the storyboard.
        Private Sub stopButton_Clicked(sender As Object, args As RoutedEventArgs)
            myStoryboard.Stop(Me)

        End Sub



    End Class
End Namespace
' </SnippetControlStoryboardExampleUsingWholePage>
