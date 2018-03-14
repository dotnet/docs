' <Snippet1>
Imports System
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices

Public Class LibWrap
' Visual Basic does not support varargs, so all arguments must be 
' explicitly defined. CallingConvention.Cdecl must be used since the stack 
' is cleaned up by the caller. 
' int printf( const char *format [, argument]... )

<DllImport("msvcrt.dll", CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)> _
Overloads Shared Function printf( _
    ByVal format As String, ByVal i As Integer, ByVal d As Double) As Integer
End Function

<DllImport("msvcrt.dll", CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)> _
Overloads Shared Function printf( _
    ByVal format As String, ByVal i As Integer, ByVal s As String) As Integer
End Function
End Class 'LibWrap

Public Class App
    Public Shared Sub Main()
        LibWrap.printf(ControlChars.CrLf + "Print params: %i %f", 99, _
                       99.99)
        LibWrap.printf(ControlChars.CrLf + "Print params: %i %s", 99, _
                       "abcd")
    End Sub 'Main
End Class 'App
' </Snippet1>