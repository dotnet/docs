'
'
'This Sample shows a Rectangle with a gradient fill and an animated height
'
'


Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Namespace Microsoft.Samples.Animation.AnimatedTransformations
	Public Class AnimatedHeightExample
		Inherits Page


		Private myStoryboard As Storyboard

		Public Sub New()

			 ' Create a name scope for the page.
			 NameScope.SetNameScope(Me, New NameScope())

			 WindowTitle = "Animated Height Example"
 '<SnippetFEName>              
			 '  
			 ' Create a Rectangle
			 '
			 Dim myRectangle As New Rectangle()
			 myRectangle.Width = 200
			 myRectangle.Height = 200
			 myRectangle.Name = "myRectangle"
			 Me.RegisterName(myRectangle.Name, myRectangle)
 '</SnippetFEName>                
			 '
			 '  Set the Rectangle's Fill Property with a LinearGradientBrush      
			 '
			 Dim myLinearGradientBrush As New LinearGradientBrush()
			 myLinearGradientBrush.StartPoint = New Point(0,0)
			 myLinearGradientBrush.EndPoint = New Point(0,1)

			 Dim myGradientStop1 As New GradientStop()
			 myGradientStop1.Color = Colors.Red
			 myGradientStop1.Offset = 0
			 myLinearGradientBrush.GradientStops.Add(myGradientStop1)

			 Dim myGradientStop2 As New GradientStop()
			 myGradientStop2.Color = Colors.Purple
			 myGradientStop2.Offset = 0.5
			 myLinearGradientBrush.GradientStops.Add(myGradientStop2)

			 Dim myGradientStop3 As New GradientStop()
			 myGradientStop3.Color = Colors.Blue
			 myGradientStop3.Offset = 1
			 myLinearGradientBrush.GradientStops.Add(myGradientStop3)

			 myRectangle.Fill = myLinearGradientBrush

			 '
			 ' Start animating the rectangle's height after it's been loaded.
			 '
			 myStoryboard = New Storyboard()
			 Dim myDoubleAnimation As New DoubleAnimation(0.0, 100.0, New Duration(TimeSpan.FromSeconds(2)))
			 myDoubleAnimation.BeginTime = TimeSpan.FromSeconds(0.5)
			 myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever
			 myDoubleAnimation.AutoReverse = True
			 Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.HeightProperty))
			 myStoryboard.Children.Add(myDoubleAnimation)

			 ' Create an event handler to start the storyboard
			 ' after the rectangle is loaded.
			 AddHandler myRectangle.Loaded, AddressOf rectangleLoaded

			 Dim mainPanel As New DockPanel()
			 mainPanel.Children.Add(myRectangle)
			 Me.Content = mainPanel

		End Sub

		Private Sub rectangleLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)

			' Start the storyboard.
			myStoryboard.Begin(Me)
		End Sub
	End Class
End Namespace
