'<snippet1>
Imports System

Public Class RemoveTest
    
    Public Shared Sub Main()
        Dim name As String = "Michelle Violet Banks"
                
        Console.WriteLine("The entire name is '{0}'", name)
        Dim foundS1 As Integer = name.IndexOf(" ")
        Dim foundS2 As Integer = name.IndexOf(" ", foundS1 + 1)
        If foundS1 <> foundS2 And foundS1 >= 0 Then
            
            ' remove the middle name, identified by finding the spaces in the middle of the name...    
            name = name.Remove(foundS1 + 1, foundS2 - foundS1)
            
            Console.WriteLine("After removing the middle name, we are left with '{0}'", name)
        End If
    End Sub
End Class 
' The example displays the following output:
'       The entire name is 'Michelle Violet Banks'
'       After removing the middle name, we are left with 'Michelle Banks'
'</snippet1>