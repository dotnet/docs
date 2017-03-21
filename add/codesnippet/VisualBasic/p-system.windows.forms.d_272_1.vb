Private Sub ChangeFontHeight(ByVal myGrid As DataGrid)
   ' Change the font first.
   myGrid.Font = New System.Drawing.Font _
   ("Microsoft Sans Serif", 15, _
   System.Drawing.FontStyle.Regular)

   myGrid.PreferredRowHeight = myGrid.Font.Height
End Sub
