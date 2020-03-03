// <Snippet2>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

public partial class DocSamples_DynamicDataDynamicHyperlink : 
    System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Get the list of visible tables.
            System.Collections.IList tables =
                ASP.global_asax.model.VisibleTables;

            // Throw an exception if there are no visible tables.
            if (tables.Count == 0)
            {
                throw new InvalidOperationException();
            }

            // Bind the data-bound control to 
            // the list of tables.
            GridView2.DataSource = tables;
            GridView2.DataBind();
        }
    }

    protected void DynamicHyperLink_DataBinding(object sender,
        EventArgs e)
    {
        MetaTable table = (MetaTable)GetDataItem();
        DynamicHyperLink dynamicHyperLink =
            (DynamicHyperLink)sender;
        // Set the context type name for the DynamicHyperLink 
        dynamicHyperLink.ContextTypeName =
            table.DataContextType.AssemblyQualifiedName;
    }
}
// </Snippet2>
