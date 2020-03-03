<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom DataList - CreateControlStyle - C# Example</title>
    <script runat="server">
      private void Page_Load(object sender, System.EventArgs e)
      {
        // Create sample data for the DataList control.
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.DataRow dr;
        dt.Columns.Add(new System.Data.DataColumn("Column1", typeof(String)));

        dr = dt.NewRow();
        dr[0] = "Hello";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr[0] = "DataList";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr[0] = "World";
        dt.Rows.Add(dr);

        // Show the DataTable values in the DataList.
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom DataList - CreateControlStyle - C# Example</h3>

      <aspSample:CustomDataListCreateControlStyle id="DataList1" runat="server" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="Vertical" BorderWidth="1px" Width="100px">

        <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084" />
        <HeaderTemplate>
          <asp:Label id="Label1" runat="server">Column1</asp:Label>
        </HeaderTemplate>

        <ItemStyle ForeColor="Black" BackColor="#EEEEEE" />
        <ItemTemplate>
          <asp:Label id="Label2" runat="server"><%# DataBinder.Eval(Container.DataItem, "Column1") %></asp:Label>
        </ItemTemplate>

        <AlternatingItemStyle BackColor="#DCDCDC" />
        <AlternatingItemTemplate>
          <asp:Label id="Label3" runat="server"><%# DataBinder.Eval(Container.DataItem, "Column1") %></asp:Label>
        </AlternatingItemTemplate>

      </aspSample:CustomDataListCreateControlStyle>

    </form>
  </body>
</html>
<!-- </Snippet1> -->
