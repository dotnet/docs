' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports Windows.UI.Core


''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>

Public NotInheritable Class MainPage
    Inherits Page


    ' <Snippet4>
    Private Async Sub DoSomeWork(milliseconds As Integer)
        ' Simulate work.
        Await Task.Delay(milliseconds)

        ' Report completion.
        Dim uiAccess As Boolean = textBox1.Dispatcher.HasThreadAccess
        Dim msg As String = String.Format("Some work completed in {0} ms. on {1}UI thread" + vbCrLf,
                                          milliseconds, If(uiAccess, String.Empty, "non-"))
        If (uiAccess) Then
            textBox1.Text += msg
        Else
            Await textBox1.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, Sub() textBox1.Text += msg)
        End If
    End Sub
    ' </Snippet4>

    Private Async Sub threadExampleBtn_Click(sender As Object, e As RoutedEventArgs) ' Handles threadExampleBtn.Click
        textBox1.Text = String.Empty

        textBox1.Text = "Simulating work on UI thread." + vbCrLf
        DoSomeWork(20)
        textBox1.Text += "Work completed..." + vbCrLf

        textBox1.Text += "Simulating work on non-UI thread." + vbCrLf
        Await Task.Run(Sub() DoSomeWork(1000))
        textBox1.Text += "Work completed.." + vbCrLf

    End Sub
End Class
