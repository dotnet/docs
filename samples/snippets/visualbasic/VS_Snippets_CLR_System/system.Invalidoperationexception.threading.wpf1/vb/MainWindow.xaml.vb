Imports System.Threading
Imports System.Threading.Tasks

Class MainWindow
    ' <Snippet1>
    Private Async Sub threadExampleBtn_Click(sender As Object, e As RoutedEventArgs) Handles threadExampleBtn.Click
        textBox1.Text = String.Empty

        textBox1.Text = "Simulating work on UI thread." + vbCrLf
        DoSomeWork(20)
        textBox1.Text += "Work completed..." + vbCrLf

        textBox1.Text += "Simulating work on non-UI thread." + vbCrLf
        Await Task.Factory.StartNew(Sub()
                                        DoSomeWork(1000)
                                    End Sub)
        textBox1.Text += "Work completed..." + vbCrLf
    End Sub

    Private Async Sub DoSomeWork(milliseconds As Integer)
        ' Simulate work.
        Await Task.Delay(milliseconds)

        ' Report completion.
        Dim msg = String.Format("Some work completed in {0} ms.", milliseconds) + vbCrLf
        textBox1.Text += msg
    End Sub
    ' </Snippet1>
End Class
