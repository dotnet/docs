' <Snippet11>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace SDKSample


    ' Uses a storyboard to animate the properties
    ' of two buttons.
    Public Class StoryboardExample
        Inherits Page
        
        Private Dim WithEvents myWidthAnimatedButton As Button
        Private Dim WithEvents myColorAnimatedButton As Button        
        Private Dim myWidthAnimatedButtonStoryboard As Storyboard
        Private Dim myColorAnimatedButtonStoryboard As Storyboard
        

        Public Sub New()
            ' Create a name scope for the page.
            NameScope.SetNameScope(Me, New NameScope())

            Me.WindowTitle = "Animate Properties using Storyboards"
            Dim myStackPanel As New StackPanel()
            myStackPanel.MinWidth = 500
            myStackPanel.Margin = New Thickness(30)
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Left
            Dim myTextBlock As New TextBlock()
            myTextBlock.Text = "Storyboard Animation Example"
            myStackPanel.Children.Add(myTextBlock)

            '
            ' Create and animate the first button.
            '

            ' Create a button.
            myWidthAnimatedButton = New Button()
            myWidthAnimatedButton.Height = 30
            myWidthAnimatedButton.Width = 200
            myWidthAnimatedButton.HorizontalAlignment = HorizontalAlignment.Left
            myWidthAnimatedButton.Content = "A Button"

            ' Set the Name of the button so that it can be referred
            ' to in the storyboard that's created later.
            ' The ID doesn't have to match the variable name;
            ' it can be any unique identifier.
            myWidthAnimatedButton.Name = "myWidthAnimatedButton"

            ' Register the name with the page to which the button belongs.
            Me.RegisterName(myWidthAnimatedButton.Name, myWidthAnimatedButton)

            ' Create a DoubleAnimation to animate the width of the button.
            Dim myDoubleAnimation As New DoubleAnimation()
            myDoubleAnimation.From = 200
            myDoubleAnimation.To = 300
            myDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(3000))

            ' Configure the animation to target the button's Width property.
            Storyboard.SetTargetName(myDoubleAnimation, myWidthAnimatedButton.Name)
            Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Button.WidthProperty))

            ' Create a storyboard to contain the animation.
            myWidthAnimatedButtonStoryboard = New Storyboard()
            myWidthAnimatedButtonStoryboard.Children.Add(myDoubleAnimation)

            myStackPanel.Children.Add(myWidthAnimatedButton)

            '
            ' Create and animate the second button.
            '

            ' Create a second button.
            myColorAnimatedButton = New Button()
            myColorAnimatedButton.Height = 30
            myColorAnimatedButton.Width = 200
            myColorAnimatedButton.HorizontalAlignment = HorizontalAlignment.Left
            myColorAnimatedButton.Content = "Another Button"

            ' Create a SolidColorBrush to paint the button's background.
            Dim myBackgroundBrush As New SolidColorBrush()
            myBackgroundBrush.Color = Colors.Blue

            ' Because a Brush isn't a FrameworkElement, it doesn't
            ' have a Name property to set. Instead, you just
            ' register a name for the SolidColorBrush with
            ' the page where it's used.
            Me.RegisterName("myAnimatedBrush", myBackgroundBrush)

            ' Use the brush to paint the background of the button.
            myColorAnimatedButton.Background = myBackgroundBrush

            ' Create a ColorAnimation to animate the button's background.
            Dim myColorAnimation As New ColorAnimation()
            myColorAnimation.From = Colors.Red
            myColorAnimation.To = Colors.Blue
            myColorAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(7000))

            ' Configure the animation to target the brush's Color property.
            Storyboard.SetTargetName(myColorAnimation, "myAnimatedBrush")
            Storyboard.SetTargetProperty(myColorAnimation, New PropertyPath(SolidColorBrush.ColorProperty))

            ' Create a storyboard to contain the animation.
            myColorAnimatedButtonStoryboard = New Storyboard()
            myColorAnimatedButtonStoryboard.Children.Add(myColorAnimation)

            myStackPanel.Children.Add(myColorAnimatedButton)
            Me.Content = myStackPanel

        End Sub
        
        ' Start the animation when the button is clicked.
        Private Sub myWidthAnimatedButton_Loaded(ByVal sender as object, ByVal args as RoutedEventArgs) Handles myWidthAnimatedButton.Click
        
            myWidthAnimatedButtonStoryboard.Begin(myWidthAnimatedButton)
        
        End Sub        
        
        ' Start the animation when the button is clicked.
        Private Sub myColorAnimatedButton_Loaded(ByVal sender as object, ByVal args as RoutedEventArgs) Handles myColorAnimatedButton.Click
        
            myColorAnimatedButtonStoryboard.Begin(myColorAnimatedButton)
        
        End Sub           
        
    End Class
End Namespace
' </Snippet11>