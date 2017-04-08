' <Snippet1>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim cts As New CancellationTokenSource()
      Dim factory As New TaskFactory(cts.Token,
                                     TaskCreationOptions.PreferFairness,
                                     TaskContinuationOptions.ExecuteSynchronously,
                                     New CustomScheduler())

      Dim t2 = factory.StartNew(Sub() DoWork())
      cts.Dispose()
   End Sub

   Sub DoWork()
      ' ...
   End Sub
End Module
' </snippet1>

Class CustomScheduler : Inherits TaskScheduler

        Protected Overrides Function GetScheduledTasks() As IEnumerable(Of Task)

            Throw New NotImplementedException()

        End Function
        Protected Overrides Sub QueueTask(ByVal t As Task)

            Throw New NotImplementedException()
        End Sub

        Protected Overrides Function TryExecuteTaskInline(ByVal t As Task, ByVal taskWasPreviouslyQueued As Boolean) As Boolean

            Throw New NotImplementedException()
        End Function
    End Class
