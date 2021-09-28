'<snippet36>
Imports System.Runtime.InteropServices

'<snippet37>

Public Delegate Function FPtr(ByVal value As Integer) As Boolean
Public Delegate Function FPtr2(ByVal value As String) As Boolean

Friend Class NativeMethods
    ' Declares managed prototypes for unmanaged functions.
    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Sub TestCallBack(
        ByVal cb As FPtr, ByVal value As Integer)
    End Sub

    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Friend Shared Sub TestCallBack2(
        ByVal cb2 As FPtr2, ByVal value As String)
    End Sub
End Class
'</snippet37>

'<snippet38>
Public Class App
    Public Shared Sub Main()
        Dim cb As FPtr = AddressOf App.DoSomething
        Dim cb2 As FPtr2 = AddressOf App.DoSomething2
        NativeMethods.TestCallBack(cb, 99)
        NativeMethods.TestCallBack2(cb2, "abc")
    End Sub

    Public Shared Function DoSomething(ByVal value As Integer) As Boolean
        Console.WriteLine(ControlChars.CrLf + $"Callback called with param: {value}")
        ' ...
        Return True
    End Function

    Public Shared Function DoSomething2(ByVal value As String) As Boolean
        Console.WriteLine(ControlChars.CrLf + $"Callback called with param: {value}")
        ' ...
        Return True
    End Function
End Class
'</snippet38>
'</snippet36>
