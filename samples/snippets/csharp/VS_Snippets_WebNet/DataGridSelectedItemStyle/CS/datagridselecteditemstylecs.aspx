<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title>DataGrid SelectedItemStyle Example</title>
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
         for (int i = 0; i < 9; i++) 
         {
            dr = dt.NewRow();
 
            dr[0] = i;
            dr[1] = "Item " + i.ToString();
            dr[2] = 1.23 * (i + 1);
 
            dt.Rows.Add(dr);
         }
 
         // Create a DataView from the DataTable.
         DataView dv = new DataView(dt);
         return dv;

      }
 
      void Page_Load(Object sender, EventArgs e) 
      {
 
         // Load sample data only once when the page is first loaded.
         if (!IsPostBack) 
         {
            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
         }

      }

      void IndexChange_Command(Object sender, EventArgs e)
      {
          
         // Display the details of the selected item.
         DetailsLabel.Text = "Item Number: " + ItemsGrid.SelectedItem.Cells[1].Text + "<br />" +
                             "Description: " + ItemsGrid.SelectedItem.Cells[2].Text + "<br />" +
                             "Price: $" + ItemsGrid.SelectedItem.Cells[3].Text + "<br />";

      }

      void Selection_Change(Object sender, EventArgs e)
      {

         // Set the background color for the paging controls section of
         // the DataGrid control.
         ItemsGrid.SelectedItemStyle.BackColor = System.Drawing.Color.FromName(List.SelectedItem.Value);

      }

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>DataGrid SelectedItemStyle Example</h3>

      Select an item and a backcolor for the selected item. 

      <br /><br />

      <asp:DataGrid id="ItemsGrid" 
           BorderColor="Black"
           ShowFooter="False" 
           CellPadding="3" 
           CellSpacing="0"
           HeaderStyle-BackColor="#aaaadd"
           OnSelectedIndexChanged="IndexChange_Command"
           runat="server">

         <SelectedItemStyle BackColor="White">
         </SelectedItemStyle>

         <Columns>

            <asp:ButtonColumn Text="Select"
                 CommandName="Select"/>

         </Columns>

      </asp:DataGrid>

      <hr />

      <table style="border-color:Black; border-width:1" cellspacing="0">

         <tr style="background-color:#aaaadd">

            <td>

               Details

            </td>

         </tr>

         <tr>

            <td>

               <asp:Label id="DetailsLabel"
                    runat="server"
                    Text="No item selected."/>

            </td>

         </tr>

      </table>

      <table cellpadding="5">

         <tr>

            <td>

               Backcolor:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="List"
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
