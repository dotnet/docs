'<snippet2>
Imports System
Imports System.Diagnostics

Public Class MyConsoleApp

    Public Shared Sub Main()

        Dim myApp As New MyConsoleApp()
        myApp.MyPublicSub()

    End Sub

    Public Shared Sub MyPublicSub()
        Dim helperClass As New MyInnerClass()
        helperClass.ThrowsException()
    End Sub


End Class

Class MyInnerClass
    Sub ThrowsException()
        Try
            Throw New Exception("A problem was encountered.")

        Catch e As Exception
            ' Create a StackTrace starting at the next level
            ' stack frame.  Skip the first frame, the frame of
            ' this level, which hides the internal implementation
            ' of the ThrowsException method.  Include the line
            ' number, file name, and column number information
            ' for each frame.
            '<snippet3>
            Dim strace As New StackTrace(1, True)
            Dim stFrames As StackFrame() = strace.GetFrames()

            Dim sf As StackFrame
            For Each sf In  stFrames
               Console.WriteLine("Method: {0}", sf.GetMethod())
            Next sf
            '</snippet3>

        End Try

    End Sub

End Class

' This console application produces the following output
' when compiled with optimization off.
'
' Note that the ThrowsException() method is not identified in
' this stack trace.
'
'   Method: Void MyPublicSub()
'   Method: Void Main()
'
'</snippet2>
