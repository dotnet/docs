      ' Override CreateChildControls to create the control tree.
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="Execution")> _
      Protected Overrides Sub CreateChildControls()
         
         ' Add a LiteralControl to the current ControlCollection.
         Me.Controls.Add(New LiteralControl("<h3>Value: "))
         
         
         ' Create a text box control, set the default Text property, 
         ' and add it to the ControlCollection.
         Dim box As New TextBox()
         box.Text = "0"
         Me.Controls.Add(box)
         
         Me.Controls.Add(New LiteralControl("</h3>"))
      End Sub 'CreateChildControls