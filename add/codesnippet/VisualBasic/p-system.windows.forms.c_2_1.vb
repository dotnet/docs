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