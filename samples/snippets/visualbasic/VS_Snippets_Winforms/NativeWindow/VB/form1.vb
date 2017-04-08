'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class Form1
    Inherits System.Windows.Forms.Form

    Private nwl As MyNativeWindowListener
    Private nw As MyNativeWindow

    Friend Sub ApplicationActivated(ByVal ApplicationActivated As Boolean)
        ' The application has been activated or deactivated
        System.Diagnostics.Debug.WriteLine("Application Active = " + ApplicationActivated.ToString())
    End Sub

    Private Sub New()
        MyBase.New()

        Me.Size = New System.Drawing.Size(300, 300)
        Me.Text = "Form1"

        nwl = New MyNativeWindowListener(Me)
        nw = New MyNativeWindow(Me)

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class

'<Snippet2>
' NativeWindow class to listen to operating system messages.
Friend Class MyNativeWindowListener
    Inherits NativeWindow

    ' Constant value was found in the "windows.h" header file.
    Private Const WM_ACTIVATEAPP As Integer = &H1C

    Private parent As Form1

    Public Sub New(ByVal parent As Form1)

        AddHandler parent.HandleCreated, AddressOf Me.OnHandleCreated
        AddHandler parent.HandleDestroyed, AddressOf Me.OnHandleDestroyed
        Me.parent = parent
    End Sub

    ' Listen for the control's window creation and hook into it.    
    Private Sub OnHandleCreated(ByVal sender As Object, ByVal e As EventArgs)
        ' Window is now created, assign handle to NativeWindow.
        AssignHandle(CType(sender, Form).Handle)
    End Sub

    Private Sub OnHandleDestroyed(ByVal sender As Object, ByVal e As EventArgs)
        ' Window was destroyed, release hook.
        ReleaseHandle()
    End Sub

    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub WndProc(ByRef m As Message)
        ' Listen for operating system messages

        Select Case (m.Msg)
            Case WM_ACTIVATEAPP

                ' Notify the form that this message was received.
                ' Application is activated or deactivated, 
                ' based upon the WParam parameter.
                parent.ApplicationActivated(m.WParam.ToInt32() <> 0)

        End Select

        MyBase.WndProc(m)
    End Sub
End Class
'</Snippet2>

'<Snippet3>
' MyNativeWindow class to create a window given a class name.
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Friend Class MyNativeWindow
    Inherits NativeWindow

    ' Constant values were found in the "windows.h" header file.
    Private Const WS_CHILD As Integer = &H40000000, _
                  WS_VISIBLE As Integer = &H10000000, _
                  WM_ACTIVATEAPP As Integer = &H1C

    Private windowHandle As Integer

    Public Sub New(ByVal parent As Form)

        Dim cp As CreateParams = New CreateParams()

        ' Fill in the CreateParams details.
        cp.Caption = "Click here"
        cp.ClassName = "Button"

        ' Set the position on the form
        cp.X = 100
        cp.Y = 100
        cp.Height = 100
        cp.Width = 100

        ' Specify the form as the parent.
        cp.Parent = parent.Handle

        ' Create as a child of the specified parent
        cp.Style = WS_CHILD Or WS_VISIBLE

        ' Create the actual window
        Me.CreateHandle(cp)
    End Sub

    ' Listen to when the handle changes to keep the variable in sync
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub OnHandleChange()
        windowHandle = Me.Handle.ToInt32()
    End Sub

    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub WndProc(ByRef m As Message)
        ' Listen for messages that are sent to the button window. Some messages are sent
        ' to the parent window instead of the button's window.

        Select Case (m.Msg)
            Case WM_ACTIVATEAPP
                ' Do something here in response to messages
        End Select

        MyBase.WndProc(m)
    End Sub

End Class
'</Snippet3>
'</Snippet1>