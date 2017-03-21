<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Protected Overrides Sub Render(Output As HtmlTextWriter)
    If HasControls() And TypeOf Controls(0) Is LiteralControl
        Dim Ctrl As LiteralControl = CType(Controls(0), LiteralControl)
        Output.Write("<H2>Your Message: " & Ctrl.Text & "</H2>")
    End If
End Sub