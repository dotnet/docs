' <snippet12>
Imports System.IO
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        ' This should throw an UnauthorizedAccessException.
       Try
           Dim files = GetAllFiles("C:\")
           If files IsNot Nothing Then
              For Each file In files
                 Console.WriteLine(file)
              Next
           End If
        Catch ae As AggregateException
           For Each ex In ae.InnerExceptions
               Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message)
           Next
        End Try
        Console.WriteLine()

       ' This should throw an ArgumentException.
        Try
           For Each s In GetAllFiles("")
              Console.WriteLine(s)
           Next
        Catch ae As AggregateException
           For Each ex In ae.InnerExceptions
               Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message)
           Next
        End Try
        Console.WriteLine()
    End Sub

    Function GetAllFiles(ByVal path As String) As String()
       Dim task1 = Task.Run( Function()
                                Return Directory.GetFiles(path, "*.txt",
                                                          SearchOption.AllDirectories)
                             End Function)
       Try
          Return task1.Result
       Catch ae As AggregateException
          ae.Handle( Function(x)
                        ' Handle an UnauthorizedAccessException
                        If TypeOf x Is UnauthorizedAccessException Then
                            Console.WriteLine("You do not have permission to access all folders in this path.")
                            Console.WriteLine("See your network administrator or try another path.")
                        End If
                        Return TypeOf x Is UnauthorizedAccessException
                     End Function)
       End Try
       Return Array.Empty(Of String)()
    End Function
End Module
' The example displays the following output:
'       You do not have permission to access all folders in this path.
'       See your network administrator or try another path.
'
'       ArgumentException: The path is not of a legal form.
' </snippet12>
