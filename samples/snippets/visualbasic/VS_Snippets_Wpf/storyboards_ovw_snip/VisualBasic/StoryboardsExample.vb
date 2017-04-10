' <Snippet100>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Data
Imports System.Windows.Shapes
Imports System.Windows.Input


Namespace Microsoft.Samples.Animation
	Public Class StoryboardsExample
		Inherits Page
		Public Sub New()
			Me.WindowTitle = "Storyboards Example"
			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20)

			' <Snippet102>            
			Dim myRectangle As New Rectangle()
			myRectangle.Name = "MyRectangle"

			' Create a name scope for the page.
			NameScope.SetNameScope(Me, New NameScope())

			Me.RegisterName(myRectangle.Name, myRectangle)
			' </Snippet102>
			myRectangle.Width = 100
			myRectangle.Height = 100
			' <Snippet103>
			Dim mySolidColorBrush As New SolidColorBrush(Colors.Blue)
			Me.RegisterName("MySolidColorBrush", mySolidColorBrush)
			' </Snippet103>
			myRectangle.Fill = mySolidColorBrush

			Dim myDoubleAnimation As New DoubleAnimation()
			myDoubleAnimation.From = 100
			myDoubleAnimation.To = 200
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
			' <Snippet105> 
			Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name)
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			' </Snippet105>

			Dim myColorAnimation As New ColorAnimation()
			myColorAnimation.From = Colors.Blue
			myColorAnimation.To = Colors.Red
			myColorAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
			' <Snippet107>
			Storyboard.SetTargetName(myColorAnimation, "MySolidColorBrush")
			Storyboard.SetTargetProperty(myColorAnimation, New PropertyPath(SolidColorBrush.ColorProperty))
			' </Snippet107>
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)
			myStoryboard.Children.Add(myColorAnimation)

			AddHandler myRectangle.MouseEnter, Sub(sender As Object, e As MouseEventArgs) myStoryboard.Begin(Me)

			myStackPanel.Children.Add(myRectangle)
			Me.Content = myStackPanel
		End Sub
	End Class
End Namespace
' </Snippet100>