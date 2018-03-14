<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
        // Generate rows and cells.           
        int numRows = 3;
        int numCells = 2;
        for (int rowNum = 0; rowNum < numRows; rowNum++)
        {
            TableRow rw = new TableRow();
            for (int cellNum = 0; cellNum < numCells; cellNum++)
            {
                TableCell cel = new TableCell();
                cel.Text = String.Format(
                    "row {0}, cell {1}", rowNum, cellNum);
                rw.Cells.Add(cel);
            }
            Table1.Rows.Add(rw);
            Table1.GridLines = GridLines.Both;
            Table1.CellPadding = 4;
            Table1.CellSpacing = 0;
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Programmatic Table</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Table Example, constructed programmatically</h3>
        <asp:Table id="Table1" runat="server"/>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
