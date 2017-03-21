void Button_Click_Coord(object sender, EventArgs e) 
 {
          
    for (int i=0; i<Table1.Rows.Count; i++) 
    {          
       for (int j=0; j<Table1.Rows[i].Cells.Count; j++) 
       {
                
          Table1.Rows[i].Cells[j].Text = "(" + 
             j.ToString() + ", " + i.ToString() + ")";
                
       }            
    }
 
 }
 