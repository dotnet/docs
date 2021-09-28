﻿'<snippet1>
Imports System.Text
Imports System.Runtime.InteropServices

'<snippet2>
Friend Class NativeMethods
    Friend Declare Auto Sub GetSystemDirectory Lib "Kernel32.dll" _
        (ByVal sysDirBuffer As StringBuilder, ByVal buffSize As Integer)

    Declare Auto Function GetCommandLine Lib "Kernel32.dll" () As IntPtr
End Class
'</snippet2>

'<snippet3>
Public Class App
    Public Shared Sub Main()
        ' Call GetSystemDirectory.
        Dim sysDirBuffer As New StringBuilder(256)
        NativeMethods.GetSystemDirectory(sysDirBuffer, sysDirBuffer.Capacity)
        ' ...
        ' Call GetCommandLine.
        Dim cmdLineStr As IntPtr = NativeMethods.GetCommandLine()
        Dim commandLine As String = Marshal.PtrToStringAuto(cmdLineStr)
    End Sub
End Class
'</snippet3>
'</snippet1>
