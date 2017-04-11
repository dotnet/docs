// <Snippet2> 
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

    protected void Page_Init(object sender, EventArgs e) {
        table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
        GridView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
        GridDataSource.EntityTypeName = table.EntityType.AssemblyQualifiedName;
        if (table.EntityType != table.RootEntityType) {
            GridQueryExtender.Expressions.Add(new OfTypeExpression(table.EntityType));
        }

        // Initialize the URL for routing to all categories.
        ViewAllLink.NavigateUrl = Request.Path;
    }

    protected void Page_Load(object sender, EventArgs e) {
        Title = table.DisplayName;
        

        // Disable various options if the table is readonly
        if (table.IsReadOnly) {
            GridView1.Columns[0].Visible = false;
            InsertHyperLink.Visible = false;
            GridView1.EnablePersistedSelection = false;
        }
    }

    protected void Label_PreRender(object sender, EventArgs e) {
        Label label = (Label)sender;
        DynamicFilter dynamicFilter = (DynamicFilter)label.FindControl("DynamicFilter");
        QueryableFilterUserControl fuc = dynamicFilter.FilterTemplate as QueryableFilterUserControl;
        if (fuc != null && fuc.FilterControl != null) {
            label.AssociatedControlID = fuc.FilterControl.GetUniqueIDRelativeTo(label);
        }
    }

    protected override void OnPreRenderComplete(EventArgs e) {
        RouteValueDictionary routeValues = new RouteValueDictionary(GridView1.GetDefaultValues());
        InsertHyperLink.NavigateUrl = table.GetActionPath(PageAction.Insert, routeValues);
        base.OnPreRenderComplete(e);
    }

    protected void DynamicFilter_FilterChanged(object sender, EventArgs e) {
        GridView1.PageIndex = 0;
    }

 // <Snippet3> 
    // Create route information based on the
    // foreign-key specified in the 
    // DynamicRouteExpression page markup. 
    protected string GetRouteInformation()
    {

        // Retrieve the current data item.
        var productItem = (Product)GetDataItem();

        if (productItem != null)
        {

            RouteValueDictionary rvd = new RouteValueDictionary();
            rvd.Add("ProductCategoryID", productItem.ProductCategoryID );

            string routePath =
                table.GetActionPath(PageAction.List, rvd);

            return routePath;

        }

        return string.Empty;
    }

    // Get the name of the foreign-key category. 
    protected string GetProductCategory()
    {
        // Retrieves the current data item.
        var productItem = (Product)GetDataItem();

        if (productItem != null)
        {
            return productItem.ProductCategory.Name;
        }
        return string.Empty;
    }
   // </Snippet3> 
}
// </Snippet2> 