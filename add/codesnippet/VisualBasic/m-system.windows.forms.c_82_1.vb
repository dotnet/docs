Private Sub MakeLabelVisible()
   ' If the panel contains label1, bring it 
   ' to the front to make sure it is visible. 
   If panel1.Contains(label1) Then
      label1.BringToFront()
   End If
End Sub