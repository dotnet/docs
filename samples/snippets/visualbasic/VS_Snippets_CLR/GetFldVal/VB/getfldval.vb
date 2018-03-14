' <Snippet1>
Imports System.Reflection

Class Example
    Public Shared val As String = "test"
    
    Public Shared Sub Main()
        Dim fld As FieldInfo = GetType(Example).GetField("val")
        Console.WriteLine(fld.GetValue(Nothing))
        val = "hi"
        Console.WriteLine(fld.GetValue(Nothing))
    End Sub 
End Class 
' The example displays the following output:
'     test
'     hi
' </Snippet1>