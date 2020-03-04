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
    // <Snippet4>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cache[ObjectDataSource2.CacheKeyDependency] = "CacheExample";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Cache.Remove(ObjectDataSource2.CacheKeyDependency);
        Cache[ObjectDataSource2.CacheKeyDependency] = "CacheExample";
        DetailsView1.DataBind();
    }
    // </Snippet4>
}
