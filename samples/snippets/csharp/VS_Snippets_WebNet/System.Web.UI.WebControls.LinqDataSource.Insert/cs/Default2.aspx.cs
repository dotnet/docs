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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    // <Snippet1>
    protected void Add_Click(object sender, EventArgs e)
    {
        System.Collections.Specialized.ListDictionary listDictionary
            = new System.Collections.Specialized.ListDictionary();
        listDictionary.Add("ProductName", TextBox1.Text);
        listDictionary.Add("ProductCategory", "General");
        listDictionary.Add("Color", "Not assigned");
        listDictionary.Add("ListPrice", null);
        LinqDataSource1.Insert(listDictionary);

        TextBox1.Text = String.Empty;
        DetailsView1.DataBind();
    }
    // </Snippet1>
}
