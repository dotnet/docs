   Delegate Sub MyDelegate(myControl As Label, myArg2 As String)
   
   Private Sub Button_Click(sender As Object, e As EventArgs)
      Dim myArray(1) As Object
      
      myArray(0) = New Label()
      myArray(1) = "Enter a Value"
      myTextBox.BeginInvoke(New MyDelegate(AddressOf DelegateMethod), myArray)
   End Sub 'Button_Click
   
   Public Sub DelegateMethod(myControl As Label, myCaption As String)
      myControl.Location = New Point(16, 16)
      myControl.Size = New Size(80, 25)
      myControl.Text = myCaption
      Me.Controls.Add(myControl)
   End Sub 'DelegateMethod
   