' <Snippet1>
Imports System.Runtime.InteropServices

Friend Class NativeMethods
    ' Visual Basic doesn't support varargs so all arguments must be explicitly defined.
    ' CallingConvention.Cdecl must be used since the stack is
    ' cleaned up by the caller.
    ' int printf(const char *format [, argument]...)
    <DllImport("msvcrt.dll", CharSet:=CharSet.Ansi,
        CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function printf(format As String, i As Integer, d As Double) As Integer
    End Function
    <DllImport("msvcrt.dll", CharSet:=CharSet.Ansi,
        CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Function printf(format As String, i As Integer, s As String) As Integer
    End Function
End Class

Public Class App
    Public Shared Sub Main()
        NativeMethods.printf(vbCrLf + "Print params: %i %f", 99, 99.99)
        NativeMethods.printf(vbCrLf + "Print params: %i %s", 99, "abcd")
    End Sub
End Class
' </Snippet1>

Public Class TheClass
    ' <Snippet2>
    <DllImport("unmanaged.dll, MyAssembly, Version= 1.0.0.0," +
        "Culture=neutral, PublicKeyToken=a77e0ba5eab10125")>
    Friend Shared Function DummyFuncion1(parm As Integer) As Integer
    End Function
    ' </Snippet2>

    ' <Snippet3>
    <DllImport("My.dll", CharSet:=CharSet.Ansi,
        BestFitMapping:=False,
        ThrowOnUnmappableChar:=True)>
    Friend Shared Function SomeFuncion2(parm As Integer) As Integer
    End Function
    ' </Snippet3>
End Class

Namespace znippet4

    ' <Snippet4>
    Friend Class NativeMethods
        <DllImport("user32.dll", ExactSpelling:=False)>
        Friend Shared Function MessageBox(hWnd As IntPtr, lpText As String,
            lpCaption As String, uType As UInteger) As Integer
        End Function
    End Class
    ' </Snippet4>
End Namespace

Namespace znippet5

    ' <Snippet5>
    Friend Class NativeMethods
        <DllImport("user32.dll", SetLastError:=True)>
        Friend Shared Function MessageBoxA(hWnd As IntPtr, lpText As String,
            lpCaption As String, uType As UInteger) As Integer
        End Function
    End Class
    ' </Snippet5>
End Namespace

