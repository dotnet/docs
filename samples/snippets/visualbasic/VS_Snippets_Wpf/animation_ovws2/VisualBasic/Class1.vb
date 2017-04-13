Imports System.Windows.Media.Animation

Public Class Class1
    Inherits Window

    Private Sub CreateRectangle()
        '<SnippetRectangleOpacityFadeExampleCode_1>
        Dim myPanel As StackPanel = New StackPanel
        myPanel.Margin = New Thickness(10)

        Dim myRectangle As Rectangle = New Rectangle
        myRectangle.Name = "myRectangle"
        Me.RegisterName(myRectangle.Name, myRectangle)
        myRectangle.Width = 100
        myRectangle.Height = 100
        myRectangle.Fill = Brushes.Blue

        myPanel.Children.Add(myRectangle)
        Me.Content = myPanel
        '</SnippetRectangleOpacityFadeExampleCode_1>
    End Sub

    Private Sub CreateDoubleAnimation()
        '<SnippetRectangleOpacityFadeExampleCode_2>
        Dim myDoubleAnimation As DoubleAnimation = New DoubleAnimation()
        myDoubleAnimation.From = 1.0
        myDoubleAnimation.To = 0.0
        '</SnippetRectangleOpacityFadeExampleCode_2>
        '<SnippetRectangleOpacityFadeExampleCode_3>
        myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(5))
        '</SnippetRectangleOpacityFadeExampleCode_3>
        '<SnippetRectangleOpacityFadeExampleCode_4>
        myDoubleAnimation.AutoReverse = True
        myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever
        '</SnippetRectangleOpacityFadeExampleCode_4>
    End Sub
End Class
