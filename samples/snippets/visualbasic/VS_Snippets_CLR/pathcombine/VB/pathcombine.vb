'<snippet1>
Imports System
Imports System.IO

Public Class ChangeExtensionTest
    
    
    Public Shared Sub Main()
        Dim path1 As String = "c:\temp"
        Dim path2 As String = "subdir\file.txt"
        Dim path3 As String = "c:\temp.txt"
        Dim path4 As String = "c:^*&)(_=@#'\\^&#2.*(.txt"
        Dim path5 As String = ""
        Dim path6 As String = Nothing

        CombinePaths(path1, path2)
        CombinePaths(path1, path3)
        CombinePaths(path3, path2)
        CombinePaths(path4, path2)
        CombinePaths(path5, path2)
        CombinePaths(path6, path2)
    End Sub 'Main

    Private Shared Sub CombinePaths(p1 As String, p2 As String)
        
        Try
            Dim combination As String = Path.Combine(p1, p2)
            
            Console.WriteLine("When you combine '{0}' and '{1}', the result is: {2}'{3}'", p1, p2, Environment.NewLine, combination)
        Catch e As Exception
            If p1 = Nothing Then
                p1 = "Nothing"
            End If
            If p2 = Nothing Then
                p2 = "Nothing"
            End If
            Console.WriteLine("You cannot combine '{0}' and '{1}' because: {2}{3}", p1, p2, Environment.NewLine, e.Message)
        End Try
        
        Console.WriteLine()
    End Sub 'CombinePaths
End Class 'ChangeExtensionTest
' This code produces output similar to the following:
'
' When you combine 'c:\temp' and 'subdir\file.txt', the result is: 
' 'c:\temp\subdir\file.txt'
' 
' When you combine 'c:\temp' and 'c:\temp.txt', the result is: 
' 'c:\temp.txt'
' 
' When you combine 'c:\temp.txt' and 'subdir\file.txt', the result is: 
' 'c:\temp.txt\subdir\file.txt'
' 
' When you combine 'c:^*&)(_=@#'\^&#2.*(.txt' and 'subdir\file.txt', the result is: 
' 'c:^*&)(_=@#'\^&#2.*(.txt\subdir\file.txt'
' 
' When you combine '' and 'subdir\file.txt', the result is: 
' 'subdir\file.txt'
' 
' You cannot combine '' and 'subdir\file.txt' because: 
' Value cannot be null.
' Parameter name: path1

'</snippet1>