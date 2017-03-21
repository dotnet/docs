        ' Add two LiteralControls that render HTML H3 elements and text.
        <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub CreateChildControls()

            Me.Controls.Add(New LiteralControl("<h3>Value: "))

            Dim Box As New TextBox
            Box.Text = "0"
            Me.Controls.Add(box)

            Me.Controls.Add(New LiteralControl("</h3>"))
        End Sub