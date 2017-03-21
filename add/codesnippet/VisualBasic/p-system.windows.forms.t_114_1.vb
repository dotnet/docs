   ' This utility method creates and initializes three 
   ' ToolStripDropDownItem controls and adds them 
   ' to the form's ToolStrip control.
   Private Sub InitializeToolStripDropDownItems()
      Dim b As New ToolStripDropDownButton("DropDownButton")
      b.DropDown = Me.contextMenuStrip1
      AddHandler b.DropDownClosed, AddressOf toolStripDropDownItem_DropDownClosed
      AddHandler b.DropDownItemClicked, AddressOf toolStripDropDownItem_DropDownItemClicked
      AddHandler b.DropDownOpened, AddressOf toolStripDropDownItem_DropDownOpened
      
      Dim m As New ToolStripMenuItem("MenuItem")
      m.DropDown = Me.contextMenuStrip1
      AddHandler m.DropDownClosed, AddressOf toolStripDropDownItem_DropDownClosed
      AddHandler m.DropDownItemClicked, AddressOf toolStripDropDownItem_DropDownItemClicked
      AddHandler m.DropDownOpened, AddressOf toolStripDropDownItem_DropDownOpened
      
      Dim sb As New ToolStripSplitButton("SplitButton")
      sb.DropDown = Me.contextMenuStrip1
      AddHandler sb.DropDownClosed, AddressOf toolStripDropDownItem_DropDownClosed
      AddHandler sb.DropDownItemClicked, AddressOf toolStripDropDownItem_DropDownItemClicked
      AddHandler sb.DropDownOpened, AddressOf toolStripDropDownItem_DropDownOpened
      
      Me.toolStrip1.Items.AddRange(New ToolStripItem() {b, m, sb})
   End Sub 