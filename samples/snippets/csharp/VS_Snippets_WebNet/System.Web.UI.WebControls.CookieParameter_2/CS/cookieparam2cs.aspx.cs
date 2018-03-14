using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
// <Snippet2>
public partial class cookieparam2cs_aspx : System.Web.UI.Page 
{
    void Page_Load(Object sender, EventArgs e)
    {
        // These cookies might be added by a login form.
        // They are added here for simplicity.
        if (!IsPostBack)
        {
            Response.Cookies.Add(new HttpCookie("lname", "davolio"));
            Response.Cookies.Add(new HttpCookie("loginname", "ndavolio"));
            Response.Cookies.Add(new HttpCookie("lastvisit", DateTime.Now.ToString()));


            // You can add a CookieParameter to the SqlDataSource control's
            // SelectParameters collection programmatically.
            CookieParameter cookieParam = new CookieParameter();
            cookieParam.Name = "lastname";
            cookieParam.Type = TypeCode.String;
            cookieParam.CookieName = "lname";

            SqlDataSource1.SelectParameters.Add(cookieParam);
        }

    }
}
// </Snippet2>