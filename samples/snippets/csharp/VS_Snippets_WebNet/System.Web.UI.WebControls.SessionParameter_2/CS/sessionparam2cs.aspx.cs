using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class sessionparam2cs_aspx : System.Web.UI.Page
{
    private void Page_Load(object sender, EventArgs e)
    {
// <Snippet1>
        // In this example, the session parameter "empid" is set
        // after the employee successfully logs in.
        SessionParameter empid = new SessionParameter();
        empid.Name = "empid";
        empid.Type = TypeCode.Int32;
        empid.SessionField = "empid";
// </Snippet1>
    }
}
