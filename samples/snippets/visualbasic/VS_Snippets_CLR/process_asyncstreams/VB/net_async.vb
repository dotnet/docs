' System.Diagnostics
'
' Requires .NET Framework version 1.2 or higher.
'

' The following example uses the net view command to list the 
' available network resources available on a remote computer, 
' and displays the results to the console. Specifying the optional
' error log file redirects error output to that file.

' <Snippet2>
' Define the namespaces used by this sample.
Imports System
Imports System.Text
Imports System.Globalization
Imports System.IO
Imports System.Diagnostics
Imports System.Threading
Imports System.ComponentModel
Imports Microsoft.VisualBasic


Namespace ProcessAsyncStreamSamples
   
   Class ProcessAsyncErrorRedirection
      ' Define static variables shared by class methods.
      Private Shared streamError As StreamWriter = Nothing
      Private Shared netErrorFile As String = ""
      Private Shared netOutput As StringBuilder = Nothing
      Private Shared errorRedirect As Boolean = False
      Private Shared errorsWritten As Boolean = False
      
      Public Shared Sub RedirectNetCommandStreams()
         Dim netArguments As String
         Dim netProcess As Process
         
         ' Get the input computer name.
         Console.WriteLine("Enter the computer name for the net view command:")
         netArguments = Console.ReadLine().ToUpper(CultureInfo.InvariantCulture)
         If String.IsNullOrEmpty(netArguments) Then
            ' Default to the help command if there is 
            ' not an input argument.
            netArguments = "/?"
         End If
         
         ' Check if errors should be redirected to a file.
         errorsWritten = False
         Console.WriteLine("Enter a fully qualified path to an error log file")
         Console.WriteLine("  or just press Enter to write errors to console:")
         netErrorFile = Console.ReadLine().ToUpper(CultureInfo.InvariantCulture)
         If Not String.IsNullOrEmpty(netErrorFile) Then
            errorRedirect = True
         End If
         
         ' Note that at this point, netArguments and netErrorFile
         ' are set with user input.  If the user did not specify
         ' an error file, then errorRedirect is set to false.

         ' Initialize the process and its StartInfo properties.
         netProcess = New Process()
         netProcess.StartInfo.FileName = "Net.exe"
         
         ' Build the net command argument list.
         netProcess.StartInfo.Arguments = String.Format("view {0}", _
                                                        netArguments)
         
         ' Set UseShellExecute to false for redirection.
         netProcess.StartInfo.UseShellExecute = False
         
         ' Redirect the standard output of the net command.  
         ' Read the stream asynchronously using an event handler.
         netProcess.StartInfo.RedirectStandardOutput = True
         AddHandler netProcess.OutputDataReceived, _
                            AddressOf NetOutputDataHandler
         netOutput = new StringBuilder()
         
         If errorRedirect Then
            ' Redirect the error output of the net command. 
            netProcess.StartInfo.RedirectStandardError = True
            AddHandler netProcess.ErrorDataReceived, _
                            AddressOf NetErrorDataHandler
         Else
            ' Do not redirect the error output.
            netProcess.StartInfo.RedirectStandardError = False
         End If
         
         Console.WriteLine(ControlChars.Lf + "Starting process: NET {0}", _
                           netProcess.StartInfo.Arguments)
         If errorRedirect Then
            Console.WriteLine("Errors will be written to the file {0}", _
                           netErrorFile)
         End If
         
         ' Start the process.
         netProcess.Start()
         
         ' Start the asynchronous read of the standard output stream.
         netProcess.BeginOutputReadLine()
         
         If errorRedirect Then
            ' Start the asynchronous read of the standard
            ' error stream.
            netProcess.BeginErrorReadLine()
         End If
         
         ' Let the net command run, collecting the output.
         netProcess.WaitForExit()
      
         If Not streamError Is Nothing Then
             ' Close the error file.
             streamError.Close()
         Else 
             ' Set errorsWritten to false if the stream is not
             ' open.   Either there are no errors, or the error
             ' file could not be opened.
             errorsWritten = False
         End If
   
         If netOutput.Length > 0 Then
            ' If the process wrote more than just
            ' white space, write the output to the console.
            Console.WriteLine()
            Console.WriteLine("Public network shares from net view:")
            Console.WriteLine()
            Console.WriteLine(netOutput)
            Console.WriteLine()
         End If
         
         If errorsWritten Then
            ' Signal that the error file had something 
            ' written to it.
            Dim errorOutput As String()
            errorOutput = File.ReadAllLines(netErrorFile)
            If errorOutput.Length > 0 Then

                Console.WriteLine(ControlChars.Lf + _
                    "The following error output was appended to {0}.", _
                    netErrorFile)
                Dim errLine as String
                For Each errLine in errorOutput
                    Console.WriteLine("  {0}", errLine)
                Next
          
                Console.WriteLine()
            End If
         End If
         
         netProcess.Close()
      End Sub 
      
      
      Private Shared Sub NetOutputDataHandler(sendingProcess As Object, _
          outLine As DataReceivedEventArgs)

         ' Collect the net view command output.
         If Not String.IsNullOrEmpty(outLine.Data) Then
            ' Add the text to the collected output.
            netOutput.Append(Environment.NewLine + "  " + outLine.Data)
         End If
      End Sub 
       
      
      Private Shared Sub NetErrorDataHandler(sendingProcess As Object, _
          errLine As DataReceivedEventArgs)

         ' Write the error text to the file if there is something to
         ' write and an error file has been specified.

         If Not String.IsNullOrEmpty(errLine.Data) Then

            If Not errorsWritten Then
                If streamError Is Nothing Then
                    ' Open the file.
                    Try 
                        streamError = New StreamWriter(netErrorFile, true)
                    Catch e As Exception
                        Console.WriteLine("Could not open error file!")
                        Console.WriteLine(e.Message.ToString())
                    End Try
                End If

                If Not streamError Is Nothing Then

                    ' Write a header to the file if this is the first
                    ' call to the error output handler.
                    streamError.WriteLine()
                    streamError.WriteLine(DateTime.Now.ToString())
                    streamError.WriteLine("Net View error output:")

                End If

                errorsWritten = True
            End If
                     
            If Not streamError Is Nothing Then
                  
                ' Write redirected errors to the file.
                streamError.WriteLine(errLine.Data)
                streamError.Flush()
             End If
          End If
      End Sub 
   End Class  
End Namespace 
' </Snippet2>

Namespace ProcessAsyncStreamSamples
  
   Class ProcessSampleMain

      ' The main entry point for the application.
      Shared Sub Main()
         Try
            ProcessAsyncErrorRedirection.RedirectNetCommandStreams()
         
         Catch e As InvalidOperationException
            Console.WriteLine("Exception:")
            Console.WriteLine(e.ToString())
         End Try
      End Sub 'Main
   End Class  'ProcessSampleMain
End Namespace 'Process_AsyncStream_Sample
