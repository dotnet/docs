' <SnippetRectFadeInOutCodeExampleWholePage>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace SDKSample

    Public Class RectangleOpacityFadeExample
        Inherits Page
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
            myDoubleAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(5000))
            myDoubleAnimation.AutoReverse = True
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever

            Dim myStoryboard As New Storyboard()
            myStoryboard.Children.Add(myDoubleAnimation)
            Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name)
            Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.OpacityProperty))

            Dim myBeginStoryboard As New BeginStoryboard()
            myBeginStoryboard.Storyboard = myStoryboard

            Dim myLoadedEventTrigger As New EventTrigger()
            myLoadedEventTrigger.RoutedEvent = Rectangle.LoadedEvent
            myLoadedEventTrigger.Actions.Add(myBeginStoryboard)

            myRectangle.Triggers.Add(myLoadedEventTrigger)
            myPanel.Children.Add(myRectangle)
            Me.Content = myPanel
        End Sub
    End Class
End Namespace

' </SnippetRectFadeInOutCodeExampleWholePage>