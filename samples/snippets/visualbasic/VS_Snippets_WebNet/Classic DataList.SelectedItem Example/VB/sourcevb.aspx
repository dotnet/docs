<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>DataList SelectedItem Example</title>
<script language="VB" runat="server">
 
    Dim Cart As DataTable
    Dim CartView As DataView

    Sub Page_Load(sender As Object, e As EventArgs)
        If Session("DL3_ShoppingCart") Is Nothing Then
            Cart = New DataTable()
            Cart.Columns.Add(New DataColumn("Qty", GetType(String)))
            Cart.Columns.Add(New DataColumn("Item", GetType(String)))
            Cart.Columns.Add(New DataColumn("Price", GetType(String)))
            Session("DL3_ShoppingCart") = Cart
            
            ' First Load - Create some data.
            Dim i As Integer
            For i = 1 To 9
                Dim dr As DataRow = Cart.NewRow()
                dr(0) =(i Mod 2 + 1).ToString()
                dr(1) = "Item " & i.ToString()
                dr(2) =(1.23 *(i + 1)).ToString()
                Cart.Rows.Add(dr)
            Next i
        Else
            Cart = CType(Session("DL3_ShoppingCart"), DataTable)
        End If 
        CartView = New DataView(Cart)
        CartView.Sort = "Item"
        If Not IsPostBack Then
            BindList()
        End If
    End Sub 'Page_Load
     
    Sub BindList()
        DataList1.DataSource = CartView
        DataList1.DataBind()
    End Sub 'BindList

    Sub DataList_ItemCommand(sender As Object, e As DataListCommandEventArgs)
        DataList1.SelectedIndex = e.Item.ItemIndex
        BindList()
        Label4.Text = "You selected: " & CType(DataList1.SelectedItem.FindControl("Label1"), Label).Text
    End Sub 'DataList_ItemCommand

    Sub Button_Click(sender As Object, e As EventArgs)
        If Not (DataList1.SelectedItem Is Nothing) Then
            DataList1.SelectedItem.ForeColor = System.Drawing.Color.Red
        End If
    End Sub 'Button_Click

</script>

</head>
<body>

   <form id="form1" runat="server">

      <h3>DataList SelectedItem Example</h3>
      <p></p>
       
      <asp:DataList id="DataList1" runat="server"
           GridLines="Both"
           CellPadding="3"
           CellSpacing="0"           
           OnItemCommand="DataList_ItemCommand">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <SelectedItemStyle BackColor="lightgreen">
         </SelectedItemStyle>

         <HeaderTemplate>

            Items

         </HeaderTemplate>
         
         <ItemTemplate>

            <asp:LinkButton id="button1" 
                 Text="Select" 
                 CommandName="select"
                 runat="server"/>
            <%# (CType(Container.DataItem, DataRowView))("Item")%>

         </ItemTemplate>
              
         <SelectedItemTemplate>

            Item:
            <asp:Label id="Label1" 
                 Text='<%# (CType(Container.DataItem, DataRowView))("Item")%>' 
                 runat="server"/>

            <br />

            Quantity:
            <asp:Label id="Label2" 
                 Text='<%# (CType(Container.DataItem, DataRowView))("Qty")%>' 
                 runat="server"/>

            <br />

            Price:
            <asp:Label id="Label3" 
                 Text='<%# DataBinder.Eval(Container.DataItem, "Price")%>' 
                 runat="server"/>

         </SelectedItemTemplate>

      </asp:DataList>

      <br /><br />

      <asp:Label id="Label4"
           runat="server"/>

      <br /><br />

      <asp:Button id="Button2"
           Text="Change Text to Red" 
           OnClick="Button_Click"
           runat="server"/>

   </form>

</body>
</html>

<!--</Snippet1>-->
