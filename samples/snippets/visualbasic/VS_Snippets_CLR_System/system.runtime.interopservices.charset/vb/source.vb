Imports System
Imports System.Runtime.InteropServices


Public Class InteropCharSet
    ' <Snippet1>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Structure MyPerson
        Public first As String
        Public last As String
    End Structure
    ' </Snippet1>

    Public Shared Sub Main
        Dim aperson As MyPerson

        aperson.first = "FirstName"
        aperson.last = "LastName"
    End Sub
End Class