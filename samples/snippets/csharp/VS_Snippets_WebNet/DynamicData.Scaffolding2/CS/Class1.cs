using System.Web.DynamicData;
using System.Web.Routing;
// <Snippet2>
using System.ComponentModel.DataAnnotations;

[ScaffoldTable(true)]
public partial class Product {
}
// </Snippet2>

public class Registration {
    void RegisterContext() {
        MetaModel model = new MetaModel();
        // <Snippet1>
        model.RegisterContext(typeof(AdventureWorksLTDataContext),
            new ContextConfiguration() { ScaffoldAllTables = true });
        // </Snippet1>
    }

    void RegisterListDetailsTemplate() {
        RouteCollection routes = RouteTable.Routes;
        MetaModel model = new MetaModel();

        // <Snippet3>
        routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx")
        {
            Action = PageAction.List,
            ViewName = "ListDetails",
            Model = model
        });

        routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx")
        {
            Action = PageAction.Details,
            ViewName = "ListDetails",
            Model = model
        });
        // </Snippet3>
    }

    void RegisterSpecificRoute() {
        RouteCollection routes = RouteTable.Routes;
        MetaModel model = new MetaModel();

        // <Snippet4>
        routes.Add(new DynamicDataRoute("Products/{action}.aspx")
        {
            ViewName = "ListDetails",
            Table = "Products",
            Model = model
        });

        routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
        {
            Constraints = new RouteValueDictionary(
              new { action = "List|Details|Edit|Insert" }),
            Model = model
        });
        // </Snippet4>

    }
}

class AdventureWorksLTDataContext {

}