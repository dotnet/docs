using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// <Snippet63>
using System.Web.UI.HtmlControls;
// </Snippet63>

public partial class Section : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    // <Snippet62>
    protected void ListView1_PreRender(object sender, EventArgs e)
    {
        string s = ObjectDataSource1.SelectParameters["sectionName"].DefaultValue.ToString();
        if (Request.QueryString["Section"] != null)
        {
            s = Request.QueryString["Section"];
        }
        HeadingLabel.Text = HeadingLabel.Text.Replace("[name]", s);

        HtmlGenericControl tableCaption =
            ListView1.FindControl("ElementTableCaption")
            as System.Web.UI.HtmlControls.HtmlGenericControl;
        if (tableCaption != null)
        {
            tableCaption.InnerText = 
                tableCaption.InnerText.Replace("[name]", s);
        }

        Label noElementsLabel =
            ListView1.Controls[0].FindControl("NoElementsLabel") as Label;
        if (noElementsLabel != null)
        {
            noElementsLabel.Text = 
                noElementsLabel.Text.Replace("[name]", s);
        }

    }
    // </Snippet62>
}