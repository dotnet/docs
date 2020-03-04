<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
        int numRows = 5;
        int numCells = 6;
        int counter = 1;

        // Create a table.
        for (int rowNum = 0; rowNum < numRows; rowNum++)
        {
            TableRow rw = new TableRow();
            for (int cellNum = 0; cellNum < numCells; cellNum++)
            {
                TableCell cel = new TableCell();
                cel.Text = counter.ToString();
                if (cellNum == List2.SelectedIndex)
                    cel.BackColor = System.Drawing.Color.Chartreuse;
                else if (rowNum == List1.SelectedIndex)
                    cel.BackColor = System.Drawing.Color.CadetBlue;
                else
                    cel.BackColor = System.Drawing.Color.White;
                rw.Cells.Add(cel);
                counter++;
            }
            Table1.Rows.Add(rw);
        }

        if (!IsPostBack)
        {
            // Fill a DropDownList with row numbers
            for (int rowNum = 0; rowNum < numRows; rowNum++)
            {
                List1.Items.Add(rowNum.ToString());
            }

            // Fill a DropDownList with column numbers
            for (int cellNum = 0; cellNum < numCells; cellNum++)
            {
                List2.Items.Add(cellNum.ToString());
            }
        }
    }

    void Button_Click(object sender, EventArgs e)
    {
        int rowNum = List1.SelectedIndex;
        TableRow rw = Table1.Rows[rowNum];

        Label1.Text = "The row index of the selected cell is " +
            Table1.Rows.GetRowIndex(rw).ToString();
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
        <asp:Table id="Table1" runat="server" />
        <br />&nbsp;<br />
        Select a cell:
        <br />&nbsp;<br />
        Row: <asp:DropDownList id="List1" runat="server" />
        Column: <asp:DropDownList id="List2" runat="server" />
        <br />&nbsp;<br />
        <asp:Button id="Button1"
           Text="Get Index"
           OnClick="Button_Click"
           runat="server" />
        <br />&nbsp;<br />
        <asp:Label id="Label1" runat="server" />
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
