'<SnippetAddItemLogic> 
Imports System.Windows
Imports System.Windows.Controls

Partial Public Class AddItemWindow
    Inherits Window
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Submit_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        DialogResult = True
        Close()
    End Sub

    ' Select all text when the TextBox gets focus. 
    Private Sub TextBoxFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim tbx As TextBox = TryCast(sender, TextBox)

        tbx.SelectAll()
    End Sub
End Class
'</SnippetAddItemLogic> 