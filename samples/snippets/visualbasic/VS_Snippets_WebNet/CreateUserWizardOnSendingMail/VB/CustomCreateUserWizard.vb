' <Snippet2>
Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
  <AspNetHostingPermission(System.Security.Permissions.SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(System.Security.Permissions.SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  Public Class CustomCreateUserWizard
    Inherits CreateUserWizard
    
    Public Sub New()
      Me.MailDefinition.BodyFileName = "MailFile.txt"
      Me.MailDefinition.From = "userAdmin@your.site.name.here"
    End Sub
    
    Protected Overloads Sub OnSendingMail(ByVal e As MailMessageEventArgs)
      e.Message.Subject = "New user on Web site."
      ' Replace placeholder text in message body with information
      '  provided by the user.
      e.Message.Body.Replace("<%PasswordQuestion%>", Me.Question)
      e.Message.Body.Replace("<%PasswordAnswer%>", Me.Answer)
      
      MyBase.OnSendingMail(e)
    End Sub
  End Class
End Namespace
' </Snippet2>