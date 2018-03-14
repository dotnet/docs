<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language="vb" runat="server">
        Function CreateDataSource() As ICollection
            Dim dt As New DataTable()
            Dim dr As DataRow
            
            dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
            dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
            dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
            
            Dim i As Integer
            For i = 0 To 8
                dr = dt.NewRow()
                dr(0) = i
                dr(1) = "Item " + i.ToString()
                dr(2) = 1.23 *(i + 1)
                dt.Rows.Add(dr)
            Next i
            
            Dim dv As New DataView(dt)
            CreateDataSource = dv
        End Function 'CreateDataSource


        Sub Page_Load(sender As Object, e As EventArgs)
            If Not IsPostBack Then
                ' Load this data only once.
                ItemsGrid.DataSource = CreateDataSource()
                ItemsGrid.DataBind()
            End If
        End Sub 'Page_Load


        Sub Grid_CartCommand(sender As Object, e As DataGridCommandEventArgs)
            
            ' e.Item is the table row where the command is raised.
            ' For bound columns, the value is stored in the Text property of the TableCell.
            Label1.Text = "You selected: " + e.Item.Cells(0).Text + "."
        End Sub 'Grid_CartCommand 
   </script>
<head runat="server">
    <title>ButtonColumn Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>ButtonColumn Example</h3>
 
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="false"
           OnItemCommand="Grid_CartCommand"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>
 
         <Columns>
 
            <asp:BoundColumn 
                 HeaderText="Item" 
                 DataField="StringValue"/>

            <asp:ButtonColumn 
                 HeaderText="Price" 
                 ButtonType="PushButton" 
                 DataTextField="CurrencyValue"
                 DataTextFormatString="{0:C}"
                 CommandName="AddToCart" /> 

         </Columns>

      </asp:DataGrid>

      <br /><br />

      <asp:Label id="Label1" runat="server"/>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
