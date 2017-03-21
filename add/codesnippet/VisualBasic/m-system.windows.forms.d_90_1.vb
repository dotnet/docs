Public Class CustomDataGridView
    Inherits DataGridView

    <System.Security.Permissions.UIPermission( _
        System.Security.Permissions.SecurityAction.LinkDemand, _
        Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)> _
    Protected Overrides Function ProcessDialogKey( _
        ByVal keyData As Keys) As Boolean

        ' Extract the key code from the key value. 
        Dim key As Keys = keyData And Keys.KeyCode

        ' Handle the ENTER key as if it were a RIGHT ARROW key. 
        If key = Keys.Enter Then
            Return Me.ProcessRightKey(keyData)
        End If

        Return MyBase.ProcessDialogKey(keyData)

    End Function

    <System.Security.Permissions.SecurityPermission( _
        System.Security.Permissions.SecurityAction.LinkDemand, Flags:= _
        System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Function ProcessDataGridViewKey( _
        ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean

        ' Handle the ENTER key as if it were a RIGHT ARROW key. 
        If e.KeyCode = Keys.Enter Then
            Return Me.ProcessRightKey(e.KeyData)
        End If

        Return MyBase.ProcessDataGridViewKey(e)

    End Function

End Class