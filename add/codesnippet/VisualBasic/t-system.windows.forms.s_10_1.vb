    Private WithEvents iconListView As New ListView()
    Private previousItemBox As New TextBox()
    
    
    Private Sub InitializeLocationSearchListView()
        previousItemBox.Location = New Point(150, 20)

        ' Create an image list for the icon ListView.
        iconListView.LargeImageList = New ImageList()

        ' Add an image to the ListView large icon list.
        iconListView.LargeImageList.Images.Add(New Bitmap(GetType(Control), "Edit.bmp"))

        ' Set the view to large icon and add some items with the image
        ' in the image list.
        iconListView.View = View.SmallIcon
        iconListView.Items.AddRange(New ListViewItem() { _
            New ListViewItem("Amy Alberts", 0), _
            New ListViewItem("Amy Recker", 0), _
            New ListViewItem("Erin Hagens", 0), _
            New ListViewItem("Barry Johnson", 0), _
            New ListViewItem("Jay Hamlin", 0), _
            New ListViewItem("Brian Valentine", 0), _
            New ListViewItem("Brian Welker", 0), _
            New ListViewItem("Daniel Weisman", 0)})

        Me.Controls.Add(iconListView)
        Me.Controls.Add(previousItemBox)
    End Sub
    
    Sub iconListView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles iconListView.MouseDown

        ' Find the next item up from where the user clicked.
        Dim foundItem As ListViewItem = _
        iconListView.FindNearestItem(SearchDirectionHint.Up, e.X, e.Y)

        ' Display the results in a textbox.
        If (foundItem IsNot Nothing) Then
            previousItemBox.Text = foundItem.Text
        Else
            previousItemBox.Text = "No item found"
        End If


    End Sub