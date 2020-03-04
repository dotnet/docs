<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
        // Generate rows and cells.           
        int numRows = 5;
        int numCells = 6;
    int counter = 1;

        for (int rowNum = 0; rowNum < numRows; rowNum++)
        {
            TableRow rw = new TableRow();
            for (int cellNum = 0; cellNum < numCells; cellNum++)
            {
                TableCell cel = new TableCell();
                cel.Text = counter.ToString();
                rw.Cells.Add(cel);
                counter++;
            }
            Table1.Rows.Add(rw);
            Table1.GridLines = GridLines.Both;
            Table1.CellPadding = 4;
            Table1.CellSpacing = 0;
        }
    }

    void Button_Click(object sender, EventArgs e)
    {
        Table1.Rows.RemoveAt(2);
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
            Text="Remove middle row"
            OnClick="Button_Click"
            runat="server"/>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
