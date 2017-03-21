   Public Sub ShowInsertInSameLocationSample()
      ' Notice how the items are in backward order.  
      ' This is because "merge-one" gets applied, then a search occurs for the new second position 
      ' for "merge-two", and so on.
      Dim item As ToolStripItem
      For Each item In  cmsItemsToMerge.Items
         item.MergeAction = MergeAction.Insert
         item.MergeIndex = 2
      Next item
   End Sub