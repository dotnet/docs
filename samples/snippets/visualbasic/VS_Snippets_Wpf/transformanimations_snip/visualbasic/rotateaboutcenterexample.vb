'
'  RotateAboutCenterExample.vb
'     This example shows how to use the RepeatBehavior property to make a timeline repeat.
'
'


Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation


Namespace Microsoft.Samples.Animation
	Partial Public Class RotateAboutCenterExample
		Inherits Page
'<SnippetUIElementRenderTransformOrigin>
		Public Sub New()
			Me.WindowTitle = "Rotate About Center Example"
			NameScope.SetNameScope(Me, New NameScope())
			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(50)

			Dim myButton As New Button()
			myButton.Name = "myRenderTransformButton"
			Me.RegisterName(myButton.Name,myButton)
			myButton.RenderTransformOrigin = New Point(0.5,0.5)
			myButton.HorizontalAlignment = HorizontalAlignment.Left
			myButton.Content = "Hello World"


			Dim myRotateTransform As New RotateTransform(0)
			myButton.RenderTransform = myRotateTransform
			Me.RegisterName("MyAnimatedTransform",myRotateTransform)

			myStackPanel.Children.Add(myButton)

			'
			' Creates an animation that accelerates through 40% of its duration and
			'      decelerates through the 60% of its duration.
			'
			Dim myRotateAboutCenterAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myRotateAboutCenterAnimation,"MyAnimatedTransform")
			Storyboard.SetTargetProperty(myRotateAboutCenterAnimation,New PropertyPath(RotateTransform.AngleProperty))
			myRotateAboutCenterAnimation.From = 0.0
			myRotateAboutCenterAnimation.To = 360
			myRotateAboutCenterAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(1000))

			' Create a Storyboard to contain the animations and
			' add the animations to the Storyboard.
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myRotateAboutCenterAnimation)

			' Create an EventTrigger and a BeginStoryboard action to
			' start the storyboard.
			Dim myEventTrigger As New EventTrigger()
			myEventTrigger.RoutedEvent = Button.ClickEvent
			myEventTrigger.SourceName = myButton.Name
			Dim myBeginStoryboard As New BeginStoryboard()
			myBeginStoryboard.Storyboard = myStoryboard
			myEventTrigger.Actions.Add(myBeginStoryboard)
			myStackPanel.Triggers.Add(myEventTrigger)

			Me.Content = myStackPanel
		End Sub
'</SnippetUIElementRenderTransformOrigin>
	End Class
End Namespace
