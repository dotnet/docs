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

        // Create a table.
        for (int rowNum = 0; rowNum < numrows; rowNum++) 
        {          
             TableRow rw = new TableRow();
             for (int cellNum = 0; cellNum < numcells; cellNum++) 
             {
                 TableCell cel = new TableCell();
                 cel.Text=counter.ToString();
                 counter++;
                 rw.Cells.Add(cel);
             }
             Table1.Rows.Add(rw);
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
    <asp:Table id="Table1" runat="server"/>

    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
