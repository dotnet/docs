<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <title>DataGrid SelectedItemStyle Example</title>
<script runat="server">

      Function CreateDataSource() As ICollection 
      
         ' Create sample data for the DataGrid control.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
 
         ' Define the columns of the table.
         dt.Columns.Add(New DataColumn("IntegerValue", GetType(Integer)))
         dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))

         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 to 8
      
            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
 
            dt.Rows.Add(dr)
         
         Next i
 
         ' Create a DataView from the DataTable.
         Dim dv As DataView = New DataView(dt)
         Return dv

      End Function
 
      Sub Page_Load(sender As Object, e As EventArgs) 
 
         ' Load sample data only once when the page is first loaded.
         If Not IsPostBack Then 
         
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
         
         End If

      End Sub

      Sub IndexChange_Command(sender As Object, e As EventArgs)
          
         ' Display the details of the selected item.
         DetailsLabel.Text = "Item Number: " & ItemsGrid.SelectedItem.Cells(1).Text & "<br />" & _
                             "Description: " & ItemsGrid.SelectedItem.Cells(2).Text & "<br />" & _
                             "Price: $" & ItemsGrid.SelectedItem.Cells(3).Text & "<br />"

      End Sub

      Sub Selection_Change(sender As Object, e As EventArgs)

         ' Set the background color for the paging controls section of
         ' the DataGrid control.
         ItemsGrid.SelectedItemStyle.BackColor = System.Drawing.Color.FromName(List.SelectedItem.Value)

      End Sub

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
