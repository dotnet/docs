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

//<Snippet3>
public partial class Default3 : System.Web.UI.Page
{
    string[] citiesArray = 
    { 
        "Atlanta", 
        "Charlotte", 
        "Denver", 
        "New York", 
        "San Francisco" 
    };

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void LinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        var cities = from city in citiesArray
                     where city.CompareTo("B") > 0
                     select city;
        e.Result = cities;
        // Or we could set e.Result = citiesArray to return all rows.
    }
}
//</Snippet3>
