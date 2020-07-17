'
'  RepeatBehaviorExample.vb
'     This example shows how to use the RepeatBehavior property to make a timeline repeat.
'
'


Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.Animation.TimingBehaviors
	Partial Public Class RepeatBehaviorExample
		Inherits Page
		Public Sub New()

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			WindowTitle = "RepeatBehavior Example"

            Dim myBorder As New Border With {
                .HorizontalAlignment = HorizontalAlignment.Stretch
            }
            Content = myBorder

            Dim myStackPanel As New StackPanel With {
                .Margin = New Thickness(20)
            }
            myBorder.Child = myStackPanel

			Dim myBorder1 As New Border()
			Dim mySolidColorBrush As New SolidColorBrush(Color.FromArgb(153,255,255,255))
			myBorder1.Background = mySolidColorBrush
			myStackPanel.Children.Add(myBorder1)

            Dim myTextBlock As New TextBlock With {
                .Margin = New Thickness(20),
                .Text = "This example shows how the RepeatBehavior property "
            }
            myTextBlock.Text &= "is used to make a timeline repeat. Several rectangles are animated by "
			myTextBlock.Text &= "DoubleAnimations with identical durations and target values, but with different "
			myTextBlock.Text &= "RepeatBehavior settings."
			myBorder1.Child = myTextBlock

            myTextBlock = New TextBlock With {
                .Text = vbLf & "RepeatBehavior=""Forever"" "
            }
            myStackPanel.Children.Add(myTextBlock)

            Dim foreverRepeatingRectangle As New Rectangle With {
                .Name = "foreverRepeatingRectangle"
            }
            RegisterName(foreverRepeatingRectangle.Name, foreverRepeatingRectangle)
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(170,51,51,255))
			foreverRepeatingRectangle.Fill = mySolidColorBrush
			foreverRepeatingRectangle.Width = 50
			foreverRepeatingRectangle.Height = 20
			foreverRepeatingRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(foreverRepeatingRectangle)


            myTextBlock = New TextBlock With {
                .Text = vbLf & "RepeatBehavior=""0:0:4"" "
            }
            myStackPanel.Children.Add(myTextBlock)


            Dim fourSecondsRepeatingRectangle As New Rectangle With {
                .Name = "fourSecondsRepeatingRectangle"
            }
            RegisterName(fourSecondsRepeatingRectangle.Name, fourSecondsRepeatingRectangle)
			fourSecondsRepeatingRectangle.Fill= mySolidColorBrush
			fourSecondsRepeatingRectangle.Width = 50
			fourSecondsRepeatingRectangle.Height = 20
			fourSecondsRepeatingRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(fourSecondsRepeatingRectangle)

            myTextBlock = New TextBlock With {
                .Text = vbLf & "RepeatBehavior=""2x"" "
            }
            myStackPanel.Children.Add(myTextBlock)

            Dim twiceRepeatingRectangle As New Rectangle With {
                .Name = "twiceRepeatingRectangle"
            }
            RegisterName(twiceRepeatingRectangle.Name, twiceRepeatingRectangle)
			twiceRepeatingRectangle.Fill = mySolidColorBrush
			twiceRepeatingRectangle.Width = 50
			twiceRepeatingRectangle.Height = 20
			twiceRepeatingRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(twiceRepeatingRectangle)

            myTextBlock = New TextBlock With {
                .Text = vbLf & "RepeatBehavior=""0.05"" "
            }
            myStackPanel.Children.Add(myTextBlock)

            Dim halfRepeatingRectangle As New Rectangle With {
                .Name = "halfRepeatingRectangle"
            }
            RegisterName(halfRepeatingRectangle.Name, halfRepeatingRectangle)

			halfRepeatingRectangle.Fill = mySolidColorBrush
			halfRepeatingRectangle.Width = 50
			halfRepeatingRectangle.Height = 20
			halfRepeatingRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(halfRepeatingRectangle)

            myTextBlock = New TextBlock With {
                .Text = vbLf & "RepeatBehavior=""0:0:1"" "
            }
            myStackPanel.Children.Add(myTextBlock)

            Dim oneSecondRepeatingRectangle As New Rectangle With {
                .Name = "oneSecondRepeatingRectangle"
            }
            RegisterName(oneSecondRepeatingRectangle.Name, oneSecondRepeatingRectangle)
			oneSecondRepeatingRectangle.Fill = mySolidColorBrush
			oneSecondRepeatingRectangle.Width = 50
			oneSecondRepeatingRectangle.Height = 20
			oneSecondRepeatingRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(oneSecondRepeatingRectangle)

			Dim myStackPanel1 As New StackPanel()
			myStackPanel.Children.Add(myStackPanel1)
			myStackPanel1.Orientation = Orientation.Horizontal
			myStackPanel1.Margin = New Thickness(0,20,0,0)

			'
			' Create an animation that repeats indefinitely.
			'
			Dim myForeverRepeatingDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myForeverRepeatingDoubleAnimation,foreverRepeatingRectangle.Name)
			Storyboard.SetTargetProperty(myForeverRepeatingDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myForeverRepeatingDoubleAnimation.From = 50
			myForeverRepeatingDoubleAnimation.To = 300
			myForeverRepeatingDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myForeverRepeatingDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever


			'
			'  Create an animation that repeats for four seconds.
			'      As a result,the animation repeats twice.
			Dim myFourSecondsRepeatingDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myFourSecondsRepeatingDoubleAnimation, fourSecondsRepeatingRectangle.Name)
			Storyboard.SetTargetProperty(myFourSecondsRepeatingDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myFourSecondsRepeatingDoubleAnimation.From = 50
			myFourSecondsRepeatingDoubleAnimation.To = 300
			myFourSecondsRepeatingDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myFourSecondsRepeatingDoubleAnimation.RepeatBehavior= New RepeatBehavior(TimeSpan.FromMilliseconds(4000))

			'
			' Create an animation that repeats twice.
			'
			Dim myTwiceRepeatingDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myTwiceRepeatingDoubleAnimation, twiceRepeatingRectangle.Name)
			Storyboard.SetTargetProperty(myTwiceRepeatingDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myTwiceRepeatingDoubleAnimation.From = 50
			myTwiceRepeatingDoubleAnimation.To = 300
			myTwiceRepeatingDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myTwiceRepeatingDoubleAnimation.RepeatBehavior = New RepeatBehavior(2)


			'
			' Create an animation that repeats 0.5 times. The resulting animation plays for one second,
			'   half of its Duration. It animates from 50 to 150.
			Dim myHalfRepeatingDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myHalfRepeatingDoubleAnimation, halfRepeatingRectangle.Name)
			Storyboard.SetTargetProperty(myHalfRepeatingDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myHalfRepeatingDoubleAnimation.From = 50
			myHalfRepeatingDoubleAnimation.To = 300
			myHalfRepeatingDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myHalfRepeatingDoubleAnimation.RepeatBehavior = New RepeatBehavior(0.5)

			'
			'  Create an animation that repeats for one second. The resulting animation
			'       plays for one second, half of its Duration. It animates from 50 to 150.
			Dim myOneSecondDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myOneSecondDoubleAnimation,oneSecondRepeatingRectangle.Name)
			Storyboard.SetTargetProperty(myOneSecondDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myOneSecondDoubleAnimation.From = 50
			myOneSecondDoubleAnimation.To = 300
			myOneSecondDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myOneSecondDoubleAnimation.RepeatBehavior = New RepeatBehavior(TimeSpan.FromMilliseconds(1000))

			'
			'  Create a Storyboard to contain the animations and add the animations to the Storyboard
			'
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myForeverRepeatingDoubleAnimation)
			myStoryboard.Children.Add(myFourSecondsRepeatingDoubleAnimation)
			myStoryboard.Children.Add(myTwiceRepeatingDoubleAnimation)
			myStoryboard.Children.Add(myHalfRepeatingDoubleAnimation)
			myStoryboard.Children.Add(myOneSecondDoubleAnimation)

            '
            '  Create buttons to restart and stop the animations.
            '
            Dim myRestartButton As New Button With {
                .Name = "restartButton"
            }
            RegisterName(myRestartButton.Name, myRestartButton)
			myRestartButton.Content = "Start Animations"
			myStackPanel1.Children.Add(myRestartButton)

            Dim myStopButton As New Button With {
                .Name = "stopButton"
            }
            RegisterName(myStopButton.Name, myStopButton)
			myStopButton.Content = "Stop"
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(102,153,0,255))
			myStopButton.Background = mySolidColorBrush
			myStackPanel1.Children.Add(myStopButton)

            '
            '  Create EventTriggers and the BeginStoryboard and StopStoryboard actions to start
            '    and stop the storyboard.
            Dim myBeginStoryboard As New BeginStoryboard With {
                .Name = "myBeginStoryboard"
            }
            RegisterName(myBeginStoryboard.Name,myBeginStoryboard)
			myBeginStoryboard.Storyboard = myStoryboard

            Dim myEventTrigger As New EventTrigger With {
                .RoutedEvent = Button.ClickEvent,
                .SourceName = myRestartButton.Name
            }
            myEventTrigger.Actions.Add(myBeginStoryboard)
			myStackPanel.Triggers.Add(myEventTrigger)

            Dim myEventTrigger1 As New EventTrigger With {
                .RoutedEvent = Button.ClickEvent,
                .SourceName = myStopButton.Name
            }

            Dim myStopStoryboard As New StopStoryboard With {
                .BeginStoryboardName = myBeginStoryboard.Name
            }
            myEventTrigger1.Actions.Add(myStopStoryboard)
			myStackPanel.Triggers.Add(myEventTrigger1)


		End Sub
	End Class
End Namespace
