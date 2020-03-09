'
'
'This example shows how the BeginTime property determines when a timeline starts.
'Several rectangles re-animated by DoubleAnimations with identical durations and target values, but with different
'  BeginTime settings.
'
'


Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.Animation.TimingBehaviors
	Partial Public Class BeginTimeExample
		Inherits Page
		Public Sub New()

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			WindowTitle = "BeginTime Example"

            Dim myStackPanel As New StackPanel With {
                .Margin = New Thickness(20)
            }

            Dim myBorder As New Border()
			Dim myColor As New Color()
            Dim mySolidColorBrush As New SolidColorBrush(Color.FromArgb(153, 255, 255, 255)) With {
                .Color = myColor
            }
            myBorder.Background = mySolidColorBrush

            Dim myTextBlock As New TextBlock With {
                .Margin = New Thickness(20),
                .Text = "This example shows how the BeginTime property determines when a timeline starts."
            }
            myTextBlock.Text &= " Several rectangles are animated by DoubleAnimations with identical durations and"
			myTextBlock.Text &= " target values, but with different BeginTime settings."
			myBorder.Child = myTextBlock
			myStackPanel.Children.Add(myBorder)

            myTextBlock = New TextBlock With {
                .Text = "Animation BeginTime: ""0:0:0"" "
            }
            myStackPanel.Children.Add(myTextBlock)

            Dim defaultBeginTimeRectangle As New Rectangle With {
                .Name = "defaultBeginTimeRectangle"
            }
            RegisterName(defaultBeginTimeRectangle.Name, defaultBeginTimeRectangle)
			defaultBeginTimeRectangle.Width = 20
			defaultBeginTimeRectangle.Height = 20
			myColor = New Color()
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(170,51,51,255))
			defaultBeginTimeRectangle.Fill = mySolidColorBrush
			defaultBeginTimeRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(defaultBeginTimeRectangle)

            myTextBlock = New TextBlock With {
                .Margin = New Thickness(0, 20, 0, 0),
                .Text = "Animation BeginTime: ""0:0:5"" " & vbLf
            }
            myStackPanel.Children.Add(myTextBlock)

            Dim delayedBeginTimeRectangle As New Rectangle With {
                .Name = "delayedBeginTimeRectangle"
            }
            RegisterName(delayedBeginTimeRectangle.Name, delayedBeginTimeRectangle)
			delayedBeginTimeRectangle.Width = 20
			delayedBeginTimeRectangle.Height = 20
			myColor = New Color()
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(170,51,51,255))
			delayedBeginTimeRectangle.Fill = mySolidColorBrush
			delayedBeginTimeRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(delayedBeginTimeRectangle)


            myTextBlock = New TextBlock With {
                .Text = vbLf & "Parent Timeline BeginTime: ""0:0:5"" " & vbLf & "Animation BeginTime: ""0:0:5"" "
            }
            myStackPanel.Children.Add(myTextBlock)

            Dim delayedAnimationWithDelayedParentRectangle As New Rectangle With {
                .Name = "delayedAnimationWithDelayedParentRectangle"
            }
            RegisterName(delayedAnimationWithDelayedParentRectangle.Name, delayedAnimationWithDelayedParentRectangle)
			delayedAnimationWithDelayedParentRectangle.Width = 20
			delayedAnimationWithDelayedParentRectangle.Height = 20
			myColor = New Color()
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(170,51,51,255))
			delayedAnimationWithDelayedParentRectangle.Fill = mySolidColorBrush
			delayedAnimationWithDelayedParentRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(delayedAnimationWithDelayedParentRectangle)

			'
			'  Create an animation with no delay in the start time.
			'
			Dim myDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myDoubleAnimation, defaultBeginTimeRectangle.Name)
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myDoubleAnimation.From = 20
			myDoubleAnimation.To = 400
			myDoubleAnimation.BeginTime = TimeSpan.FromSeconds(0)
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myDoubleAnimation.FillBehavior = FillBehavior.HoldEnd


			'
			'  Create an animation with a 5 second delay in the start time.
			'
			Dim myDelayedDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myDelayedDoubleAnimation, delayedBeginTimeRectangle.Name)
			Storyboard.SetTargetProperty(myDelayedDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myDelayedDoubleAnimation.BeginTime = TimeSpan.FromSeconds(5)
			myDelayedDoubleAnimation.From = 20
			myDelayedDoubleAnimation.To = 400
			myDelayedDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myDelayedDoubleAnimation.FillBehavior = FillBehavior.HoldEnd


            '
            '  Create an animation with a 5 second delay in both the parent and
            '  child timelines.
            '
            Dim myParallelTimeline As New ParallelTimeline With {
                .BeginTime = TimeSpan.FromSeconds(5)
            }
            Dim myParallelDelayedDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myParallelDelayedDoubleAnimation, delayedAnimationWithDelayedParentRectangle.Name)
			Storyboard.SetTargetProperty(myParallelDelayedDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myParallelDelayedDoubleAnimation.From = 20
			myParallelDelayedDoubleAnimation.To = 400
			myParallelDelayedDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myParallelDelayedDoubleAnimation.FillBehavior = FillBehavior.HoldEnd
			myParallelDelayedDoubleAnimation.BeginTime = TimeSpan.FromSeconds(5)

			'
			' Create a Storyboard to contain the animations and add the animations to the Storyboard
			'
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)
			myStoryboard.Children.Add(myDelayedDoubleAnimation)
			myParallelTimeline.Children.Add(myParallelDelayedDoubleAnimation)
			myStoryboard.Children.Add(myParallelTimeline)

            '
            '  Create the button to restart the animations
            '
            Dim myButton As New Button With {
                .Margin = New Thickness(0, 30, 0, 0),
                .HorizontalAlignment = HorizontalAlignment.Left,
                .Content = "Restart Animations"
            }
            myStackPanel.Children.Add(myButton)

            '
            '  Create an EventTrigger and a BeginStoryboard action to start
            '    the storyboard
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
