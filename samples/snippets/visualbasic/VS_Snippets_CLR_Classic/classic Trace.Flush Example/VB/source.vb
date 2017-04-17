' <Snippet1>
' Specify /d:TRACE=True when compiling.

Imports System
Imports System.IO
Imports System.Diagnostics

Class Test
    
    Shared Sub Main()
    
        ' Create a file for output named TestFile.txt.
        Using myFileStream As New FileStream("TestFile.txt", FileMode.Append)
        
            ' Create a new text writer using the output stream
            ' and add it to the trace listeners. 
            Dim myTextListener As New TextWriterTraceListener(myFileStream)
            Trace.Listeners.Add(myTextListener)
            
            ' Write output to the file.
            Trace.WriteLine("Test output")
            
            ' Flush and close the output stream.
            Trace.Flush()
            Trace.Close()
        
        End Using
        
    End Sub 'Main

End Class
' </Snippet1>
