 Private Sub ClickMyRadioButton()
     ' If Item1 is selected and radioButton2 
     ' is checked, click radioButton1.
     If (listBox1.Text = "Item1") And radioButton2.Checked Then
         radioButton1.PerformClick()
     End If
 End Sub
