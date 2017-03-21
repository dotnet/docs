   ' This method handles the Click event for the button.
   ' it selects the first item in the ToolStrip control
   ' by using the ToolStripITem.Select method.
   Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim item As RolloverItem = CType(Me.toolStrip1.Items(0), RolloverItem)
      
      If (item IsNot Nothing) Then
         item.Select()
         
         Me.Invalidate()
      End If
    End Sub