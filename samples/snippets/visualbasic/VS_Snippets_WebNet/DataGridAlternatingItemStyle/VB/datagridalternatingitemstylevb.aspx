<!--<Snippet1>-->

<%@ Page Language="VB" %>

<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      Function CreateDataSource() As ICollection 
   
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
         Dim i As Integer
         Dim dv As DataView
 
         dt.Columns.Add(New DataColumn("IntegerValue", GetType(Integer)))
         dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
 
         For i = 0 to 8

            dr = dt.NewRow()
   
            dr(0) = i
            dr(1) = "Item " + i.ToString()
            dr(2) = 1.23 * (i+1)
    
            dt.Rows.Add(dr)
      
         Next i
 
         dv = New DataView(dt)
         CreateDataSource = dv
   
      End Function
 
      Sub Page_Load(sender As Object, e As EventArgs) 
 
         If Not IsPostBack 
         
            ' Load this data only once.
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
          
         End If
         
      End Sub
 
   </script>
 
<head runat="server">
    <title>DataGrid AlternatingItemStyle Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGrid AlternatingItemStyle Example</h3>
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="false"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <ItemStyle BackColor="Yellow">
         </ItemStyle>

         <AlternatingItemStyle BackColor="LightGreen">
         </AlternatingItemStyle>

         <Columns>

            <asp:BoundColumn
                 HeaderText="Number" 
                 DataField="IntegerValue">
            </asp:BoundColumn>

            <asp:BoundColumn
                 HeaderText="Description" 
                 DataField="StringValue">
            </asp:BoundColumn>

            <asp:BoundColumn
                 HeaderText="Price" 
                 DataField="CurrencyValue" 
                 DataFormatString="{0:c}">
            </asp:BoundColumn>

         </Columns>
 
      </asp:DataGrid>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->