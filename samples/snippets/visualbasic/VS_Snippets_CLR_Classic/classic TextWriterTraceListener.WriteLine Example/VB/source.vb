Imports System
Imports System.Diagnostics

' <Snippet1>
Public Class Sample
    
    Public Shared Sub Main()
        ' Create a text writer that writes to the console screen and add
        ' it to the trace listeners 
        Dim myWriter As New TextWriterTraceListener()
        myWriter.Writer = System.Console.Out
        Trace.Listeners.Add(myWriter)
        
        ' Write the output to the console screen.
        myWriter.Write("Write to the Console screen. ")
        myWriter.WriteLine("Again, write to console screen.")
        
        ' Flush and close the output.
        myWriter.Flush()
        myWriter.Close()
    End Sub

End Class
' </Snippet1>

