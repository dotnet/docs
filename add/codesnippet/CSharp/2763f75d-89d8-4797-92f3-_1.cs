void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
{
   DataGridPageChangedEventArgs page_change_args = new DataGridPageChangedEventArgs(e.CommandSource, e.NewPageIndex);
}
   