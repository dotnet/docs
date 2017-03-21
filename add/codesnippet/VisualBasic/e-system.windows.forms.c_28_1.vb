    Private Sub MyPopupEventHandler(sender As System.Object, e As System.EventArgs)
        ' Define the MenuItem objects to display for the TextBox.
        Dim menuItem1 As New MenuItem("&Copy")
        Dim menuItem2 As New MenuItem("&Find and Replace")
        ' Define the MenuItem object to display for the PictureBox.
        Dim menuItem3 As New MenuItem("C&hange Picture")
        
        ' Clear all previously added MenuItems.
        contextMenu1.MenuItems.Clear()
        
        If contextMenu1.SourceControl Is textBox1 Then
            ' Add MenuItems to display for the TextBox.
            contextMenu1.MenuItems.Add(menuItem1)
            contextMenu1.MenuItems.Add(menuItem2)
        ElseIf contextMenu1.SourceControl Is pictureBox1 Then
            ' Add the MenuItem to display for the PictureBox.
            contextMenu1.MenuItems.Add(menuItem3)
        End If
    End Sub 'MyPopupEventHandler '