'<Snippet1>
' Specify /d:TRACE=True when compiling.

Imports System
Imports System.Diagnostics

Class Test
    
    Shared Sub Main()
    
        Trace.Listeners.Add(New TextWriterTraceListener(Console.Out))
        Trace.AutoFlush = True
        Trace.Indent()
        Trace.WriteLine("Entering Main")
        Console.WriteLine("Hello World.")
        Trace.WriteLine("Exiting Main")
        Trace.Unindent()
        
    End Sub 'Main

End Class
'</Snippet1>

