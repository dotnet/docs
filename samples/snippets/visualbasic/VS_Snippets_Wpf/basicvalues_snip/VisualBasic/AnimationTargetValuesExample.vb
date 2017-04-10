Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls

Namespace Microsoft.Samples.Animation.AnimatePathShapeSample

	Public Class AnimationTargetValuesExample
		Inherits Page

		Private Function CreateRectangle1() As Rectangle
            ' <SnippetFromToAnimationInline>
            ' Demonstrates the From and To properties used together.

            ' Create a NameScope for this page so that
            ' Storyboards can be used.
            NameScope.SetNameScope(Me, New NameScope())

			Dim myRectangle As New Rectangle()

			' Assign the Rectangle a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("fromToAnimatedRectangle", myRectangle)
			myRectangle.Height = 10
			myRectangle.Width = 100
			myRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myRectangle.Fill = Brushes.Black

			' Demonstrates the From and To properties used together.
			' Animates the rectangle's Width property from 50 to 300 over 10 seconds.
			Dim myDoubleAnimation As New DoubleAnimation()
			myDoubleAnimation.From = 50
			myDoubleAnimation.To = 300
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(10))

			Storyboard.SetTargetName(myDoubleAnimation, "fromToAnimatedRectangle")
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)

			' Use an anonymous event handler to begin the animation
			' when the rectangle is clicked.
			AddHandler myRectangle.MouseLeftButtonDown, Sub(sender As Object, args As MouseButtonEventArgs) myStoryboard.Begin(myRectangle)
			' </SnippetFromToAnimationInline>
			Return myRectangle

		End Function

		Private Function CreateRectangle2() As Rectangle
            ' <SnippetToAnimationInline>
            ' Demonstrates the use of the To property.

            ' Create a NameScope for this page so that
            ' Storyboards can be used.
            NameScope.SetNameScope(Me, New NameScope())

			Dim myRectangle As New Rectangle()

			' Assign the Rectangle a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("toAnimatedRectangle", myRectangle)
			myRectangle.Height = 10
			myRectangle.Width = 100
			myRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myRectangle.Fill = Brushes.Gray

			' Demonstrates the To property used by itself. Animates
			' the Rectangle's Width property from its base value
			' (100) to 300 over 10 seconds.
			Dim myDoubleAnimation As New DoubleAnimation()
			myDoubleAnimation.To = 300
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(10))

			Storyboard.SetTargetName(myDoubleAnimation, "toAnimatedRectangle")
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)

			' Use an anonymous event handler to begin the animation
			' when the rectangle is clicked.
			AddHandler myRectangle.MouseLeftButtonDown, Sub(sender As Object, args As MouseButtonEventArgs) myStoryboard.Begin(myRectangle)
			' </SnippetToAnimationInline>
			Return myRectangle

		End Function

		Private Function CreateRectangle3() As Rectangle
            ' <SnippetByAnimationInline>
            ' Demonstrates the use of the By property.

            ' Create a NameScope for this page so that
            ' Storyboards can be used.
            NameScope.SetNameScope(Me, New NameScope())

			Dim myRectangle As New Rectangle()

			' Assign the Rectangle a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("byAnimatedRectangle", myRectangle)
			myRectangle.Height = 10
			myRectangle.Width = 100
			myRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myRectangle.Fill = Brushes.RoyalBlue

			' Demonstrates the By property used by itself.
			' Increments the Rectangle's Width property by 300 over 10 seconds.
			' As a result, the Width property is animated from its base value
			' (100) to 400 (100 + 300) over 10 seconds.
			Dim myDoubleAnimation As New DoubleAnimation()
			myDoubleAnimation.By = 300
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(10))

			Storyboard.SetTargetName(myDoubleAnimation, "byAnimatedRectangle")
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)

			' Use an anonymous event handler to begin the animation
			' when the rectangle is clicked.
			AddHandler myRectangle.MouseLeftButtonDown, Sub(sender As Object, args As MouseButtonEventArgs) myStoryboard.Begin(myRectangle)
			' </SnippetByAnimationInline>
			Return myRectangle

		End Function

		Private Function CreateRectangle4() As Rectangle
            ' <SnippetFromByAnimationInline>
            ' Demonstrates the use of the From and By properties.

            ' Create a NameScope for this page so that
            ' Storyboards can be used.
            NameScope.SetNameScope(Me, New NameScope())

			Dim myRectangle As New Rectangle()

			' Assign the Rectangle a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("byAnimatedRectangle", myRectangle)
			myRectangle.Height = 10
			myRectangle.Width = 100
			myRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myRectangle.Fill = Brushes.BlueViolet

			' Demonstrates the From and By properties used together.
			' Increments the Rectangle's Width property by 300 over 10 seconds.
			' As a result, the Width property is animated from 50
			' to 350 (50 + 300) over 10 seconds.
			Dim myDoubleAnimation As New DoubleAnimation()
			myDoubleAnimation.From = 50
			myDoubleAnimation.By = 300
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(10))

			Storyboard.SetTargetName(myDoubleAnimation, "byAnimatedRectangle")
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)

			' Use an anonymous event handler to begin the animation
			' when the rectangle is clicked.
			AddHandler myRectangle.MouseLeftButtonDown, Sub(sender As Object, args As MouseButtonEventArgs) myStoryboard.Begin(myRectangle)
			' </SnippetFromByAnimationInline>
			Return myRectangle

		End Function

		Private Function CreateRectangle5() As Rectangle
            ' <SnippetFromAnimationInline>
            ' Demonstrates the use of the From property.

            ' Create a NameScope for this page so that
            ' Storyboards can be used.
            NameScope.SetNameScope(Me, New NameScope())

			Dim myRectangle As New Rectangle()

			' Assign the Rectangle a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("fromAnimatedRectangle", myRectangle)
			myRectangle.Height = 10
			myRectangle.Width = 100
			myRectangle.HorizontalAlignment = HorizontalAlignment.Left
			myRectangle.Fill = Brushes.Purple

			' Demonstrates the From property used by itself. Animates the
			' rectangle's Width property from 50 to its base value (100)
			' over 10 seconds.
			Dim myDoubleAnimation As New DoubleAnimation()
			myDoubleAnimation.From = 50
			myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(10))

			Storyboard.SetTargetName(myDoubleAnimation, "fromAnimatedRectangle")
			Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.WidthProperty))
			Dim myStoryboard As New Storyboard()
			myStoryboard.Children.Add(myDoubleAnimation)

			' Use an anonymous event handler to begin the animation
			' when the rectangle is clicked.
			AddHandler myRectangle.MouseLeftButtonDown, Sub(sender As Object, args As MouseButtonEventArgs) myStoryboard.Begin(myRectangle)
			' </SnippetFromAnimationInline>
			Return myRectangle

		End Function


		Public Sub New()
			NameScope.SetNameScope(Me, New NameScope())

			Dim myStackPanel As New StackPanel()
			myStackPanel.Margin = New Thickness(20)
			Dim rectangle2 As Rectangle = CreateRectangle2()
			myStackPanel.Children.Add(rectangle2)

			Me.Content = myStackPanel
		End Sub
	End Class
End Namespace
