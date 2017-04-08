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
                cel.Text=counter.ToString();
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
        int row = List1.SelectedIndex;
        TableCell[] myCellArray = new TableCell[6];
 
        // Copy the collection to an array.
        Table1.Rows[row].Cells.CopyTo(myCellArray, 0);      
 
        Label1.Text = "The copied items from the selected row are: ";

        // Iterate through the array and display its contents.
        foreach (TableCell cel in myCellArray) 
        {
            Label1.Text = Label1.Text + " " + cel.Text;
        }
    }
 
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TableCellCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>TableCellCollection Example</h3>
    <asp:Table id="Table1" 
        GridLines="Both" 
        HorizontalAlign="Center" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="15" 
        CellSpacing="0" 
        runat="server" />

        <p style="text-align:center">Select a row:
            <br />&nbsp;<br />
            Row: <asp:DropDownList id="List1" 
            runat="server" />
 
            <br /><br />
            <asp:Button id="Button1"
                Text="Copy Row to Array"
                OnClick="Button_Click"
                runat="server" />
            <br /><br />
            <asp:Label id="Label1"
                runat="server" />
       </p>
 
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
