//<snippet2>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class ChangePassword_cs_aspx : System.Web.UI.Page
{
    protected void Page_Load(Object sender, EventArgs e)
    {
        // Manually register the event-handling methods.
        ChangePassword1.SendingMail += new MailMessageEventHandler(this._SendingMail);
        ChangePassword1.SendMailError += new SendMailErrorEventHandler(this._SendMailError);

        ChangePassword1.MailDefinition.BodyFileName = "~/Attachments/ChangePasswordMail.htm";

        EmbeddedMailObject loginGif = new EmbeddedMailObject();
        loginGif.Name = "LoginGif";
        loginGif.Path = "~/Attachments/Login.gif";

        EmbeddedMailObject privacyNoticeTxt = new EmbeddedMailObject();
        privacyNoticeTxt.Name = "PrivacyNoticeTxt";
        privacyNoticeTxt.Path = "~/Attachments/PrivacyNotice.txt";

        ChangePassword1.MailDefinition.EmbeddedObjects.Add(loginGif);
        ChangePassword1.MailDefinition.EmbeddedObjects.Add(privacyNoticeTxt);
    }

    protected void _SendingMail(object sender, MailMessageEventArgs e)
    {
        Message1.Visible = true;
        Message1.Text = "Sent mail to you to confirm the password change.";

        System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress("someone@example.com", "Someone");
        System.Net.Mail.MailAddress copy = new System.Net.Mail.MailAddress("someone@example.com", "Someone");

        e.Message.From = from;
        e.Message.CC.Add(copy);
        e.Message.Subject = "Activity information for you";
        e.Message.IsBodyHtml = true;
    }

    protected void _SendMailError(object sender, SendMailErrorEventArgs e)
    {
        Message1.Visible = true;
        Message1.Text = "Could not send email to confirm password change.";

        // The MySamplesSite event source has already been created by an administrator.
        System.Diagnostics.EventLog myLog = new System.Diagnostics.EventLog();
        myLog.Source = "MySamplesSite";
        myLog.Log = "Application";
        myLog.WriteEntry(
          "Sending mail via SMTP failed with the following error: " +
          e.Exception.Message.ToString(),
          System.Diagnostics.EventLogEntryType.Error);

        e.Handled = true;
    }
}
//</snippet2>