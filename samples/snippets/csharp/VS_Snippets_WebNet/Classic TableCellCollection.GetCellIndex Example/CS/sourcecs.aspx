<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    void Page_Load(Object sender, EventArgs e)
    {

        int numrows = 5;
        int numcells = 6;
        int counter = 1;
        ArrayList a_row = new ArrayList();
        ArrayList a_column = new ArrayList();

        // Create a table.
        for (int rowNum = 0; rowNum < numrows; rowNum++)
        {
            TableRow rw = new TableRow();
            for (int cellNum = 0; cellNum < numcells; cellNum++)
            {
                TableCell cel = new TableCell();
                cel.Text = counter.ToString();
                rw.Cells.Add(cel);
                counter++;
            }
            Table1.Rows.Add(rw);
        }

        if (!IsPostBack)
        {
            // Create a DropDownList for the number of rows.
            for (int k = 0; k < numrows; k++)
            {
                a_row.Add(k.ToString());
            }

            // Create a DropDownList for the number of columns.
            for (int l = 0; l < numcells; l++)
            {
                a_column.Add(l.ToString());
            }

            List1.DataSource = a_row;
            List2.DataSource = a_column;
            List1.DataBind();
            List2.DataBind();
        }
    }

    void Button_Click(object sender, EventArgs e)
    {
        int row = List1.SelectedIndex;
        int column = List2.SelectedIndex;
        TableCell cell = Table1.Rows[row].Cells[column];

        Label1.Text = "The column index of the selected cell is " +
            Table1.Rows[row].Cells.GetCellIndex(cell).ToString();
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
    <p style="text-align:center">
        Select a cell:
        <br />&nbsp;<br />
        Row: <asp:DropDownList id="List1" runat="server"/>
        Column: <asp:DropDownList id="List2" runat="server"/>
        <br />&nbsp;<br />
        <asp:Button id="Button1"
             Text="Get Index"
             OnClick="Button_Click"
             runat="server"/>
        <br />&nbsp;<br />
        <asp:Label id="Label1" runat="server"/>
    </p>

    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
