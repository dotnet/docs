' <Snippet1>
Imports System.Runtime.InteropServices

Friend Class NativeMethods
    ' Visual Basic does not support varargs, so all arguments must be 
    ' explicitly defined. CallingConvention.Cdecl must be used since the stack 
    ' is cleaned up by the caller. 
    ' int printf( const char *format [, argument]... )

    <DllImport("msvcrt.dll", CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Friend Overloads Shared Function printf(
        ByVal format As String, ByVal i As Integer, ByVal d As Double) As Integer
    End Function

    <DllImport("msvcrt.dll", CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Friend Overloads Shared Function printf(
        ByVal format As String, ByVal i As Integer, ByVal s As String) As Integer
    End Function
End Class

Public Class App
    Public Shared Sub Main()
        NativeMethods.printf(ControlChars.CrLf + "Print params: %i %f", 99, 99.99)
        NativeMethods.printf(ControlChars.CrLf + "Print params: %i %s", 99, "abcd")
    End Sub
End Class
' </Snippet1>
