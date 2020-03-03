<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      Function CreateDataSource() As ICollection

         ' Create sample data for the DataGrid control.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow 
 
         ' Define the columns of the table.
         dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
         dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
 
         ' Populate the table with sample values.
         Dim i As Integer         

         For i=0 To 10 

            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
 
            dt.Rows.Add(dr)
         
         Next i
 
         Dim dv As DataView = New DataView(dt)

         return dv
      
      End Function
 
      Sub Page_Load(sender As Object, e As EventArgs)

         ' Manually register the event-handling method for the  
         ' ItemDataBound event of the DataGrid control.
         AddHandler ItemsGrid.ItemDataBound, AddressOf Item_Bound
 
         ' Load sample data only once, when the page is first loaded.
         If Not IsPostBack Then
         
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
         
         End If

      End Sub
 
      Sub Item_Bound(sender As Object, e As DataGridItemEventArgs) 
 
         ' Use the ItemDataBound event to customize the DataGrid control. 
         ' The ItemDataBound event allows you to access the data before 
         ' the item is displayed in the control. In this example, the 
         ' ItemDataBound event is used to format the items in the 
         ' CurrencyColumn in currency format.
         If e.Item.ItemType = ListItemType.Item Or _
             e.Item.ItemType = ListItemType.AlternatingItem Then
 
            ' Retrieve the text of the CurrencyColumn from the DataGridItem
            ' and convert the value to a Double.
            Dim Price As Double = Convert.ToDouble(e.Item.Cells(2).Text)

            ' Format the value as currency and redisplay it in the DataGrid.
            e.Item.Cells(2).Text = Price.ToString("c")
        
         End If         
 
      End Sub
 
</script>
 
<head runat="server">
    <title>DataGrid ItemDataBound Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGrid ItemDataBound Example</h3>
 
      <asp:DataGrid id="ItemsGrid" runat="server"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="true">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>
   
      </asp:DataGrid>

   </form>
 
</body>
</html>

<!-- </Snippet1> -->