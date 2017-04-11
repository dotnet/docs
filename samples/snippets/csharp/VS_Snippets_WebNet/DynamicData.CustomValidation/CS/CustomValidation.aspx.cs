// <Snippet4> 
using System;
using System.Collections;
using System.Configuration;
using System.Web.DynamicData;

public partial class CustomValidation : System.Web.UI.Page
{
    protected MetaTable _table1, _table2;

    protected void Page_Init(object sender, EventArgs e)
    {
        // Register data controls with the data manager.
        DynamicDataManager1.RegisterControl(GridView1);
        DynamicDataManager1.RegisterControl(GridView2);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the table entities.
        _table1 = GridDataSource.GetTable();
        _table2 = GridDataSource2.GetTable();
        
        // Assign title dynamically.
        Title = string.Concat("Customize Validation of the ",
            _table1.Name, " and ",  _table2.Name, " Tables");

    }
}
// </Snippet4> 