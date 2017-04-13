using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;

public partial class List : System.Web.UI.Page {
    protected MetaTable table;

    // Perform page elements initialization. 
    protected void Page_Init(object sender, EventArgs e) {
        
        // Get the metadata of the current table.
        table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
        
        GridView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
        GridDataSource.EntityTypeName = table.EntityType.AssemblyQualifiedName;

        // Limit the query only to the specified type.
        if (table.EntityType != table.RootEntityType) {
            GridQueryExtender.Expressions.Add(new OfTypeExpression(table.EntityType));
        }
    }

    // Perform intialization to be done during page load phase.
    protected void Page_Load(object sender, EventArgs e) {
        Title = table.DisplayName;
        
        // Set the page title.
        Title = "Display " + table.DisplayName;
       
        // Disable various options if the table is readonly
        if (table.IsReadOnly) {
            GridView1.Columns[0].Visible = false;
            InsertHyperLink.Visible = false;
            GridView1.EnablePersistedSelection = false;
        }
    }

    // Set the filter controls.
    protected void Label_PreRender(object sender, EventArgs e) {
        Label label = (Label)sender;

        // Customize the filter label in case of custom enumerator.
        if (label.Text == "OrderQty")
            label.Text = "Custom Enumeration " + label.Text;

        // Get the current filter control from the ones contained by 
        // the QueryableFilterRepeater control.
        DynamicFilter dynamicFilter = (DynamicFilter)label.FindControl("DynamicFilter");

        // Assign the label name for the current filter.
        QueryableFilterUserControl fuc = dynamicFilter.FilterTemplate as QueryableFilterUserControl;
        if (fuc != null && fuc.FilterControl != null) {
            label.AssociatedControlID = fuc.FilterControl.GetUniqueIDRelativeTo(label);
        }
    }

    // Initialize the insert action link. Also assure that the client scripts
    // are loaded to enable the script manager to handle partial page rendering. 
    // Notice: You must assure that the base.OnPreRenderComplete(e) call is 
    // performed to allow for the appropriate scripts to be loaded in the page and 
    // to avoid that "Sys undefined runtime error" is issued  
    // for the <asp:ScriptManager> control.
    protected override void OnPreRenderComplete(EventArgs e) {
        RouteValueDictionary routeValues = new RouteValueDictionary(GridView1.GetDefaultValues());
        InsertHyperLink.NavigateUrl = table.GetActionPath(PageAction.Insert, routeValues);
        base.OnPreRenderComplete(e);
    }

    // Set page index to 0 after table row filtering.
    protected void DynamicFilter_FilterChanged(object sender, EventArgs e) {
        GridView1.PageIndex = 0;
    }

}
