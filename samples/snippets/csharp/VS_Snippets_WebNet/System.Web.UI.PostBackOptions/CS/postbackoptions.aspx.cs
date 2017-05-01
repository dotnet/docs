// <snippet2>
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class postbackoptionscs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            Label1.Text = "A postback event has occurred.";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Create a new PostBackOptions object and set its properties.
        PostBackOptions myPostBackOptions = new PostBackOptions(this);
        myPostBackOptions.ActionUrl = "Page2.aspx";
        myPostBackOptions.AutoPostBack = false;
        myPostBackOptions.RequiresJavaScriptProtocol = true;
        myPostBackOptions.PerformValidation = true;

        // Add the client-side script to the HyperLink1 control.
        HyperLink1.NavigateUrl = Page.ClientScript.GetPostBackEventReference(myPostBackOptions);

        Label1.Text = "Click this hyperlink to initiate a postback event.";
    }
}
// </snippet2>