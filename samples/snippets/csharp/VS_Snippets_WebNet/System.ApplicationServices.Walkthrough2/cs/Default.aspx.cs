// <Snippet3>  
using System;
using System.Web;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

        if (HttpContext.Current.User.Identity.IsAuthenticated) {
            LoggedId.Text = HttpContext.Current.User.Identity.Name +
                " you are logged in.";
        } else
            LoggedId.Text = "You are not logged in.";

    }
}
// </Snippet3>