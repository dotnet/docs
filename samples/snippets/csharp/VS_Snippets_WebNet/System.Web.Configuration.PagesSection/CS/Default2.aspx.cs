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

public partial class Default2 : System.Web.UI.Page
{
    // <Snippet50>
    // This method will be automatically bound to the Load event
    // when AutoEventWireup is true.
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("Hello world");

    }
    // This method will be automatically bound to the Load event 
    // when AutoEventWireup is true only if no overload having 
    // object and EventArgs parameters is found.
    protected void Page_Load()
    {
        Response.Write("Hello world");
    }
    // </Snippet50>
}
