' System.Diagnostics
'
' Requires .NET Framework version 1.2 or higher.
'

' <Snippet3>
' Define the namespaces used by this sample.
Imports System
Imports System.Text
Imports System.IO
Imports System.Diagnostics
Imports System.Threading
Imports System.ComponentModel
Imports Microsoft.VisualBasic


Class ProcessNMakeStreamRedirection

   ' Define static variables shared by class methods.
   Private Shared buildLogStream As StreamWriter = Nothing
   Private Shared logMutex As Mutex = New Mutex()
   Private Shared maxLogLines As Integer = 25
   Private Shared currentLogLines As Integer = 0
   
   
   Public Shared Sub RedirectNMakeCommandStreams()
      Dim nmakeArguments As String = Nothing
      Dim nmakeProcess As Process
      
      ' Get the input nmake command-line arguments.
      Console.WriteLine("Enter the NMake command line arguments" + _
          " (@commandfile or /f makefile, etc):")
      Dim inputText As String = Console.ReadLine()
      If Not String.IsNullOrEmpty(inputText) Then
         nmakeArguments = inputText
      End If
      
      Console.WriteLine("Enter max line limit for log file (default is 25):")
      inputText = Console.ReadLine()
      If Not String.IsNullOrEmpty(inputText) Then
         If Not Int32.TryParse(inputText, maxLogLines) Then
            maxLogLines = 25
         End If
      End If
      Console.WriteLine("Output beyond {0} lines will be ignored.", _
          maxLogLines)
      
      ' Initialize the process and its StartInfo properties.
      nmakeProcess = New Process()
      nmakeProcess.StartInfo.FileName = "NMake.exe"
      
      ' Build the nmake command argument list.
      If Not String.IsNullOrEmpty(nmakeArguments) Then
         nmakeProcess.StartInfo.Arguments = nmakeArguments
      End If
      
      ' Set UseShellExecute to false for redirection.
      nmakeProcess.StartInfo.UseShellExecute = False
      
      ' Redirect the standard output of the nmake command.  
      ' Read the stream asynchronously using an event handler.
      nmakeProcess.StartInfo.RedirectStandardOutput = True
      AddHandler nmakeProcess.OutputDataReceived, _
                AddressOf NMakeOutputDataHandler
      
      ' Redirect the error output of the nmake command. 
      nmakeProcess.StartInfo.RedirectStandardError = True
      AddHandler nmakeProcess.ErrorDataReceived, _
                AddressOf NMakeErrorDataHandler

      logMutex.WaitOne()

      currentLogLines = 0
    
      ' Write a header to the log file.
      Const buildLogFile As String = "NmakeCmd.Txt"
      Try 
          buildLogStream = new StreamWriter(buildLogFile, true)
      Catch e As Exception
          Console.WriteLine("Could not open output file {0}", buildLogFile)
          Console.WriteLine("Exception = {0}", e.ToString())
          Console.WriteLine(e.Message)

          buildLogStream = Nothing
      End Try

      If Not buildLogStream Is Nothing Then
               
          Console.WriteLine("Nmake output logged to {0}", _
              buildLogFile)
    
          buildLogStream.WriteLine()
          buildLogStream.WriteLine(DateTime.Now.ToString())
          
          If Not String.IsNullOrEmpty(nmakeArguments) Then
              buildLogStream.Write("Command line = NMake {0}", _
                        nmakeArguments)
          Else 
              buildLogStream.Write("Command line = Nmake")
          End If
          
          buildLogStream.WriteLine()
          buildLogStream.Flush()
            
          logMutex.ReleaseMutex()
      
           ' Start the process.
           Console.WriteLine()
           Console.WriteLine("\nStarting Nmake command...")
           Console.WriteLine()
           nmakeProcess.Start()

           ' Start the asynchronous read of the error stream.
           nmakeProcess.BeginErrorReadLine()

           ' Start the asynchronous read of the output stream.
           nmakeProcess.BeginOutputReadLine()
    
           ' Let the nmake command run, collecting the output.
           nmakeProcess.WaitForExit()

           nmakeProcess.Close()
           buildLogStream.Close()
           logMutex.Dispose()
       End If
   End Sub 
   
    Private Shared Sub NMakeOutputDataHandler(sendingProcess As Object, _
       outLine As DataReceivedEventArgs)

        ' Collect the output, displaying it to the screen and 
        ' logging it to the output file.  Cancel the read
        ' operation when the maximum line limit is reached.

        If Not String.IsNullOrEmpty(outLine.Data) Then
            logMutex.WaitOne()

            currentLogLines = currentLogLines + 1
            If currentLogLines > maxLogLines Then
                
                ' Display the line to the console.
                ' Skip writing the line to the log file.
                Console.WriteLine("StdOut: {0}", outLine.Data)
            Else If currentLogLines = maxLogLines Then
                
                LogToFile("StdOut", "<Max build log limit reached!>", _
                    true)
    
                ' Stop reading the output streams.
                Dim p As Process = sendingProcess 
                If Not (p Is Nothing) Then
                    p.CancelOutputRead()
                    p.CancelErrorRead()
                End If
            Else 
                ' Write the line to the log file.
                LogToFile("StdOut", outLine.Data, true)
            End If

            logMutex.ReleaseMutex()
        End If
 
    End Sub 
   
   Private Shared Sub NMakeErrorDataHandler(sendingProcess As Object, _
        errLine As DataReceivedEventArgs)

      ' Collect the error output, displaying it to the screen and 
      ' logging it to the output file.  Cancel the error output
      ' read operation when the maximum line limit is reached.

        If Not String.IsNullOrEmpty(errLine.Data) Then
            logMutex.WaitOne()

            currentLogLines = currentLogLines + 1
            If currentLogLines > maxLogLines Then
                
                ' Display the line to the console.
                ' Skip writing the line to the log file.
                Console.WriteLine("StdErr: {0}", errLine.Data)
            Else If currentLogLines = maxLogLines Then
                
                LogToFile("StdErr", "<Max build log limit reached!>", _
                    true)
    
                ' Stop reading the output streams.
                Dim p As Process = sendingProcess 
                If Not (p Is Nothing) Then
                    p.CancelOutputRead()
                    p.CancelErrorRead()
                End If
            Else 
                ' Write the line to the log file.
                LogToFile("StdErr", errLine.Data, true)
            End If

            logMutex.ReleaseMutex()
        End If
 
    End Sub
   
    Private Shared Sub LogToFile(logPrefix As String, _
                                logText As String, _
                                echoToConsole As String)

        ' Write the specified line to the log file stream.
        Dim logString As StringBuilder = New StringBuilder()

        If Not String.IsNullOrEmpty(logPrefix) Then
                logString.AppendFormat("{0}> ", logPrefix)
        End If

        If Not String.IsNullOrEmpty(logText) Then
            logString.Append(logText)
        End If

        If Not buildLogStream Is Nothing Then
        
            buildLogStream.WriteLine("[{0}] {1}", _
                DateTime.Now.ToString(), logString.ToString())
            buildLogStream.Flush()
         End If
            
         If echoToConsole Then
            Console.WriteLine(logString.ToString())
         End If
  
    End Sub 
End Class 
' </Snippet3>

Namespace ProcessAsyncStreamSamples
  
   Class ProcessSampleMain

      ' The main entry point for the application.
      Shared Sub Main()
         Try
            ProcessNMakeStreamRedirection.RedirectNMakeCommandStreams()
         
         Catch e As InvalidOperationException
            Console.WriteLine("Exception:")
            Console.WriteLine(e.ToString())
         End Try
      End Sub 'Main
   End Class  'ProcessSampleMain
End Namespace 'Process_AsyncStream_Sample
