<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      ICollection CreateDataSource() 
      {
      
         // Create sample data for the DataGrid control.
         DataTable dt = new DataTable();
         DataRow dr;
 
         // Define the columns of the table.
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
         // Populate the table with sample values.
         for (int i = 0; i < 5; i++) 
         {
            dr = dt.NewRow();
 
            dr[0] = i;
            dr[1] = "Item " + i.ToString();
            dr[2] = 1.23 * (i + 1);
 
            dt.Rows.Add(dr);
         }
 
         DataView dv = new DataView(dt);
         return dv;
      }
 
      void Page_Load(Object sender, EventArgs e) 
      {
 
         // Load sample data only once, when the page is first loaded.
         if (!IsPostBack) 
         {
            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
         }

      }

      void Selection_Change(Object sender, EventArgs e)
      {

         // Set the background color for the items and alternating items in
         // the DataGrid control. Notice that the ItemStyle property affects
         // the even-numbered items, while the AlternatingItemStyle property 
         // affects the odd-numbered items.
         ItemsGrid.ItemStyle.BackColor = 
             System.Drawing.Color.FromName(ItemBackColorList.SelectedItem.Value);
         ItemsGrid.AlternatingItemStyle.BackColor = 
             System.Drawing.Color.FromName(AltItemBackColorList.SelectedItem.Value);

      }

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