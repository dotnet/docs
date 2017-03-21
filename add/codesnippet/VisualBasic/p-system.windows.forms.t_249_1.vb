   ' This utility method creates a RolloverItem 
   ' and adds it to a ToolStrip control.
    Private Function CreateRolloverItem( _
    ByVal owningToolStrip As ToolStrip, _
    ByVal txt As String, _
    ByVal f As Font, _
    ByVal imgKey As String, _
    ByVal tir As TextImageRelation, _
    ByVal backImgKey As String) As RolloverItem

        Dim item As New RolloverItem()

        item.Alignment = ToolStripItemAlignment.Left
        item.AllowDrop = False
        item.AutoSize = True

        item.BackgroundImage = owningToolStrip.ImageList.Images(backImgKey)
        item.BackgroundImageLayout = ImageLayout.Center
        item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        item.DoubleClickEnabled = True
        item.Enabled = True
        item.Font = f

        ' These assignments are equivalent. Each assigns an
        ' image from the owning toolstrip's image list.
        item.ImageKey = imgKey
        'item.Image = owningToolStrip.ImageList.Images[infoIconKey];
        'item.ImageIndex = owningToolStrip.ImageList.Images.IndexOfKey(infoIconKey);
        item.ImageScaling = ToolStripItemImageScaling.None

        item.Owner = owningToolStrip
        item.Padding = New Padding(2)
        item.Text = txt
        item.TextAlign = ContentAlignment.MiddleLeft
        item.TextDirection = ToolStripTextDirection.Horizontal
        item.TextImageRelation = tir

        Return item
    End Function