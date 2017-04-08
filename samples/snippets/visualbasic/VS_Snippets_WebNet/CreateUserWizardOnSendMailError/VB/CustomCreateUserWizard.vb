' <snippet2>
Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
  <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class CustomCreateUserWizard
    Inherits CreateUserWizard

    Private Sub SiteSpecificErrorLoggingProcedure(ByVal e As SendMailErrorEventArgs)
      ' Site-specific code for logging e-mail errors goes here.
    End Sub
    
    Overloads Sub OnSendMailError(ByVal e As SendMailErrorEventArgs)
      Me.SiteSpecificErrorLoggingProcedure(e)
      e.Handled = True
    End Sub
  End Class
End Namespace
' </snippet2>