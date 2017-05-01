'
'AnimatingSizeExample.vb
'  This example shows two ways of animating the size
'     of a framework element.
'

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation


Namespace Microsoft.Samples.Animation
	Partial Public Class AnimatingSizeExample
		Inherits Page
		Public Sub New()
			Me.WindowTitle = "Animating Size Example"
			NameScope.SetNameScope(Me, New NameScope())
			Dim myCanvas As New Canvas()
			myCanvas.Width = 650
			myCanvas.Height = 400

			'
			'  Create the the first button.
			'
			Dim myAnimatedWidthButton As New Button()
			myAnimatedWidthButton.Name = "AnimatedWidthButton"
			Me.RegisterName(myAnimatedWidthButton.Name,myAnimatedWidthButton)
			Canvas.SetLeft(myAnimatedWidthButton, 20)
			Canvas.SetTop(myAnimatedWidthButton, 20)
			myAnimatedWidthButton.Width = 200
			myAnimatedWidthButton.Height = 150
			myAnimatedWidthButton.BorderBrush = Brushes.Red
			myAnimatedWidthButton.BorderThickness = New Thickness(5)
			myAnimatedWidthButton.Content = "Click Me"

			'
			'  Create an animation to increase the size of a button
			'    by animating the width property.
			Dim myWidthAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myWidthAnimation,"AnimatedWidthButton")
			Storyboard.SetTargetProperty(myWidthAnimation,New PropertyPath(Button.WidthProperty))
			myWidthAnimation.To = 500
			myWidthAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(10000))
			myWidthAnimation.RepeatBehavior = RepeatBehavior.Forever

			'
			' Create a Storyboard to contain the animation and
			'   add the animation to the Storyboard.
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myWidthAnimation)

			'
			' Create an EventTrigger and a BeginStoryboard action to
			' start the storyboard.
			'
			Dim myEventTrigger As New EventTrigger()
			myEventTrigger.RoutedEvent = Button.LoadedEvent
			Dim myBeginStoryboard As New BeginStoryboard()
			myBeginStoryboard.Storyboard = myStoryboard
			myEventTrigger.Actions.Add(myBeginStoryboard)
			myAnimatedWidthButton.Triggers.Add(myEventTrigger)
			myCanvas.Children.Add(myAnimatedWidthButton)

			'
			'
			'
			Dim myAnimatedScaleTransformButton As New Button()
			Canvas.SetLeft(myAnimatedScaleTransformButton, 20)
			Canvas.SetTop(myAnimatedScaleTransformButton, 200)
			myAnimatedScaleTransformButton.Width = 200
			myAnimatedScaleTransformButton.Height = 150
			myCanvas.Children.Add(myAnimatedScaleTransformButton)

			myAnimatedScaleTransformButton.BorderBrush = Brushes.Black
			myAnimatedScaleTransformButton.BorderThickness = New Thickness(3)
			myAnimatedScaleTransformButton.Content = "Click Me"
			Dim myScaleTransform As New ScaleTransform(1,1)
			myAnimatedScaleTransformButton.RenderTransform = myScaleTransform
			Me.RegisterName("MyAnimatedScaleTransform",myScaleTransform)

			'
			'  Create an animation to increase the size of a button
			'    by transforming the X-scale property.
			Dim myScaleTransformAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myScaleTransformAnimation,"MyAnimatedScaleTransform")
			Storyboard.SetTargetProperty(myScaleTransformAnimation,New PropertyPath(ScaleTransform.ScaleXProperty))
			myScaleTransformAnimation.To = 3.0
			myScaleTransformAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(10000))
			myScaleTransformAnimation.AutoReverse = True
			myWidthAnimation.RepeatBehavior = RepeatBehavior.Forever

			'
			' Create a Storyboard to contain the animation and
			'   add the animation to the Storyboard.
			Dim myScaleTransformStoryboard As New Storyboard()
			myScaleTransformStoryboard.Children.Add(myScaleTransformAnimation)

			'
			' Create an EventTrigger and a BeginStoryboard action to
			' start the storyboard.
			'
			Dim myScaleTransformEventTrigger As New EventTrigger()
			myScaleTransformEventTrigger.RoutedEvent = Button.LoadedEvent
			Dim myScaleTransformBeginStoryboard As New BeginStoryboard()
			myScaleTransformBeginStoryboard.Storyboard = myScaleTransformStoryboard
			myScaleTransformEventTrigger.Actions.Add(myScaleTransformBeginStoryboard)
			myAnimatedScaleTransformButton.Triggers.Add(myScaleTransformEventTrigger)

			Me.Content = myCanvas
		End Sub
	End Class
End Namespace
