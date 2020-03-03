' <Snippet1>
Imports System.Runtime.InteropServices

' Declare a class member for each structure element.
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
Public Class OpenFileName

    Public structSize As Integer = 0
    Public filter As String = Nothing
    Public file As String = Nothing
    ' ...

End Class

Friend Class NativeMethods
    ' Declare managed prototype for the unmanaged function.
    Friend Declare Unicode Function GetOpenFileName Lib "Comdlg32.dll" (
       <[In](), Out()> ByVal ofn As OpenFileName) As Boolean
End Class

Public Class App
    Public Shared Sub Main()

    End Sub
End Class

' </Snippet1>
