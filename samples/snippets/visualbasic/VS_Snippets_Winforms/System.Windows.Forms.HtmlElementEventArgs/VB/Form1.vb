Public Class Form1

    Dim WithEvents Doc As HtmlDocument

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        webBrowser1.Url = New Uri("D:\HtmlElementEventArgsProject\TestTable.htm")
    End Sub


    Private Sub webBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles webBrowser1.DocumentCompleted
        Doc = webBrowser1.Document
    End Sub

    '<SNIPPET2>
    Private Sub HtmlDocument_Click(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
        Dim doc As HtmlDocument = webBrowser1.Document
        Dim msg As String = "ClientMousePosition: " & e.ClientMousePosition.ToString() & vbCrLf & _
            "MousePosition: " & e.MousePosition.ToString() & vbCrLf & _
            "OffsetMousePosition: " & e.OffsetMousePosition.ToString()
        MessageBox.Show(msg)
    End Sub
    '</SNIPPET2>
End Class
