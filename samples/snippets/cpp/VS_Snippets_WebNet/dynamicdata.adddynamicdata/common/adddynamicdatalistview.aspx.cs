using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;

public partial class AddDynamicDataListView : System.Web.UI.Page
{
    protected MetaTable table;

    // Perform page elements initialization. 
    protected void Page_Init(object sender, EventArgs e)
    {
        // Get the metadata of the current table.
        table = EntityDataSource1.GetMetaTable();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Set page title. 
        Title = "Display " + table.DisplayName + " Row";
    }

    // You must assure that the base.OnPreRenderComplete(e) call is 
    // performed to allow for the appropriate scripts to be loaded in the page and 
    // to avoid that the "Sys undefined runtime error" is issued  
    // in the <asp:ScriptManager> control.
    protected override void OnPreRenderComplete(EventArgs e)
    {
      base.OnPreRenderComplete(e);
    }
}