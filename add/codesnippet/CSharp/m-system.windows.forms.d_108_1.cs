private void dataGrid1_MouseDown
(object sender, System.Windows.Forms.MouseEventArgs e)
{
   if(dataGrid1.HitTest(e.X,e.Y).Equals (DataGrid.HitTestInfo.Nowhere)) 
   {
      Console.WriteLine("Nowhere");
   }
}
   