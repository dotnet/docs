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

    private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Determine which list item was clicked.
        // Display the selected scroll bars in the panel.
        switch (ListBox1.SelectedIndex)
        {
            case 0:
                Panel1.ScrollBars = ScrollBars.None;
                break;
            case 1:
                Panel1.ScrollBars = ScrollBars.Horizontal;
                break;
            case 2:
                Panel1.ScrollBars = ScrollBars.Vertical;
                break;
            case 3:
                Panel1.ScrollBars = ScrollBars.Both;
                break;
            case 4:
                Panel1.ScrollBars = ScrollBars.Auto;
                break;
            default:
                throw new Exception("Select a valid list item.");
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Panel.ScrollBars Property Example</h3>

    <h4>Select the scrollbars to display in the panel.</h4>
    <asp:ListBox ID="ListBox1" runat="Server"
      Rows="5" AutoPostBack="True"
      SelectionMode="Single"
      OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
      <asp:ListItem>None</asp:ListItem>
      <asp:ListItem>Horizontal</asp:ListItem> 
      <asp:ListItem>Vertical</asp:ListItem>
      <asp:ListItem>Both</asp:ListItem> 
      <asp:ListItem>Auto</asp:ListItem>              
    </asp:ListBox>

    <hr />              

    <asp:Panel ID="Panel1" runat="Server"
      Height="300px" Width="400px" BackColor="Aqua">
      <asp:Table ID="Table1" runat="Server" />
    </asp:Panel>           
         
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
