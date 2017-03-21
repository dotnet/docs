        Dim UIservice As IUIService = CType(Me.GetService( _
            GetType(System.Windows.Forms.Design.IUIService)), IUIService)
        If (UIservice IsNot Nothing) Then
            UIservice.ShowMessage("Test message", "Test caption", _
                System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore)
        End If