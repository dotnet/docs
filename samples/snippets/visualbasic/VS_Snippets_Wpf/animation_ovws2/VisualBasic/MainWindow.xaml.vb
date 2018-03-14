'<SnippetRectangleOpacityFadeExampleCode>
Imports System.Windows.Media.Animation

'<SnippetRectangleOpacityFadeExampleCode_100>
Class MainWindow

    Private myStoryboard As Storyboard
    '</SnippetRectangleOpacityFadeExampleCode_100>

    Public Sub New()
        InitializeComponent()

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
        myDoubleAnimation.Duration = New Duration(TimeSpan.FromSeconds(5))
        myDoubleAnimation.AutoReverse = True
        myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever

        '<SnippetRectangleOpacityFadeExampleCode_101>
        myStoryboard = New Storyboard()
        myStoryboard.Children.Add(myDoubleAnimation)
        '</SnippetRectangleOpacityFadeExampleCode_101>
        '<SnippetRectangleOpacityFadeExampleCode_102>
        Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name)
        '</SnippetRectangleOpacityFadeExampleCode_102>
        '<SnippetRectangleOpacityFadeExampleCode_103>
        Storyboard.SetTargetProperty(myDoubleAnimation, New PropertyPath(Rectangle.OpacityProperty))
        '</SnippetRectangleOpacityFadeExampleCode_103>

        ' Use the Loaded event to start the Storyboard.
        '<SnippetRectangleOpacityFadeExampleCode_104>
        AddHandler myRectangle.Loaded, AddressOf myRectangleLoaded
        '</SnippetRectangleOpacityFadeExampleCode_104>

        myPanel.Children.Add(myRectangle)
        Me.Content = myPanel
    End Sub

    '<SnippetRectangleOpacityFadeExampleCode_105>
    Private Sub myRectangleLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        myStoryboard.Begin(Me)
    End Sub
    '</SnippetRectangleOpacityFadeExampleCode_105>

End Class
'</SnippetRectangleOpacityFadeExampleCode>
