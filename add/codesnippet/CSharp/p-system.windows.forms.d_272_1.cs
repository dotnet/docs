private void ChangeFontHeight(DataGrid myGrid)
{
   myGrid.Font = new System.Drawing.Font
      ("Microsoft Sans Serif",
      15, System.Drawing.FontStyle.Regular);
   myGrid.PreferredRowHeight = myGrid.Font.Height;
}
