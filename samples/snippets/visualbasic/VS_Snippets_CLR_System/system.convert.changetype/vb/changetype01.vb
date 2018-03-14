' <Snippet2>
Imports System

Public Class ChangeTypeTest
    
    Public Shared Sub Main()
        Dim d As [Double] = - 2.345
        Dim i As Integer = CInt(Convert.ChangeType(d, TypeCode.Int32))
        
        Console.WriteLine("The Double {0} when converted to an Int32 is {1}", d, i)
        Dim s As String = "12/12/2009"
        Dim dt As DateTime = CDate(Convert.ChangeType(s, TypeCode.DateTime))
        
        Console.WriteLine("The String {0} when converted to a Date is {1}", s, dt)
    End Sub 
End Class 
' The example displays the following output:
'    The Double -2.345 when converted to an Int32 is -2
'    The String 12/12/2009 when converted to a Date is 12/12/2009 12:00:00 AM
' </Snippet2>
