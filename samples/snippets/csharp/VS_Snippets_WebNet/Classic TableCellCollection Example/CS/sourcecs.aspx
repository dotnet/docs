<!--<Snippet1>-->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    private void Page_Load(Object sender, EventArgs e) 
    {
        // Generate rows and cells.           
        int numrows = 4;
        int numcells = 6;
        int counter = 1;
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
 
    private void Button_Click_Coord(object sender, EventArgs e) 
    {
        for (int rowNum = 0; rowNum < Table1.Rows.Count; rowNum++) 
        {          
            for (int cellNum = 0; cellNum < 
                Table1.Rows[rowNum].Cells.Count; cellNum++) 
            {
                Table1.Rows[rowNum].Cells[cellNum].Text = 
                    String.Format("(Row{0}, Cell{1})", rowNum, cellNum);
            }
        }
    }

    private void Button_Click_Number(object sender, EventArgs e) 
    {
        int counter = 1;
          
        for (int rowNum = 0; rowNum < Table1.Rows.Count; rowNum++) 
        {
            for (int cellNum = 0; cellNum < 
                Table1.Rows[rowNum].Cells.Count; cellNum++) 
            {
                Table1.Rows[rowNum].Cells[cellNum].Text = 
                    counter.ToString();
                counter++;
            }            
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
            runat="server"/>
       <br />
       <center>
          <asp:Button id="Button1"
               Text="Display Table Coordinates"
               OnClick="Button_Click_Coord"
               runat="server"/>
          <asp:Button id="Button2"
               Text="Display Cell Numbers"
               OnClick="Button_Click_Number"
               runat="server"/>
       </center>
 
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
