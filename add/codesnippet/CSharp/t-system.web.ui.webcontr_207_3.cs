public partial class param1acs_aspx : System.Web.UI.Page 
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        SqlDataSource sqlSource = new SqlDataSource(
          ConfigurationManager.ConnectionStrings["MyNorthwind"].ConnectionString,
          "SELECT FirstName, LastName FROM Employees WHERE Country = @country;");

        ControlParameter country = new ControlParameter();
        country.Name = "country";
        country.Type = TypeCode.String;
        country.ControlID = "DropDownList1";
        country.PropertyName = "SelectedValue";

        // If the DefaultValue is not set, the DataGrid does not
        // display anything on the first page load. This is because
        // on the first page load, the DropDownList has no
        // selected item, and the ControlParameter evaluates to
        // String.Empty.
        country.DefaultValue = "USA";

        sqlSource.SelectParameters.Add(country);

        // Add the SqlDataSource to the page controls collection.
        Page.Controls.Add(sqlSource);

        DataGrid1.DataSource = sqlSource;
        DataGrid1.DataBind();
    }
}