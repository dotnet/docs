        Dim UIservice As IUIService = CType(Me.GetService( _
            GetType(System.Windows.Forms.Design.IUIService)), IUIService)
        If (UIservice IsNot Nothing) Then
            UIservice.ShowError(New Exception( _
                "This is a message in a test exception, displayed by the IUIService", _
                New ArgumentException("Test inner exception")))
        End If