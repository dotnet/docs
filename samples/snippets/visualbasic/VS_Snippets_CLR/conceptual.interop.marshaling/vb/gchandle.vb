'<snippet39>
Imports System.IO
Imports System.Runtime.InteropServices

'<snippet40>
Public Delegate Function CallBack(
    ByVal handle As Integer, ByVal param As IntPtr) As Boolean

Friend Class NativeMethods
    ' Passes a managed object instead of an LPARAM.
    ' Declares a managed prototype for the unmanaged function.
    Friend Declare Function EnumWindows Lib "user32.dll" (
        ByVal cb As CallBack, ByVal param As IntPtr) As Boolean
End Class
'</snippet40>

'<snippet41>
Public Class App
    Public Shared Sub Main()
        Dim tw As TextWriter = Console.Out
        Dim gch As GCHandle = GCHandle.Alloc(tw)

        ' Platform invoke prevents the delegate from being garbage collected
        ' before the call ends.
        Dim cewp As CallBack
        cewp = AddressOf App.CaptureEnumWindowsProc
        NativeMethods.EnumWindows(cewp, GCHandle.op_Explicit(gch))
        gch.Free()
    End Sub

    Public Shared Function CaptureEnumWindowsProc(
        ByVal handle As Integer, ByVal param As IntPtr) As Boolean
        Dim gch As GCHandle = GCHandle.op_Explicit(param)
        Dim tw As TextWriter = CType(gch.Target, TextWriter)
        tw.WriteLine(handle)
        Return True
    End Function
End Class
'</snippet41>
'</snippet39>
