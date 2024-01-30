' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Runtime.InteropServices

Public Module Example5
    ' <DllImport("kernel32.dll", SetLastError = true)>
    Private Declare Function GetStdHandle Lib "Kernel32" (
                   nStdHandle As Integer) As IntPtr

    ' [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    Private Declare Function GetCurrentConsoleFontEx Lib "Kernel32" (
                   consoleOutput As IntPtr,
                   maximumWindow As Boolean,
                   ByRef lpConsoleCurrentFontEx As CONSOLE_FONT_INFO_EX) As Boolean

    ' [DllImport("kernel32.dll", SetLastError = true)]
    Private Declare Function SetCurrentConsoleFontEx Lib "Kernel32" (
                   consoleOutput As IntPtr,
                   maximumWindow As Boolean,
                   consoleCurrentFontEx As CONSOLE_FONT_INFO_EX) As Boolean

    Private Const STD_OUTPUT_HANDLE As Integer = -11
    Private Const TMPF_TRUETYPE As Integer = 4
    Private Const LF_FACESIZE As Integer = 32
    Private INVALID_HANDLE_VALUE As IntPtr = New IntPtr(-1)

    Public Sub Main()
        Dim fontName As String = "Lucida Console"
        Dim hnd As IntPtr = GetStdHandle(STD_OUTPUT_HANDLE)
        If hnd <> INVALID_HANDLE_VALUE Then
            Dim info As CONSOLE_FONT_INFO_EX = New CONSOLE_FONT_INFO_EX()
            info.cbSize = CUInt(Marshal.SizeOf(info))
            Dim tt As Boolean = False
            ' First determine whether there's already a TrueType font.
            If GetCurrentConsoleFontEx(hnd, False, info) Then
                tt = (info.FontFamily And TMPF_TRUETYPE) = TMPF_TRUETYPE
                If tt Then
                    Console.WriteLine("The console already is using a TrueType font.")
                    Return
                End If
                ' Set console font to Lucida Console.
                Dim newInfo As CONSOLE_FONT_INFO_EX = New CONSOLE_FONT_INFO_EX()
                newInfo.cbSize = CUInt(Marshal.SizeOf(newInfo))
                newInfo.FontFamily = TMPF_TRUETYPE
                newInfo.FaceName = fontName
                ' Get some settings from current font.
                newInfo.dwFontSize = New COORD(info.dwFontSize.X, info.dwFontSize.Y)
                newInfo.FontWeight = info.FontWeight
                SetCurrentConsoleFontEx(hnd, False, newInfo)
            End If
        End If
    End Sub

    <StructLayout(LayoutKind.Sequential)> Friend Structure COORD
        Friend X As Short
        Friend Y As Short

        Friend Sub New(x As Short, y As Short)
            Me.X = x
            Me.Y = y
        End Sub
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> Friend Structure CONSOLE_FONT_INFO_EX
        Friend cbSize As UInteger
        Friend nFont As UInteger
        Friend dwFontSize As COORD
        Friend FontFamily As Integer
        Friend FontWeight As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> Friend FaceName As String
    End Structure
End Module
' </Snippet3>
