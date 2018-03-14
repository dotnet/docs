using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected MenuItem menuItem1;
 protected MenuItem menuItem2;
 protected ContextMenu contextMenu1;
// <Snippet1>
 private void MergeMyMenus()
 {
    // Set the merge type to merge the items from both top menu items.
    menuItem1.MergeType = MenuMerge.MergeItems;
    menuItem2.MergeType = MenuMerge.MergeItems;
    // Create a copy of my menu item.
    MenuItem tempMenuItem = new MenuItem();
    // Create a copy of menuItem1 before doing the merge.
    tempMenuItem = menuItem1.CloneMenu();
    // Merge menuItem1's copy with a clone of menuItem2
    tempMenuItem.MergeMenu(menuItem2.CloneMenu());
 
    // Add the merged menu to the ContextMenu control.
    contextMenu1.MenuItems.Add(tempMenuItem);
 }

// </Snippet1>
}
