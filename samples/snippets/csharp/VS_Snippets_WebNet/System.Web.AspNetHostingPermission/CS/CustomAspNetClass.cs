//<Snippet1>
using System;
using System.Web;
using System.Security.Permissions;

[AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Medium)]
public class CustomAspNetClass
{

}
//</Snippet1>