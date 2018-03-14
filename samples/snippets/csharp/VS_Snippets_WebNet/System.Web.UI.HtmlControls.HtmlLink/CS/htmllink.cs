// <snippet2>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class HtmlLinkcs_aspx
{
    void Page_Init(object sender, EventArgs e)
    {
        // Create an instance of HtmlLink.
        HtmlLink myHtmlLink = new HtmlLink();
        myHtmlLink.Href = "StyleSheet.css";     
        myHtmlLink.Attributes.Add("rel", "stylesheet");
        myHtmlLink.Attributes.Add("type", "text/css");   

        // Add the instance of HtmlLink to the <HEAD> section of the page.
        head1.Controls.Add(myHtmlLink);
        
    }
}
// </snippet2>