' <Snippet2> 
Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Threading

Namespace Samples.AspNet.VB.Controls

    Public Class MyAsyncTask

        Private _taskprogress As String
        Private _dlgt As AsyncTaskDelegate

        ' Create delegate.
        Delegate Function AsyncTaskDelegate()

        Public Function GetAsyncTaskProgress() As String
            Return _taskprogress
        End Function

        Public Function DoTheAsyncTask()

            ' Introduce an artificial delay to simulate a delayed 
            ' asynchronous task. Make this greater than the 
            ' AsyncTimeout property.
            Thread.Sleep(TimeSpan.FromSeconds(5.0))

        End Function


        ' Define the method that will get called to
        ' start the asynchronous task.
        Public Function OnBegin(ByVal sender As Object, ByVal e As EventArgs, ByVal cb As AsyncCallback, ByVal extraData As Object) As IAsyncResult

            _taskprogress = "Beginning async task."

            Dim _dlgt As New AsyncTaskDelegate(AddressOf DoTheAsyncTask)
            Dim result As IAsyncResult = _dlgt.BeginInvoke(cb, extraData)
            Return result

        End Function 'OnBegin

        ' Define the method that will get called when
        ' the asynchronous task is ended.
        Public Sub OnEnd(ByVal ar As IAsyncResult)

            _taskprogress = "Asynchronous task completed."
            _dlgt.EndInvoke(ar)

        End Sub

        ' Define the method that will get called if the task
        ' is not completed within the asynchronous timeout interval.
        Public Sub OnTimeout(ByVal ar As IAsyncResult)

            _taskprogress = "Ansynchronous task failed to complete because " & _
            "it exceeded the AsyncTimeout parameter."

        End Sub

    End Class

End Namespace

' </Snippet2> 
