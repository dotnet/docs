 Public Sub AddToMyListBox()
     ' Stop the ListBox from drawing while items are added.
     listBox1.BeginUpdate()
        
     ' Loop through and add five thousand new items.
     Dim x As Integer
     For x = 1 To 4999
         listBox1.Items.Add("Item " & x.ToString())
     Next x
     ' End the update process and force a repaint of the ListBox.
     listBox1.EndUpdate()
 End Sub
