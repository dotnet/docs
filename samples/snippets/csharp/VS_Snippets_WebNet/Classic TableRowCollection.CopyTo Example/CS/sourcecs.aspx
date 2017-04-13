<!--<Snippet1>-->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Text" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void Page_Load(object sender, EventArgs e)
    {
        int numRows = 5;
        int numCells = 6;
        int counter = 1;
        ArrayList a_row = new ArrayList();

        // Create a table.
        for (int rowNum = 0; rowNum < numRows; rowNum++)
        {
            TableRow rw = new TableRow();
            int cellNum = 0;
            for (cellNum = 0; cellNum < numCells; cellNum++)
            {
                TableCell cel = new TableCell();
                cel.Text = counter.ToString();
                rw.Cells.Add(cel);
                counter++;
            }
            Table1.Rows.Add(rw);
        }
    }

    void Button_Click(object sender, EventArgs e)
    {
        int rowCounter = 0;
        TableRow[] myRowArray = null;
        TableCell[] myCellArray = null;
        StringBuilder tb = new StringBuilder();

        // Copy the Rows collection to an array.
        Table1.Rows.CopyTo(myRowArray, 0);

        tb.Append("The copied items from the table are: \n");

        // Iterate through the TableRows in the array.
        foreach (TableRow rw in myRowArray)
        {
            // Copy the Cells collection of a row to an array.
            Table1.Rows[rowCounter].Cells.CopyTo(myCellArray, 0);

            // Iterate through the cell array 
            // and display its contents.
            foreach (TableCell cell in myCellArray)
                tb.Append(cell.Text + ", ");

            Label1.Text = tb.ToString();
            rowCounter++;
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableCellCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>TableCellCollection Example</h3>
        <asp:Table id="Table1" runat="server"/>
        <br />&nbsp;<br />
        <asp:Button id="Button1"
            Text="Copy Table to Array"
            OnClick="Button_Click"
            runat="server"/>
        <br />&nbsp;<br />
        <asp:Label id="Label1" runat="server"/>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
