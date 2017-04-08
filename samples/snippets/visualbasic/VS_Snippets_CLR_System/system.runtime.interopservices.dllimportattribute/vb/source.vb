' <Snippet1>
Imports System
Imports System.Runtime.InteropServices

Public Class LibWrap
    ' Visual Basic doesn't support varargs so all arguments must be explicitly defined.
    ' CallingConvention.Cdecl must be used since the stack is
    ' cleaned up by the caller.
    ' int printf(const char *format [, argument]...)
    <DllImport("msvcrt.dll", CharSet := CharSet.Ansi, _
    CallingConvention := CallingConvention.Cdecl)> _
    Public Shared Function printf(format As String, i As Integer, d As Double) As Integer
    End Function
    <DllImport("msvcrt.dll", CharSet := CharSet.Ansi, _
    CallingConvention := CallingConvention.Cdecl)> _
    Public Shared Function printf(format As String, i As Integer, s As String) As Integer
    End Function
End Class

Public Class App
    Public Shared Sub Main()
        LibWrap.printf(vbCrLf + "Print params: %i %f", 99, 99.99)
        LibWrap.printf(vbCrLf + "Print params: %i %s", 99, "abcd")
    End Sub
End Class
' </Snippet1>

Public Class TheClass
    ' <Snippet2>
    <DllImport("unmanaged.dll, MyAssembly, Version= 1.0.0.0," + _
     "Culture=neutral, PublicKeyToken=a77e0ba5eab10125")> _
    Public Shared Function DummyFuncion1(parm As Integer) As Integer
    End Function
    ' </Snippet2>

    ' <Snippet3>
    <DllImport("My.dll", CharSet := CharSet.Ansi, _
                   BestFitMapping := false, _
                   ThrowOnUnmappableChar := true)> _
    Public Shared Function SomeFuncion2(parm As Integer) As Integer
    End Function
    ' </Snippet3>
End Class

Namespace znippet4

' <Snippet4>
Public Class Win32
    <DllImport("user32.dll", ExactSpelling := False)> _
    Public Shared Function MessageBox(hWnd As IntPtr, text As String, _
               caption As String, type As UInteger) As Integer
    End Function
End Class
' </Snippet4>
End Namespace

Namespace znippet5

' <Snippet5>
Public Class Win32
    <DllImport("user32.dll", SetLastError := true)> _
    Public Shared Function MessageBoxA(hWnd As IntPtr, text As String, _
               caption As String, type As UInteger) As Integer
    End Function
End Class
' </Snippet5>
End Namespace

