   ' Override the InitializeItem method to add a PathSeparator
   ' and DropDownList to the current node.
   Protected Overrides Sub InitializeItem(item As SiteMapNodeItem)

      ' The only node that must be handled is the CurrentNode.
      If item.ItemType = SiteMapNodeItemType.Current Then
         Dim hLink As New HyperLink()

         ' No Theming for the HyperLink.
         hLink.EnableTheming = False
         ' Enable the link of the SiteMapPath is enabled.
         hLink.Enabled = Me.Enabled

         ' Set the properties of the HyperLink to
         ' match those of the corresponding SiteMapNode.
         hLink.NavigateUrl = item.SiteMapNode.Url
         hLink.Text = item.SiteMapNode.Title
         If ShowToolTips Then
            hLink.ToolTip = item.SiteMapNode.Description
         End If

         ' Apply styles or templates to the HyperLink here.
         ' ...
         ' ...
         ' Add the item to the Controls collection.
         item.Controls.Add(hLink)

         AddDropDownListAfterCurrentNode(item)
      Else
         MyBase.InitializeItem(item)
      End If
   End Sub 'InitializeItem
