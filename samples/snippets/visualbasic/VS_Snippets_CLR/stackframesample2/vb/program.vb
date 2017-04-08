'<Snippet1>
Imports System
Imports System.Diagnostics



Class Program

    Shared Sub Main(ByVal args() As String)
        Try
            Method1()
        Catch e As Exception
            Dim st As New StackTrace()
            Dim st1 As New StackTrace(New StackFrame(True))
            Console.WriteLine(" Stack trace for Main: {0}", st1.ToString())
            Console.WriteLine(st.ToString())
        End Try
        Console.WriteLine("Press Enter to exit.")
        Console.ReadLine()

    End Sub 'Main

    Private Shared Sub Method1()
        Try
            Method2(4)
        Catch e As Exception
            Dim st As New StackTrace()
            Dim st1 As New StackTrace(New StackFrame(True))
            Console.WriteLine(" Stack trace for Method1: {0}", st1.ToString())
            Console.WriteLine(st.ToString())
            ' Build a stack trace for the next frame.
            Dim st2 As New StackTrace(New StackFrame(1, True))
            Console.WriteLine(" Stack trace for next level frame: {0}", st2.ToString())
            Throw e
        End Try

    End Sub 'Method1

    Private Shared Sub Method2(ByVal count As Integer)
        Try
            If count < 5 Then
                Throw New ArgumentException("count too large", "count")
            End If
        Catch e As Exception
            Dim st As New StackTrace()
            Dim st1 As New StackTrace(New StackFrame(2, True))
            Console.WriteLine(" Stack trace for Method2: {0}", st1.ToString())
            Console.WriteLine(st.ToString())
            Throw e
        End Try

    End Sub 'Method2
End Class 'Program
'</Snippet1>