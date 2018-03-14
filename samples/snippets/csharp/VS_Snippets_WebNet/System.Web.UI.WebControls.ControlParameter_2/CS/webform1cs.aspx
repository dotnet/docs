<!-- <Snippet1> -->
<%@ Page language="c#"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
   
<script runat="server">
private void Page_Load(object sender, System.EventArgs e)
{
  if (IsPostBack) {
    GridView1.DataBind();
  }
  else {
    ListBox1.Items.Add(new ListItem("Nancy Davolio",   "1",true));
    ListBox1.Items.Add(new ListItem("Janet Leverling", "3",true));
    ListBox1.Items.Add(new ListItem("Margaret Peacock","4",true));
    ListBox1.Items.Add(new ListItem("Michael Suyama",  "6",true));
    ListBox1.Items.Add(new ListItem("Robert King",     "7",true));
    ListBox1.Items.Add(new ListItem("Anne Dodsworth",  "9",true));
  }
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
      <p>Show Orders For:</p>

      <p>
      <asp:ListBox
        id="ListBox1"
        runat="server"
        AutoPostBack="True">
      </asp:ListBox></p>

      <asp:SqlDataSource
        id="OdbcDataSource1"
        runat="server"
        ProviderName="System.Data.Odbc"
        DataSourceMode="DataSet"
        SelectCommand="SELECT OrderID, ShipName FROM Orders WHERE EmployeeID = ?;"
        ConnectionString="dsn=MyOdbcDSN;">
        <SELECTPARAMETERS>
          <asp:ControlParameter
            PropertyName="SelectedValue"
            ControlID="ListBox1"
            Name="empID">
          </asp:ControlParameter>
        </SELECTPARAMETERS>
      </asp:SqlDataSource>

      <p>
      <asp:GridView
        id="GridView1"
        runat="server"
        DataSourceID="OdbcDataSource1">
      </asp:GridView></p>
    </form>
  </body>
</html>
<!-- </Snippet1> -->