' <Snippet1> 

Imports System
Imports System.Reflection
Imports System.Runtime.Serialization
Imports Microsoft.VisualBasic

<Serializable()> _
Public Class [MyClass]
    Public myShort As Short

    ' The following field will not be serialized.  
    <NonSerialized()> Public myInt As Integer
End Class '[MyClass]

Public Class Type_IsNotSerializable

    Public Shared Sub Main()
        ' Get the type of MyClass.
        Dim myType As Type = GetType([MyClass])

        ' Get the fields of MyClass.
        Dim myFields As FieldInfo() = myType.GetFields((BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Static))
        Console.WriteLine(ControlChars.Cr & "Displaying whether or not the field is serializable." & ControlChars.Cr)
        Console.WriteLine()
        ' Displaying whether or not the field is serializable.
        Dim i As Integer
        For i = 0 To myFields.Length - 1
            If myFields(i).IsNotSerialized Then
                Console.WriteLine("The {0} field is not serializable.", myFields(i))
            Else
                Console.WriteLine("The {0} field is serializable.", myFields(i))
            End If
        Next i
    End Sub 'Main
End Class 'Type_IsNotSerializable
' </Snippet1>