// <Snippet11> 
using System;
using System.Collections;
using System.Configuration;
using System.Web.DynamicData;

public partial class Default : System.Web.UI.Page
{
    protected MetaTable _table;

    protected void Page_Init(object sender, EventArgs e)
    {
        // Register control with the data manager.
        DynamicDataManager1.RegisterControl(GridView1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the table entity.
        _table = GridDataSource.GetTable();
        // Assign title dinamically.
        Title = string.Concat("Applying the DisplayFormatAttribute to ",
           _table.DisplayName, " Table");

    }
}
// </Snippet11> 