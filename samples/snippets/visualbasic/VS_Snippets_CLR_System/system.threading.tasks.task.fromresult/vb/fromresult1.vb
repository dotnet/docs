' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim args() As String = Environment.GetCommandLineArgs()
      If args.Length > 1 Then
         Dim tasks As New List(Of Task(Of Long))
         For ctr = 1 To args.Length - 1
            tasks.Add(GetFileLengthsAsync(args(ctr)))
         Next
         Try
            Task.WaitAll(tasks.ToArray())
         ' Ignore exceptions here.
         Catch e As AggregateException
         End Try

         For ctr As Integer = 0 To tasks.Count - 1
            If tasks(ctr).Status = TaskStatus.Faulted Then
               Console.WriteLine("{0} does not exist", args(ctr + 1))
            Else
               Console.WriteLine("{0:N0} bytes in files in '{1}'",
                                 tasks(ctr).Result, args(ctr + 1))
            End If
         Next
      Else
         Console.WriteLine("Syntax error: Include one or more file paths.")
      End If
   End Sub
   
   Private Function GetFileLengthsAsync(filePath As String) As Task(Of Long)
      If Not Directory.Exists(filePath) Then
         Return Task.FromException(Of Long)(
                     New DirectoryNotFoundException("Invalid directory name."))
      Else
         Dim files As String() = Directory.GetFiles(filePath)
         If files.Length = 0 Then
            Return Task.FromResult(0L)
         Else
            Return Task.Run( Function()
                                Dim total As Long = 0
                                Dim lockObj As New Object
                                Parallel.ForEach(files, Sub(fileName)
                                                           Dim fs As New FileStream(fileName, FileMode.Open,
                                                                     FileAccess.Read, FileShare.ReadWrite,
                                                                     256, True)
                                                           Dim length As Long = fs.Length
                                                           Interlocked.Add(total, length)
                                                           fs.Close()
                                                        End Sub)
                                Return total
                             End Function )
         End If
      End If
   End Function
End Module
' When launched with the following command line arguments:
'      subdir . newsubdir
' the example displays output like the following:
'       0 bytes in files in 'subdir'
'       2,059 bytes in files in '.'
'       newsubdir does not exist
' </Snippet1>
