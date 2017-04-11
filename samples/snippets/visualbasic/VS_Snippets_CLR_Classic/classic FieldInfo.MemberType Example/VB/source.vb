' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

' Make a field.
Public Class Myfield
    Private m_field As String = "a private field"

    Public ReadOnly Property Field() As String
        Get
            Return m_field
        End Get
    End Property
End Class

Public Class Myfieldinfo

    Public Shared Sub Main()
        Console.WriteLine()
        Console.WriteLine(ControlChars.Cr & "Reflection.FieldInfo")
        Console.WriteLine()
        Dim Myfield As New Myfield()

        ' Get the Type and FieldInfo.
        Dim MyType As Type = GetType(Myfield)
        Dim Myfieldinfo As FieldInfo = _
           MyType.GetField("m_field", BindingFlags.NonPublic Or BindingFlags.Instance)

        ' Get and display the MemberType.
        Console.Write(ControlChars.Cr & "{0}.", MyType.FullName)
        Console.Write("{0} - ", Myfieldinfo.Name)
        Console.Write("{0};", Myfield.Field)
        Dim Mymembertypes As MemberTypes = Myfieldinfo.MemberType
        Console.Write("MemberType is a {0}.", Mymembertypes.ToString())
    End Sub
End Class
' </Snippet1>
