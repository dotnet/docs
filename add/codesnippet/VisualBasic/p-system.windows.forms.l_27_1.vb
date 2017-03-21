    Private list As New ImageList()
    Private hotTrackinglistView As New ListView()


    Private Sub InitializeHotTrackingListView()
        list.Images.Add(New Bitmap(GetType(Button), "Button.bmp"))
        hotTrackinglistView.SmallImageList = list
        hotTrackinglistView.Location = New Point(20, 20)
        hotTrackinglistView.View = View.SmallIcon
        Dim listItem1 As New ListViewItem("Short", 0)
        Dim listItem2 As New ListViewItem("Tiny", 0)
        hotTrackinglistView.Items.Add(listItem1)
        hotTrackinglistView.Items.Add(listItem2)
        hotTrackinglistView.HotTracking = True
        Me.Controls.Add(hotTrackinglistView)

    End Sub