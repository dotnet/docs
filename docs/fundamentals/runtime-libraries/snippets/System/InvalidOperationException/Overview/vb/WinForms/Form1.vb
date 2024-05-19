Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    ' <Snippet2>
    Dim lines As New List(Of String)()
    Private Async Sub threadExampleBtn_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = String.Empty
        lines.Clear()

        lines.Add("Simulating work on UI thread.")
        TextBox1.Lines = lines.ToArray()
        DoSomeWork(20)

        lines.Add("Simulating work on non-UI thread.")
        TextBox1.Lines = lines.ToArray()
        Await Task.Run(Sub() DoSomeWork(1000))

        lines.Add("ThreadsExampleBtn_Click completes. ")
        TextBox1.Lines = lines.ToArray()
    End Sub

    Private Async Sub DoSomeWork(milliseconds As Integer)
        ' Simulate work.
        Await Task.Delay(milliseconds)

        ' Report completion.
        lines.Add(String.Format("Some work completed in {0} ms on UI thread.", milliseconds))
        textBox1.Lines = lines.ToArray()
    End Sub
    ' </Snippet2>
End Class
