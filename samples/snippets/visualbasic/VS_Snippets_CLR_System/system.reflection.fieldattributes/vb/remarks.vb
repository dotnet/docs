
Imports System
Imports System.Reflection

Class FieldAttribTest
    Public Shared field1 as Integer = 99

    Public Shared Sub Main()
        Dim obj As Object = New FieldAttribTest

        ' <snippet1>
        Dim fi As FieldInfo = obj.GetType().GetField("field1")

        If (fi.Attributes And FieldAttributes.FieldAccessMask) = _
            FieldAttributes.Public Then
            Console.WriteLine("{0:s} is public. Value: {1:d}", fi.Name, fi.GetValue(obj))
        End If
        ' </snippet1>
    End Sub
End Class





