' <Snippet11>
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'''This sample demonstrates how to apply non-storyboard animations to a property.
'''To animate in markup, you must use storyboards.
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls

Namespace Microsoft.Samples.Animation.LocalAnimations

    ' Create the demonstration.
    Public Class LocalAnimationExample
        Inherits Page

        Public Sub New()

            WindowTitle = "Animate Property Example"
            Dim myStackPanel As New StackPanel()
            myStackPanel.Margin = New Thickness(20)

            ' Create and set the Button.
            Dim aButton As New Button()
            aButton.Content = "A Button"

            ' Animate the Button's Width.
            Dim myDoubleAnimation As New DoubleAnimation()
            myDoubleAnimation.From = 75
            myDoubleAnimation.To = 300
            myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(5))
            myDoubleAnimation.AutoReverse = True
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever

            ' Apply the animation to the button's Width property.
            aButton.BeginAnimation(Button.WidthProperty, myDoubleAnimation)

            ' Create and animate a Brush to set the button's Background.
            Dim myBrush As New SolidColorBrush()
            myBrush.Color = Colors.Blue

            Dim myColorAnimation As New ColorAnimation()
            myColorAnimation.From = Colors.Blue
            myColorAnimation.To = Colors.Red
            myColorAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(7000))
            myColorAnimation.AutoReverse = True
            myColorAnimation.RepeatBehavior = RepeatBehavior.Forever

            ' Apply the animation to the brush's Color property.
            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation)
            aButton.Background = myBrush

            ' Add the Button to the panel.
            myStackPanel.Children.Add(aButton)
            Me.Content = myStackPanel
        End Sub
    End Class
End Namespace
' </Snippet11>
