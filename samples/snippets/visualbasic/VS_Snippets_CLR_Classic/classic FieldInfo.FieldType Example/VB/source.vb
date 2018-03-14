'<Snippet1>
Imports System.Reflection

Public Class TestClass
    ' Define a field.
    Private field As String = "private field"
End Class 'Myfield

Public Module Example
    Public Sub Main()
        Dim cl As New TestClass()

        ' Get the type and FieldInfo.
        Dim t As Type = cl.GetType()
        Dim fi As FieldInfo = t.GetField("field", _
                 BindingFlags.Instance Or BindingFlags.NonPublic)

        ' Get and display the FieldType.
        Console.WriteLine("Field Name: {0}.{1}", t.FullName, fi.Name)
        Console.WriteLine("Field Value: '{0}'", fi.GetValue(cl))
        Console.WriteLine("Field Type: {0}", fi.FieldType)
    End Sub 
End Module
' The example displays the following output:
'       Field Name: TestClass.field
'       Field Value: 'private field'
'       Field Type: System.String
' </Snippet1>