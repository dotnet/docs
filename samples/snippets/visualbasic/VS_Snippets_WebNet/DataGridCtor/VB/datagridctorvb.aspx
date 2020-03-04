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

         For i = 0 to 8 
        
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

         ' Create a DataGrid control.
         Dim ItemsGrid As DataGrid = New DataGrid()

         ' Set the properties of the DataGrid.
         ItemsGrid.ID = "ItemsGrid"
         ItemsGrid.BorderColor = System.Drawing.Color.Black
         ItemsGrid.CellPadding = 3
         ItemsGrid.AutoGenerateColumns = False

         ' Set the styles for the DataGrid.
         ItemsGrid.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(&H0000aaaa)

         ' Create the columns for the DataGrid control. The DataGrid
         ' columns are dynamically generated. Therefore, the columns   
         ' must be re-created each time the page is refreshed.
         
         ' Create and add the columns to the collection.
         ItemsGrid.Columns.Add(CreateBoundColumn("IntegerValue", "Item"))
         ItemsGrid.Columns.Add( _
             CreateBoundColumn("StringValue", "Description"))
         ItemsGrid.Columns.Add( _
             CreateBoundColumn("CurrencyValue", "Price", "{0:c}", _
             HorizontalAlign.Right))
         ItemsGrid.Columns.Add( _
             CreateLinkColumn("http:'www.microsoft.com", "_self", _
             "Microsoft", "Related link"))
        
         ' Specify the data source and bind it to the control.     
         ItemsGrid.DataSource = CreateDataSource()
         ItemsGrid.DataBind()

         ' Add the DataGrid control to the Controls collection of 
         ' the PlaceHolder control.
         Place.Controls.Add(ItemsGrid)

      End Sub

      Function CreateBoundColumn(DataFieldValue As String, HeaderTextValue As String) As BoundColumn

         ' This version of CreateBoundColumn method sets only the 
         ' DataField and HeaderText properties.

         ' Create a BoundColumn.
         Dim column As BoundColumn = New BoundColumn()

         ' Set the properties of the BoundColumn.
         column.DataField = DataFieldValue
         column.HeaderText = HeaderTextValue

         Return column

      End Function

      Function CreateBoundColumn(DataFieldValue As String, _
          HeaderTextValue As String, FormatValue As String, _
          AlignValue As HorizontalAlign) As BoundColumn

         ' This version of CreateBoundColumn method sets the DataField,
         ' HeaderText, and DataFormatString properties. It also sets the 
         ' HorizontalAlign property of the ItemStyle property of the column. 

         ' Create a BoundColumn using the overloaded CreateBoundColumn method.
         Dim column As BoundColumn = CreateBoundColumn(DataFieldValue, HeaderTextValue)

         ' Set the properties of the BoundColumn.
         column.DataFormatString = FormatValue
         column.ItemStyle.HorizontalAlign = AlignValue

         Return column

      End Function

      Function CreateLinkColumn(NavUrlValue As String, TargetValue As String, _
         TextValue As String, HeaderTextValue As String) As HyperLinkColumn 

         ' Create a BoundColumn.
         Dim column As HyperLinkColumn = New HyperLinkColumn()

         ' Set the properties of the ButtonColumn.
         column.NavigateUrl = NavUrlValue
         column.Target = TargetValue
         column.Text = TextValue
         column.HeaderText = HeaderTextValue

         Return column

      End Function

   </script>
 
<head runat="server">
    <title>DataGrid Constructor Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGrid Constructor Example</h3>
 
      <b>Product List</b>

      <asp:PlaceHolder id="Place"
           runat="server"/>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->