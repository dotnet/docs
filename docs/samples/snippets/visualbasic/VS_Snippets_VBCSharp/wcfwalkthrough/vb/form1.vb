Public Class Form1
    ' <Snippet3>
    Private Sub Button1_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Button1.Click
        Dim client As New ServiceReference1.Service1Client
        Dim returnString As String

        returnString = client.GetData(TextBox1.Text)
        Label1.Text = returnString
    End Sub
    ' </Snippet3>
End Class
