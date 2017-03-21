    ' Create a control and bind it to the ExampleAccessDataSourceDesigner.
    <AspNetHostingPermission(System.Security.Permissions.SecurityAction.Demand, _
        Level:=System.Web.AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(System.Security.Permissions.SecurityAction.InheritanceDemand, _
        Level:=System.Web.AspNetHostingPermissionLevel.Minimal)> _
    <Designer("CustomControls.Design.ExampleAccessDataSourceDesigner")> _
    Public Class ExampleAccessDataSource
        Inherits AccessDataSource

        ' Does nothing extra
    End Class