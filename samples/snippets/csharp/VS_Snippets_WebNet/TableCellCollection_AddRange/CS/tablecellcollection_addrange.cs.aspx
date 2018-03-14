<%--
   System.Web.UI.WebControls.TableCellCollection.AddRange
   
   The following program generates an array of 'TableCell' and then
   adds the array to each row using 'AddRange' method of 
   'TableCellCollection' class.
   The row 'tRow' is then added to the Table.    
--%>
<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    // <Snippet1>      
    void Page_Load(Object sender, EventArgs e) 
    {
        int numRows = 3;
        int numCells = 2;
        // Create 3 rows, each containing 2 cells.
        for(int rowNum = 0; rowNum < numRows; rowNum++) 
        {
            TableCell[] arrayOfTableRowCells = 
                new TableCell[numCells];
            TableRow tRow =  new TableRow();

            for (int cellNum = 0; cellNum < numCells; cellNum++)
            {
                TableCell tCell =  new TableCell();
                tCell.Text = 
                    String.Format("[Row {0}, Cell {1}]", 
                        rowNum, cellNum);
                arrayOfTableRowCells[cellNum] = tCell;
            } 

            // Get 'TableCellCollection' associated 
            // with the 'TableRow'.
            TableCellCollection myTableCellCol = tRow.Cells;
            // Add a row of cells. 
            myTableCellCol.AddRange(arrayOfTableRowCells);
            Table1.Rows.Add(tRow);
        } 
    }
    // </Snippet1>      
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableCaptionAlign Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>TableCellCollection Example</h3>
    <asp:Table id="Table1" GridLines="Both" 
        CellPadding="8" Runat="server" />

    </div>
    </form>
  </body>
</html>
