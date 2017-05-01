' System.Diagnostics
'
' Requires .NET Framework version 1.2 or higher.
'

' The following example uses the sort command to sort a list
' of input text lines, and displays the sorted list to the console. 


'<Snippet1>
' Define the namespaces used by this sample.
Imports System
Imports System.Text
Imports System.IO
Imports System.Diagnostics
Imports System.Threading
Imports System.ComponentModel
Imports Microsoft.VisualBasic

Namespace ProcessAsyncStreamSamples
   
   Class ProcessAsyncOutputRedirection
      ' Define static variables shared by class methods.
      Private Shared sortOutput As StringBuilder = Nothing
      Private Shared numOutputLines As Integer = 0
      
      Public Shared Sub SortInputListText()
         
         ' Initialize the process and its StartInfo properties.
         ' The sort command is a console application that
         ' reads and sorts text input.
         Dim sortProcess As New Process()
         sortProcess.StartInfo.FileName = "Sort.exe"
         
         ' Set UseShellExecute to false for redirection.
         sortProcess.StartInfo.UseShellExecute = False
         
         ' Redirect the standard output of the sort command.  
         ' Read the stream asynchronously using an event handler.
         sortProcess.StartInfo.RedirectStandardOutput = True
         sortOutput = new StringBuilder()

         ' Set our event handler to asynchronously read the sort output.
         AddHandler sortProcess.OutputDataReceived, _
                    AddressOf SortOutputHandler
         
         ' Redirect standard input as well.  This stream
         ' is used synchronously.
         sortProcess.StartInfo.RedirectStandardInput = True
         
         ' Start the process.
         sortProcess.Start()
         
         ' Use a stream writer to synchronously write the sort input.
         Dim sortStreamWriter As StreamWriter = sortProcess.StandardInput
     
         ' Start the asynchronous read of the sort output stream.
         sortProcess.BeginOutputReadLine()
         
         ' Prompt the user for input text lines.  Write each 
         ' line to the redirected input stream of the sort command.
         Console.WriteLine("Ready to sort up to 50 lines of text")
         
         Dim inputText As String
         Dim numInputLines As Integer = 0
         Do
            Console.WriteLine("Enter a text line (or press the Enter key to stop):")
            
            inputText = Console.ReadLine()
            If Not String.IsNullOrEmpty(inputText) Then
               numInputLines += 1
               sortStreamWriter.WriteLine(inputText)
            End If
         Loop While Not String.IsNullOrEmpty(inputText) AndAlso numInputLines < 50
         Console.WriteLine("<end of input stream>")
         Console.WriteLine()
         
         ' End the input stream to the sort command.
         sortStreamWriter.Close()
         
         ' Wait for the sort process to write the sorted text lines.
         sortProcess.WaitForExit()
         
         If Not String.IsNullOrEmpty(numOutputLines) Then
            ' Write the formatted and sorted output to the console.
            Console.WriteLine(" Sort results = {0} sorted text line(s) ", _
                              numOutputLines)
            Console.WriteLine("----------")
            Console.WriteLine(sortOutput)
         Else
            Console.WriteLine(" No input lines were sorted.")
         End If
         
         sortProcess.Close()
      End Sub 
      
      Private Shared Sub SortOutputHandler(sendingProcess As Object, _
         outLine As DataReceivedEventArgs)

         ' Collect the sort command output.
         If Not String.IsNullOrEmpty(outLine.Data) Then
            numOutputLines += 1
            
            ' Add the text to the collected output.
            sortOutput.Append(Environment.NewLine + "[" _
                         + numOutputLines.ToString() + "] - " _
                         + outLine.Data)
         End If
      End Sub 
   End Class  
End Namespace 

Namespace ProcessAsyncStreamSamples
  
   Class ProcessSampleMain

      ' The main entry point for the application.
      Shared Sub Main()
         Try
            ProcessAsyncOutputRedirection.SortInputListText()
         
         Catch e As InvalidOperationException
            Console.WriteLine("Exception:")
            Console.WriteLine(e.ToString())
         End Try
      End Sub 'Main
   End Class  'ProcessSampleMain
End Namespace 'Process_AsyncStream_Sample
' </Snippet1>
