private void dataGrid1_MouseDown
(object sender, System.Windows.Forms.MouseEventArgs e)
{
   string newLine = "\n";
   Console.WriteLine(newLine);
   System.Windows.Forms.DataGrid.HitTestInfo myHitTest;
   // Use the DataGrid control's HitTest method with the x and y properties.
   myHitTest = dataGrid1.HitTest(e.X,e.Y);
   Console.WriteLine("Column " + myHitTest.Column);
   Console.WriteLine("Row " + myHitTest.Row);
}
   