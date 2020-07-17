Imports System.IO
Imports System.Text

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>

Partial Public Class MainWindow
    Inherits Window
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Async Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim charsRead As Char() = New Char(UserInput.Text.Length) {}
        Using reader As StringReader = New StringReader(UserInput.Text)
            Await reader.ReadAsync(charsRead, 0, UserInput.Text.Length)
        End Using

        Dim reformattedText As StringBuilder = New StringBuilder()
        Using writer As StringWriter = New StringWriter(reformattedText)
            For Each c As Char In charsRead
                If Char.IsLetter(c) Or Char.IsWhiteSpace(c) Then
                    Await writer.WriteLineAsync(Char.ToLower(c))
                End If
            Next
        End Using
        Result.Text = reformattedText.ToString()
    End Sub
End Class
