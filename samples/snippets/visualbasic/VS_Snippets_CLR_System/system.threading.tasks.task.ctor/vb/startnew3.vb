' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections.Generic
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim tasks As New List(Of Task)()
      Dim rnd As New Random()
      Dim lockObj As New Object()
      Dim words6() As String = { "reason", "editor", "rioter", "rental",
                                 "senior", "regain", "ordain", "rained" }

      For Each word6 in words6
         Dim t As New Task( Sub(word)
                               Dim chars() As Char = word.ToString().ToCharArray()
                               Dim order(chars.Length - 1) As Double
                               SyncLock lockObj
                                  For ctr As Integer = 0 To order.Length - 1
                                     order(ctr) = rnd.NextDouble()
                                  Next
                               End SyncLock
                               Array.Sort(order, chars)
                               Console.WriteLine("{0} --> {1}", word,
                                                 New String(chars))
                            End Sub, word6)
         t.Start()
         tasks.Add(t)
      Next
      Task.WaitAll(tasks.ToArray())
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
' </Snippet3>

