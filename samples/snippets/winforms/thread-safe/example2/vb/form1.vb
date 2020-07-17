Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

Public Class BackgroundWorkerForm : Inherits Form

    Public Shared Sub Main()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.EnableVisualStyles()
        Dim frm As New BackgroundWorkerForm()
        Application.Run(frm)
    End Sub

    Dim WithEvents BackgroundWorker1 As BackgroundWorker
    Dim WithEvents Button1 As Button
    Dim TextBox1 As TextBox

    Private Sub New()
        BackgroundWorker1 = New BackgroundWorker()
        Button1 = New Button()
        With Button1
            .Text = "Set text safely with BackgroundWorker"
            .Location = New Point(15, 55)
            .Size = New Size(240, 20)
        End With
        TextBox1 = New TextBox()
        With TextBox1
            .Location = New Point(15, 15)
            .Size = New Size(240, 20)
        End With
        Controls.Add(Button1)
        Controls.Add(TextBox1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) _
     Handles BackgroundWorker1.DoWork
        ' Sleep 2 seconds to emulate getting data.
        Thread.Sleep(2000)
        e.Result = "This text was set safely by BackgroundWorker."
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) _
     Handles BackgroundWorker1.RunWorkerCompleted
        textBox1.Text = e.Result.ToString()
    End Sub
End Class
