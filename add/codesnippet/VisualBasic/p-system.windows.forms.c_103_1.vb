' Add a button to a form and set some of its common properties.
Private Sub AddMyButton()
   ' Create a button and add it to the form.
   Dim button1 As New Button()
   
   ' Anchor the button to the bottom right corner of the form
   button1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
   
   ' Assign a background image.
   button1.BackgroundImage = imageList1.Images(0)

   ' Specify the layout style of the background image. Tile is the default.
   button1.BackgroundImageLayout = ImageLayout.Center
   
   ' Make the button the same size as the image.
   button1.Size = button1.BackgroundImage.Size
   
   ' Set the button's TabIndex and TabStop properties.
   button1.TabIndex = 1
   button1.TabStop = True

   ' Add a delegate to handle the Click event.
   AddHandler button1.Click, AddressOf Me.button1_Click
   
   ' Add the button to the form.
   Me.Controls.Add(button1)
End Sub