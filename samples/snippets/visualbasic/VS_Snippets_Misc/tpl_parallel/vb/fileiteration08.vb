Option Strict On

' <Snippet08>
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Security
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    Sub Main()
        Try
            TraverseTreeParallelForEach("C:\Program Files",
                                        Sub(f)
                                            ' Exceptions are No-ops.         
                                            Try
                                                ' Do nothing with the data except read it.
                                                Dim data() As Byte = File.ReadAllBytes(f)
                                                ' In the event the file has been deleted.
                                            Catch e As FileNotFoundException

                                                ' General I/O exception, especially if the file is in use.
                                            Catch e As IOException

                                                ' Lack of adequate permissions.
                                            Catch e As UnauthorizedAccessException

                                                ' Lack of adequate permissions.
                                            Catch e As SecurityException

                                            End Try
                                            ' Display the filename.
                                            Console.WriteLine(f)
                                        End Sub)
        Catch e As ArgumentException
            Console.WriteLine("The directory 'C:\Program Files' does not exist.")
        End Try
        ' Keep the console window open.
        Console.ReadKey()
    End Sub

    Public Sub TraverseTreeParallelForEach(ByVal root As String, ByVal action As Action(Of String))
        'Count of files traversed and timer for diagnostic output
        Dim fileCount As Integer = 0
        Dim sw As Stopwatch = Stopwatch.StartNew()

        ' Determine whether to parallelize file processing on each folder based on processor count.
        Dim procCount As Integer = System.Environment.ProcessorCount

        ' Data structure to hold names of subfolders to be examined for files.
        Dim dirs As New Stack(Of String)

        If Not Directory.Exists(root) Then Throw New ArgumentException(
            "The given root directory doesn't exist.", NameOf(root))

        dirs.Push(root)

        While (dirs.Count > 0)
            Dim currentDir As String = dirs.Pop()
            Dim subDirs() As String = Nothing
            Dim files() As String = Nothing

            Try
                subDirs = Directory.GetDirectories(currentDir)
                ' Thrown if we do not have discovery permission on the directory.
            Catch e As UnauthorizedAccessException
                Console.WriteLine(e.Message)
                Continue While
                ' Thrown if another process has deleted the directory after we retrieved its name.
            Catch e As DirectoryNotFoundException
                Console.WriteLine(e.Message)
                Continue While
            End Try

            Try
                files = Directory.GetFiles(currentDir)
            Catch e As UnauthorizedAccessException
                Console.WriteLine(e.Message)
                Continue While
            Catch e As DirectoryNotFoundException
                Console.WriteLine(e.Message)
                Continue While
            Catch e As IOException
                Console.WriteLine(e.Message)
                Continue While
            End Try

            ' Execute in parallel if there are enough files in the directory.
            ' Otherwise, execute sequentially.Files are opened and processed
            ' synchronously but this could be modified to perform async I/O.
            Try
                If files.Length < procCount Then
                    For Each file In files
                        action(file)
                        fileCount += 1
                    Next
                Else
                    Parallel.ForEach(files, Function() 0, Function(file, loopState, localCount)
                                                              action(file)
                                                              localCount = localCount + 1
                                                              Return localCount
                                                          End Function,
                                     Sub(c)
                                         Interlocked.Add(fileCount, c)
                                     End Sub)
                End If
            Catch ae As AggregateException
                ae.Handle(Function(ex)

                              If TypeOf (ex) Is UnauthorizedAccessException Then

                                  ' Here we just output a message and go on.
                                  Console.WriteLine(ex.Message)
                                  Return True
                              End If
                              ' Handle other exceptions here if necessary...

                              Return False
                          End Function)
            End Try
            ' Push the subdirectories onto the stack for traversal.
            ' This could also be done before handing the files.
            For Each str As String In subDirs
                dirs.Push(str)
            Next

            ' For diagnostic purposes.
            Console.WriteLine("Processed {0} files in {1} milliseconds", fileCount, sw.ElapsedMilliseconds)
        End While
    End Sub
End Module
'</snippet08>
