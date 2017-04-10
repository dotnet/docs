<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>BaseDataList DataKeys and DataKeyField Example</title>
<script runat="server">

      Function CreateDataSource() As ICollection 
      
         ' Create sample data for the DataGrid control.
         Dim dt As DataTable = New DataTable()
         Dim dr As DataRow
 
         ' Define the columns of the table.
         dt.Columns.Add(new DataColumn("IntegerValue", GetType(Integer)))
         dt.Columns.Add(new DataColumn("StringValue", GetType(String)))
         dt.Columns.Add(new DataColumn("CurrencyValue", GetType(Double)))

         ' Define the primary key for the table as the IntegerValue 
         ' column (column 0). To do this, first create an array of 
         ' DataColumns to represent the primary key. The primary key can
         ' consist of multiple columns, but in this example, only
         ' one column is used.
         Dim keys(1) As DataColumn
         keys(0) = dt.Columns(0)

         ' Then assign the array to the PrimaryKey property of the DataTable. 
         dt.PrimaryKey = keys
 
         ' Populate the table with sample values.
         Dim i As Integer

         For i = 0 To 8 
     
            dr = dt.NewRow()
 
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
 
            dt.Rows.Add(dr)

         Next

         ' To persist the data source between posts to the server, 
         ' store it in session state.  
         Session("Source") = dt
 
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

      Sub Delete_Command(sender As Object, e As DataGridCommandEventArgs)

         ' Retrieve the data table from session state.
         Dim dt As DataTable = CType(Session("Source"), DataTable)

         ' Retrieve the data row to delete from the data table. 
         ' Use the DataKeys property of the DataGrid control to get 
         ' the primary key value of the selected row. 
         ' Search the Rows collection of the data table for this value. 
         Dim row As DataRow
         row = dt.Rows.Find(ItemsGrid.DataKeys(e.Item.ItemIndex))

         ' Delete the item selected in the DataGrid from the data source.
         If Not row is Nothing Then
         
            dt.Rows.Remove(row)
         
         End If

         ' Save the data source.
         Session("Source") = dt

         ' Create a DataView and bind it to the DataGrid control.
         Dim dv As DataView = New DataView(dt)
         ItemsGrid.DataSource = dv
         ItemsGrid.DataBind()

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>BaseDataList DataKeys and DataKeyField Example</h3>

      <asp:DataGrid id="ItemsGrid" 
           BorderColor="Black"
           ShowFooter="False" 
           CellPadding="3" 
           CellSpacing="0"
           HeaderStyle-BackColor="#aaaadd"
           DataKeyField="IntegerValue"
           OnDeleteCommand="Delete_Command"
           runat="server">

         <Columns>

            <asp:ButtonColumn Text="Delete"
                 CommandName="Delete"/>

         </Columns>

      </asp:DataGrid>

   </form>

</body>
</html>

<!-- </Snippet1> -->
