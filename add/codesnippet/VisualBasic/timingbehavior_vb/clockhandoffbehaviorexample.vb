'<SnippetClockHandoffBehaviorExampleWholePage>
'
'
'   This sample animates the position of an ellipse when 
'   the user clicks within the main border. If the user
'   left-clicks, the SnapshotAndReplace HandoffBehavior
'   is used when applying the animations. If the user
'   right-clicks, the Compose HandoffBehavior is used
'   instead.
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

Namespace Microsoft.Samples.Animation.TimingBehaviors

	' Create the demonstration.
	Public Class ClockHandoffBehaviorExample
		Inherits Page


		Private interactiveTranslateTransform As TranslateTransform
		Private containerBorder As Border
		Private interactiveEllipse As Ellipse

		Public Sub New()

			WindowTitle = "Interactive Animation Example"
			Dim myPanel As New DockPanel()
			myPanel.Margin = New Thickness(20.0)

			containerBorder = New Border()
			containerBorder.Background = Brushes.White
			containerBorder.BorderBrush = Brushes.Black
			containerBorder.BorderThickness = New Thickness(2.0)
			containerBorder.VerticalAlignment = VerticalAlignment.Stretch

            interactiveEllipse = New Ellipse()
            With interactiveEllipse
                .Fill = Brushes.Lime
                .Stroke = Brushes.Black
                .StrokeThickness = 2.0
                .Width = 25
                .Height = 25
                .HorizontalAlignment = HorizontalAlignment.Left
                .VerticalAlignment = VerticalAlignment.Top
            End With

            interactiveTranslateTransform = New TranslateTransform()
            interactiveEllipse.RenderTransform = interactiveTranslateTransform

            AddHandler containerBorder.MouseLeftButtonDown, AddressOf border_mouseLeftButtonDown
            AddHandler containerBorder.MouseRightButtonDown, AddressOf border_mouseRightButtonDown

            containerBorder.Child = interactiveEllipse
            myPanel.Children.Add(containerBorder)
            Me.Content = myPanel
		End Sub


		' When the user left-clicks, use the 
		' SnapshotAndReplace HandoffBehavior when applying the animation.        
		Private Sub border_mouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)

			Dim clickPoint As Point = Mouse.GetPosition(containerBorder)

			' Set the target point so the center of the ellipse
			' ends up at the clicked point.
			Dim targetPoint As New Point()
            targetPoint.X = clickPoint.X - interactiveEllipse.Width / 2
            targetPoint.Y = clickPoint.Y - interactiveEllipse.Height / 2

			' Animate to the target point.
			Dim xAnimation As New DoubleAnimation(targetPoint.X, New Duration(TimeSpan.FromSeconds(4)))
			Dim xAnimationClock As AnimationClock = xAnimation.CreateClock()

			interactiveTranslateTransform.ApplyAnimationClock(TranslateTransform.XProperty, xAnimationClock, HandoffBehavior.SnapshotAndReplace)

			Dim yAnimation As New DoubleAnimation(targetPoint.Y, New Duration(TimeSpan.FromSeconds(4)))

			Dim yAnimationClock As AnimationClock = yAnimation.CreateClock()
			interactiveTranslateTransform.ApplyAnimationClock(TranslateTransform.YProperty, yAnimationClock, HandoffBehavior.SnapshotAndReplace)

			' Change the color of the ellipse.
			interactiveEllipse.Fill = Brushes.Lime

		End Sub

		' When the user right-clicks, use the 
		' Compose HandoffBehavior when applying the animation.
		Private Sub border_mouseRightButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)

			' Find the point where the use clicked.
			Dim clickPoint As Point = Mouse.GetPosition(containerBorder)

			' Set the target point so the center of the ellipse
			' ends up at the clicked point.
			Dim targetPoint As New Point()
            targetPoint.X = clickPoint.X - interactiveEllipse.Width / 2
            targetPoint.Y = clickPoint.Y - interactiveEllipse.Height / 2

			' Animate to the target point.
			Dim xAnimation As New DoubleAnimation(targetPoint.X, New Duration(TimeSpan.FromSeconds(4)))
			Dim xAnimationClock As AnimationClock = xAnimation.CreateClock()

			interactiveTranslateTransform.ApplyAnimationClock(TranslateTransform.XProperty, xAnimationClock, HandoffBehavior.Compose)

			Dim yAnimation As New DoubleAnimation(targetPoint.Y, New Duration(TimeSpan.FromSeconds(4)))

			Dim yAnimationClock As AnimationClock = yAnimation.CreateClock()
			interactiveTranslateTransform.ApplyAnimationClock(TranslateTransform.YProperty, yAnimationClock, HandoffBehavior.Compose)

			' Change the color of the ellipse.
			interactiveEllipse.Fill = Brushes.Orange


		End Sub

	End Class

End Namespace
'</SnippetClockHandoffBehaviorExampleWholePage>