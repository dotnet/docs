Imports System
Imports System.Windows.Forms

Public Class FontDialogOverride
    Inherits FontDialog

    '<snippet1>
    ' Defines the constants for Windows messages.

    Const WM_SETFOCUS = &H7
    Const WM_INITDIALOG = &H110
    Const WM_LBUTTONDOWN = &H201
    Const WM_RBUTTONDOWN = &H204
    Const WM_MOVE = &H3
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Function HookProc(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr


        ' Evaluates the message parameter to determine the user action.

        Select Case msg

            Case WM_INITDIALOG
                System.Diagnostics.Trace.Write("The WM_INITDIALOG message was received.")
            Case WM_SETFOCUS
                System.Diagnostics.Trace.Write("The WM_SETFOCUS message was received.")
            Case WM_LBUTTONDOWN
                System.Diagnostics.Trace.Write("The WM_LBUTTONDOWN message was received.")
            Case WM_RBUTTONDOWN
                System.Diagnostics.Trace.Write("The WM_RBUTTONDOWN message was received.")
            Case WM_MOVE
                System.Diagnostics.Trace.Write("The WM_MOVE message was received.")

        End Select

        ' Always call the base class hook procedure.

        Return MyBase.HookProc(hWnd, msg, wParam, lParam)

    End Function
    '</snippet1>

End Class
