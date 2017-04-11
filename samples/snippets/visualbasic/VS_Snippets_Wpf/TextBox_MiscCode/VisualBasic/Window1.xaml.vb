' Interaction logic for Window1.xaml
Partial Public Class Window1
    Inherits Window

    Public Sub New()
        InitializeComponent()
    End Sub

    Sub MoveCursorToStart()
        ' <Snippet_CursorToStart>
        tbPositionCursor.Select(0, 0)
        ' </Snippet_CursorToStart>
    End Sub

    Sub MoveCursorToEnd()
        ' <Snippet_CursorToEnd>
        tbPositionCursor.Select(tbPositionCursor.Text.Length, 0)
        ' </Snippet_CursorToEnd>
    End Sub


    ' <Snippet_TextChangedEventHandler>
    ' TextChangedEventHandler delegate method.
    Private Sub textChangedEventHandler(ByVal sender As Object, ByVal args As TextChangedEventArgs)
        ' Omitted Code: Insert code that does something whenever
        ' the text changes...
    End Sub
    ' </Snippet_TextChangedEventHandler>

    ' <Snippet_SelectText>
    Private Sub OnClick(ByVal senter As Object, ByVal e As RoutedEventArgs)
        Dim sSelectedText As String = tbSelectSomeText.SelectedText
    End Sub
    ' </Snippet_SelectText>

    Sub FocusTextBox()
        ' <Snippet_FocusTextBox>
        tbFocusMe.Focus()
        ' </Snippet_FocusTextBox>
    End Sub

    Sub TextBoxSetText()
        ' <Snippet_TextBoxSetText>
        tbSettingText.Text = "Initial text contents of the TextBox."
        ' </Snippet_TextBoxSetText>
    End Sub

End Class
