' <snippet2>
Imports System
Imports System.Diagnostics

Class TraceIntroExample
    Public Shared Sub Main()
        '/ <snippet3>
        Trace.WriteLine("Hello World!")
        Debug.WriteLine("Hello World!")
        ' </snippet3>

       ' <snippet4>
       Dim errorFlag As Boolean = False
       Trace.WriteLine("Error in AppendData procedure.")
       Trace.WriteLineIf(errorFlag, "Error in AppendData procedure.")
       ' </snippet4>
    End Sub
End Class
' </snippet2>
