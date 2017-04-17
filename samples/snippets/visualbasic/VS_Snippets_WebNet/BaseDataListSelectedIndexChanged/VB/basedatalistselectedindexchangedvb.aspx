<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Declarative BaseDataList SelectedIndexChanged Example</title>
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
         DetailsLabel.Text = _
            "Item Number: " & ItemsGrid.SelectedItem.Cells(1).Text & "<br />" & _
            "Description: " & ItemsGrid.SelectedItem.Cells(2).Text & "<br />" & _
            "Price: $" & ItemsGrid.SelectedItem.Cells(3).Text & "<br />"

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>Declarative BaseDataList SelectedIndexChanged Example</h3>

      Select an item: 

      <br /><br />

      <asp:DataGrid id="ItemsGrid" 
           BorderColor="Black"
           ShowFooter="False" 
           CellPadding="3" 
           CellSpacing="0"
           HeaderStyle-BackColor="#aaaadd"
           OnSelectedIndexChanged="IndexChange_Command"
           runat="server">

         <Columns>

            <asp:ButtonColumn Text="Select"
                 CommandName="Select"/>

         </Columns>

      </asp:DataGrid>

      <hr />

      <table border="1" style="border-color:Black; margin:0">

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

   </form>

</body>
</html>

<!-- </Snippet1> -->
