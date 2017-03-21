        Private Sub CreateMyListView()
            ' Create a new ListView control.
            Dim listView1 As New ListView()
            listView1.Bounds = New Rectangle(New Point(10, 10), New Size(300, 200))

            ' Set the view to show details.
            listView1.View = View.Details
            ' Allow the user to edit item text.
            listView1.LabelEdit = True
            ' Allow the user to rearrange columns.
            listView1.AllowColumnReorder = True
            ' Display check boxes.
            listView1.CheckBoxes = True
            ' Select the item and subitems when selection is made.
            listView1.FullRowSelect = True
            ' Display grid lines.
            listView1.GridLines = True
            ' Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Ascending

            ' Create three items and three sets of subitems for each item.
            Dim item1 As New ListViewItem("item1", 0)
            ' Place a check mark next to the item.
            item1.Checked = True
            item1.SubItems.Add("1")
            item1.SubItems.Add("2")
            item1.SubItems.Add("3")
            Dim item2 As New ListViewItem("item2", 1)
            item2.SubItems.Add("4")
            item2.SubItems.Add("5")
            item2.SubItems.Add("6")
            Dim item3 As New ListViewItem("item3", 0)
            ' Place a check mark next to the item.
            item3.Checked = True
            item3.SubItems.Add("7")
            item3.SubItems.Add("8")
            item3.SubItems.Add("9")

            ' Create columns for the items and subitems.
            ' Width of -2 indicates auto-size.
            listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left)
            listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left)
            listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left)
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center)

            'Add the items to the ListView.
            listView1.Items.AddRange(New ListViewItem() {item1, item2, item3})

            ' Create two ImageList objects.
            Dim imageListSmall As New ImageList()
            Dim imageListLarge As New ImageList()

            ' Initialize the ImageList objects with bitmaps.
            imageListSmall.Images.Add(Bitmap.FromFile("C:\MySmallImage1.bmp"))
            imageListSmall.Images.Add(Bitmap.FromFile("C:\MySmallImage2.bmp"))
            imageListLarge.Images.Add(Bitmap.FromFile("C:\MyLargeImage1.bmp"))
            imageListLarge.Images.Add(Bitmap.FromFile("C:\MyLargeImage2.bmp"))

            'Assign the ImageList objects to the ListView.
            listView1.LargeImageList = imageListLarge
            listView1.SmallImageList = imageListSmall

            ' Add the ListView to the control collection.
            Me.Controls.Add(listView1)
        End Sub 'CreateMyListView
