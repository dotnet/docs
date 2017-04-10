// <snippet2>
using System;
using System.Web;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls 
{
    [AspNetHostingPermission(System.Security.Permissions.SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class PasswordRecoveryOnBeforeSendingEmail : PasswordRecovery
    {
        protected override void OnSendingMail(MailMessageEventArgs e)
        {
            e.Message.Subject = "New password on Web site.";
            base.OnSendingMail(e);
        }
    }
}
// </snippet2>