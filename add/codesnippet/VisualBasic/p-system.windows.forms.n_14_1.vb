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