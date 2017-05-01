// <snippet7>
using System;
using System.Web;
using System.Web.Security;

public partial class CreateUser : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }
    protected void On_CreatedUser(object sender, EventArgs e) {
        string userName = CreateUserWizard1.UserName;
        if (RDO_Manager.Checked){
            HttpContext.Current.Response.Write(userName);
            Roles.AddUserToRole(userName, "Managers");
        } else
            Roles.AddUserToRole(userName, "Friends");

        HttpContext.Current.Response.Redirect("~/default.aspx");
    }
}
// </snippet7>