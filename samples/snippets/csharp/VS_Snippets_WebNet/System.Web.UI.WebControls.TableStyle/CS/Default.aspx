<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        // Create a TableStyle
        TableStyle ts = new TableStyle();
        ts.BackImageUrl = "image1.jpg";
        ts.CellSpacing = 5;
        ts.CellPadding = 13;
        ts.GridLines = GridLines.Both;
        ts.HorizontalAlign = HorizontalAlign.Center;

        // Apply it to Table1
        Table1.ApplyStyle(ts);
        
        // Fill in the contents so it renders
        for (int i = 0; i < 10; i++)
        {
            TableRow tr = new TableRow();
            tr.ID = i.ToString();
            for (int j = 0; j < 5; j++)
            {
                TableCell tc = new TableCell();
                tc.ID = j.ToString();
                tc.Text = "Row " + i + ", Cell " + j;
                tr.Cells.Add(tc);
            }
            Table1.Rows.Add(tr);
        }
        
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TableStyle Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3 style="text-align:center">TableStyle Example</h3>
        <asp:Table ID="Table1" runat="server" />
    </div>
    </form>
</body>
</html>
