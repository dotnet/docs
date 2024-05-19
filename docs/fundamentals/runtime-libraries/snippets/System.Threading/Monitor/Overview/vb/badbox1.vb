' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Example2
    Public Sub Main()
        Dim nTasks As Integer = 0
        Dim o As Object = nTasks
        Dim tasks As New List(Of Task)()

        Try
            For ctr As Integer = 0 To 9
                tasks.Add(Task.Run(Sub()
                                       ' Instead of doing some work, just sleep.
                                       Thread.Sleep(250)
                                       ' Increment the number of tasks.
                                       Monitor.Enter(o)
                                       Try
                                           nTasks += 1
                                       Finally
                                           Monitor.Exit(o)
                                       End Try
                                   End Sub))
            Next
            Task.WaitAll(tasks.ToArray())
            Console.WriteLine("{0} tasks started and executed.", nTasks)
        Catch e As AggregateException
            Dim msg As String = String.Empty
            For Each ie In e.InnerExceptions
                Console.WriteLine("{0}", ie.GetType().Name)
                If Not msg.Contains(ie.Message) Then
                    msg += ie.Message + Environment.NewLine
                End If
            Next
            Console.WriteLine(vbCrLf + "Exception Message(s):")
            Console.WriteLine(msg)
        End Try
    End Sub
End Module
' The example displays the following output:
'       10 tasks started and executed.
' </Snippet3>

