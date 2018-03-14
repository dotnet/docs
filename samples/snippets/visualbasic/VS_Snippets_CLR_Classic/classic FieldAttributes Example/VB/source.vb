' Updated for 406827 REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class Demo
    ' Declare three fields.
    ' The first field is private.
    Private m_field As String = "String A"

    'The second field is public.
    Public Field As String = "String B"

    ' The third field is public and const, hence also static
    ' and literal with a default value.
    Public Const FieldC As String = "String C"

End Class

Module Module1
    Sub Main()
        ' Create an instance of the Demo class.
        Dim d As New Demo()

        Console.WriteLine(vbCrLf & "Reflection.FieldAttributes")

        ' Get a Type object for Demo, and a FieldInfo for each of
        ' the three fields. Use the FieldInfo to display field
        ' name, value for the Demo object in d, and attributes.
        '
        Dim myType As Type = GetType(Demo)

        Dim fiPrivate As FieldInfo = myType.GetField("m_field", _
            BindingFlags.NonPublic Or BindingFlags.Instance)
        DisplayField(d, fiPrivate)

        Dim fiPublic As FieldInfo = myType.GetField("Field", _
            BindingFlags.Public Or BindingFlags.Instance)
        DisplayField(d, fiPublic)

        Dim fiConstant As FieldInfo = myType.GetField("FieldC", _
            BindingFlags.Public Or BindingFlags.Static)
        DisplayField(d, fiConstant)
    End Sub

    Sub DisplayField(ByVal obj As Object, ByVal f As FieldInfo)

        ' Display the field name, value, and attributes.
        '
        Console.WriteLine("{0} = ""{1}""; attributes: {2}", _
            f.Name, f.GetValue(obj), f.Attributes)
    End Sub

End Module

' This code example produces the following output:
'
'm_field = "String A"; attributes: Private
'Field = "String B"; attributes: Public
'FieldC = "String C"; attributes: Public, Static, Literal, HasDefault
'</Snippet1>