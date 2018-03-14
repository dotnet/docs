Imports System.Threading
Imports System.Threading.Tasks

Class MainWindow
    Private Async Sub threadExampleBtn_Click(sender As Object, e As RoutedEventArgs) Handles threadExampleBtn.Click
        textBox1.Text = String.Empty

        textBox1.Text = "Simulating work on UI thread." + vbCrLf
        DoSomeWork(20)
        textBox1.Text += "Work completed..."

        textBox1.Text += "Simulating work on non-UI thread." + vbCrLf
        Await Task.Factory.StartNew(Sub()
                                        DoSomeWork(1000)
                                    End Sub)
        textBox1.Text += "Work completed..." + vbCrLf
    End Sub

    ' <Snippet3>
    Private Async Sub DoSomeWork(milliseconds As Integer)
        ' Simulate work.
        Await Task.Delay(milliseconds)

        ' Report completion.
        Dim uiAccess As Boolean = textBox1.Dispatcher.CheckAccess()
        Dim msg As String = String.Format("Some work completed in {0} ms. on {1}UI thread",
                                          milliseconds, If(uiAccess, String.Empty, "non-")) + 
                                          vbCrLf 
        If uiAccess Then
            textBox1.Text += msg
        Else
            textBox1.Dispatcher.Invoke( Sub() textBox1.Text += msg)
        End If
    End Sub
    ' </Snippet3>
End Class
