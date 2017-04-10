' <snippet2>
Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:= AspNetHostingPermissionLevel.Minimal)> _
    Public Class PasswordRecoveryOnBeforeSendingEmail
        Inherits PasswordRecovery

        Protected Overloads Sub OnSendingMail(ByVal e As MailMessageEventArgs)

            e.Message.Subject = "New password on Web site."
            MyBase.OnSendingMail(e)

        End Sub
    End Class

End Namespace
' </snippet2>
