<!-- <Snippet1> -->
<%@ Page language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
private void Page_Load(object sender, System.EventArgs e)
{
  // Create two ListBox controls, each with some simple data.
  ListBox1.Items.Add(new ListItem("USA","USA",true));
  ListBox1.Items.Add(new ListItem("UK","UK",true));

  ListBox2.Items.Add(new ListItem("<No One>","0",true));
  ListBox2.Items.Add(new ListItem("Andrew Fuller","2",true));
  ListBox2.Items.Add(new ListItem("Steven Buchanan","5",true));

  // SqlDataSource uses named parameters.
  SqlDataSource sqlSource = new SqlDataSource(
      ConfigurationManager.ConnectionStrings["MyNorthwind"].ConnectionString,
  "SELECT FirstName, LastName FROM Employees WHERE Country = @country AND ReportsTo = @report");

// <snippet2>

  ControlParameter country =
    new ControlParameter("country",TypeCode.String,"ListBox1","SelectedValue");
  sqlSource.SelectParameters.Add(country);

  ControlParameter report  =
    new ControlParameter("report",TypeCode.Int16,"ListBox2","SelectedValue");
  sqlSource.SelectParameters.Add(report);

// </snippet2>

  Page.Controls.Add(sqlSource);

  GridView grid   = new GridView();
  grid.DataSource = sqlSource;

  PlaceHolder3.Controls.Add(grid);

  // A Postback indicates that a ListBox selection has changed.
  // Only bind the grid on Postback events to the page.
  if (IsPostBack) grid.DataBind();
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
      <p>
       <asp:ListBox id="ListBox1" runat="server" /></p>

      <p>
       <asp:ListBox id="ListBox2" runat="server" /></p>

      <p>&nbsp;</p>

      <p>
       <asp:Button id="Button1" runat="server" Text="Submit" /></p>

      <p>
       <asp:PlaceHolder id="PlaceHolder3" runat="server" /></p>

    </form>
  </body>
</html>
<!-- </Snippet1> -->