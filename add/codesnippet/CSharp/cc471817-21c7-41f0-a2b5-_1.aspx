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