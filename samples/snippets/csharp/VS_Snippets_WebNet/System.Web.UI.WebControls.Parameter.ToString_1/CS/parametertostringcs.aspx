<!--<Snippet1>-->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 private void Page_Load(object sender, EventArgs e) {

    SqlDataSource sqlSource = 
        new SqlDataSource(ConfigurationManager.ConnectionStrings["MyNorthwind"].ConnectionString,
                          "SELECT * From Employees where EmployeeID = @employee");
    
    // When a Parameter is not named, Name returns String.Empty.
    Parameter userID = new Parameter();

    if (userID.Name.Equals(String.Empty)) {
        Response.Write("Name is Empty<br />");
    }

    if (null == userID.Name) {
        Response.Write("Name is Null<br />");
    }

    // Set the Name of the Parameter
    userID.Name = "employee";

    // The Parameter.DefaultValue property is used to bind a static String.
    userID.DefaultValue = "3";

    // The ToString method returns the Name of the Parameter.
    Response.Write(userID.ToString() + "<br />");
    Response.Write(userID.Name + "<br />");

    // The default Type of the Parameter is TypeCode.Object
    Response.Write(userID.Type.ToString() + "<br />");

    sqlSource.SelectParameters.Add(userID);
    Page.Controls.Add(sqlSource);

    GridView grid = new GridView();
    grid.DataSource = sqlSource;
    grid.DataBind();

    PlaceHolder1.Controls.Add(grid);
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">

       <asp:PlaceHolder id="PlaceHolder1" runat="server"/>

        </form>
    </body>
</html>
<!--</Snippet1>-->