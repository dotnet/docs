' <snippet2>
Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Security.Permissions
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class MyManagerIDLabel

    Inherits Label

    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)

      EnsureChildControls()
      Me.Text = _
        WebPartManager.GetCurrentWebPartManager(Page).ID

    End Sub

  End Class

End Namespace
' </snippet2>
