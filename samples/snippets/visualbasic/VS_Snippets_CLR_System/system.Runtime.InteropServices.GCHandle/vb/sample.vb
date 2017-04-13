' <snippet1>
Imports System
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

Public Delegate Function CallBack(ByVal handle As Integer, ByVal param As IntPtr) As Boolean


Module LibWrap

    ' passing managed object as LPARAM
    ' BOOL EnumWindows(WNDENUMPROC lpEnumFunc, LPARAM lParam);
    <DllImport("user32.dll")> _
    Function EnumWindows(ByVal cb As CallBack, ByVal param As IntPtr) As Boolean
    End Function
End Module 'LibWrap


Module App

    Sub Main()
	Run()

    End Sub

    <SecurityPermission(SecurityAction.Demand, UnmanagedCode:=true)> _
    Sub Run()

        Dim tw As TextWriter = System.Console.Out
        Dim gch As GCHandle = GCHandle.Alloc(tw)

        Dim cewp As CallBack
        cewp = AddressOf CaptureEnumWindowsProc

        ' platform invoke will prevent delegate to be garbage collected
        ' before call ends
        LibWrap.EnumWindows(cewp, GCHandle.ToIntPtr(gch))
        gch.Free()

    End Sub


    Function CaptureEnumWindowsProc(ByVal handle As Integer, ByVal param As IntPtr) As Boolean
        Dim gch As GCHandle = GCHandle.FromIntPtr(param)
        Dim tw As TextWriter = CType(gch.Target, TextWriter)
        tw.WriteLine(handle)
        Return True

    End Function
End Module
' </snippet1>