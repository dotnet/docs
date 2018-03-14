// <Snippet6> 
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
using System.Web.DynamicData;
using System.Text;

public partial class TablesMenu : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e) {
     
         GetVisibleTables();
         GetTables();
      
    }

    // <Snippet61> 
    // Gets all the tables in the data model.
    protected void GetTables()
    {
         System.Collections.IList tables = 
             MetaModel.Default.Tables;
         if (tables.Count == 0)
         {
             throw new InvalidOperationException(
                 "There are no tables in the data model.");
         }
         Menu2.DataSource = tables;
         Menu2.DataBind();
     }
    // </Snippet61> 

    // <Snippet62> 
    // Gets only the visible tables in the data model.
    protected void GetVisibleTables()
    {
         System.Collections.IList visibleTables =
             MetaModel.Default.VisibleTables;
         if (visibleTables.Count == 0)
         {
             throw new InvalidOperationException(
                 "There are no accessible tables. Make sure that at least one data model is registered in Global.asax and scaffolding is enabled or implement custom pages.");
         }
         Menu1.DataSource = visibleTables;
         Menu1.DataBind();
    }
    // </Snippet62> 
}
// </Snippet6> 