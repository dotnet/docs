   Public Sub New()
      ' Size the form to show three wide menu items.
      Me.Width = 500
      Me.Text = "ToolStripContextMenuStrip: Image and Check Margins"
      
      ' Create a new MenuStrip control.
      Dim ms As New MenuStrip()
      
      ' Create the ToolStripMenuItems for the MenuStrip control.
      Dim bothMargins As New ToolStripMenuItem("BothMargins")
      Dim imageMarginOnly As New ToolStripMenuItem("ImageMargin")
      Dim checkMarginOnly As New ToolStripMenuItem("CheckMargin")
      Dim noMargins As New ToolStripMenuItem("NoMargins")
      
      ' Customize the DropDowns menus.
      ' This ToolStripMenuItem has an image margin 
      ' and a check margin.
      bothMargins.DropDown = CreateCheckImageContextMenuStrip()
      CType(bothMargins.DropDown, ContextMenuStrip).ShowImageMargin = True
      CType(bothMargins.DropDown, ContextMenuStrip).ShowCheckMargin = True
      
      ' This ToolStripMenuItem has only an image margin.
      imageMarginOnly.DropDown = CreateCheckImageContextMenuStrip()
      CType(imageMarginOnly.DropDown, ContextMenuStrip).ShowImageMargin = True
      CType(imageMarginOnly.DropDown, ContextMenuStrip).ShowCheckMargin = False
      
      ' This ToolStripMenuItem has only a check margin.
      checkMarginOnly.DropDown = CreateCheckImageContextMenuStrip()
      CType(checkMarginOnly.DropDown, ContextMenuStrip).ShowImageMargin = False
      CType(checkMarginOnly.DropDown, ContextMenuStrip).ShowCheckMargin = True
      
      ' This ToolStripMenuItem has no image and no check margin.
      noMargins.DropDown = CreateCheckImageContextMenuStrip()
      CType(noMargins.DropDown, ContextMenuStrip).ShowImageMargin = False
      CType(noMargins.DropDown, ContextMenuStrip).ShowCheckMargin = False
      
      ' Populate the MenuStrip control with the ToolStripMenuItems.
      ms.Items.Add(bothMargins)
      ms.Items.Add(imageMarginOnly)
      ms.Items.Add(checkMarginOnly)
      ms.Items.Add(noMargins)
      
      ' Dock the MenuStrip control to the top of the form.
      ms.Dock = DockStyle.Top
      
      ' Add the MenuStrip control to the controls collection last.
      ' This is important for correct placement in the z-order.
      Me.Controls.Add(ms)
    End Sub