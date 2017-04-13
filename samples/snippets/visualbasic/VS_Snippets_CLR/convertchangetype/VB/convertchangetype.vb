'<snippet1>
Imports System

Public Class ChangeTypeTest
    
    Public Shared Sub Main()
        Dim d As [Double] = - 2.345
        Dim i As Integer = CInt(Convert.ChangeType(d, GetType(Integer)))
        
        Console.WriteLine("The double value {0} when converted to an int becomes {1}", d, i)
        Dim s As String = "12/12/98"
        Dim dt As DateTime = CType(Convert.ChangeType(s, GetType(DateTime)), DateTime)
        
        Console.WriteLine("The string value {0} when converted to a Date becomes {1}", s, dt)
    End Sub 'Main
End Class 'ChangeTypeTest
'</snippet1>