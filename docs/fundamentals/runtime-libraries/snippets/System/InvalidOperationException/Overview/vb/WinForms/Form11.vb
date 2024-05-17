Imports System.Collections.Generic
Imports System.Threading.Tasks

Public Class Form11

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

    ' <Snippet5>
    Private Async Sub DoSomeWork(milliseconds As Integer)
        ' Simulate work.
        Await Task.Delay(milliseconds)

        ' Report completion.
        Dim uiMarshal As Boolean = TextBox1.InvokeRequired
        Dim msg As String = String.Format("Some work completed in {0} ms. on {1}UI thread" + vbCrLf,
                                          milliseconds, If(uiMarshal, String.Empty, "non-"))
        lines.Add(msg)

        If uiMarshal Then
            TextBox1.Invoke(New Action(Sub() TextBox1.Lines = lines.ToArray()))
        Else
            TextBox1.Lines = lines.ToArray()
        End If
    End Sub
    ' </Snippet5>
End Class
