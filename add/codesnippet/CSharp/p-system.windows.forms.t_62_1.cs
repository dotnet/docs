    public void ShowInsertInSameLocationSample()
    {
        // Notice how the items are in backward order.  
        // This is because "merge-one" gets applied, then a search occurs for the new second position 
        // for "merge-two", and so on.
        foreach (ToolStripItem item in cmsItemsToMerge.Items)
        {
            item.MergeAction = MergeAction.Insert;
            item.MergeIndex = 2;
        }
    }