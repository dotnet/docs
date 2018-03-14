' <SnippetMultipleNameScopesExample>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Namespace Microsoft.Samples.Animation.AnimatingWithStoryboards


	Public Class MultipleNameScopesExample
		Inherits Page

		Private storyboard1, storyboard2 As Storyboard
		Private mainPanel, childPanel1, childPanel2 As StackPanel
		Private rectangle1, rectangle2 As Rectangle

		Public Sub New()


			Me.Background = Brushes.White
			mainPanel = New StackPanel()
			mainPanel.Background = Brushes.Gray
			childPanel1 = New StackPanel()
			childPanel1.Background = Brushes.Orange
			mainPanel.Children.Add(childPanel1)
			childPanel2 = New StackPanel()
			childPanel2.Background = Brushes.Red
			mainPanel.Children.Add(childPanel2)

			' Create a name scope for each panel.
			NameScope.SetNameScope(mainPanel, New NameScope())
			NameScope.SetNameScope(childPanel1, New NameScope())
			NameScope.SetNameScope(childPanel2, New NameScope())

			' Create a rectangle, add it to childPanel1,
			' and register its name with childPanel1.
			rectangle1 = New Rectangle()
			rectangle1.Width = 50
			rectangle1.Height = 50
			rectangle1.Fill = Brushes.Blue
			childPanel1.RegisterName("rectangle1", rectangle1)
			childPanel1.Children.Add(rectangle1)

			' Animate rectangle1's width.
			Dim myDoubleAnimation As New DoubleAnimation(10,100, New Duration(TimeSpan.FromSeconds(3)))
			Storyboard.SetTargetName(myDoubleAnimation, "rectangle1")
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			storyboard1 = New Storyboard()
			storyboard1.Children.Add(myDoubleAnimation)

			Dim startRectangle1AnimationButton As New Button()
			startRectangle1AnimationButton.Content = "Start rectangle1 Animation"
			AddHandler startRectangle1AnimationButton.Click, AddressOf startRectangle1AnimationButton_clicked
			mainPanel.Children.Add(startRectangle1AnimationButton)


			' Create a rectangle, add it to childPanel1,
			' but register its name with mainPanel.
			rectangle2 = New Rectangle()
			rectangle2.Width = 50
			rectangle2.Height = 50
			rectangle2.Fill = Brushes.Black
			mainPanel.RegisterName("rectangle2", rectangle2)
			childPanel1.Children.Add(rectangle2)

			' Animate rectangle2's width.
			myDoubleAnimation = New DoubleAnimation(10,100, New Duration(TimeSpan.FromSeconds(3)))
			Storyboard.SetTargetName(myDoubleAnimation, "rectangle2")
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			storyboard2 = New Storyboard()
			storyboard2.Children.Add(myDoubleAnimation)

			Dim startRectangle2AnimationButton As New Button()
			startRectangle2AnimationButton.Content = "Start rectangle2 Animation"
			AddHandler startRectangle2AnimationButton.Click, AddressOf startRectangle2AnimationButton_clicked
			mainPanel.Children.Add(startRectangle2AnimationButton)




			Me.Content = mainPanel

		End Sub


		Private Sub startRectangle1AnimationButton_clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)

			' Starts the animation.
			storyboard1.Begin(childPanel1)

		End Sub

		Private Sub startRectangle2AnimationButton_clicked(ByVal sender As Object, ByVal args As RoutedEventArgs)

			Try

				' This statement throws an exception because
				' rectangle2's name is registered with
				' mainPanel, and childPanel1 is not in
				' mainPanel's name scope.
				' Normally, as a child of mainPanel, 
				' childPanel1 would share mainPanel's name scope.
				' however, because we gave childPanel1 its own
				' name scope, it no longer shares mainPanel's name scope.
				storyboard2.Begin(childPanel1)

			Catch ex As System.InvalidOperationException

			End Try

			Try

				' This statement also throws an exception because
				' rectangle2's name is registered with
				' mainPanel, and childPanel1 is not in
				' mainPanel's name scope.
				' Normally, as a child of mainPanel, 
				' childPanel1 would share mainPanel's name scope.
				' however, because we gave childPanel1 its own
				' name scope, it no longer shares mainPanel's name scope.
				storyboard2.Begin(rectangle2)

			Catch ex As System.InvalidOperationException

			End Try

			' This statement works as expected.
			storyboard2.Begin(mainPanel)


		End Sub

	End Class

End Namespace
' </SnippetMultipleNameScopesExample>