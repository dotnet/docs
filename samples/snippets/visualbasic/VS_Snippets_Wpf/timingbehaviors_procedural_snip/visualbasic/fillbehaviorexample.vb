'
'
'FillBehaviorExample.vb
'  This Sample demonstrates how the FillBehavior property influences behavior at the end of an animation.
'
'


Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Media.Imaging

Namespace Microsoft.Samples.Animation.TimingBehaviors
	Public Class FillBehaviorExample
		Inherits Page
		Public Sub New()

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			WindowTitle = "FillBehavior Example"

            Dim myStackPanel As New StackPanel With {
                .Margin = New Thickness(20)
            }

            Dim myBorder As New Border()
			Dim mySolidColorBrush As New SolidColorBrush(Color.FromArgb(153,255,255,255))
			myBorder.Background = mySolidColorBrush

            Dim myTextBlock As New TextBlock With {
                .Text = "This example shows how the FillBehavior property determines how an "
            }
            myTextBlock.Text &= "animation behaves after it reaches the end of its duration."
			myTextBlock.Margin = New Thickness(20)
			myBorder.Child = myTextBlock
			myStackPanel.Children.Add(myBorder)

            myTextBlock = New TextBlock With {
                .Text = "FillBehavior = ""Deactivate"""
            }
            myStackPanel.Children.Add(myTextBlock)


            '
            '  Create the first rectangle to animate.
            '
            Dim deactivateAnimationRectangle As New Rectangle With {
                .Name = "deactivateAnimationRectangle"
            }
            RegisterName(deactivateAnimationRectangle.Name, deactivateAnimationRectangle)
			deactivateAnimationRectangle.Width = 20
			deactivateAnimationRectangle.Height = 20
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(170,51,51,255))
			deactivateAnimationRectangle.Fill = mySolidColorBrush
			deactivateAnimationRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(deactivateAnimationRectangle)

            myTextBlock = New TextBlock With {
                .Text = vbLf & "FillBehavior = ""HoldEnd"""
            }
            myStackPanel.Children.Add(myTextBlock)

            '
            '  Create the second rectangle to animate.
            '
            Dim holdEndAnimationRectangle As New Rectangle With {
                .Name = "holdEndAnimationRectangle"
            }
            RegisterName(holdEndAnimationRectangle.Name, holdEndAnimationRectangle)
			holdEndAnimationRectangle.Width = 20
			holdEndAnimationRectangle.Height = 20
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(170,51,51,255))
			holdEndAnimationRectangle.Fill = mySolidColorBrush
			holdEndAnimationRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(holdEndAnimationRectangle)

			'
			' Create an animation which reverts the  width of the rectangle
			'     back to its non-animated value.
			'
			Dim myStopDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myStopDoubleAnimation, deactivateAnimationRectangle.Name)
			Storyboard.SetTargetProperty(myStopDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myStopDoubleAnimation.From = 100
			myStopDoubleAnimation.To = 400
			myStopDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myStopDoubleAnimation.FillBehavior = FillBehavior.Stop

			'
			'  Create an animation which maintains the width of the rectangle at the completion of the animation.
			'
			Dim myHoldEndDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myHoldEndDoubleAnimation, holdEndAnimationRectangle.Name)
			Storyboard.SetTargetProperty(myHoldEndDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myHoldEndDoubleAnimation.From = 100
			myHoldEndDoubleAnimation.To = 400
			myHoldEndDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myHoldEndDoubleAnimation.FillBehavior = FillBehavior.HoldEnd

			'
			'  Create a Storyboard to contain the animations and add the animations to the Storyboard
			'
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myStopDoubleAnimation)
			myStoryboard.Children.Add(myHoldEndDoubleAnimation)

            '
            '  Create the button to start the animation
            '
            Dim myButton As New Button With {
                .Name = "myButton"
            }
            RegisterName(myButton.Name, myButton)
			myButton.Margin = New Thickness(0,30,0,0)
			myButton.Content = "Restart Animations"
			myButton.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(myButton)

            '
            '  Create an EventTrigger and a BeginStoryboard action to start
            '    the storyboard.
            '
            Dim myBeginStoryboard As New BeginStoryboard With {
                .Storyboard = myStoryboard
            }

            Dim myEventTrigger As New EventTrigger With {
                .RoutedEvent = Button.ClickEvent,
                .SourceName = myButton.Name
            }
            myEventTrigger.Actions.Add(myBeginStoryboard)
			myStackPanel.Triggers.Add(myEventTrigger)

			Content = myStackPanel
		End Sub
	End Class
End Namespace
