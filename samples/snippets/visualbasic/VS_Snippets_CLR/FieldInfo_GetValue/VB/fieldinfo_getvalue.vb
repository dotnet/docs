' <Snippet1>
Imports System.Reflection

Public Class FieldsClass
    Public fieldA As String
    Public fieldB As String

    Public Sub New()
        fieldA = "A public field"
        fieldB = "Another public field"
    End Sub 
End Class 

Public Module Example
    Public Sub Main()
        Dim fieldsInst As New FieldsClass()
        ' Get the type of FieldsClass.
        Dim fieldsType As Type = GetType(FieldsClass)

        ' Get an array of FieldInfo objects.
        Dim fields As FieldInfo() = fieldsType.GetFields(BindingFlags.Public Or BindingFlags.Instance)
        ' Display the values of the fields.
        Console.WriteLine("Displaying the values of the fields of {0}:", fieldsType)
        For i As Integer = 0 To fields.Length - 1
            Console.WriteLine("   {0}:{2}'{1}'",
                fields(i).Name, fields(i).GetValue(fieldsInst), vbTab)
        Next 
    End Sub 
End Module
' The example displays the following output:
'     Displaying the values of the fields of FieldsClass:
'        fieldA:      'A public field'
'        fieldB:      'Another public field'
' </Snippet1>
