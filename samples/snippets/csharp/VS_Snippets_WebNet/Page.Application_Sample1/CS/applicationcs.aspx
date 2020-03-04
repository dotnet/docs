<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

  <script language="C#" runat="server">
// <snippet1>
      // When this page is loaded, the source for the 
      // MyDataGrid control is obtained from Application state.
      void Page_Load(object sender, EventArgs e ) {
      
          DataView Source = (DataView)(Application["Source"]);
          MySpan.Controls.Add(new LiteralControl(Source.Table.TableName));
          MyDataGrid.DataSource = Source;
          MyDataGrid.DataBind(); 
      }
// </snippet1>
  </script>

<head runat="server">
    <title>Reading Data in Application_OnStart</title>
</head>
<body>

  <h3>Reading Data in Application_OnStart</h3>
  <h4>XML Data for Table: <asp:PlaceHolder runat="server" id="MySpan"/></h4>

  <ASP:DataGrid id="MyDataGrid" runat="server"
    Width="900"
    BackColor="#ccccff" 
    BorderColor="black"
    ShowFooter="false" 
    CellPadding="3" 
    CellSpacing="0"
    Font-Names="Verdana"
    Font-Size="8pt"
    HeaderStyle-BackColor="#aaaadd"
    EnableViewState="false"
  />

</body>
</html>


  