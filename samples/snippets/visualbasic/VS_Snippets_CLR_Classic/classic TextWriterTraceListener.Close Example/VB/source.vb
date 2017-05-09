' <Snippet1>
#Const TRACE=True

Imports System
Imports System.IO
Imports System.Diagnostics

Public Class TextWriterTraceListenerSample
   
   Public Shared Sub Main()
      Dim myTextListener As TextWriterTraceListener = Nothing

      ' Create a file for output named TestFile.txt.
      Dim myFileName As String = "TestFile.txt"
      Dim myOutputWriter As New StreamWriter(myFileName, True)
 
      ' Add a TextWriterTraceListener for the file.
      myTextListener = New TextWriterTraceListener(myOutputWriter)
      Trace.Listeners.Add(myTextListener)
     
      ' Write trace output to all trace listeners.
      Trace.WriteLine(DateTime.Now.ToString() + " - Trace output")
      
      ' Remove and close the file writer/trace listener.
      myTextListener.Flush()
      Trace.Listeners.Remove(myTextListener)
      myTextListener.Close()

   End Sub
End Class
' </Snippet1>