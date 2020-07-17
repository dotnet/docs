'
'
'OpacityAnimationExample.vb
'  This example shows how to animate the opacity of objects,
'     making them fade in and out of view.
'
'


Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation


Namespace Microsoft.Samples.Animation.TimingBehaviors
	Partial Public Class OpacityAnimationExample
		Inherits Page
		Public Sub New()

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			WindowTitle = "Opacity Animation Example"
			Background = Brushes.White

            Dim myStackPanel As New StackPanel With {
                .Margin = New Thickness(20)
            }

                '
                '  Clicking on this button animates its opacity.
                '
            Dim opacityAnimatedButton As New Button With {
                .Name = "opacityAnimatedButton"
            }
            RegisterName(opacityAnimatedButton.Name, opacityAnimatedButton)
			opacityAnimatedButton.Content = "A Button"
			myStackPanel.Children.Add(opacityAnimatedButton)

			'
			'  Create an animation to animate the opacity of a button
			'
			Dim myOpacityDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myOpacityDoubleAnimation,opacityAnimatedButton.Name)
			Storyboard.SetTargetProperty(myOpacityDoubleAnimation,New PropertyPath(Button.OpacityProperty))
			myOpacityDoubleAnimation.From = 1
			myOpacityDoubleAnimation.To = 0
			myOpacityDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(5000))
			myOpacityDoubleAnimation.AutoReverse = True

			'
			'  Create a Storyboard to contain the animations and add the animations to the Storyboard
			'
			Dim myOpacityStoryboard As New Storyboard()
			myOpacityStoryboard.Children.Add(myOpacityDoubleAnimation)

			'
			'  Create EventTriggers and a BeginStoryboard action to start
			'  the storyboard
			Dim myOpacityBeginStoryboard As New BeginStoryboard()
            Dim myOpacityEventTrigger As New EventTrigger With {
                .RoutedEvent = Button.ClickEvent,
                .SourceName = opacityAnimatedButton.Name
            }
            myStackPanel.Triggers.Add(myOpacityEventTrigger)

			myOpacityBeginStoryboard.Storyboard = myOpacityStoryboard
			myOpacityEventTrigger.Actions.Add(myOpacityBeginStoryboard)



            '
            '  Clicking on this button animates the opacity of the brush used to paint the background.
            '
            Dim opacityBrushPaintedButton As New Button With {
                .Name = "opacityBrushPaintedButton"
            }
            RegisterName(opacityBrushPaintedButton.Name, opacityBrushPaintedButton)
			opacityBrushPaintedButton.Content = "A Button"
			Dim mySolidColorBrush As New SolidColorBrush()
			RegisterName("mySolidColorBrush", mySolidColorBrush)
			mySolidColorBrush.Color = Colors.Orange
			opacityBrushPaintedButton.Background = mySolidColorBrush
			myStackPanel.Children.Add(opacityBrushPaintedButton)

			'
			'  Create an animation to animate the opacity of the brush used to paint the background of the button.
			'
			Dim myBackgroundOpacityDoubleAnimation As New DoubleAnimation()
			Storyboard.SetTargetName(myBackgroundOpacityDoubleAnimation, "mySolidColorBrush")
			Storyboard.SetTargetProperty(myBackgroundOpacityDoubleAnimation, New PropertyPath(Brush.OpacityProperty))

			myBackgroundOpacityDoubleAnimation.From = 1
			myBackgroundOpacityDoubleAnimation.To = 0
			myBackgroundOpacityDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(5))
			myBackgroundOpacityDoubleAnimation.AutoReverse = True

			Dim myBackgroundOpacityStoryboard As New Storyboard()
			myBackgroundOpacityStoryboard.Children.Add(myBackgroundOpacityDoubleAnimation)

			'
			'  Create EventTriggers and a BeginStoryboard action to start
			'  the storyboard
			Dim myBackgroundOpacityBeginStoryboard As New BeginStoryboard()
            Dim myBackgroundOpacityEventTrigger As New EventTrigger With {
                .RoutedEvent = Button.ClickEvent,
                .SourceName = opacityBrushPaintedButton.Name
            }
            myStackPanel.Triggers.Add(myBackgroundOpacityEventTrigger)

			myBackgroundOpacityBeginStoryboard.Storyboard = myBackgroundOpacityStoryboard
			myBackgroundOpacityEventTrigger.Actions.Add(myBackgroundOpacityBeginStoryboard)

			Content = myStackPanel
		End Sub
	End Class
End Namespace
