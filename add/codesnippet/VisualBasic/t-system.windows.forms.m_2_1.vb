' This code example demonstrates how to use ToolStripPanel
' controls with a multiple document interface (MDI).
Public Class Form1
   Inherits Form
   
   Public Sub New()
      ' Make the Form an MDI parent.
      Me.IsMdiContainer = True
      
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

      ' Create a MenuStrip control with a new window.
      Dim ms As New MenuStrip()
      Dim windowMenu As New ToolStripMenuItem("Window")
      Dim windowNewMenu As New ToolStripMenuItem("New", Nothing, New EventHandler(AddressOf windowNewMenu_Click))
      windowMenu.DropDownItems.Add(windowNewMenu)
      CType(windowMenu.DropDown, ToolStripDropDownMenu).ShowImageMargin = False
      CType(windowMenu.DropDown, ToolStripDropDownMenu).ShowCheckMargin = True
      
      ' Assign the ToolStripMenuItem that displays 
      ' the list of child forms.
      ms.MdiWindowListItem = windowMenu
      
      ' Add the window ToolStripMenuItem to the MenuStrip.
      ms.Items.Add(windowMenu)
      
      ' Dock the MenuStrip to the top of the form.
      ms.Dock = DockStyle.Top
      
      ' The Form.MainMenuStrip property determines the merge target.
      Me.MainMenuStrip = ms
      
      ' Add the ToolStripPanels to the form in reverse order.
      Me.Controls.Add(tspRight)
      Me.Controls.Add(tspLeft)
      Me.Controls.Add(tspBottom)
      Me.Controls.Add(tspTop)
      
      ' Add the MenuStrip last.
      ' This is important for correct placement in the z-order.
      Me.Controls.Add(ms)
    End Sub
   
   ' This event handler is invoked when 
   ' the "New" ToolStripMenuItem is clicked.
   ' It creates a new Form and sets its MdiParent 
   ' property to the main form.
    Private Sub windowNewMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim f As New Form()
        f.MdiParent = Me
        f.Text = "Form - " + Me.MdiChildren.Length.ToString()
        f.Show()
    End Sub
End Class