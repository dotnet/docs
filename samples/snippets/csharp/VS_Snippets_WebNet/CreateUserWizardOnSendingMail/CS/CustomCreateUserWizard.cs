// <snippet2>
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls {

[AspNetHostingPermission (System.Security.Permissions.SecurityAction.Demand,
  Level = AspNetHostingPermissionLevel.Minimal)]
[AspNetHostingPermission (System.Security.Permissions.SecurityAction.InheritanceDemand,
  Level = AspNetHostingPermissionLevel.Minimal)]
  public class CustomCreateUserWizard : CreateUserWizard
  {
    public CustomCreateUserWizard()
    {
      this.MailDefinition.BodyFileName = "MailFile.txt";
      this.MailDefinition.From = "userAdmin@your.site.name.here";
    }
  
    protected override void OnSendingMail(MailMessageEventArgs e) 
    {
      e.Message.Subject = "New Web site user.";
    
      // Replace placeholder text in message body with information
      //  provided by the user.
      e.Message.Body.Replace("<%PasswordQuestion%>",this.Question);
      e.Message.Body.Replace("<%PasswordAnswer%>", this.Answer);
    
      base.OnSendingMail(e);
    }
  }
}
// </snippet2>