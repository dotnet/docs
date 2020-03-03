<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    private void Page_Load(Object sender, EventArgs e)
    {
        // Generate rows and cells.    
        int numrows = 5;
        int numcells = 4;
            
        for(int j=0; j<=numrows - 1; j++)
        {
            TableRow rw = new TableRow();
                
            for(int i=0; i <= numcells - 1; i++)
            {
               TableCell cel = new TableCell();
               cel.Controls.Add(new LiteralControl(
                   String.Format("row {0}, cell {1}", j, i)));
               rw.Cells.Add(cel);
            }
                
            Table1.Rows.Add(rw);
        }
    }

    private void Button_Click(Object sender, EventArgs e)
    { 
        Table1.GridLines = (GridLines)DropDown1.SelectedIndex;
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Table GridLines Example</h3>

    <asp:Table id="Table1" 
        BorderColor="black" 
        BorderWidth="1" 
        GridLines="Both" 
        runat="server" />

    <br />GridLines:

    <asp:DropDownList id="DropDown1" runat="server">
        <asp:ListItem Value="0">None</asp:ListItem>
        <asp:ListItem Value="1">Horizontal</asp:ListItem>
        <asp:ListItem Value="2">Vertical</asp:ListItem>
        <asp:ListItem Value="3">Both</asp:ListItem>
    </asp:DropDownList><br />

    <asp:button id="Button1"
        Text="Display Table"
        OnClick="Button_Click" 
        runat="server" />

    </div>
    </form>
</body>
</html>    
<!--</Snippet1>-->
