' <Snippet1>
' Specify /d:DEBUG=True when compiling.

Imports System
Imports System.Data
Imports System.Diagnostics

Class Test

    Shared Sub Main()
    
        Debug.Listeners.Add(New TextWriterTraceListener(Console.Out))
        Debug.AutoFlush = True
        Debug.Indent()
        Debug.WriteLine("Entering Main")
        Console.WriteLine("Hello World.")
        Debug.WriteLine("Exiting Main")
        Debug.Unindent()
        
    End Sub
    
End Class
' </Snippet1>




