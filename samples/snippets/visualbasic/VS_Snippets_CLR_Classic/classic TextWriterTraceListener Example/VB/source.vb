Imports System
Imports System.IO
Imports System.Diagnostics

' <Snippet1>
Public Class Sample
    
    Public Shared Sub Main()
        ' Create a file for output named TestFile.txt.
        Dim myFile As Stream = File.Create("TestFile.txt")
        
        ' Create a new text writer using the output stream, and add it to
        ' the trace listeners. 
        Dim myTextListener As New TextWriterTraceListener(myFile)
        Trace.Listeners.Add(myTextListener)

        
        ' Write output to the file.
        Trace.Write("Test output ")
        
        ' Flush the output.
        Trace.Flush() 

        System.Environment.ExitCode = 0
    End Sub

End Class

' </Snippet1>