
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim SecPerm As New SecurityPermission(SecurityPermissionFlag.UnmanagedCode)
            SecPerm.Demand()

            ' Extend the CreateParams property of the Button class.
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            ' Update the button Style.
            cp.Style = cp.Style Or &H40 ' BS_ICON value

            Return cp
        End Get
    End Property