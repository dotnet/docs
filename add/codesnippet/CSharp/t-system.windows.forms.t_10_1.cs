        // Distinguish the merged items by setting the shortcut display string.
        foreach (ToolStripMenuItem tsmi in cmsItemsToMerge.Items)
        {
            tsmi.ShortcutKeyDisplayString = "Merged Item";
        }