      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Function CreateControlCollection() As ControlCollection
         myControlCollection = New ControlCollection(Me)
         Return myControlCollection
      End Function 'CreateControlCollection
      