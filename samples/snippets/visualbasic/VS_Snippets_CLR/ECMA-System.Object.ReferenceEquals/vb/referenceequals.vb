'<snippet1>
Imports System

Public Class App
    Public Shared Sub Main() 
        Dim o As Object = Nothing
        Dim p As Object = Nothing
        Dim q As New Object
        Console.WriteLine(Object.ReferenceEquals(o, p))
        p = q
        Console.WriteLine(Object.ReferenceEquals(p, q))
        Console.WriteLine(Object.ReferenceEquals(o, p))
    End Sub 
End Class 
' This code produces the following output:
'
' True
' True
' False
'
'</snippet1>



























