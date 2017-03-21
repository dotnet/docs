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