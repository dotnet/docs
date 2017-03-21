      ' Allow the user to select a Color.
      Dim myColorDialog As New ColorDialog()
      myColorDialog.AllowFullOpen = False
      myColorDialog.ShowHelp = True
      ' Set the initial color select to the current color.
      myColorDialog.Color = myGridTableStyle.SelectionBackColor
      ' Show color dialog box.
      myColorDialog.ShowDialog()
      ' Set the backcolor for the selected cells. 
      myGridTableStyle.SelectionBackColor = myColorDialog.Color