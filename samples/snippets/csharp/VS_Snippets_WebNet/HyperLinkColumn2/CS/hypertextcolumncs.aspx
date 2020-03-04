<!-- <Snippet1> -->
<!-- 
This example demonstrates using a hyperlink column. The code below
should be copied into a file called HyperTextColumnCS.aspx.  The file
should be stored in the same directory as the file DetailsPageCS.aspx
described below.
-->
<!-- </Snippet1> -->
<!-- <Snippet2> -->
<!-- To view this code snippet in a fully-working example, see the 
HyperLinkColumn class topic. -->

<!-- </Snippet2> -->

<!-- <Snippet3> -->
<%@ Page language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    private DataView dv;
    private DataTable dt = new DataTable();

    private void Page_Load(object sender, System.EventArgs e)
    {
        // Create a DataTable to use as the data source for 
        // the DataGrid.
        dt.Columns.Add(new DataColumn("ItemNumber"));
        dt.Columns["ItemNumber"].Caption = "Item Number";
        dt.Columns.Add(new DataColumn("Item"));
        dt.Columns["ItemNumber"].Caption = "Item";
        dt.Columns.Add(new DataColumn("Price"));
        dt.Columns["ItemNumber"].Caption = "Price";

        // Add some data to the DataTable.
        DataRow myDataRow;
        for (int i = 0; i < 5; i++)
        {
            myDataRow = dt.NewRow();
            myDataRow[0] = i;
            myDataRow[1] = "Item " + i.ToString();
            myDataRow[2] = 1.23 * (i + 1);
            dt.Rows.Add(myDataRow);
        }
        
        // Use the table to create a DataView.
        dv = new DataView(dt);

//<Snippet4>
        // Create hyperlink columns that contain the item name
        // and price.
        HyperLinkColumn nameCol = new HyperLinkColumn();
        nameCol.DataNavigateUrlField = "ItemNumber";
        nameCol.DataTextField = "Item";
        nameCol.DataNavigateUrlFormatString = 
            "DetailspageCS.aspx?id={0}";
        nameCol.HeaderText = dt.Columns["Item"].Caption;

        HyperLinkColumn priceCol = new HyperLinkColumn();
        priceCol.DataNavigateUrlField = "ItemNumber";
        priceCol.DataTextField = "Price";
        priceCol.DataNavigateUrlFormatString = 
            "DetailspageCS.aspx?id={0}";
        priceCol.DataTextFormatString = "{0:c}";
        priceCol.HeaderText = dt.Columns["Price"].Caption;
//</Snippet4>

        // Add the new columns to the DataGrid.
        DataGrid1.Columns.Add(nameCol);
        DataGrid1.Columns.Add(priceCol);

        // Set the DataView as the data source, and bind 
        // it to the DataGrid.
        DataGrid1.DataSource = dv;
        DataGrid1.DataBind();

    }

    private void DataGrid1_ItemDataBound(object sender, 
        System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        ListItemType itemType = (ListItemType)e.Item.ItemType;

        if ((itemType != ListItemType.Header) &&
            (itemType != ListItemType.Footer) &&
            (itemType != ListItemType.Separator))
        {

//<Snippet5>
            // Get the IntegerValue cell from the grid's column 
            // collection.
            TableCell currentCell = (TableCell)e.Item.Controls[0];
            DataGrid1.Columns[1].InitializeCell(currentCell, 1,
                ListItemType.Item);
//</Snippet5>

//<Snippet6>
            // Add attributes to the cell.
            currentCell.Attributes.Add("id", "currentCell" + 
                e.Item.ItemIndex.ToString());
            currentCell.Attributes.Add("OnClick",
                "Update_currentCell" +
                e.Item.ItemIndex.ToString() +
                "()");
//</Snippet6>
        }
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>HyperLinkColumn Example</title>
</head>
    <body>
        <form id="form1" runat="server">
            <h3>HyperLinkColumn Example</h3>
                <asp:DataGrid Runat="server" ID="DataGrid1" CellPadding="4"
                    AutoGenerateColumns="False" BorderStyle="None" GridLines="None">
                    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black">
                    </HeaderStyle>
                </asp:DataGrid>
                <p>Click on an item name or price to add the item to your order.</p>
        </form>
    </body>
</html>
<!-- </Snippet3> -->
