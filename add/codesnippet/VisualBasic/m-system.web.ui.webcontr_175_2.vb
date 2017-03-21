    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomLiteralCreateControlCollection
        Inherits System.Web.UI.WebControls.Literal

        Protected Overrides Function CreateControlCollection() As System.Web.UI.ControlCollection

            ' Return a new EmptyControlCollection
            Return New System.Web.UI.EmptyControlCollection(Me)
        End Function
    End Class