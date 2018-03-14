<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    int numrows = 5;
    int numcells = 6;
    int counter = 1;

    void Page_Load(Object sender, EventArgs e)
    {

        // Create a table.
        for (int rowNum = 0; rowNum < numrows; rowNum++)
        {
            TableRow rw = new TableRow();
            for (int cellNum = 0; cellNum < numcells; cellNum++)
            {
                TableCell cel = new TableCell();
                cel.Text = counter.ToString();
                counter++;
                rw.Cells.Add(cel);
            }
            Table1.Rows.Add(rw);
        }
        Table1.GridLines = GridLines.Both;
        Table1.CellPadding = 4;
        Table1.CellSpacing = 0;
    }

    void Button_Click(Object sender, EventArgs e)
    {

        // Clear the table.
        Table1.Rows.Clear();

        // Create new rows and cells.
        for (int rowNum = 0; rowNum < numrows; rowNum++)
        {
            TableRow rw = new TableRow();
            for (int cellNum = 0; cellNum < numcells; cellNum++)
            {
                TableCell cel = new TableCell();
                cel.Text = "***";
                rw.Cells.Add(cel);
            }
            Table1.Rows.Add(rw);
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
        <h3>Programmatic Table Example</h3>
        <asp:Table id="Table1" runat="server"/>

        <asp:Button id="Button1"
            Text="Replace All Rows With ***"
            OnClick="Button_Click"
            runat="server"/>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
