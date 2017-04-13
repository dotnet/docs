' <Snippet2> 
Imports Microsoft.VisualBasic
Imports System.Threading

Namespace Samples.AspNet.VB.Controls

    Public Class SlowTask
        Private _taskprogress As String
        Private _dlgt As AsyncTaskDelegate

        ' Create delegate.
        Protected Delegate Sub AsyncTaskDelegate()

        Public Function GetAsyncTaskProgress() As String
            Return _taskprogress
        End Function

        Public Sub ExecuteAsyncTask()
            ' Introduce an artificial delay to simulate a delayed 
            ' asynchronous task.
            Thread.Sleep(TimeSpan.FromSeconds(5.0))
        End Sub

        ' Define the method that will get called to
        ' start the asynchronous task.
        Public Function OnBegin(ByVal sender As Object, ByVal e As EventArgs, ByVal cb As AsyncCallback, ByVal extraData As Object) As IAsyncResult
            _taskprogress = "AsyncTask started at: " + DateTime.Now.ToString + ". "

            _dlgt = New AsyncTaskDelegate(AddressOf ExecuteAsyncTask)
            Dim result As IAsyncResult = _dlgt.BeginInvoke(cb, extraData)

            Return result
        End Function

        ' Define the method that will get called when
        ' the asynchronous task is ended.
        Public Sub OnEnd(ByVal ar As IAsyncResult)
            _taskprogress += "AsyncTask completed at: " + DateTime.Now.ToString
            _dlgt.EndInvoke(ar)
        End Sub


        ' Define the method that will get called if the task
        ' is not completed within the asynchronous timeout interval.
        Public Sub OnTimeout(ByVal ar As IAsyncResult)
            _taskprogress += "AsyncTask failed to complete " + _
                "because it exceeded the AsyncTimeout parameter."
        End Sub
    End Class
End Namespace
' </Snippet2> 
