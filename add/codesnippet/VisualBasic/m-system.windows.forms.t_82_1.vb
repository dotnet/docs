   ' This utility method creates a ContextMenuStrip control
   ' that has four ToolStripMenuItems showing the four 
   ' possible combinations of image and check margins.
   Friend Function CreateCheckImageContextMenuStrip() As ContextMenuStrip
      ' Create a new ContextMenuStrip control.
      Dim checkImageContextMenuStrip As New ContextMenuStrip()
      
      ' Create a ToolStripMenuItem with a
      ' check margin and an image margin.
      Dim yesCheckYesImage As New ToolStripMenuItem("Check, Image")
      yesCheckYesImage.Checked = True
      yesCheckYesImage.Image = CreateSampleBitmap()
      
      ' Create a ToolStripMenuItem with no
      ' check margin and with an image margin.
      Dim noCheckYesImage As New ToolStripMenuItem("No Check, Image")
      noCheckYesImage.Checked = False
      noCheckYesImage.Image = CreateSampleBitmap()
      
      ' Create a ToolStripMenuItem with a
      ' check margin and without an image margin.
      Dim yesCheckNoImage As New ToolStripMenuItem("Check, No Image")
      yesCheckNoImage.Checked = True
      
      ' Create a ToolStripMenuItem with no
      ' check margin and no image margin.
      Dim noCheckNoImage As New ToolStripMenuItem("No Check, No Image")
      noCheckNoImage.Checked = False
      
      ' Add the ToolStripMenuItems to the ContextMenuStrip control.
      checkImageContextMenuStrip.Items.Add(yesCheckYesImage)
      checkImageContextMenuStrip.Items.Add(noCheckYesImage)
      checkImageContextMenuStrip.Items.Add(yesCheckNoImage)
      checkImageContextMenuStrip.Items.Add(noCheckNoImage)
      
      Return checkImageContextMenuStrip
    End Function