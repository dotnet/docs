' <SnippetNameScopeExample>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Namespace Microsoft.Samples.Animation.AnimatingWithStoryboards




	Public Class ScopeExample
		Inherits Page

		Private myStoryboard As Storyboard
		Private myMainPanel As StackPanel
		Private button1, button2 As Button

		Public Sub New()

			Me.Background = Brushes.White
			myMainPanel = New StackPanel()

			' Create a name scope for the stackpanel. 
			NameScope.SetNameScope(myMainPanel, New NameScope())

			myMainPanel.Background = Brushes.Orange

			button1 = New Button()
			button1.Name = "Button1"

			' Register button1's name with myMainPanel.
			myMainPanel.RegisterName(button1.Name, button1)
			button1.Content = "Button 1"
			AddHandler button1.Click, AddressOf button1Clicked
			myMainPanel.Children.Add(button1)

			button2 = New Button()
			button2.Name = "Button2"

			' Register button2's name with myMainPanel.
			myMainPanel.RegisterName(button2.Name, button2)
			button2.Content = "Button 2"
			AddHandler button2.Click, AddressOf button2Clicked
			myMainPanel.Children.Add(button2)


			' Create some animations and a storyboard.
			Dim button1WidthAnimation As New DoubleAnimation(300, 200, New Duration(TimeSpan.FromSeconds(5)))
			Storyboard.SetTargetName(button1WidthAnimation, button1.Name)
			Storyboard.SetTargetProperty(button1WidthAnimation, New PropertyPath(Button.WidthProperty))

			Dim button2WidthAnimation As New DoubleAnimation(300, 200, New Duration(TimeSpan.FromSeconds(5)))
			Storyboard.SetTargetName(button2WidthAnimation, button2.Name)
			Storyboard.SetTargetProperty(button2WidthAnimation, New PropertyPath(Button.WidthProperty))

			Dim heightAnimationWithoutTarget As New DoubleAnimation(300, 200, New Duration(TimeSpan.FromSeconds(5)))
			Storyboard.SetTargetProperty(heightAnimationWithoutTarget, New PropertyPath(FrameworkElement.HeightProperty))

			myStoryboard = New Storyboard()
			myStoryboard.Children.Add(button1WidthAnimation)
			myStoryboard.Children.Add(button2WidthAnimation)
			myStoryboard.Children.Add(heightAnimationWithoutTarget)

			Me.Content = myMainPanel

		End Sub


		Private Sub button1Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)

			' Starts the animations. The animation without a specified 
			' target name, heightAnimationWithoutTarget, is applied to
			' myMainPanel.
			myStoryboard.Begin(myMainPanel)

		End Sub

		Private Sub button2Clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)

			' Starts the animations. The animation without a specified 
			' target name, heightAnimationWithoutTarget, is applied to
			' button2.
			myStoryboard.Begin(button2)

		End Sub

	End Class


End Namespace
' </SnippetNameScopeExample>