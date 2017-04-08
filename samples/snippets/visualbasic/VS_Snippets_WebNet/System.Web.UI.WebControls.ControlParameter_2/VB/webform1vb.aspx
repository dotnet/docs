<!-- <Snippet1> -->
<%@ Page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
Private Sub Page_Load(sender As Object, e As EventArgs)

    If (IsPostBack) Then
        GridView1.DataBind()
    Else
      Dim li As ListItem

      li = New ListItem("Nancy Davolio",   "1",True)
      ListBox1.Items.Add(li)

      li = New ListItem("Janet Leverling", "3",True)
      ListBox1.Items.Add(li)

      li = New ListItem("Margaret Peacock","4",True)
      ListBox1.Items.Add(li)

      li = New ListItem("Michael Suyama",  "6",True)
      ListBox1.Items.Add(li)

      li = New ListItem("Robert King",     "7",True)
      ListBox1.Items.Add(li)

      li = New ListItem("Anne Dodsworth",  "9",True)
      ListBox1.Items.Add(li)
    End If
End Sub ' Page_Load
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