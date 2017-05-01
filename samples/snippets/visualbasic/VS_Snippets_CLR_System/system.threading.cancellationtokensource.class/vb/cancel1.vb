' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      ' Define the cancellation token.
      Dim source As New CancellationTokenSource()
      Dim token As CancellationToken = source.Token

      Dim lockObj As New Object()
      Dim rnd As New Random

      Dim tasks As New List(Of Task(Of Integer()))
      Dim factory As New TaskFactory(token)
      For taskCtr As Integer = 0 To 10
         Dim iteration As Integer = taskCtr + 1
         tasks.Add(factory.StartNew(Function()
                                       Dim value, values(9) As Integer
                                       For ctr As Integer = 1 To 10
                                          SyncLock lockObj
                                             value = rnd.Next(0,101)
                                          End SyncLock
                                          If value = 0 Then 
                                             source.Cancel
                                             Console.WriteLine("Cancelling at task {0}", iteration)
                                             Exit For
                                          End If   
                                          values(ctr-1) = value 
                                       Next
                                       Return values
                                    End Function, token))   
         
      Next
      Try
         Dim fTask As Task(Of Double) = factory.ContinueWhenAll(tasks.ToArray(), 
                                                         Function(results)
                                                            Console.WriteLine("Calculating overall mean...")
                                                            Dim sum As Long
                                                            Dim n As Integer 
                                                            For Each t In results
                                                               For Each r In t.Result
                                                                  sum += r
                                                                  n+= 1
                                                               Next
                                                            Next
                                                            Return sum/n
                                                         End Function, token)
         Console.WriteLine("The mean is {0}.", fTask.Result)
      Catch ae As AggregateException
         For Each e In ae.InnerExceptions
            If TypeOf e Is TaskCanceledException
               Console.WriteLine("Unable to compute mean: {0}", 
                                 CType(e, TaskCanceledException).Message)
            Else
               Console.WriteLine("Exception: " + e.GetType().Name)
            End If   
         Next
      Finally
         source.Dispose()
      End Try                                                          
   End Sub
End Module
' Repeated execution of the example produces output like the following:
'       Cancelling at task 5
'       Unable to compute mean: A task was canceled.
'       
'       Cancelling at task 10
'       Unable to compute mean: A task was canceled.
'       
'       Calculating overall mean...
'       The mean is 5.29545454545455.
'       
'       Cancelling at task 4
'       Unable to compute mean: A task was canceled.
'       
'       Cancelling at task 5
'       Unable to compute mean: A task was canceled.
'       
'       Cancelling at task 6
'       Unable to compute mean: A task was canceled.
'       
'       Calculating overall mean...
'       The mean is 4.97363636363636.
'       
'       Cancelling at task 4
'       Unable to compute mean: A task was canceled.
'       
'       Cancelling at task 5
'       Unable to compute mean: A task was canceled.
'       
'       Cancelling at task 4
'       Unable to compute mean: A task was canceled.
'       
'       Calculating overall mean...
'       The mean is 4.86545454545455.
' </Snippet1>
