' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class Fieldinfo_IsPinvoke
    Public myField As String = "A public field"

    Public Shared Sub Main()
        Dim myObject As New Fieldinfo_IsPinvoke()

        ' Get the Type and FieldInfo.
        Dim myType1 As Type = GetType(Fieldinfo_IsPinvoke)
        Dim myFieldInfo As FieldInfo = myType1.GetField("myField", _
           BindingFlags.Public Or BindingFlags.Instance)

        ' Display the name, field and the PInvokeImpl attribute for the field.
        Console.Write(ControlChars.NewLine & "Name of class: {0}", _
                                         myType1.FullName)
        Console.Write(ControlChars.NewLine & "Value of field: {0}", _
                                         myFieldInfo.GetValue(myObject))
        Console.Write(ControlChars.NewLine & "IsPinvokeImpl: {0}", _
                                         myFieldInfo.IsPinvokeImpl)
    End Sub
End Class
' </Snippet1>