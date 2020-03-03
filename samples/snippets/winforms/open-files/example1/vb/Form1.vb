Imports System.Drawing
Imports System.IO
Imports System.Security
Imports System.Windows.Forms

Public Class OpenFileDialogForm : Inherits Form

    Public Shared Sub Main()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.EnableVisualStyles()
        Dim frm As New OpenFileDialogForm()
        Application.Run(frm)
    End Sub

    Dim WithEvents SelectButton As Button
    Dim openFileDialog1 As OpenFileDialog
    Dim TextBox1 As TextBox

    Private Sub New()
        ClientSize = New Size(400, 400)
        openFileDialog1 = New OpenFileDialog()
        SelectButton = New Button()
        With SelectButton
            .Text = "Select file"
            .Location = New Point(15, 15)
            .Size = New Size(100, 25)
        End With
        TextBox1 = New TextBox()
        With TextBox1
            .Size = New Size(300, 300)
            .Location = New Point(15, 50)
            .Multiline = True
            .ScrollBars = ScrollBars.Vertical
        End With
        Controls.Add(SelectButton)
        Controls.Add(TextBox1)
    End Sub

    Private Sub SetText(text)
        TextBox1.Text = text
    End Sub

    Public Sub SelectButton_Click(sender As Object, e As EventArgs) _
              Handles SelectButton.Click
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim sr As New StreamReader(openFileDialog1.FileName)
                SetText(sr.ReadToEnd())
            Catch SecEx As SecurityException
                MessageBox.Show($"Security error:{vbCrLf}{vbCrLf}{SecEx.Message}{vbCrLf}{vbCrLf}" &
                $"Details:{vbCrLf}{vbCrLf}{SecEx.StackTrace}")
            End Try
        End If
    End Sub
End Class
