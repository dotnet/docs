' <snippet2>
Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
  <AspNetHostingPermission(System.Security.Permissions.SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(System.Security.Permissions.SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class CustomCreateUserWizard
    Inherits CreateUserWizard
    
    Overloads Sub OnCreatingUser(ByVal e As LoginCancelEventArgs)
      Me.UserName.ToLower()
      MyBase.OnCreatingUser(e)
    End Sub    
    
  End Class
End Namespace
' </snippet2>