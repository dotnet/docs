<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<script language="VB" runat="server">
 
    Dim Cart As DataTable
    Dim CartView As DataView
    
    Function CreateDataSource() As ICollection
        Dim dt As New DataTable()
        Dim dr As DataRow
        
        dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
        dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
        dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
        
        Dim i As Integer
        For i = 0 To 9
            dr = dt.NewRow()
            
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 *(i + 1)
            
            dt.Rows.Add(dr)
        Next i
        
        Dim dv As New DataView(dt)
        Return dv
    End Function 'CreateDataSource


    Sub Page_Load(sender As Object, e As EventArgs)
        
        If Not IsPostBack Then
            ' Need to load this data only once.
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
        End If
    End Sub 'Page_Load
     

    Sub Item_Created(sender As Object, e As DataGridItemEventArgs)
        
        Label1.Text = Label1.Text & " " & e.Item.ItemIndex
    End Sub 'Item_Created 
 
</script>
 
<head runat="server">
    <title>DataGrid ItemCreated Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGrid ItemCreated Example</h3>
 
      <asp:DataGrid id="ItemsGrid" runat="server"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="true"
           OnItemCreated="Item_Created"
           AutoGenerateColumns="true">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>
   
      </asp:DataGrid>
 
      <br />
 
      <asp:Label id="Label1" 
           Text="Order of items created: " 
           runat="server"/>

      <br />

      <asp:Label id="Label2" 
           Text="Note: The -1's refer to the header and footer." 
           runat="server"/>
 
   </form>
 
</body>
</html>
   
<!--</Snippet1>-->
