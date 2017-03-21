        Dim UIservice As IUIService = CType(Me.GetService( _
            GetType(System.Windows.Forms.Design.IUIService)), IUIService)
        If (UIservice IsNot Nothing) Then
            UIservice.ShowDialog(New ExampleForm())
        End If