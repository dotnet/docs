Imports System

Public Class CallerInfo

    '<Snippet51>
    Private Sub DoProcessing()
        TraceMessage("Something happened.")
    End Sub

    Public Sub TraceMessage(message As String,
            <System.Runtime.CompilerServices.CallerMemberName> Optional memberName As String = Nothing,
            <System.Runtime.CompilerServices.CallerFilePath> Optional sourcefilePath As String = Nothing,
            <System.Runtime.CompilerServices.CallerLineNumber()> Optional sourceLineNumber As Integer = 0)

        System.Diagnostics.Trace.WriteLine("message: " & message)
        System.Diagnostics.Trace.WriteLine("member name: " & memberName)
        System.Diagnostics.Trace.WriteLine("source file path: " & sourcefilePath)
        System.Diagnostics.Trace.WriteLine("source line number: " & sourceLineNumber)
    End Sub

    ' Sample output:
    '   message: Something happened.
    '   member name: DoProcessing
    '   source file path: C:\Users\username\Documents\Visual Studio 2012\Projects\CallerInfoVB\CallerInfoVB\Form1.vb
    '   source line number: 15
    '</Snippet51>


End Class
