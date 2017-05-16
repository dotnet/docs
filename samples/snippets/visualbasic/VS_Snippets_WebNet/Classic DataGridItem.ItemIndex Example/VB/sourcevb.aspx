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
     

    Sub Button_Click(sender As Object, e As EventArgs)
        
        Label1.Text = "The DataSetIndex of each item in the DataGrid are: <br />"
        
        Dim item As DataGridItem
        For Each item In  ItemsGrid.Items
            Label1.Text &= "<br />" & item.ItemIndex.ToString() & " - " & item.Cells(1).Text
        Next item
    End Sub 'Button_Click
 
</script>
 
<head runat="server">
    <title>DataGridItem ItemIndex Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGridItem ItemIndex Example</h3>
 
      <asp:DataGrid id="ItemsGrid" runat="server"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="true"
           AutoGenerateColumns="true">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>
   
      </asp:DataGrid>
 
      <br />

      <asp:Button id="Button1"
           Text="Display ItemIndex of Items in DataGrid"
           OnClick="Button_Click"
           runat="server"/>

      <br /><br />
 
      <asp:Label id="Label1" 
           runat="server"/>
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
