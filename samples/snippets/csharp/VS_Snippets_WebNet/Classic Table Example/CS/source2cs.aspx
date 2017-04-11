<!--<Snippet2>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
     "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    private void Page_Load(Object sender, EventArgs e)
    {
        // Generate rows and cells.           
        int numrows = 3;
        int numcells = 2;
        for (int j = 0; j < numrows; j++)
        {          
            TableRow r = new TableRow();
            for (int i = 0; i < numcells; i++) {
                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl("row " 
                    + j.ToString() + ", cell " + i.ToString()));
                r.Cells.Add(c);
            }
            Table1.Rows.Add(r);
        }
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Table Example, constructed programmatically</h3>
    <asp:Table id="Table1" 
        GridLines="Both" 
        HorizontalAlign="Center" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="15" 
        CellSpacing="0" 
        Runat="server"/>

    </div>
    </form>
</body>
</html>
<!--</Snippet2>-->
