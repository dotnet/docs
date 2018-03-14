'<Snippet31>

#Const TRACE_ON = True
Imports System
Imports System.Diagnostics
Module TestConditionalAttribute
    Public Class Trace
        <Conditional("TRACE_ON")> 
        Public Shared Sub Msg(ByVal msg As String)
            Console.WriteLine(msg)
        End Sub

    End Class

    Sub Main()
        Trace.Msg("Now in Main...")
        Console.WriteLine("Done.")
    End Sub
End Module
'</Snippet31>

Class TestDebug
    '<Snippet32>
    <Conditional("DEBUG")> 
    Shared Sub DebugMethod()

    End Sub
    '</Snippet32>

    '<Snippet33>
#If DEBUG Then
    Sub ConditionalMethod()
    End Sub
#End If
    '</Snippet33>
End Class