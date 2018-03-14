'<Snippet1>
Imports System
Imports System.Runtime.InteropServices

Public Class Example
    Public Shared Sub Main()
        DisplayLayoutAttribute(GetType(Example).StructLayoutAttribute)
        DisplayLayoutAttribute(GetType(Test1).StructLayoutAttribute)
        DisplayLayoutAttribute(GetType(Test2).StructLayoutAttribute)
    End Sub

    Private Shared Sub DisplayLayoutAttribute( _
        ByVal sla As StructLayoutAttribute)
        Console.WriteLine(vbCrLf & "CharSet: " & sla.CharSet.ToString() _
            & vbCrLf & "   Pack: " & sla.Pack.ToString() _
            & vbCrLf & "   Size: " & sla.Size.ToString() _
            & vbCrLf & "  Value: " & sla.Value.ToString())
    End Sub

    Public Structure Test1
        Public B1 As Byte
        Public S As Short
        Public B2 As Byte
    End Structure

    <StructLayout(LayoutKind.Explicit, Pack:=1)> _
    Public Structure Test2
        <FieldOffset(0)> Public B1 As Byte
        <FieldOffset(1)> Public S As Short
        <FieldOffset(3)> Public B2 As Byte
    End Structure
End Class
'</Snippet1>