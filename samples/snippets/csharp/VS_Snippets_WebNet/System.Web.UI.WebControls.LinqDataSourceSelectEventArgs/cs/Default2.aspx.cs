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

    //<Snippet2>
    protected void LinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        ExampleDataContext exampleContext = new ExampleDataContext();
        
        e.Result = from p in exampleContext.Products 
             where p.Category == "Beverages"
             select new {
               ID = p.ProductID,
               Name = p.Name
             };
    }
    //</Snippet2>
}
