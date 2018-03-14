using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;

public partial class SectionGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // <Snippet40>
        SectionGroupGridView.HeaderRow.TableSection =
            TableRowSection.TableHeader;
        // </Snippet40>

        // <Snippet42>
        string s = ObjectDataSource1.SelectParameters["sectionGroupName"].DefaultValue.ToString();
        if (Request.QueryString["SectionGroup"] != null)
        {
            s = Request.QueryString["SectionGroup"];
        }
        HeadingLabel.Text = HeadingLabel.Text.Replace("[name]", s);
        SectionGroupGridView.Caption =
            SectionGroupGridView.Caption.Replace("[name]", s);
        // </Snippet42>
    }
}

