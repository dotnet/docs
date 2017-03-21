private void dataGrid1_CurrentCellChange(object sender, EventArgs e)
 {
    Rectangle rect;
    rect = dataGrid1.GetCurrentCellBounds();
    Console.WriteLine(rect.ToString());
 }
 