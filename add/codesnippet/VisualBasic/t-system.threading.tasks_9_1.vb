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