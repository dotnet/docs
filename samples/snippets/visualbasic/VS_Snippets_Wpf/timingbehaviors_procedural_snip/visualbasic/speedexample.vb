'
'  SpeedExample.vb
'     This example demonstrates how different speed ratios affect an animation
'
'

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.Animation.TimingBehaviors
	Partial Public Class SpeedExample
		Inherits Page
		Public Sub New()

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			WindowTitle = "Speed Example"

            Dim myStackPanel As New StackPanel With {
                .Margin = New Thickness(20)
            }

            Dim myTextBlock As New TextBlock With {
                .Text = "Speed=""1"""
            }
            myStackPanel.Children.Add(myTextBlock)

            '
            '  Create the rectangles to animate
            '
            Dim defaultSpeedRectangle As New Rectangle With {
                .Name = "defaultSpeedRectangle"
            }
            RegisterName(defaultSpeedRectangle.Name, defaultSpeedRectangle)
			defaultSpeedRectangle.Width = 20
			defaultSpeedRectangle.Height = 20
			Dim mySolidColorBrush As New SolidColorBrush(Color.FromArgb(170,51,51,255))
			defaultSpeedRectangle.Fill = mySolidColorBrush
			defaultSpeedRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(defaultSpeedRectangle)

            myTextBlock = New TextBlock With {
                .Margin = New Thickness(0, 20, 0, 0),
                .Text = "Speed=""2"""
            }
            myStackPanel.Children.Add(myTextBlock)

            Dim fasterRectangle As New Rectangle With {
                .Name = "fasterRectangle"
            }
            RegisterName(fasterRectangle.Name, fasterRectangle)
			fasterRectangle.Width = 20
			fasterRectangle.Height = 20
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(170,51,51,255))
			fasterRectangle.Fill = mySolidColorBrush
			fasterRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(fasterRectangle)

            myTextBlock = New TextBlock With {
                .Margin = New Thickness(0, 20, 0, 0),
                .Text = "Speed=""0.5"""
            }
            myStackPanel.Children.Add(myTextBlock)

            Dim slowerRectangle As New Rectangle With {
                .Name = "slowerRectangle"
            }
            RegisterName(slowerRectangle.Name, slowerRectangle)
			slowerRectangle.Width = 20
			slowerRectangle.Height = 20
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(170,51,51,255))
			slowerRectangle.Fill = mySolidColorBrush
			slowerRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(slowerRectangle)

			'
			'  Creates an animation with the default speed ratio value of 1
			'
			Dim myDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myDoubleAnimation, defaultSpeedRectangle.Name)
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myDoubleAnimation.From = 20
			myDoubleAnimation.To = 400
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myDoubleAnimation.SpeedRatio = 1

			'
			'  Creates an animation with the speed ratio value of 2
			'
			Dim myDoubleSpeedRatioDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myDoubleSpeedRatioDoubleAnimation, fasterRectangle.Name)
			Storyboard.SetTargetProperty(myDoubleSpeedRatioDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myDoubleSpeedRatioDoubleAnimation.From = 20
			myDoubleSpeedRatioDoubleAnimation.To = 400
			myDoubleSpeedRatioDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myDoubleSpeedRatioDoubleAnimation.SpeedRatio = 2

			'
			'  Creates an animation with the speed ratio value of 0.5
			'
			Dim myHalvedSpeedRatioDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myHalvedSpeedRatioDoubleAnimation, slowerRectangle.Name)
			Storyboard.SetTargetProperty(myHalvedSpeedRatioDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myHalvedSpeedRatioDoubleAnimation.From = 20
			myHalvedSpeedRatioDoubleAnimation.To = 400
			myHalvedSpeedRatioDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myHalvedSpeedRatioDoubleAnimation.SpeedRatio = 0.5

			'
			'  Create a Storyboard to contain the animations and add the animations to the Storyboard
			'
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)
			myStoryboard.Children.Add(myDoubleSpeedRatioDoubleAnimation)
			myStoryboard.Children.Add(myHalvedSpeedRatioDoubleAnimation)

            '
            '  Create the button to restart the animations.
            '
            Dim myButton As New Button With {
                .Margin = New Thickness(0, 30, 0, 0),
                .HorizontalAlignment = HorizontalAlignment.Left,
                .Content = "Restart Animations"
            }
            myStackPanel.Children.Add(myButton)

            '
            '  Create an EventTrigger and a BeginStoryboard action to start the storyboard
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
