'
'AutoReverseExample.xaml
'     This example shows how to use the AutoReverse property to make a timeline play backwards at the end of each iteration.
'     Several rectangles are animated by DoubleAnimations with identical durations and target values, but with different
'     AutoReverse and RepeatBehavior settings.
'


Imports System
Imports System.Windows
Imports System.Windows.Shapes
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports Microsoft.VisualBasic

Namespace Microsoft.Samples.Animation.TimingBehaviors
	Partial Public Class AutoReverseExample
		Inherits Page
		Public Sub New()

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20)

			Dim myBorder As New Border()
			Dim myTextBlock As New TextBlock()
			myTextBlock.Margin = New Thickness(20)
			myTextBlock.Text = "This example shows how to use the AutoReverse property to make a"
			myTextBlock.Text &= " timeline play backwards at the end of each  iteration. Several rectangles are"
			myTextBlock.Text &= " animated by DoubleAnimations with identical durations and target values, but with different "
			myTextBlock.Text &= " AutoReverse and RepeatBehavior settings."

			myBorder.Child = myTextBlock
			myStackPanel.Children.Add(myBorder)

			myTextBlock = New TextBlock()
			myTextBlock.Text = "AutoReverse=""False"" (Default)."
			myStackPanel.Children.Add(myTextBlock)

			'
			'  Create the rectangles to animate
			'
			Dim withoutAutoReverseRectangle As New Rectangle()
			withoutAutoReverseRectangle.Name = "withoutAutoReverseRectangle"
			Me.RegisterName(withoutAutoReverseRectangle.Name,withoutAutoReverseRectangle)
			withoutAutoReverseRectangle.Width = 100
			withoutAutoReverseRectangle.Height = 20
			Dim mySolidColorBrush As New SolidColorBrush(Color.FromArgb(170,51,51,255))
			withoutAutoReverseRectangle.Fill = mySolidColorBrush
			withoutAutoReverseRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(withoutAutoReverseRectangle)

			myTextBlock = New TextBlock()
			myTextBlock.Margin = New Thickness(0,20,0,0)
			myTextBlock.Text = "AutoReverse=""True""."
			myStackPanel.Children.Add(myTextBlock)

			Dim autoReverseRectangle As New Rectangle()
			autoReverseRectangle.Name = "autoReverseRectangle"
			Me.RegisterName(autoReverseRectangle.Name, autoReverseRectangle)
			autoReverseRectangle.Width = 100
			autoReverseRectangle.Height = 20
			autoReverseRectangle.Fill = mySolidColorBrush
			autoReverseRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(autoReverseRectangle)

			myTextBlock = New TextBlock()
			myTextBlock.Margin = New Thickness(0,20,0,0)
			myTextBlock.Text = "In this example, AutoReverse=""True"" " & vbLf & "RepeatBehavior=""2x""."
			myStackPanel.Children.Add(myTextBlock)

			Dim autoReverseRectangleWithRepeats As New Rectangle()
			autoReverseRectangleWithRepeats.Name = "autoReverseRectangleWithRepeats"
			Me.RegisterName(autoReverseRectangleWithRepeats.Name, autoReverseRectangleWithRepeats)
			autoReverseRectangleWithRepeats.Width = 100
			autoReverseRectangleWithRepeats.Height = 20
			autoReverseRectangleWithRepeats.Fill = mySolidColorBrush
			autoReverseRectangleWithRepeats.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(autoReverseRectangleWithRepeats)


			myTextBlock = New TextBlock()
			myTextBlock.Margin = New Thickness(0,20,0,0)
			myTextBlock.Text = "In this example, AutoReverse=""True"" and RepeatBehavior=""2x"" "
			myTextBlock.Text &= "have been set on the animation's parent timeline."
			myStackPanel.Children.Add(myTextBlock)

			Dim complexAutoReverseExample As New Rectangle()
			complexAutoReverseExample.Name = "complexAutoReverseExample"
			Me.RegisterName(complexAutoReverseExample.Name, complexAutoReverseExample)
			complexAutoReverseExample.Width = 100
			complexAutoReverseExample.Height = 20
			complexAutoReverseExample.Fill = mySolidColorBrush
			complexAutoReverseExample.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(complexAutoReverseExample)

			'
			'  Create an animation that does not automatically play in reverse.
			'
			Dim myDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myDoubleAnimation, withoutAutoReverseRectangle.Name)
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myDoubleAnimation.From = 100
			myDoubleAnimation.To = 400
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myDoubleAnimation.AutoReverse = False

			'
			' Create an animation that automatically reverses at the end of each iteration.
			'
			Dim myAutomaticallyReversedDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myAutomaticallyReversedDoubleAnimation, autoReverseRectangle.Name)
			Storyboard.SetTargetProperty(myAutomaticallyReversedDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myAutomaticallyReversedDoubleAnimation.From = 100
			myAutomaticallyReversedDoubleAnimation.To = 400
			myAutomaticallyReversedDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myAutomaticallyReversedDoubleAnimation.AutoReverse = True


			'
			' Create an animation that automatically reverses at the end of each iteration.
			'  Set the animation to repeat twice. As
			'  a result, then animation plays forward, then backward, then forward, and then backward again.
			Dim myRepeatedAndReversedDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myRepeatedAndReversedDoubleAnimation, autoReverseRectangleWithRepeats.Name)
			Storyboard.SetTargetProperty(myRepeatedAndReversedDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myRepeatedAndReversedDoubleAnimation.From = 100
			myRepeatedAndReversedDoubleAnimation.To = 400
			myRepeatedAndReversedDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myRepeatedAndReversedDoubleAnimation.AutoReverse = True
			myRepeatedAndReversedDoubleAnimation.RepeatBehavior = New RepeatBehavior(2)

			'
			' Set the parent timeline's AutoReverse property to True and set the animation's
			'   RepeatBehavior to 2x. As a result, the animation plays forward twice and then backwards twice.
			'
			Dim myParallelTimeline As New ParallelTimeline()
			myParallelTimeline.AutoReverse = True
			Dim myParallelRepeatedAndReversedDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myParallelRepeatedAndReversedDoubleAnimation, complexAutoReverseExample.Name)
			Storyboard.SetTargetProperty(myParallelRepeatedAndReversedDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myParallelRepeatedAndReversedDoubleAnimation.From = 100
			myParallelRepeatedAndReversedDoubleAnimation.To = 400
			myParallelRepeatedAndReversedDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(2000))
			myParallelRepeatedAndReversedDoubleAnimation.AutoReverse = True
			myParallelRepeatedAndReversedDoubleAnimation.RepeatBehavior = New RepeatBehavior(2)

			'
			' Create a Storyboard to contain the animations and add the animations to the Storyboard
			'
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)
			myStoryboard.Children.Add(myAutomaticallyReversedDoubleAnimation)
			myStoryboard.Children.Add(myRepeatedAndReversedDoubleAnimation)
			myParallelTimeline.Children.Add(myParallelRepeatedAndReversedDoubleAnimation)
			myStoryboard.Children.Add(myParallelTimeline)

			'
			'  Create the button to restart the animations.
			'
			Dim myButton As New Button()
			myButton.Margin = New Thickness(0,30,0,0)
			myButton.HorizontalAlignment = HorizontalAlignment.Left
			myButton.Content = "Restart Animations"
			myStackPanel.Children.Add(myButton)

			'
			'  Create an EventTrigger and a BeginStoryboard action to start
			'    the storyboard
			Dim myBeginStoryboard As New BeginStoryboard()
			myBeginStoryboard.Storyboard = myStoryboard

			Dim myEventTrigger As New EventTrigger()
			myEventTrigger.RoutedEvent = Button.ClickEvent
			myEventTrigger.SourceName = myButton.Name
			myEventTrigger.Actions.Add(myBeginStoryboard)
			myStackPanel.Triggers.Add(myEventTrigger)
			Me.Content = myStackPanel
		End Sub
	End Class
End Namespace
