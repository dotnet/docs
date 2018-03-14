using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

// <snippet6>
public partial class ProfileInfo : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        ProfileCommon Profile = HttpContext.Current.Profile as ProfileCommon;

        if (HttpContext.Current.User.Identity.IsAuthenticated) {
            Lbl_UserName.Text = HttpContext.Current.User.Identity.Name;
            string[] roles = Roles.GetRolesForUser();
            Lbl_Roles.Text = "";
            foreach (string r in roles) {
                Lbl_Roles.Text += r + " ";
            }

            Lbl_FirstName.Text = Profile.FirstName;
            Lbl_LastName.Text = Profile.LastName;
            Lbl_Phone.Text = Profile.PhoneNumber;

        } else {
            Lbl_UserName.Text = "User is not logged in.";
            Lbl_UserName.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void But_ReadProfile_Click(object sender, EventArgs e) {
        if (HttpContext.Current.User.Identity.IsAuthenticated) {
            Lbl_UserName.Text = HttpContext.Current.User.Identity.Name;
            string[] roles = Roles.GetRolesForUser();
            Lbl_Roles.Text = "";
            foreach (string r in roles) {
                Lbl_Roles.Text += r + " ";
            }

            Lbl_FirstName.Text = Profile.FirstName;
            Lbl_LastName.Text = Profile.LastName;
            Lbl_Phone.Text = Profile.PhoneNumber;

        } else {
            Lbl_UserName.Text = "User is not logged in.";
            Lbl_UserName.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void But_UpdateProfile_Click(object sender, EventArgs e) {
        if (HttpContext.Current.User.Identity.IsAuthenticated) {
            Profile.FirstName = TB_FirstName.Text;
            Profile.LastName = TB_LastName.Text;
            Profile.PhoneNumber = TB_phoneNumber.Text;
        }
    }
}

// </snippet6>