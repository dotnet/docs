<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    private ICollection CreateDataSource()
    {
        // Create sample data for the DataGrid control.
        DataTable dt = new DataTable();
        DataRow dr;

        // Define the columns of the table.
        dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
        dt.Columns.Add(new DataColumn("StringValue", typeof(String)));
        dt.Columns.Add(new DataColumn("CurrencyValue", typeof(Double)));

        // Populate the table with sample values.
        for (int i = 0; i <= 100; i++) 
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

    private void Page_Load(Object sender, EventArgs e)
    { 
        // Load sample data only once, when the page is first loaded.
        if (!IsPostBack)
        { 
            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
        }
    }

    private void Check_Change(Object sender, EventArgs e)
    {
        // Allow or prevent paging depending 
        // on the user's selection.
        ItemsGrid.AllowPaging = AllowPagingCheckBox.Checked;

        // Rebind the data to refresh the DataGrid control. 
        ItemsGrid.DataSource = CreateDataSource();
        ItemsGrid.DataBind();
    }

    private void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
    {
        // For the DataGrid control to navigate to the correct page when
        // paging is allowed, the CurrentPageIndex property must be updated
        // programmatically. This process is usually accomplished in the
        // event-handling method for the PageIndexChanged event.

        // Set CurrentPageIndex to the page the user clicked.
        ItemsGrid.CurrentPageIndex = e.NewPageIndex;

        // Rebind the data to refresh the DataGrid control. 
        ItemsGrid.DataSource = CreateDataSource();
        ItemsGrid.DataBind();
    }
</script>
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>DataGrid AllowPaging Example</title>
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
    <asp:Label runat="server" 
        AssociatedControlID="ItemsGrid" 
        Font-Bold="true">Product List</asp:Label>
    <asp:DataGrid id="ItemsGrid" runat="server"
        BorderColor="Gray"
        BorderWidth="1"
        CellPadding="3"
        AutoGenerateColumns="False"
        UseAccessibleHeader="true"
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