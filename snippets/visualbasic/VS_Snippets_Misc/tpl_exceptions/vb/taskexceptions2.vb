'<snippet13>
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
       Try
          ExecuteTasks()
       Catch ae As AggregateException
          For Each e In ae.InnerExceptions
             Console.WriteLine("{0}:{2}   {1}", e.GetType().Name, e.Message,
                               vbCrLf)
          Next
       End Try
    End Sub

    Sub ExecuteTasks()
        ' Assume this is a user-entered String.
        Dim path = "C:\"
        Dim tasks As New List(Of Task)
        
        tasks.Add(Task.Run(Function()
                             ' This should throw an UnauthorizedAccessEXception.
                              Return Directory.GetFiles(path, "*.txt",
                                                        SearchOption.AllDirectories)
                           End Function))

        tasks.Add(Task.Run(Function()
                              If path = "C:\" Then
                                 Throw New ArgumentException("The system root is not a valid path.")
                              End If
                              Return { ".txt", ".dll", ".exe", ".bin", ".dat" }
                           End Function))

        tasks.Add(Task.Run(Sub()
                              Throw New NotImplementedException("This operation has not been implemented.")
                           End Sub))

        Try
            Task.WaitAll(tasks.ToArray)
        Catch ae As AggregateException
            Throw ae.Flatten()
        End Try
    End Sub
End Module
' The example displays the following output:
'       UnauthorizedAccessException:
'          Access to the path 'C:\Documents and Settings' is denied.
'       ArgumentException:
'          The system root is not a valid path.
'       NotImplementedException:
'          This operation has not been implemented.
' </snippet13>
