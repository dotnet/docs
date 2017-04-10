'<snippet02>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module WaitAllDemo
    Sub Main()
        Dim tasks As New List(Of Task(Of Integer))()
        ' Define a delegate that prints and returns the system tick count
        Dim action As Func(Of Object, Integer) = Function(obj As Object)
                                                     Dim i As Integer = CInt(obj)

                                                     ' Make each thread sleep a different time in order to return a different tick count
                                                     Thread.Sleep(i * 100)

                                                     ' The tasks that receive an argument between 2 and 5 throw exceptions
                                                     If 2 <= i AndAlso i <= 5 Then
                                                         Throw New InvalidOperationException("SIMULATED EXCEPTION")
                                                     End If

                                                     Dim tickCount As Integer = Environment.TickCount
                                                     Console.WriteLine("Task={0}, i={1}, TickCount={2}, Thread={3}", Task.CurrentId, i, tickCount, Thread.CurrentThread.ManagedThreadId)

                                                     Return tickCount
                                                 End Function

        ' Construct started tasks
        For i As Integer = 0 To 9
            Dim index As Integer = i
            tasks.Add(Task(Of Integer).Factory.StartNew(action, index))
        Next

        Try
            ' Wait for all the tasks to finish.
            Task.WaitAll(tasks.ToArray())

            ' We should never get to this point
            Console.WriteLine("WaitAll() has not thrown exceptions. THIS WAS NOT EXPECTED.")
        Catch e As AggregateException
            Console.WriteLine(vbLf & "The following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)")
            For j As Integer = 0 To e.InnerExceptions.Count - 1
                Console.WriteLine(vbLf & "-------------------------------------------------" & vbLf & "{0}", e.InnerExceptions(j).ToString())
            Next
        End Try
    End Sub
End Module
' The example displays output like the following:
'     Task=1, i=0, TickCount=1203822250, Thread=3
'     Task=2, i=1, TickCount=1203822359, Thread=4
'     Task=7, i=6, TickCount=1203823484, Thread=3
'     Task=8, i=7, TickCount=1203823890, Thread=4
'     Task=9, i=8, TickCount=1203824296, Thread=3
'     Task=10, i=9, TickCount=1203824796, Thread=4
'     
'     The following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)
'     
'     -------------------------------------------------
'     System.InvalidOperationException: SIMULATED EXCEPTION
'        at Example.<Main>b__0(Object obj)
'        at System.Threading.Tasks.Task`1.InnerInvoke()
'        at System.Threading.Tasks.Task.Execute()
'     
'     -------------------------------------------------
'     System.InvalidOperationException: SIMULATED EXCEPTION
'        at Example.<Main>b__0(Object obj)
'        at System.Threading.Tasks.Task`1.InnerInvoke()
'        at System.Threading.Tasks.Task.Execute()
'     
'     -------------------------------------------------
'     System.InvalidOperationException: SIMULATED EXCEPTION
'        at Example.<Main>b__0(Object obj)
'        at System.Threading.Tasks.Task`1.InnerInvoke()
'        at System.Threading.Tasks.Task.Execute()
'     
'     -------------------------------------------------
'     System.InvalidOperationException: SIMULATED EXCEPTION
'        at Example.<Main>b__0(Object obj)
'        at System.Threading.Tasks.Task`1.InnerInvoke()
'        at System.Threading.Tasks.Task.Execute()
'</snippet02>