<!-- <Snippet1> -->
<%@ Page language="VB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Private Sub Page_Load(sender As Object, e As EventArgs)
    ' Create two ListBox controls, each with some simple data.
    ListBox1.Items.Add(new ListItem("USA","USA",True))
    ListBox1.Items.Add(new ListItem("UK","UK",True))

    ListBox2.Items.Add(new ListItem("<No One>","0",True))
    ListBox2.Items.Add(new ListItem("Andrew Fuller","2",True))
    ListBox2.Items.Add(new ListItem("Steven Buchanan","5",True))

    ' SqlDataSource uses named parameters.
    Dim sqlSource As SqlDataSource
    sqlSource = New SqlDataSource( _
      ConfigurationManager.ConnectionStrings("MyNorthwind").ConnectionString, _
      "SELECT FirstName, LastName FROM Employees WHERE Country = @country AND ReportsTo = @report")

        ' <Snippet2>

    Dim country As ControlParameter
    country = New ControlParameter("country", TypeCode.String, "ListBox1", "SelectedValue")

    Dim report As ControlParameter
    report = New ControlParameter("report", TypeCode.Int16, "ListBox2", "SelectedValue")

        ' </Snippet2>

    sqlSource.SelectParameters.Add(country)
    sqlSource.SelectParameters.Add(report)

    Page.Controls.Add(sqlSource)

    Dim grid As New GridView()
    grid.DataSource = sqlSource

    PlaceHolder3.Controls.Add(grid)

    ' A Postback indicates that a ListBox selection has changed.
    ' Only bind the grid on Postback events to the page.
    If (IsPostBack) Then
        grid.DataBind()
    End If

End Sub ' Page_Load
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