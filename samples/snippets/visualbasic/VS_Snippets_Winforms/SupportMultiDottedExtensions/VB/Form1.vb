'<SNIPPET1>
Imports System.IO
Imports System.Text

Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.SaveFileDialog1.SupportMultiDottedExtensions = True
        Me.SaveFileDialog1.Filter = "Data text files|*.data.txt"
        Me.SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Try
            Dim MyFile As StreamWriter = New StreamWriter(Me.SaveFileDialog1.OpenFile(), Encoding.Unicode)
            MyFile.WriteLine("Hello, world!")
            MyFile.Close()
        Catch ex As Exception
            MessageBox.Show("Error: Could not write file. Please try again later. Error message: " & ex.Message, "Error Writing File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class
'</SNIPPET1>
