' <SnippetThicknessAnimationWholePage>

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Namespace SDKSamples
	Public Class ThicknessAnimationExample
		Inherits Page
		Public Sub New()

			' Create a NameScope for this page so that
			' Storyboards can be used.
			NameScope.SetNameScope(Me, New NameScope())

			' Create a Border which will be the target of the animation.
            Dim myBorder As New Border()
            With myBorder
                .Background = Brushes.Gray
                .BorderBrush = Brushes.Black
                .BorderThickness = New Thickness(1)
                .Margin = New Thickness(0, 60, 0, 20)
                .Padding = New Thickness(20)
            End With

			' Assign the border a name so that
			' it can be targeted by a Storyboard.
			Me.RegisterName("myAnimatedBorder", myBorder)

            Dim myThicknessAnimation As New ThicknessAnimation()
            With myThicknessAnimation
                .Duration = TimeSpan.FromSeconds(1.5)
                .FillBehavior = FillBehavior.HoldEnd

                ' Set the From and To properties of the animation.
                ' BorderThickness animates from left=1, right=1, top=1, and bottom=1 
                ' to left=28, right=28, top=14, and bottom=14 over one and a half seconds.
                .From = New Thickness(1, 1, 1, 1)
                .To = New Thickness(28, 14, 28, 14)
            End With

            ' Set the animation to target the Size property
            ' of the object named "myArcSegment."
            Storyboard.SetTargetName(myThicknessAnimation, "myAnimatedBorder")
            Storyboard.SetTargetProperty(myThicknessAnimation, New PropertyPath(Border.BorderThicknessProperty))

            ' Create a storyboard to apply the animation.
            Dim ellipseStoryboard As New Storyboard()
            ellipseStoryboard.Children.Add(myThicknessAnimation)

            ' Start the storyboard when the Path loads.
            AddHandler myBorder.Loaded, Sub(sender As Object, e As RoutedEventArgs) ellipseStoryboard.Begin(Me)

            Dim myStackPanel As New StackPanel()
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Center
            myStackPanel.Children.Add(myBorder)

            Content = myStackPanel
		End Sub
	End Class
End Namespace
' </SnippetThicknessAnimationWholePage>

