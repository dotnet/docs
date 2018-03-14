<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page language="vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom DataList - CreateControlStyle - VB Example</title>
    <script runat="server">
      Private Sub Page_Load(sender As Object, e As EventArgs)

        ' Create sample data for the DataList control.
        Dim dt As System.Data.DataTable = New System.Data.DataTable()
        Dim dr As System.Data.DataRow

        ' Create a new column named Column1, of type String.
        Dim col As New System.Data.DataColumn("Column1", GetType(String))
        ' Add the column to the DataTable.
        dt.Columns.Add(col)

        dr = dt.NewRow()
        dr(0) = "Hello"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "DataList"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "World"
        dt.Rows.Add(dr)

        ' Show the DataTable values in the DataList.
        DataList1.DataSource = dt
        DataList1.DataBind()

      End Sub ' Page_Load
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom DataList - CreateControlStyle - VB Example</h3>

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
