' <snippet12>
Imports System.Threading.Tasks

Module Example
    Function GetAllFiles(ByVal str As String) As String()

        ' Should throw an AccessDenied exception on Vista or later. If you see an "Exception was unhandled
        ' by user code" error, this is because "Just My Code" is enabled. Press F5 to continue execution or 
        ' disable Just My Code.
        Return System.IO.Directory.GetFiles(str, "*.txt", System.IO.SearchOption.AllDirectories)
    End Function

    Sub Main()
        HandleExceptions()
        ' RethrowAllExceptions()
        Console.WriteLine("Press any key.")
        Console.ReadKey()
    End Sub

    Sub HandleExceptions()
        ' Assume this is a user-entered String.
        Dim path = "C:\"

        ' Use this line to throw UnauthorizedAccessException, which we handle.
        Dim task1 = Task(Of String()).Factory.StartNew(Function() GetAllFiles(path))

        ' Use this line to throw an exception that is not handled.
        '  Task task1 = Task.Factory.StartNew(Sub ()   throw new IndexOutOfRangeException()  )
        Try
            task1.Wait()
        Catch ae As AggregateException
            ae.Handle(Function(x)
                         If TypeOf (x) Is UnauthorizedAccessException Then ' This we know how to handle
                            Console.WriteLine("You do not have permission to access all folders in this path.")
                            Console.WriteLine("See your network administrator or try another path.")
                            Return True
                         Else
                            Return False ' Let anything else stop the application.
                         End If
                      End Function)
        End Try

        Console.WriteLine("task1 has completed.")
    End Sub

    Function GetValidExtensions(ByVal path As String) As String()
        If path = "C:\" Then
            Throw New ArgumentException("The system root is not a valid path.")
        End If
        Dim result(10) As String
        Return result
    End Function

    Sub RethrowAllExceptions()
        ' Assume this is a user-entered String.
        Dim path = "C:\"

        Dim myTasks(2) As Task(Of String())
        myTasks(0) = Task(Of String()).Factory.StartNew(Function() GetAllFiles(path))
        myTasks(1) = Task(Of String()).Factory.StartNew(Function() GetValidExtensions(path))
        myTasks(2) = Task(Of String()).Factory.StartNew(Function()
                                                            Dim s(10) As String
                                                            Return s
                                                        End Function)
        Try
            Task.WaitAll(myTasks)
        Catch ae As AggregateException
            Throw ae.Flatten()
        End Try
        Console.WriteLine("task1 has completed.")
    End Sub
End Module
' </snippet12>
