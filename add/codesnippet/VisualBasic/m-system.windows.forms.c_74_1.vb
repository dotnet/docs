' This button is a simple extension of the button class that overrides
' the ProcessMnemonic method.  If the mnemonic is correctly entered,  
' the message box will appear and the click event will be raised.  
Public Class MyMnemonicButton
    Inherits Button

    ' This method makes sure the control is selectable and the 
    ' mneumonic is correct before displaying the message box
    ' and triggering the click event.
    <System.Security.Permissions.UIPermission( _
    System.Security.Permissions.SecurityAction.Demand, Window:=UIPermissionWindow.AllWindows)> _
    Protected Overrides Function ProcessMnemonic( _
        ByVal inputChar As Char) As Boolean

        If (CanSelect And IsMnemonic(inputChar, Me.Text)) Then
            MessageBox.Show("You've raised the click event " _
                & "using the mnemonic.")
            Me.PerformClick()
            Return True
        End If
        Return False
    End Function

End Class