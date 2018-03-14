<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

   <script language="VB" runat="server">
 
        Dim Cart As New DataTable
        Dim CartView As DataView
        
        Sub Page_Load(sender As Object, e As EventArgs)
            Dim dr As DataRow
            
            If Session("ShoppingCart") Is Nothing Then
                Cart.Columns.Add(New DataColumn("Qty", GetType(String)))
                Cart.Columns.Add(New DataColumn("Item", GetType(String)))
                Cart.Columns.Add(New DataColumn("Price", GetType(String)))
                Session("ShoppingCart") = Cart
                
                ' Create rows and add sample data.
                Dim i As Integer
                For i = 1 To 9
                    dr = Cart.NewRow()
                    If i Mod 2 <> 0 Then
                        dr(0) = "2"
                    Else
                        dr(0) = "1"
                    End If
                    dr(1) = "Item " & i.ToString()
                    dr(2) =(1.23 *(i + 1)).ToString()
                    Cart.Rows.Add(dr)
                Next i
            Else
                Cart = CType(Session("ShoppingCart"), DataTable)
            End If 
            CartView = New DataView(Cart)
            CartView.Sort = "Item"
            
            If Not IsPostBack Then
                BindGrid()
            End If
        End Sub 'Page_Load
         
        Sub MyDataGrid_Select(sender As Object, e As EventArgs)
            
            Label1.Text = "You selected " & MyDataGrid.SelectedItem.Cells(1).Text & _
                ".<br />" & MyDataGrid.SelectedItem.Cells(1).Text & " has an index number of " & _
                MyDataGrid.SelectedIndex.ToString() & "."
        End Sub 'MyDataGrid_Select

        Sub Select_Button_Click(sender As Object, e As EventArgs)
            
            MyDataGrid.SelectedIndex = 4
        End Sub 'Select_Button_Click
         
        Sub UnSelect_Button_Click(sender As Object, e As EventArgs)
            
            MyDataGrid.SelectedIndex = - 1
            Label1.Text = ""
        End Sub 'UnSelect_Button_Click
         
        Sub BindGrid()
            MyDataGrid.DataSource = CartView
            MyDataGrid.DataBind()
        End Sub 'BindGrid
 
   </script>
 
<head runat="server">
    <title>DataGrid Selection Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataGrid Selection Example</h3>
 
      <asp:DataGrid id="MyDataGrid" runat="server"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           Font-Names="Verdana"
           Font-Size="8pt"
           OnSelectedIndexChanged="MyDataGrid_Select"
           AutoGenerateColumns="false">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <SelectedItemStyle BackColor="Yellow">
         </SelectedItemStyle>
 
         <Columns>

            <asp:ButtonColumn
                 HeaderText="Select Item"
                 ButtonType="LinkButton"
                 Text="Select"
                 CommandName="Select">

            </asp:ButtonColumn>
 
            <asp:BoundColumn 
                 HeaderText="Item" 
                 ReadOnly="true" 
                 DataField="Item"/>

            <asp:BoundColumn 
                 HeaderText="Quantity" 
                 DataField="Qty"/>

            <asp:BoundColumn 
                 HeaderText="Price" 
                 DataField="Price"/>

         </Columns>

      </asp:DataGrid>

      <br /><br />

      <asp:Button id="Button1"
           Text="Select Item 5"
           OnClick="Select_Button_Click"
           runat="server"/>

      <asp:Button id="Button2"
           Text="Unselect Item"
           OnClick="UnSelect_Button_Click"
           runat="server"/>

      <br /><br />

      <asp:Label id="Label1" runat="server"/> 
 
   </form>
 
</body>
</html>

<!--</Snippet1>-->
