' This code example demonstrates how to handle the Opening event.
' It also demonstrates dynamic item addition and dynamic 
' SourceControl determination with reuse.
Class Form3
    Inherits Form

   ' Declare the ContextMenuStrip control.
   Private fruitContextMenuStrip As ContextMenuStrip
   
   
   Public Sub New()
      ' Create a new ContextMenuStrip control.
      fruitContextMenuStrip = New ContextMenuStrip()
      
      ' Attach an event handler for the 
      ' ContextMenuStrip control's Opening event.
      AddHandler fruitContextMenuStrip.Opening, AddressOf cms_Opening
      
      ' Create a new ToolStrip control.
      Dim ts As New ToolStrip()
      
      ' Create a ToolStripDropDownButton control and add it
      ' to the ToolStrip control's Items collections.
      Dim fruitToolStripDropDownButton As New ToolStripDropDownButton("Fruit", Nothing, Nothing, "Fruit")
      ts.Items.Add(fruitToolStripDropDownButton)
      
      ' Dock the ToolStrip control to the top of the form.
      ts.Dock = DockStyle.Top
      
      ' Assign the ContextMenuStrip control as the 
      ' ToolStripDropDownButton control's DropDown menu.
      fruitToolStripDropDownButton.DropDown = fruitContextMenuStrip
      
      ' Create a new MenuStrip control and add a ToolStripMenuItem.
      Dim ms As New MenuStrip()
      Dim fruitToolStripMenuItem As New ToolStripMenuItem("Fruit", Nothing, Nothing, "Fruit")
      ms.Items.Add(fruitToolStripMenuItem)
      
      ' Dock the MenuStrip control to the top of the form.
      ms.Dock = DockStyle.Top
      
      ' Assign the MenuStrip control as the 
      ' ToolStripMenuItem's DropDown menu.
      fruitToolStripMenuItem.DropDown = fruitContextMenuStrip
      
      ' Assign the ContextMenuStrip to the form's 
      ' ContextMenuStrip property.
      Me.ContextMenuStrip = fruitContextMenuStrip
      
      ' Add the ToolStrip control to the Controls collection.
        Me.Controls.Add(ts)

        'Add a button to the form and assign its ContextMenuStrip.
        Dim b As New Button()
        b.Location = New System.Drawing.Point(60, 60)
        Me.Controls.Add(b)
        b.ContextMenuStrip = fruitContextMenuStrip
      
      ' Add the MenuStrip control last.
      ' This is important for correct placement in the z-order.
      Me.Controls.Add(ms)
    End Sub
   
   ' This event handler is invoked when the ContextMenuStrip
   ' control's Opening event is raised. It demonstrates
   ' dynamic item addition and dynamic SourceControl 
   ' determination with reuse.
    Sub cms_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

        ' Acquire references to the owning control and item.
        Dim c As Control = fruitContextMenuStrip.SourceControl
        Dim tsi As ToolStripDropDownItem = fruitContextMenuStrip.OwnerItem 

        ' Clear the ContextMenuStrip control's 
        ' Items collection.
        fruitContextMenuStrip.Items.Clear()

        ' Check the source control first.
        If (c IsNot Nothing) Then
            ' Add custom item (Form)
            fruitContextMenuStrip.Items.Add(("Source: " + c.GetType().ToString()))
        ElseIf (tsi IsNot Nothing) Then
            ' Add custom item (ToolStripDropDownButton or ToolStripMenuItem)
            fruitContextMenuStrip.Items.Add(("Source: " + tsi.GetType().ToString()))
        End If

        ' Populate the ContextMenuStrip control with its default items.
        fruitContextMenuStrip.Items.Add("-")
        fruitContextMenuStrip.Items.Add("Apples")
        fruitContextMenuStrip.Items.Add("Oranges")
        fruitContextMenuStrip.Items.Add("Pears")

        ' Set Cancel to false. 
        ' It is optimized to true based on empty entry.
        e.Cancel = False
    End Sub
End Class