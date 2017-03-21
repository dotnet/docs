   ' The following methods handle the CheckChanged event 
   ' for all the radio buttons. Each method calls a utility
   ' method to set the ToolStripDropDownDirection appropriately.
   Private Sub radioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton1.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.AboveLeft)
    End Sub
   
   
   Private Sub radioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton2.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.AboveRight)
    End Sub
   
   
   Private Sub radioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton3.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.BelowLeft)
    End Sub
   
   
   Private Sub radioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton4.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.BelowRight)
    End Sub
   
   
   Private Sub radioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton5.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.Default)
    End Sub
   
   
   Private Sub radioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton6.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.Left)
    End Sub
   
   
   Private Sub radioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles radioButton7.CheckedChanged
      Me.HandleRadioButton(sender, ToolStripDropDownDirection.Right)
    End Sub
   
   
    ' This utility method sets the DefaultDropDownDirection property.
   Private Sub HandleRadioButton(sender As Object, direction As ToolStripDropDownDirection)
        Dim rb As RadioButton = CType(sender, RadioButton)
      
        If rb IsNot Nothing Then
            If rb.Checked Then
                Me.dropDownDirection = direction
                Me.contextMenuStrip1.DefaultDropDownDirection = direction
            End If
        End If
    End Sub