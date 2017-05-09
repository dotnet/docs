'<SnippetGetAnimationBaseValueExampleWholePage>
'
'
'   This sample shows how to use the 
'   Animatable.GetAnimationBaseValue and 
'   UIElement.GetAnimationBaseValue methods
'   to get the non-animated value of an
'   animated Animatable or UIElement.
'
'

Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls
Imports System.Windows.Input
Imports Microsoft.VisualBasic

Namespace Microsoft.Samples.Animation.TimingBehaviors


	Public Class GetAnimationBaseValueExample
		Inherits Page


		Private animatedRotateTransform As RotateTransform
		Public Sub New()

			WindowTitle = "GetAnimationBaseValue Example"
			Dim myPanel As New StackPanel()
			myPanel.Margin = New Thickness(20.0)

			' Create a button.
			Dim animatedButton As New Button()
			animatedButton.Content = "Click Me"
			animatedButton.Width = 100
			animatedButton.Margin = New Thickness(100)

			' Create and animate a RotateTransform and
			' apply it to the button's RenderTransform
			' property.
			animatedRotateTransform = New RotateTransform()
			animatedRotateTransform.Angle = 45
			Dim angleAnimation As New DoubleAnimation(0,360, TimeSpan.FromSeconds(5))
			angleAnimation.RepeatBehavior = RepeatBehavior.Forever
			animatedRotateTransform.BeginAnimation(RotateTransform.AngleProperty, angleAnimation)
			animatedButton.RenderTransform = animatedRotateTransform
			animatedButton.RenderTransformOrigin = New Point(0.5,0.5)
'<SnippetBeginAnimation>               
			' Animate the button's width.
			Dim widthAnimation As New DoubleAnimation(120, 300, TimeSpan.FromSeconds(5))
			widthAnimation.RepeatBehavior = RepeatBehavior.Forever
			widthAnimation.AutoReverse = True
			animatedButton.BeginAnimation(Button.WidthProperty, widthAnimation)
'</SnippetBeginAnimation>

			' Handle button clicks.
			AddHandler animatedButton.Click, AddressOf animatedButton_Clicked

			' Add the button to the panel.
			myPanel.Children.Add(animatedButton)
			Me.Content = myPanel
		End Sub

 '<SnippetGetAnimationBaseValue>       
		' Display the base value for Button.Width and RotateTransform.Angle.
		Private Sub animatedButton_Clicked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim animatedButton As Button = CType(sender, Button)
            MessageBox.Show("Button width base value: " & animatedButton.GetAnimationBaseValue(Button.WidthProperty).ToString & vbLf & "RotateTransform base value: " & animatedRotateTransform.GetAnimationBaseValue(RotateTransform.AngleProperty).ToString)
        End Sub
 '</SnippetGetAnimationBaseValue> 

	End Class

End Namespace
'</SnippetGetAnimationBaseValueExampleWholePage>