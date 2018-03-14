' <Snippet2>
Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Security.Permissions

<Assembly: WebResource("Samples.AspNet.VB.Controls.script_include.js", "application/x-javascript")> 
Namespace Samples.AspNet.VB.Controls

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class ClientScriptResourceLabel

        ' Class code goes here.

    End Class

End Namespace
' </Snippet2>