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
         dt.Columns.Add(New DataColumn("StringValue", GetType(string)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(double)))
 
         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 to 4 
        
            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
 
            dt.Rows.Add(dr)

         Next i
 
         Dim dv As DataView = New DataView(dt)
         Return dv

      End Function
 
      Sub Page_Load(sender As Object, e As EventArgs) 
 
         ' Load sample data only once, when the page is first loaded.
         If Not IsPostBack Then 
  
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()

         End If

      End Sub

      Sub Selection_Change(sender As Object, e As EventArgs)

         ' Set the background color for the items and alternating items in
         ' the DataGrid control. Notice that the ItemStyle property affects
         ' the even-numbered items, while the AlternatingItemStyle property 
         ' affects the odd-numbered items.
         ItemsGrid.ItemStyle.BackColor = _
             System.Drawing.Color.FromName(ItemBackColorList.SelectedItem.Value)
         ItemsGrid.AlternatingItemStyle.BackColor = _
             System.Drawing.Color.FromName(AltItemBackColorList.SelectedItem.Value)

      End Sub

   </script>
 
<head runat="server">
    <title>DataGrid ItemStyle and AlternatingItemStyle Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGrid ItemStyle and AlternatingItemStyle Example</h3>

      Select background colors for the items and alternating items.

      <br /><br />
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="False"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <ItemStyle BackColor="White">
         </ItemStyle>

         <AlternatingItemStyle BackColor="White">
         </AlternatingItemStyle>

         <Columns>

            <asp:BoundColumn DataField="IntegerValue" 
                 HeaderText="Item"/>

            <asp:BoundColumn DataField="StringValue" 
                 HeaderText="Description"/>

            <asp:BoundColumn DataField="CurrencyValue" 
                 HeaderText="Price"
                 DataFormatString="{0:c}">

               <ItemStyle HorizontalAlign="Right">
               </ItemStyle>

            </asp:BoundColumn>
 
         </Columns> 
 
      </asp:DataGrid>

      <hr />

      <table cellpadding="5">

         <tr>

            <td>

               Item BackColor:

            </td>

            <td>

               Alternating item BackColor:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="ItemBackColorList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">

                  <asp:ListItem Selected="True" Value="White"> White </asp:ListItem>
                  <asp:ListItem Value="Silver"> Silver </asp:ListItem>
                  <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
                  <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
                  <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>

               </asp:DropDownList>

            </td>

            <td>

               <asp:DropDownList id="AltItemBackColorList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">

                  <asp:ListItem Selected="True" Value="White"> White </asp:ListItem>
                  <asp:ListItem Value="Silver"> Silver </asp:ListItem>
                  <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
                  <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
                  <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>

      </table>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->