// <Snippet2>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Security.Permissions;
using System.Security;
using System.Security.Claims;
using System.IdentityModel.Services;

namespace WebApplication1
{
    public partial class Contact : System.Web.UI.Page
    {
        //THIS SHOULD THROW AN EXCEPTION
        [ClaimsPrincipalPermission(SecurityAction.Demand, Operation = "Show", Resource = "Contacts")]
        protected void Page_Load(object sender, EventArgs e)
        {


            ClaimsPrincipalPermission p = new ClaimsPrincipalPermission( "Contacts", "Show");
            p.Demand();

            ClaimsPrincipalPermission.CheckAccess("Contacts", "Show");
            // <Snippet3>
            ClaimsPrincipal principal = HttpContext.Current.User as ClaimsPrincipal;
            if (null != principal)
            {
                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
                if (null != identity)
                {
                    foreach (Claim claim in identity.Claims)
                    {
                        Response.Write("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
                    }
                }
            }
            // </Snippet3>            
        }
    }
}
// </Snippet2>