private void dataGrid1_MouseDown
(object sender, System.Windows.Forms.MouseEventArgs e)
{
   System.Windows.Forms.DataGrid.HitTestInfo myHitTest;
   // Use the DataGrid control's HitTest method with the x and y properties.
   myHitTest = dataGrid1.HitTest(e.X,e.Y);
   Console.WriteLine("ToString " + myHitTest.ToString());
}
   