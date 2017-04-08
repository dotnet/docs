' <Snippet1>
Imports System.IO
Imports System.Threading.Tasks

Module Example
    Sub Main()
        ' Get a folder path whose directories should throw an UnauthorizedAccessException.
        Dim path As String = Directory.GetParent(
                                       Environment.GetFolderPath(
                                       Environment.SpecialFolder.UserProfile)).FullName

        ' Use this line to throw UnauthorizedAccessException, which we handle.
        Dim task1 = Task(Of String()).Factory.StartNew(Function() GetAllFiles(path))

        ' Use this line to throw an exception that is not handled.
        ' Task task1 = Task.Factory.StartNew(Sub() Throw New IndexOutOfRangeException() )
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

      Console.WriteLine("task1 Status: {0}{1}", If(task1.IsCompleted, "Completed,", ""), 
                                                task1.Status)
    End Sub

    Function GetAllFiles(ByVal str As String) As String()
        ' Should throw an UnauthorizedAccessException exception. 
        Return System.IO.Directory.GetFiles(str, "*.txt", System.IO.SearchOption.AllDirectories)
    End Function
End Module
' </Snippet1>
