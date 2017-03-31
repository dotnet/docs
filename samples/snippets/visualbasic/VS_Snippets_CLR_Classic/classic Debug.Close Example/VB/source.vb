' <Snippet1>
' Specify /d:DEBUG=True when compiling.

Imports System
Imports System.IO
Imports System.Diagnostics

Class Test
    
    Shared Sub Main()
    
        ' Create a new stream object for an output file named TestFile.txt.
        Using myFileStream As New FileStream("TestFile.txt", FileMode.Append)
        
            ' Add the stream object to the trace listeners. 
            Dim myTextListener As New TextWriterTraceListener(myFileStream)
            Debug.Listeners.Add(myTextListener)
            
            ' Write output to the file.
            Debug.WriteLine("Test output")
            
            ' Flush and close the output stream.
            Debug.Flush()
            Debug.Close()
        
        End Using
        
    End Sub 'Main

End Class
' </Snippet1>
