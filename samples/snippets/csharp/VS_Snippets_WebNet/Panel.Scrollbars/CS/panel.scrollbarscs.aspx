<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    private void Page_Load(object sender, EventArgs e)
    {
        // Add more rows and columns to the table than can
        // be displayed in the panel area.
        // Scroll bars will be required to view all the data.

        // Add rows and columns to the table.
        for (int rowNum = 0; rowNum < 51; rowNum++)
        {
            TableRow tempRow = new TableRow();
            for (int cellNum = 0; cellNum < 11; cellNum++)
            {
                TableCell tempCell = new TableCell();
                tempCell.Text = 
                    String.Format("({0}, {1})", rowNum, cellNum);
                tempRow.Cells.Add(tempCell);
            }
            Table1.Rows.Add(tempRow);
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>Panel Scrollbars - C# Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Panel.ScrollBars Property Example</h3>        

    <asp:Panel ID="Panel1" runat="Server"
      Height="300px" Width="400px"
      BackColor="Aqua" ScrollBars="Auto">

      <asp:Table ID="Table1" runat="Server"></asp:Table>  

    </asp:Panel>         

    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
