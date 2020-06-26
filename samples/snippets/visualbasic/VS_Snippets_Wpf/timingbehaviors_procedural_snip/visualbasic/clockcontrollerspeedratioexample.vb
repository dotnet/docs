' <SnippetGraphicsMMClockControllerSpeedRatioExample>
'
'  This example shows how to interactively control 
'  the speed of a clock
'

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.Animation.TimingBehaviors
	Public Class ClockControllerSpeedRatioExample
		Inherits Page

        Private ReadOnly myControllableClock As AnimationClock
        Private ReadOnly speedRatioButton As Button
        Private ReadOnly speedRatioSettingTextBox As TextBox
        Private doubleParseResult As Double = 1
        Private ReadOnly currentGlobalSpeedTextBlock As TextBlock

        Public Sub New()
			Dim mainPanel As New StackPanel()

            ' Create a rectangle to animate.
            Dim animatedRectangle As New Rectangle With {
                .Width = 100,
                .Height = 100,
                .Fill = Brushes.Orange
            }
            mainPanel.Children.Add(animatedRectangle)
            '<SnippetUIElementApplyAnimationClock>            
            ' Create a DoubleAnimation to
            ' animate its width.
            'widthAnimation.RepeatBehavior = RepeatBehavior.Forever
            Dim widthAnimation As New DoubleAnimation(100, 500, New Duration(TimeSpan.FromSeconds(5))) With {
                .AutoReverse = True,
                .SpeedRatio = 0.5
            }

                ' Create a clock from the animation.
            myControllableClock = widthAnimation.CreateClock()

			' Apply the clock to the rectangle's Width property.
			animatedRectangle.ApplyAnimationClock(Rectangle.WidthProperty, myControllableClock)

            '</SnippetUIElementApplyAnimationClock>  
            '
            ' Create some controls the enable the user to
            ' interactively control the SpeedRatio of the clock. 
            '            
            Dim speedRatioDetailsPanel As New StackPanel With {
                .Margin = New Thickness(0, 20, 0, 20),
                .Orientation = Orientation.Horizontal
            }
            Dim speedRatioLabel As New Label With {
                .Content = "Speed Ratio:"
            }
            speedRatioDetailsPanel.Children.Add(speedRatioLabel)

            ' Create a text box so that the user can
            ' specify the amount by which to seek.
            speedRatioSettingTextBox = New TextBox With {
                .Text = myControllableClock.Controller.SpeedRatio.ToString(),
                .VerticalAlignment = VerticalAlignment.Top
            }
            AddHandler speedRatioSettingTextBox.TextChanged, AddressOf seekAmountTextBox_TextChanged
			speedRatioDetailsPanel.Children.Add(speedRatioSettingTextBox)

            ' Create a button to apply SpeedRatio changes.
            speedRatioButton = New Button With {
                .Content = "Apply Speed Ratio"
            }
            AddHandler speedRatioButton.Click, AddressOf speedRatioButton_Clicked
			speedRatioDetailsPanel.Children.Add(speedRatioButton)

			mainPanel.Children.Add(speedRatioDetailsPanel)

            ' Display the clock's global speed information.
            Dim myLabel As New Label With {
                .Content = "CurrentGlobalSpeed "
            }
            mainPanel.Children.Add(myLabel)
            currentGlobalSpeedTextBlock = New TextBlock With {
                .Text = myControllableClock.CurrentGlobalSpeed.ToString()
            }
            mainPanel.Children.Add(currentGlobalSpeedTextBlock)

			' List for speed changes.
			AddHandler myControllableClock.CurrentGlobalSpeedInvalidated, AddressOf myControllableClock_currentGlobalSpeedInvalidated

			Content = mainPanel
		End Sub


        ' Updates the clock's SpeedRatio.
        Private Sub speedRatioButton_Clicked(sender As Object, e As RoutedEventArgs)

            ' This statement triggers a CurrentGlobalSpeedInvalidated
            ' event.
            myControllableClock.Controller.SpeedRatio = doubleParseResult

        End Sub

        ' Displays the current global speed.
        Private Sub myControllableClock_currentGlobalSpeedInvalidated(sender As Object, e As EventArgs)

            currentGlobalSpeedTextBlock.Text = myControllableClock.CurrentGlobalSpeed.ToString() & " Event triggered at: " & Date.Now.ToString()

        End Sub

        ' Verifies that speedRatioSettingTextBox has valid text content.
        ' If it doesn't, the speedRatioButton is disabled.
        Private Sub seekAmountTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)

            Dim theTextBox As TextBox = CType(e.Source, TextBox)
            If theTextBox.Text Is Nothing OrElse theTextBox.Text.Length < 1 OrElse Double.TryParse(theTextBox.Text, System.Globalization.NumberStyles.Any, Nothing, doubleParseResult) = False Then
                speedRatioButton.IsEnabled = False
            Else
                speedRatioButton.IsEnabled = True
            End If

        End Sub

    End Class
End Namespace
' </SnippetGraphicsMMClockControllerSpeedRatioExample>
