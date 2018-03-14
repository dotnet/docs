<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {

        int numRows = 4;
        int numCells = 6;
        int counter = 1;

        // Generate a basic table.         
        for (int rowNum = 0; rowNum < numRows; rowNum++)
        {
            TableRow rw = new TableRow();
            for (int cellNum = 0; cellNum < numCells; cellNum++)
            {
                TableCell cel = new TableCell();
                cel.Text = counter.ToString();
                counter++;
                rw.Cells.Add(cel);
            }
            Table1.Rows.Add(rw);
        }

        // Add a row in the middle of the table.
        TableRow new_rw = new TableRow();
        Table1.Rows.AddAt(numRows / 2, new_rw);

        for (int cellNum = 0; cellNum < numCells; cellNum++)
        {
            TableCell cel = new TableCell();
            cel.Text = "Mid";
            Table1.Rows[numRows / 2].Cells.AddAt(cellNum, cel);
            counter++;
        }
    }
</script>
 
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Programmatic Table</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Programmatic Table Example</h3>
        <asp:Table id="Table1" runat="server"/>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
