' <SnippetRectangleOpacityFadeCodeExampleWholePage>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace SDKSample

	Public Class RectangleOpacityFadeExample
		Inherits Page
		Private myStoryboard As Storyboard

		Public Sub New()
			NameScope.SetNameScope(Me, New NameScope())

			Me.WindowTitle = "Fading Rectangle Example"
			Dim myPanel As New StackPanel()
			myPanel.Margin = New Thickness(10)

			Dim myRectangle As New Rectangle()
			myRectangle.Name = "myRectangle"
			Me.RegisterName(myRectangle.Name, myRectangle)
			myRectangle.Width = 100
			myRectangle.Height = 100
			myRectangle.Fill = Brushes.Blue

			Dim myDoubleAnimation As New DoubleAnimation()
			myDoubleAnimation.From = 1.0
			myDoubleAnimation.To = 0.0
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(5))
			myDoubleAnimation.AutoReverse = True
			myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever

			myStoryboard = New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)
			Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name)
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.OpacityProperty))

			' Use the Loaded event to start the Storyboard.
			AddHandler myRectangle.Loaded, AddressOf myRectangleLoaded

			myPanel.Children.Add(myRectangle)
			Me.Content = myPanel
		End Sub

		Private Sub myRectangleLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			myStoryboard.Begin(Me)
		End Sub

	End Class
End Namespace
' </SnippetRectangleOpacityFadeCodeExampleWholePage>