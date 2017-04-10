' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections.Generic
Imports System.Net.NetworkInformation
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim failed As Integer = 0
      Dim tasks As New List(Of Task)()
      Dim urls() As String = { "www.adatum.com", "www.cohovineyard.com",
                              "www.cohowinery.com", "www.northwindtraders.com",
                              "www.contoso.com" }
      
      For Each value In urls
         Dim url As String = value
         tasks.Add(Task.Run( Sub()
                                Dim png As New Ping()
                                Try
                                   Dim reply = png.Send(url)
                                   If Not reply.Status = IPStatus.Success Then
                                      Interlocked.Increment(failed)
                                      Throw New TimeoutException("Unable to reach " + url + ".")
                                   End If
                                   Catch e As PingException
                                      Interlocked.Increment(failed)
                                      Throw
                                   End Try
                             End Sub))
      Next
      Dim t As Task = Task.WhenAll(tasks.ToArray())
      Try
         t.Wait()
      Catch
      End Try   

      If t.Status = TaskStatus.RanToCompletion
         Console.WriteLine("All ping attempts succeeded.")
      ElseIf t.Status = TaskStatus.Faulted
         Console.WriteLine("{0} ping attempts failed", failed)      
      End If
   End Sub
End Module
' The example displays output like the following:
'     5 ping attempts failed
' </Snippet3>
