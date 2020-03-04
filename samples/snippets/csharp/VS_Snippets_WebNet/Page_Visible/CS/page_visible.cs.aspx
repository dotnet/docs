<%--
    The following program demonstrates the 'Visible'property of 'Page' class.
    
    This program creates a data source , binds it to the 'DataGrid' instance on page load event. Then 
    diplays a table and a 'Button' control on the web page. When the button is clicked it sets the 
    'Visible' property of the page 'false'.As a result all displayed items on the page become invisible.
--%>
<%@ import namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="C#" runat="server">

    ICollection CreateDataSource()
    {
  DataTable myDataTable = new DataTable();
  DataRow myDataRow;
  // Add three columns into 'DataTable' object.
  myDataTable.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
  myDataTable.Columns.Add(new DataColumn("StringValue", typeof(String)));
  myDataTable.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));

  // Add rows into 'DataTable' object.
  for(int count=0; count < 5; ++count)
  {
     myDataRow = myDataTable.NewRow();
     myDataRow[0] = count;
     myDataRow[1] = "Item" + Convert.ToString(count);
     myDataRow[2] = 1.47 * (count + 1);

     myDataTable.Rows.Add(myDataRow);
  }
  DataView viewDataTable = new DataView(myDataTable);
  return viewDataTable;     
    } 
// <Snippet1>
void HideButton_Click(Object sender, EventArgs er)
{      
   this.Visible = false;
}
// </Snippet1>
void Page_Load(Object sender, EventArgs er)
{
   if(!IsPostBack)
   {
      itemsGrid.DataSource = CreateDataSource();
      itemsGrid.DataBind();
   }
}

    </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>
          Page Example:
        </title>
</head>
  <body runat="server" id="Body1">
     <form id="myForm" method="post" runat="server">
        <h4>
          Page Example:
        </h4>
        <asp:DataGrid ID="itemsGrid" BorderColor="Blue" BorderWidth="1" CellPadding="3" AutoGenerateColumns="True" Runat="server">
          <HeaderStyle BackColor="#bcbfff"></HeaderStyle>
        </asp:DataGrid>
        <br />
        <asp:Button Text="Hide all controls" OnClick="HideButton_Click" Runat="server" id="Button1" />
     </form>
  </body>
</html>
