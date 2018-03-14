'<snippet13>
Imports System.Threading.Tasks
Module TaskExceptions2

    Sub Main()
        RethrowAllExceptions()
    End Sub
    Function GetAllFiles(ByVal str As String) As String()

        ' Should throw an AccessDenied exception on Vista or later. If you see an "Exception was unhandled
        ' by user code" error, this is because "Just My Code" is enabled. Press F5 to continue execution or 
        ' disable Just My Code.
        Return System.IO.Directory.GetFiles(str, "*.txt", System.IO.SearchOption.AllDirectories)
    End Function


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
'</snippet13>
