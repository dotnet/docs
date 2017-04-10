' <SnippetGraphicsMMCreateAnimationClockWholeClass>
'
'    This example shows how to create and apply
'    an AnimationClock.
'


Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation


Namespace Microsoft.Samples.Animation.TimingBehaviors
	Public Class AnimationClockExample
		Inherits Page

		Private myScaleTransform As ScaleTransform

		Public Sub New()

			Me.WindowTitle = "Opacity Animation Example"
			Me.Background = Brushes.White
			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20)

			' Create a button that with a ScaleTransform.
			' The ScaleTransform will animate when the
			' button is clicked.
			Dim myButton As New Button()
			myButton.Margin = New Thickness(50)
			myButton.HorizontalAlignment = HorizontalAlignment.Left
			myButton.Content = "Click Me"
			myScaleTransform = New ScaleTransform(1,1)
			myButton.RenderTransform = myScaleTransform


			' Associate an event handler with the
			' button's Click event.
			AddHandler myButton.Click, AddressOf myButton_Clicked

			myStackPanel.Children.Add(myButton)
			Me.Content = myStackPanel
		End Sub

		' Create and apply and animation when the button is clicked.
		Private Sub myButton_Clicked(ByVal sender As Object, ByVal e As RoutedEventArgs)

			' Create a DoubleAnimation to animate the
			' ScaleTransform.
			Dim myAnimation As New DoubleAnimation(1, 5, New Duration(TimeSpan.FromSeconds(5))) ' "To" value -  "From" value
			myAnimation.AutoReverse = True

			' Create a clock the for the animation.
			Dim myClock As AnimationClock = myAnimation.CreateClock()

			' Associate the clock the ScaleX and
			' ScaleY properties of the button's
			' ScaleTransform.
			myScaleTransform.ApplyAnimationClock(ScaleTransform.ScaleXProperty, myClock)
			myScaleTransform.ApplyAnimationClock(ScaleTransform.ScaleYProperty, myClock)
		End Sub
	End Class
End Namespace
' </SnippetGraphicsMMCreateAnimationClockWholeClass>