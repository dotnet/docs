    private MergeSample CurrentSample
    {
        get { return currentSample; }
        set
        {
            if (currentSample != value)
            {
                bool resetRequired = false;

                if (currentSample == MergeSample.MatchOnly)
                {
                    resetRequired = true;
                }
                currentSample = value;
                // Undo previous merge, if any.
                ToolStripManager.RevertMerge(cmsBase, cmsItemsToMerge);
                if (resetRequired)
                {
                    RebuildItemsToMerge();
                }

                switch (currentSample)
                {
                    case MergeSample.None:
                        return;
                    case MergeSample.Append:
                        ScenarioText = "This sample adds items to the end of the list using MergeAction.Append.\r\n\r\nThis is the default setting for MergeAction. A typical scenario is adding menu items to the end of the menu when some part of the program is activated.";
                        ShowAppendSample();
                        break;
                    case MergeSample.InsertInSameLocation:
                        ScenarioText = "This sample adds items to the middle of the list using MergeAction.Insert.\r\n\r\nNotice here how the items are added in reverse order: four, three, two, one. This is because they all have the same merge index.\r\n\r\nA typical scenario is adding menu items to the middle or beginning of the menu when some part of the program is activated. ";
                        ShowInsertInSameLocationSample();
                        break;
                    case MergeSample.InsertInSameLocationPreservingOrder:
                        ScenarioText = "This sample is the same as InsertInSameLocation, except the items are added in normal order by increasing the MergeIndex of \"two merged items\" to be 3, \"three merged items\" to be 5, and so on.\r\n  You could also add the original items backwards to the source ContextMenuStrip.";
                        ShowInsertInSameLocationPreservingOrderSample();
                        break;
                    case MergeSample.ReplacingItems:
                        ScenarioText = "This sample replaces a menu item using MergeAction.Replace. Use this for the MDI scenario where saving does something completely different.\r\n\r\nMatching is based on the Text property. If there is no text match, merging reverts to MergeIndex.";
                        ShowReplaceSample();
                        break;
                    case MergeSample.MatchOnly:
                        ScenarioText = "This sample adds only the subitems from the child to the target ContextMenuStrip.";
                        ShowMatchOnlySample();
                        break;

                }
                // Reapply with the new settings.
                ToolStripManager.Merge(cmsItemsToMerge, cmsBase);
            }
        }
    }