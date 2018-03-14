<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Function CreateDataSource() As ICollection
        ' Create sample data for the DataGrid control.
        Dim dt As DataTable = New DataTable()
        Dim dr As DataRow
 
        ' Define the columns of the table.
        dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
        dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
        dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
 
        ' Populate the table with sample values.
        Dim i As Integer
        For i = 0 To 100
            dr = dt.NewRow()
            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * (i + 1)
            dt.Rows.Add(dr)
        Next i
 
        Dim dv As DataView = New DataView(dt)
        Return dv
    End Function
 
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Load sample data only once, when the page is first loaded.
        If Not IsPostBack Then
            ItemsGrid.DataSource = CreateDataSource()
            ItemsGrid.DataBind()
        End If
    End Sub

    Sub Check_Change(ByVal sender As Object, ByVal e As EventArgs)
        ' Allow or prevent paging depending on the user's selection.
        ItemsGrid.AllowPaging = AllowPagingCheckBox.Checked()

        ' Rebind the data to refresh the DataGrid control. 
        ItemsGrid.DataSource = CreateDataSource()
        ItemsGrid.DataBind()
    End Sub

    Sub Grid_Change(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        ' For the DataGrid control to navigate to the correct page when
        ' paging is allowed, the CurrentPageIndex property must be updated
        ' programmatically. This process is usually accomplished in the
        ' event-handling method for the PageIndexChanged event.

        ' Set CurrentPageIndex to the page the user clicked.
        ItemsGrid.CurrentPageIndex = e.NewPageIndex

        ' Rebind the data to refresh the DataGrid control. 
        ItemsGrid.DataSource = CreateDataSource()
        ItemsGrid.DataBind()
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>DataGrid AllowPaging Example</h3>

    <p>Select whether to allow paging in the DataGrid control.<br />
       <asp:CheckBox id="AllowPagingCheckBox"
            Text="Allow paging"
            AutoPostBack="True"
            Checked="True"
            OnCheckedChanged="Check_Change"
            runat="server" />
    </p>
    <hr />
    <asp:Label ID="Label1" runat="server" 
        AssociatedControlID="ItemsGrid" 
        Font-Bold="true">Product List</asp:Label>
    <asp:DataGrid id="ItemsGrid" runat="server"
        BorderColor="Gray"
        BorderWidth="1"
        CellPadding="3"
        UseAccessibleHeader="true"
        AutoGenerateColumns="False"
        PageSize="10"
        AllowPaging="True"
        OnPageIndexChanged="Grid_Change">

        <HeaderStyle BackColor="LightBlue" />
        <Columns>
            <asp:BoundColumn DataField="IntegerValue" 
                 SortExpression="IntegerValue"
                 ItemStyle-HorizontalAlign="center"
                 HeaderText="Item" />

            <asp:BoundColumn DataField="StringValue" 
                HeaderText="Description" 
                ItemStyle-HorizontalAlign="left"
                SortExpression="StringValue" />

            <asp:BoundColumn DataField="CurrencyValue" 
                 HeaderText="Price"
                 SortExpression="CurrencyValue"
                 DataFormatString="{0:c}" />

        </Columns>
        <ItemStyle HorizontalAlign="Right" />
    </asp:DataGrid>

    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
