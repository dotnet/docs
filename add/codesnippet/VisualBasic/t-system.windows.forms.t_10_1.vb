      ' Distinguish the merged items by setting the shortcut display string.
      Dim tsmi As ToolStripMenuItem
      For Each tsmi In  cmsItemsToMerge.Items
         tsmi.ShortcutKeyDisplayString = "Merged Item"
      Next tsmi