//<Snippet8>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IdentityModel.Services;

namespace WebApplication1
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FederatedAuthentication.SessionAuthenticationModule.SignOut();
        }
    }
}
//</Snippet8>