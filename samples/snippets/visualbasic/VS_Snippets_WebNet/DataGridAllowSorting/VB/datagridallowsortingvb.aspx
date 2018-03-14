<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Function CreateDataSource() As ICollection
        ' Create a Random object to mix up the order 
        ' of items in the sample data.
        Dim randNum As Random = New Random()

        ' Create sample data for the DataGrid control.
        Dim dt As DataTable = New DataTable()

        ' Define the columns of the table.
        dt.Columns.Add( _
            New DataColumn("IntegerValue", GetType(Int32)))
        dt.Columns.Add( _
            New DataColumn("StringValue", GetType(String)))
        dt.Columns.Add( _
            New DataColumn("CurrencyValue", GetType(Double)))

        ' Populate the table with sample values.
        Dim i As Integer
        For i = 0 To 8
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i
            dr(1) = "Item " & randNum.Next(1, 15).ToString()
            dr(2) = 1.23 * randNum.Next(1, 15)
            dt.Rows.Add(dr)
        Next

        ' Persist the data source between posts to 
        ' the server, in the session state.  
        Session("Source") = dt

        Dim dv As DataView = New DataView(dt)
        Return dv
    End Function

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Load sample data when the page is first loaded.
        If Not IsPostBack Then
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
        End If
    End Sub

    Sub Sort_Grid(ByVal sender As Object, _
        ByVal e As DataGridSortCommandEventArgs)

        ' Retrieve the data source from session state.
        Dim dt As DataTable = _
            CType(Session("Source"), DataTable)

        ' Create a DataView from the DataTable.
        Dim dv As DataView = New DataView(dt)

        ' The DataView provides an easy way to 
        ' sort. Simply set the Sort property with 
        ' the name of the field to sort by.
        dv.Sort = e.SortExpression

        ' Rebind the data source and specify that 
        ' it should be sorted by the field specified 
        ' in the SortExpression property.
        ItemsGrid.DataSource = dv
        ItemsGrid.DataBind()
    End Sub

    Sub Check_Change(ByVal sender As Object, _
        ByVal e As EventArgs)
        ' Allow or prevent sorting depending 
        ' on the user's selection.
        ItemsGrid.AllowSorting = _
            AllowSortingCheckBox.Checked

        ' After changing the property, rebind 
        ' the data to refresh the DataGrid control.

        ' Retrieve data source from session state.
        Dim dt As DataTable = _
            CType(Session("Source"), DataTable)

        ' Create a DataView from the DataTable.
        Dim dv As DataView = New DataView(dt)

        ' Rebind the data source.
        ItemsGrid.DataSource = dv
        ItemsGrid.DataBind()
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>
        ExtractTemplateRows Example
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h3>DataGrid AllowSorting Example</h3>

      <p>Select whether to allow sorting in the DataGrid control.<br />
      <asp:CheckBox id="AllowSortingCheckBox"
           Text="Allow sorting"
           AutoPostBack="True"
           Checked="True"
           OnCheckedChanged="Check_Change"
           runat="server"/></p>
      <hr />
 
      <b>Product List</b>
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           OnSortCommand="Sort_Grid"
           UseAccessibleHeader="true" 
           AutoGenerateColumns="False"
           AllowSorting="True"
           runat="server">

         <HeaderStyle BackColor="#00aaaa" />
         <Columns>
            <asp:BoundColumn DataField="IntegerValue" 
                 SortExpression="IntegerValue"
                 HeaderText="Item"/>

            <asp:BoundColumn DataField="StringValue"
                 SortExpression="StringValue" 
                 HeaderText="Description"/>

            <asp:BoundColumn DataField="CurrencyValue" 
                 HeaderText="Price"
                 SortExpression="CurrencyValue"
                 DataFormatString="{0:c}">

               <ItemStyle HorizontalAlign="Right">
               </ItemStyle>
            </asp:BoundColumn>
         </Columns> 
      </asp:DataGrid>
 
   </div>
   </form>
</body>
</html>
<!--</Snippet1>-->
