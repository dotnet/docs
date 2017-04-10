using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

// <snippet2>
public partial class CreateUserWizardErrorcs_aspx : System.Web.UI.Page
{
    protected void OnCreateUserError(object sender, System.Web.UI.WebControls.CreateUserErrorEventArgs e)
    {
        
        switch (e.CreateUserError)
        {
            case MembershipCreateStatus.DuplicateUserName:
                Label1.Text = "Username already exists. Please enter a different user name.";
                break;

            case MembershipCreateStatus.DuplicateEmail:
                Label1.Text = "A username for that e-mail address already exists. Please enter a different e-mail address.";
                break;

            case MembershipCreateStatus.InvalidPassword:
                Label1.Text = "The password provided is invalid. Please enter a valid password value.";
                break;

            case MembershipCreateStatus.InvalidEmail:
                Label1.Text = "The e-mail address provided is invalid. Please check the value and try again.";
                break;

            case MembershipCreateStatus.InvalidAnswer:
                Label1.Text = "The password retrieval answer provided is invalid. Please check the value and try again.";
                break;

            case MembershipCreateStatus.InvalidQuestion:
                Label1.Text = "The password retrieval question provided is invalid. Please check the value and try again.";
                break;

            case MembershipCreateStatus.InvalidUserName:
                Label1.Text = "The user name provided is invalid. Please check the value and try again.";
                break;

            case MembershipCreateStatus.ProviderError:
                Label1.Text = "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                break;

            case MembershipCreateStatus.UserRejected:
                Label1.Text = "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                break;

            default:
                Label1.Text = "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                break;
        }
    }
}
// </snippet2>
