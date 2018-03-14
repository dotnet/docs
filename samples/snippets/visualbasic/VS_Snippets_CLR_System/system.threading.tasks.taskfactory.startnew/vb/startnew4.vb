' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim cts As New CancellationTokenSource()
      Dim token As CancellationToken = cts.Token
      Dim tasks As New List(Of Task)()
      Dim rnd As New Random()
      Dim lockObj As New Object()
      Dim words6() As String = { "reason", "editor", "rioter", "rental",
                                 "senior", "regain", "ordain", "rained" }

      For Each word6 in words6
         tasks.Add(Task.Factory.StartNew( Sub(word)
                                              Dim chars() As Char = word.ToString().ToCharArray()
                                              Dim order(chars.Length - 1) As Double
                                              Dim wasZero As Boolean = False
                                              SyncLock lockObj
                                                 For ctr As Integer = 0 To order.Length - 1
                                                    order(ctr) = rnd.NextDouble()
                                                    If order(ctr) = 0 Then
                                                       If Not wasZero Then
                                                          wasZero = True
                                                       Else
                                                          cts.Cancel()
                                                       End If
                                                    End If
                                                 Next
                                              End SyncLock
                                              token.ThrowIfCancellationRequested()
                                              Array.Sort(order, chars)
                                              Console.WriteLine("{0} --> {1}", word,
                                                                new String(chars))
                                          End Sub, word6))
      Next
      Try
         Task.WaitAll(tasks.ToArray())
      Catch e As AggregateException
         For Each ie In e.InnerExceptions
            If TypeOf ie Is OperationCanceledException
               Console.WriteLine("The word scrambling operation has been cancelled.")
               Exit For
            Else
               Console.WriteLine(ie.GetType().Name + ": " + ie.Message)
            End If
         Next
      Finally
         cts.Dispose()
      End Try
   End Sub
End Module
' The example displays output like the following:
'       regain --> irnaeg
'       ordain --> rioadn
'       reason --> soearn
'       rained --> rinade
'       rioter --> itrore
'       senior --> norise
'       rental --> atnerl
'       editor --> oteird
' </Snippet4>

