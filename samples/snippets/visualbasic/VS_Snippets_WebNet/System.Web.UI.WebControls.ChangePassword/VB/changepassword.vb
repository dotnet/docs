'<snippet2>
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports Microsoft.VisualBasic

Partial Class ChangePassword_vb_aspx
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal Sender As Object, ByVal e As System.EventArgs)
        AddHandler ChangePassword1.SendingMail, AddressOf Me._SendingMail
        AddHandler ChangePassword1.SendMailError, AddressOf Me._SendMailError
        ChangePassword1.MailDefinition.BodyFileName = "~/Attachments/ChangePasswordMail.htm"
        ChangePassword1.MailDefinition.Cc = "someone@example.com"
        ChangePassword1.MailDefinition.From = "someone@example.com"

        Dim loginGif As New EmbeddedMailObject
        loginGif.Name = "LoginGif"
        loginGif.Path = "~/Attachments/Login.gif"

        Dim privacyNoticeTxt As New EmbeddedMailObject
        privacyNoticeTxt.Name = "PrivacyNoticeTxt"
        privacyNoticeTxt.Path = "~/Attachments/PrivacyNotice.txt"

        ChangePassword1.MailDefinition.EmbeddedObjects.Add(loginGif)
        ChangePassword1.MailDefinition.EmbeddedObjects.Add(privacyNoticeTxt)
    End Sub

    Protected Sub _SendingMail(ByVal Sender As Object, ByVal e As MailMessageEventArgs)
        Message1.Visible = True
        Message1.Text = "Sent mail to you to confirm the password change."

        e.Message.Subject = "Activity information for you"
        e.Message.IsBodyHtml = True

    End Sub

    Protected Sub _SendMailError(ByVal Sender As Object, ByVal e As SendMailErrorEventArgs)
        Message1.Visible = True
        Message1.Text = "Could not send mail to confirm the password change."

        ' The MySamplesSite event source has already been created by an administrator.
        Dim myLog As System.Diagnostics.EventLog
        myLog = New System.Diagnostics.EventLog
        myLog.Log = "Application"
        myLog.Source = "MySamplesSite"
        myLog.WriteEntry("Sending mail via SMTP failed with the following error: " & e.Exception.Message.ToString(), System.Diagnostics.EventLogEntryType.Error)

        e.Handled = True

    End Sub

End Class
'</snippet2>