using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
// <snippet4>
public partial class param1acs_aspx : System.Web.UI.Page 
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        SqlDataSource sqlSource = new SqlDataSource(
          ConfigurationManager.ConnectionStrings["MyNorthwind"].ConnectionString,
          "SELECT FirstName, LastName FROM Employees WHERE Country = @country;");

// <Snippet2>
        ControlParameter country = new ControlParameter();
        country.Name = "country";
        country.Type = TypeCode.String;
        country.ControlID = "DropDownList1";
        country.PropertyName = "SelectedValue";
// </Snippet2>

// <Snippet3>
        // If the DefaultValue is not set, the DataGrid does not
        // display anything on the first page load. This is because
        // on the first page load, the DropDownList has no
        // selected item, and the ControlParameter evaluates to
        // String.Empty.
        country.DefaultValue = "USA";
// </Snippet3>

        sqlSource.SelectParameters.Add(country);

        // Add the SqlDataSource to the page controls collection.
        Page.Controls.Add(sqlSource);

        DataGrid1.DataSource = sqlSource;
        DataGrid1.DataBind();
    }
}
// </snippet4>