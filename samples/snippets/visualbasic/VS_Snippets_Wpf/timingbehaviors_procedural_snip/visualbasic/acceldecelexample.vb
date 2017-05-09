'
'
'  AccelDecelExample.vb
'     This example shows how to use the AccelerationRatio and DecelerationRatio properties of timelines
'     to make animations speed up or slow down as they progress.
'
'

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Data
Imports System.Windows.Shapes
Imports System.Windows.Media.Imaging

Namespace Microsoft.Samples.Animation.TimingBehaviors
	Partial Public Class AccelDecelExample
		Inherits Page
		Public Sub New()

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			Me.WindowTitle = "Acceleration and Deceleration Example"

			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20)

			'
			'  Create the four rectangles to animate
			'
			Dim nonAcceleratedOrDeceleratedRectangle As New Rectangle()
			nonAcceleratedOrDeceleratedRectangle.Name = "nonAcceleratedOrDeceleratedRectangle"
			Me.RegisterName(nonAcceleratedOrDeceleratedRectangle.Name,nonAcceleratedOrDeceleratedRectangle)
			nonAcceleratedOrDeceleratedRectangle.Width = 10
			nonAcceleratedOrDeceleratedRectangle.Height = 20
			Dim mySolidColorBrush As New SolidColorBrush(Color.FromArgb(251,153,51,255))
			nonAcceleratedOrDeceleratedRectangle.Fill = mySolidColorBrush
			nonAcceleratedOrDeceleratedRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(nonAcceleratedOrDeceleratedRectangle)

			Dim acceleratedRectangle As New Rectangle()
			acceleratedRectangle.Name = "acceleratedRectangle"
			Me.RegisterName(acceleratedRectangle.Name, acceleratedRectangle)
			acceleratedRectangle.Width = 10
			acceleratedRectangle.Height = 20
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(251,51,51,255))
			acceleratedRectangle.Fill = mySolidColorBrush
			acceleratedRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(acceleratedRectangle)

			Dim deceleratedRectangle As New Rectangle()
			deceleratedRectangle.Name = "deceleratedRectangle"
			Me.RegisterName(deceleratedRectangle.Name, deceleratedRectangle)
			deceleratedRectangle.Width = 10
			deceleratedRectangle.Height = 20
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(251,51,255,102))
			deceleratedRectangle.Fill = mySolidColorBrush
			deceleratedRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(deceleratedRectangle)

			Dim acceleratedAndDeceleratedRectangle As New Rectangle()
			acceleratedAndDeceleratedRectangle.Name = "acceleratedAndDeceleratedRectangle"
			Me.RegisterName(acceleratedAndDeceleratedRectangle.Name,acceleratedAndDeceleratedRectangle)
			acceleratedAndDeceleratedRectangle.Width = 10
			acceleratedAndDeceleratedRectangle.Height = 20
			mySolidColorBrush = New SolidColorBrush(Color.FromArgb(251,204,255,51))
			acceleratedAndDeceleratedRectangle.Fill = mySolidColorBrush
			acceleratedAndDeceleratedRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myStackPanel.Children.Add(acceleratedAndDeceleratedRectangle)


			'
			' Creates an animation without acceleration or deceleration for comparison
			'
			Dim myDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myDoubleAnimation, nonAcceleratedOrDeceleratedRectangle.Name)
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			myDoubleAnimation.From = 20
			myDoubleAnimation.To = 400
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(10000))


			'
			' Creates an animation that accelerates through 40% of its duration.
			'
			Dim myAcceleratedAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myAcceleratedAnimation, acceleratedRectangle.Name)
			Storyboard.SetTargetProperty(myAcceleratedAnimation, New PropertyPath(Rectangle.WidthProperty))
			myAcceleratedAnimation.From = 20
			myAcceleratedAnimation.To = 400
			myAcceleratedAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(10000))
			myAcceleratedAnimation.AccelerationRatio = 0.4



			'
			' Creates an animation that decelerates through 60% of its duration.
			'
			Dim myDeceleratedAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myDeceleratedAnimation, deceleratedRectangle.Name)
			Storyboard.SetTargetProperty(myDeceleratedAnimation, New PropertyPath(Rectangle.WidthProperty))
			myDeceleratedAnimation.From = 20
			myDeceleratedAnimation.To = 400
			myDeceleratedAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(10000))
			myDeceleratedAnimation.DecelerationRatio = 0.6


			'
			' Creates an animation that accelerates through 40% of its duration and
			'      decelerates through the 60% of its duration.
			'
			Dim myAcceleratedAndDeceleratedAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myAcceleratedAndDeceleratedAnimation,acceleratedAndDeceleratedRectangle.Name)
			Storyboard.SetTargetProperty(myAcceleratedAndDeceleratedAnimation, New PropertyPath(Rectangle.WidthProperty))
			myAcceleratedAndDeceleratedAnimation.From = 20
			myAcceleratedAndDeceleratedAnimation.To = 400
			myAcceleratedAndDeceleratedAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(10000))
			myAcceleratedAndDeceleratedAnimation.AccelerationRatio = 0.4
			myAcceleratedAndDeceleratedAnimation.DecelerationRatio = 0.6


			' Create a Storyboard to contain the animations and
			' add the animations to the Storyboard.
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)
			myStoryboard.Children.Add(myAcceleratedAnimation)
			myStoryboard.Children.Add(myDeceleratedAnimation)
			myStoryboard.Children.Add(myAcceleratedAndDeceleratedAnimation)

			'
			' Create a button to start the animations.
			'
			Dim myRestartButton As New Button()
			myRestartButton.Name = "myRestartButton"
			myRestartButton.Margin = New Thickness(0,30,0,0)
			myRestartButton.HorizontalAlignment = HorizontalAlignment.Left
			myRestartButton.Content = "Restart Animations"
			myStackPanel.Children.Add(myRestartButton)

			' Create an EventTrigger and a BeginStoryboard action to
			' start the storyboard.
			Dim myEventTrigger As New EventTrigger()
			myEventTrigger.RoutedEvent = Button.ClickEvent
			myEventTrigger.SourceName = myRestartButton.Name
			Dim myBeginStoryboard As New BeginStoryboard()
			myBeginStoryboard.Storyboard = myStoryboard
			myEventTrigger.Actions.Add(myBeginStoryboard)
			myStackPanel.Triggers.Add(myEventTrigger)

			Me.Content = myStackPanel

		End Sub
	End Class
End Namespace
