using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    // <Snippet1>
    protected void Reset_Click(object sender, EventArgs e)
    {
        ListDictionary keyValues = new ListDictionary();
        ListDictionary newValues = new ListDictionary();
        ListDictionary oldValues = new ListDictionary();

        keyValues.Add("ProductID", int.Parse(((Label)DetailsView1.FindControl("IDLabel")).Text));

        oldValues.Add("ProductName", ((Label)DetailsView1.FindControl("NameLabel")).Text);
        oldValues.Add("ProductCategory", ((Label)DetailsView1.FindControl("CategoryLabel")).Text);
        oldValues.Add("Color", ((Label)DetailsView1.FindControl("ColorLabel")).Text);

        newValues.Add("ProductName", "New Product");
        newValues.Add("ProductCategory", "General");
        newValues.Add("Color", "Not assigned");

        LinqDataSource1.Update(keyValues, newValues, oldValues);

        DetailsView1.DataBind();
    }
    // </Snippet1>
}
