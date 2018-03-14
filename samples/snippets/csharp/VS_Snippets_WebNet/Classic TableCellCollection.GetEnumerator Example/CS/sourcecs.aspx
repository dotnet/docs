<!--<Snippet1>-->
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
            for (int rowNum = 0; rowNum < numrows; rowNum++)
            {
                a_row.Add(rowNum.ToString());
            }

            List1.DataSource = a_row;
            List1.DataBind();

        }
    }

    void Button_Click(object sender, EventArgs e)
    {

        int rowNum = List1.SelectedIndex;
        TableCell current_cell;

        // Create the IEnumerator.
        IEnumerator myEnum = Table1.Rows[rowNum].Cells.GetEnumerator();

        Label1.Text = "The items in the selected row are: ";

        // Iterate through the IEnumerator and display its contents.
        while (myEnum.MoveNext())
        {
            current_cell = (TableCell)myEnum.Current;
            Label1.Text = Label1.Text + " " + current_cell.Text;
        }
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>TableCellCollection Example</h3>
    <asp:Table id="Table1" runat="server" />
    <br />&nbjsp;<br />
    <p style="text-align:center">
        Select a row:
        <br />&nbjsp;<br />
        Row: <asp:DropDownList id="List1" 
            runat="server"/>

        <br />&nbjsp;<br />
        <asp:Button id="Button1"
             Text="Create IEnumerator"
             OnClick="Button_Click"
             runat="server" />
        <br />&nbjsp;<br />
        <asp:Label id="Label1" runat="server"/>
    </p>

    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
