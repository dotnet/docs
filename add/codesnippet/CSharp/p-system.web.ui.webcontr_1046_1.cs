    void Button_Click_Coord(object sender, EventArgs e) 
    {
        for (int rowNum = 0; rowNum < Table1.Rows.Count; rowNum++)
        {
            for (int cellNum = 0; 
                cellNum < Table1.Rows[cellNum].Cells.Count; cellNum++)
            {
                Table1.Rows[rowNum].Cells[cellNum].Text = 
                    String.Format("({0}, {1})", rowNum, cellNum);
            }            
        }
    }
 