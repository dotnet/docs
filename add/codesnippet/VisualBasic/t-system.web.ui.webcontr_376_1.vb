   Private Sub AddDropDownListAfterCurrentNode(item As SiteMapNodeItem)

      Dim childNodes As SiteMapNodeCollection = item.SiteMapNode.ChildNodes

      ' Only do this work if there are child nodes.
      If Not (childNodes Is Nothing) Then

         ' Add another PathSeparator after the CurrentNode.
         Dim finalSeparator As New SiteMapNodeItem(item.ItemIndex, SiteMapNodeItemType.PathSeparator)

         Dim eventArgs As New SiteMapNodeItemEventArgs(finalSeparator)

         InitializeItem(finalSeparator)
         ' Call OnItemCreated every time a SiteMapNodeItem is
         ' created and initialized.
         OnItemCreated(eventArgs)

         ' The pathSeparator does not bind to any SiteMapNode, so
         ' do not call DataBind on the SiteMapNodeItem.
         item.Controls.Add(finalSeparator)

         ' Create a DropDownList and populate it with the children of the
         ' CurrentNode. There are no styles or templates that are applied
         ' to the DropDownList control. If OnSelectedIndexChanged is raised,
         ' the event handler redirects to the page selected.
         ' The CurrentNode has child nodes.
         Dim ddList As New DropDownList()
         ddList.AutoPostBack = True

         AddHandler ddList.SelectedIndexChanged, AddressOf Me.DropDownNavPathEventHandler

         ' Add a ListItem to the DropDownList for every node in the
         ' SiteMapNodes collection.
         Dim node As SiteMapNode
         For Each node In  childNodes
            ddList.Items.Add(New ListItem(node.Title, node.Url))
         Next node

         item.Controls.Add(ddList)
      End If
   End Sub 'AddDropDownListAfterCurrentNode
