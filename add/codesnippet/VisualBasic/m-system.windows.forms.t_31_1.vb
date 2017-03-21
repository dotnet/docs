      ' Create ToolStripPanel controls.
      Dim tspTop As New ToolStripPanel()
      Dim tspBottom As New ToolStripPanel()
      Dim tspLeft As New ToolStripPanel()
      Dim tspRight As New ToolStripPanel()
      
      ' Dock the ToolStripPanel controls to the edges of the form.
      tspTop.Dock = DockStyle.Top
      tspBottom.Dock = DockStyle.Bottom
      tspLeft.Dock = DockStyle.Left
      tspRight.Dock = DockStyle.Right
      
      ' Create ToolStrip controls to move among the 
      ' ToolStripPanel controls.
      ' Create the "Top" ToolStrip control and add
      ' to the corresponding ToolStripPanel.
      Dim tsTop As New ToolStrip()
      tsTop.Items.Add("Top")
      tspTop.Join(tsTop)
      
      ' Create the "Bottom" ToolStrip control and add
      ' to the corresponding ToolStripPanel.
      Dim tsBottom As New ToolStrip()
      tsBottom.Items.Add("Bottom")
      tspBottom.Join(tsBottom)
      
      ' Create the "Right" ToolStrip control and add
      ' to the corresponding ToolStripPanel.
      Dim tsRight As New ToolStrip()
      tsRight.Items.Add("Right")
      tspRight.Join(tsRight)
      
      ' Create the "Left" ToolStrip control and add
      ' to the corresponding ToolStripPanel.
      Dim tsLeft As New ToolStrip()
      tsLeft.Items.Add("Left")
      tspLeft.Join(tsLeft)