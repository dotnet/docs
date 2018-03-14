'<snippet1>
Imports System



Public Class ConcatTest
    
    Public Shared Sub Main()
        Dim t1 As New Test1()
        Dim t2 As New Test2()
        Dim i As Integer = 16
        Dim s As String = "Demonstration"
        Dim o As Object() = {t1, i, t2, s}
        
        ' create a group of objects
        
        ' place the objects in an array
        
        ' concatenate the objects together as a string. To do this,
        ' the ToString method in the objects is called
        Console.WriteLine(String.Concat(o))
    End Sub 'Main
End Class 'ConcatTest


' imagine these test classes are full-fledged objects...
Class Test1
End Class 'Test1

Class Test2
End Class 'Test2
'</snippet1>