
Imports System.Threading
Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Collections
Imports System.IO
Imports System.Text
Imports System.Security


' This class *MUST* be internal for security purposes

Friend Class UnmanagedClass
    <DllImport("user32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
    Public Overloads Shared Function SendMessageTimeout(ByVal hwnd As HWND, _
    ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr, _
    ByVal flags As Integer, ByVal uTimeout As Integer, ByRef pResult As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
    Friend Overloads Shared Function SendMessageTimeout(ByVal hwnd As IntPtr, _
    ByVal uMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As StringBuilder, _
    ByVal flags As Integer, ByVal uTimeout As Integer, ByRef result As IntPtr) As IntPtr
    End Function


    <DllImport("user32.dll", CharSet:=CharSet.Unicode)> _
    Public Overloads Shared Function SendMessage(ByVal hWnd As HWND, _
    ByVal nMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)> _
    Public Overloads Shared Function SendMessage(ByVal hWnd As HWND, ByVal nMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As StringBuilder) As IntPtr
    End Function

    <DllImport("user32", ExactSpelling:=True)> _
    Friend Overloads Shared Function IsWindowEnabled(ByVal hWnd As IntPtr) As Boolean
    End Function

    '
    ' Control style information
    '
    Public Const GCL_STYLE As Integer = -16

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Public Overloads Shared Function GetWindowLong(ByVal hWnd As HWND, ByVal nIndex As Integer) As Integer
    End Function


    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Public Overloads Shared Function IsWindowEnabled(ByVal hwnd As HWND) As Boolean
    End Function


    ' Editbox styles
    Friend Const ES_READONLY As Integer = &H800

    ' Editbox messages
    Friend Const WM_SETTEXT As Integer = &HC
    Friend Const EM_GETLIMITTEXT As Integer = &HD5

    <StructLayout(LayoutKind.Sequential)> Public Structure HWND
        Public h As IntPtr

        Public Shared Function Cast(ByVal h As IntPtr) As HWND
            Dim hTemp As New HWND()
            hTemp.h = h
            Return hTemp
        End Function 'Cast

        Public Overloads Shared Function Pointer(ByVal h As HWND) As IntPtr
            'ToDo: User-defined operator replaced by method.
            'References to operator will need to be replaced by calls to this method
            Return h.h
        End Function 'EqualOp


        Public ReadOnly Property NULL() As HWND
            Get
                Dim hTemp As New HWND()
                hTemp.h = IntPtr.Zero
                Return hTemp
            End Get
        End Property

        Public Overloads Shared Function EqualOp(ByVal hl As HWND, ByVal hr As HWND) As Boolean
            'ToDo: User-defined operator replaced by method.
            'References to operator will need to be replaced by calls to this method
            Return hl.h = hr.h
        End Function 'EqualOp


        Public Overloads Shared Function NotEqualOp(ByVal hl As HWND, ByVal hr As HWND) As Boolean
            'ToDo: User-defined operator replaced by method.
            'References to operator will need to be replaced by calls to this method
            Return hl.h <> hr.h
        End Function 'NotEqualOp

        Public Overrides Function Equals(ByVal oCompare As Object) As Boolean
            Dim hr As HWND = Cast(oCompare)
            Return h = hr.h
        End Function 'Equals

        Public Overrides Function GetHashCode() As Integer
            Return Fix(h)
        End Function 'GetHashCode

    End Structure 'HWND

End Class 'UnmanagedClass




