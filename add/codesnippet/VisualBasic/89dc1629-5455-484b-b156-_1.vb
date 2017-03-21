   
   Private Property CurrentSample() As MergeSample
      Get
         Return currentSample1
      End Get
      Set
         If currentSample1 <> value Then
            Dim resetRequired As Boolean = False
            
            If currentSample1 = MergeSample.MatchOnly Then
               resetRequired = True
            End If
            currentSample1 = value
            ' Undo previous merge, if any.
            ToolStripManager.RevertMerge(cmsBase, cmsItemsToMerge)
            If resetRequired Then
               RebuildItemsToMerge()
            End If
            
            Select Case currentSample1
               Case MergeSample.None
                     Return
               Case MergeSample.Append
                  ScenarioText = "This sample adds items to the end of the list using MergeAction.Append." + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + "This is the default setting for MergeAction. A typical scenario is adding menu items to the end of the menu when some part of the program is activated."
                  ShowAppendSample()
               Case MergeSample.InsertInSameLocation
                  ScenarioText = "This sample adds items to the middle of the list using MergeAction.Insert." + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + "Notice here how the items are added in reverse order: four, three, two, one. This is because they all have the same merge index." + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + "A typical scenario is adding menu items to the middle or beginning of the menu when some part of the program is activated. "
                  ShowInsertInSameLocationSample()
               Case MergeSample.InsertInSameLocationPreservingOrder
                  ScenarioText = "This sample is the same as InsertInSameLocation, except the items are added in normal order by increasing the MergeIndex of ""two merged items"" to be 3, ""three merged items"" to be 5, and so on." + ControlChars.Cr + ControlChars.Lf + "  You could also add the original items backwards to the source ContextMenuStrip."
                  ShowInsertInSameLocationPreservingOrderSample()
               Case MergeSample.ReplacingItems
                  ScenarioText = "This sample replaces a menu item using MergeAction.Replace. Use this for the MDI scenario where saving does something completely different." + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + "Matching is based on the Text property. If there is no text match, merging reverts to MergeIndex."
                  ShowReplaceSample()
               Case MergeSample.MatchOnly
                  ScenarioText = "This sample adds only the subitems from the child to the target ContextMenuStrip."
                  ShowMatchOnlySample()
            End Select
            
            ' Reapply with the new settings.
            ToolStripManager.Merge(cmsItemsToMerge, cmsBase)
         End If
      End Set
   End Property