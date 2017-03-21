    // Create a control and bind it to the ExampleAccessDataSourceDesigner.
    [AspNetHostingPermission(System.Security.Permissions.SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(System.Security.Permissions.SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [Designer(typeof(CustomControls.Design.ExampleAccessDataSourceDesigner))]
    public class ExampleAccessDataSource : AccessDataSource
    {
        // Does nothing extra
    }